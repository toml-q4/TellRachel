using System;
using Microsoft.AspNetCore.Mvc;
using TellRachel.Models.Symptom;
using AutoMapper;
using TellRachel.Domain.Entities;
using TellRachel.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TellRachel.Controllers
{
    [Route("api/notes/{noteId}/symptoms")]
    public class SymptomsController : ControllerBase
    {
        private ISymptomRepository _repository;
        private INoteRepository _noteRepository;

        public SymptomsController(ISymptomRepository repository, INoteRepository noteRepository)
        {
            _repository = repository;
            _noteRepository = noteRepository;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Guid noteId, [FromBody]SymptomCreationModel value)
        {
            if (value == null) return BadRequest("Posted data is invalid");

            if (value.TakenDate == DateTime.MinValue)
                ModelState.AddModelError(nameof(value.TakenDate), "Invalid value");

            if (noteId == Guid.Empty)
                ModelState.AddModelError(nameof(noteId), "Invalid value");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_noteRepository.Exist(noteId))
            {
                var entity = Mapper.Map<Symptom>(value);
                entity.NoteId = noteId;
                _repository.Add(entity);

                if (!_repository.Save()) return StatusCode(500, "Failed to handle your request. Unknown errors.");

                var createModel = Mapper.Map<SymptomModel>(entity);
                return CreatedAtRoute("GetSymptom", new { id = createModel.Id }, createModel);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}", Name = "GetSymptom")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
                ModelState.AddModelError(nameof(id), "Invalid symptom id");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var symptom = _repository.GetSingle(id);

            if (symptom == null) return NotFound();
            else return Ok(Mapper.Map<SymptomModel>(symptom));
        }

        [HttpDelete("{entryId}")]
        public IActionResult Delete(Guid noteId, Guid entryId)
        {
            if (noteId == Guid.Empty)
                ModelState.AddModelError(nameof(noteId), "Invalid value");

            if (entryId == Guid.Empty)
                ModelState.AddModelError(nameof(entryId), "Invalid value");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_repository.Exist(noteId, entryId))
            {
                _repository.DeleteWhere(x => x.Id == entryId);

                if (!_repository.Save()) return StatusCode(500, "Failed to handle your request. Unknown errors.");

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
