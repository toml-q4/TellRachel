using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TellRachel.Entities;
using TellRachel.Models.Note;
using TellRachel.Repositories.Note;

namespace TellRachel.Controllers
{
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult GetNote(Guid id, bool withDetails = false)
        {
            Note note;
            if (withDetails)
            {
                note = _noteRepository.GetSingle(id,
                    n => n.Symptoms,
                    n => n.MedicineDoses);
            }
            else note = _noteRepository.GetSingle(id);

            if (note == null)
                return NotFound();

            if (withDetails)
            {
                var noteWithDetailsModel = Mapper.Map<NoteWithDetailsModel>(note);

                //if (note.Symptoms != null)
                //{
                //    foreach(var symptom in note.Symptoms)
                //    {
                //        noteWithDetailsModel.Entries.Add(new NoteEntryModel
                //        {
                //            Name = symptom.Name ?? $"{symptom.TemperatureInCelsius} C - Body Temperature",
                //            TakenDateTime = symptom.TakenDate
                //        });
                //    }
                //}
                noteWithDetailsModel.Entries.Sort((a, b) => b.TakenDateTime.CompareTo(a.TakenDateTime));
                return Ok(noteWithDetailsModel);
            }

            var noteModel = Mapper.Map<NoteModel>(note);
            return Ok(noteModel);
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] NoteCreationModel noteForCreation)
        {
            if (noteForCreation == null) return BadRequest("Posted data is invalid");

            var note = Mapper.Map<Note>(noteForCreation);
            _noteRepository.Add(note);

            if (!_noteRepository.Save()) return StatusCode(500, "Failed to handle your request. Unknown errors.");

            var createNoteModel = Mapper.Map<NoteModel>(note);
            return CreatedAtRoute("GetNote", new {id = createNoteModel.Id}, createNoteModel);
        }
    }
}
