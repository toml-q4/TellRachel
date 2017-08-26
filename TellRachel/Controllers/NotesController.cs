using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TellRachel.Domain.Entities;
using TellRachel.Models.Note;
using TellRachel.Data.Repositories;

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
                    n => n.Temperatures,
                    n => n.Symptoms,
                    n => n.MedicineDoses);
            }
            else note = _noteRepository.GetSingle(id);

            if (note == null)
                return NotFound();

            if (withDetails)
            {
                var noteWithDetailsModel = Mapper.Map<NoteWithDetailsModel>(note);                

                if (note.Temperatures != null)
                {
                    double previousValue = 0.0;
                    int index = 0;
                    foreach(var temperature in note.Temperatures)
                    {
                        string rachelSense = string.Empty;

                        if (index > 0)
                        {
                            if (temperature.Value > previousValue)
                            {
                                rachelSense = "The body temperature is increasing";
                            }
                            else if (temperature.Value < previousValue)
                            {
                                rachelSense = "The body temperature is decreasing";
                            }
                            else
                            {
                                rachelSense = "The body temperature is remaining the same";
                            }
                        }
                        noteWithDetailsModel.Entries.Add(new NoteEntryModel {
                            Name = $"{temperature.Value:N1}" + (temperature.IsFahrenheit ? "F" : "C"),
                            TakenDate = temperature.TakenDate,
                            EntryType = EntryType.Temperature,
                            RachelSense = rachelSense
                        });
                        previousValue = temperature.Value;
                        index++;
                    }
                }

                noteWithDetailsModel.Entries.Sort((a, b) => b.TakenDate.CompareTo(a.TakenDate));
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
