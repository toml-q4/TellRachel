using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TellRachel.Models.Symptom;
using AutoMapper;
using TellRachel.Domain.Entities;
using TellRachel.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TellRachel.Controllers
{
    [Route("api/symptoms")]
    public class SymptomsController : ControllerBase
    {
        private ISymptomRepository _repository;

        public SymptomsController(ISymptomRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SymptomCreationModel value)
        {
            if (value == null) return BadRequest("Posted data is invalid");

            if (value.TakenDate == DateTime.MinValue)
                ModelState.AddModelError("TakenDate", "Invalid value");

            if (value.NoteId == Guid.Empty)
                ModelState.AddModelError("NoteId", "Missing value");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = Mapper.Map<Symptom>(value);
            _repository.Add(entity);

            if (!_repository.Save()) return StatusCode(500, "Failed to handle your request. Unknown errors.");

            var createModel = Mapper.Map<SymptomModel>(entity);
            return CreatedAtRoute("GetById", new { id = createModel.Id }, createModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
