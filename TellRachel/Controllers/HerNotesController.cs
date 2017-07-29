using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TellRachel.Entities;
using TellRachel.Models;
using TellRachel.Repositories;

namespace TellRachel.Controllers
{
    [Route("api/hernotes")]
    public class HerNotesController : ControllerBase
    {
        private readonly ITellRachelRepository _repository;


        public HerNotesController(ITellRachelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            var herNotes = _repository.GetHerNotes();

            if (herNotes == null) return NoContent();

            return Ok(Mapper.Map<IEnumerable<NoteModel>>(herNotes));
        }

        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult GetNote(int id, bool includeRecords = false)
        {
            var note = _repository.GetHerNote(id, includeRecords);

            if (note == null)
                return NotFound();

            if (includeRecords)
            {
                var noteWithRecordsModel = Mapper.Map<NoteWithRecordsModel>(note);
                return Ok(noteWithRecordsModel);
            }

            var noteModel = Mapper.Map<NoteModel>(note);
            return Ok(noteModel);
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] NoteCreationModel noteCreationModel)
        {
            if (noteCreationModel == null) return BadRequest("Posted data is invalid");

            if (noteCreationModel.CreatedDateTime == DateTime.MinValue)
                ModelState.AddModelError("CreatedDateTime", "Invalid value");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var herNote = Mapper.Map<HerNote>(noteCreationModel);
            _repository.CreateNote(herNote);

            if (!_repository.Save()) return StatusCode(500, "Failed to handle your request. Unknown errors.");

            var createNoteModel = Mapper.Map<NoteModel>(herNote);
            return CreatedAtRoute("GetNote", new {id = createNoteModel.Id}, createNoteModel);
        }
    }
}
