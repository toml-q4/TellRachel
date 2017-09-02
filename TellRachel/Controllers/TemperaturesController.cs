using Microsoft.AspNetCore.Mvc;
using TellRachel.Data.Repositories;
using TellRachel.Models.Temperature;
using TellRachel.Shared;
using System;
using AutoMapper;
using TellRachel.Domain.Entities;

namespace TellRachel.Controllers
{
    [Route("api/notes/{noteId}/temperatures")]
    public class TemperaturesController : ControllerBase
    {
        private ITemperatureRepository _temperatureRepository;
        private INoteRepository _noteRepository;

        public TemperaturesController(ITemperatureRepository temperatureRepository, INoteRepository noteRepository)
        {
            _temperatureRepository = temperatureRepository;
            _noteRepository = noteRepository;
        }

        [HttpGet("{id}", Name = "GetTemperature")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
                ModelState.AddModelError(nameof(id), "Invalid temperature id");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var temperature = _temperatureRepository.GetSingle(id);

            if (temperature == null) return NotFound();
            else return Ok(Mapper.Map<TemperatureModel>(temperature));
        }

        [HttpPost]
        public IActionResult Post(Guid noteId, [FromBody]TemperatureCreationModel value)
        {
            if (value == null) return BadRequest("Posted data is invalid");

            if (noteId == Guid.Empty)
                ModelState.AddModelError(nameof(noteId), "Invalid value");

            if (value.TakenDate == DateTime.MinValue)
                ModelState.AddModelError(nameof(value.TakenDate), "Invalid value");

            if (value.IsFahrenheit && (value.Value < HumanLimits.MIN_BODY_TEMPERATURE_FAHRENHEIT || value.Value > HumanLimits.MAX_BODY_TEMPERATURE_FAHRENHEIT))
                ModelState.AddModelError(nameof(value.Value), "Out of range value for Fahrenheit");

            if (!value.IsFahrenheit && (value.Value < HumanLimits.MIN_BODY_TEMPERATURE_CELSIUS || value.Value > HumanLimits.MAX_BODY_TEMPERATURE_CELSIUS))
                ModelState.AddModelError(nameof(value.Value), "Out of range value for Celsius");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_noteRepository.Exist(noteId))
            {
                var newTemperature = Mapper.Map<Temperature>(value);
                newTemperature.NoteId = noteId;
                _temperatureRepository.Add(newTemperature);
                if (!_temperatureRepository.Save()) return StatusCode(500, "Failed to handle your request. Unknown errors.");
                var createdTemperature = Mapper.Map<TemperatureModel>(newTemperature);
                return CreatedAtRoute("GetTemperature", new { id = createdTemperature.Id }, createdTemperature);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{temperatureId}")]
        public IActionResult Delete(Guid noteId, Guid temperatureId)
        {
            if (noteId == Guid.Empty)
                ModelState.AddModelError(nameof(noteId), "Invalid value");

            if (temperatureId == Guid.Empty)
                ModelState.AddModelError(nameof(temperatureId), "Invalid value");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_temperatureRepository.Exist(noteId, temperatureId))
            {
                _temperatureRepository.DeleteWhere(x => x.Id == temperatureId);

                if (!_temperatureRepository.Save()) return StatusCode(500, "Failed to handle your request. Unknown errors.");

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}