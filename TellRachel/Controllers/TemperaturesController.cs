using Microsoft.AspNetCore.Mvc;
using TellRachel.Data.Repositories;
using TellRachel.Models.Temperature;
using TellRachel.Shared;

namespace TellRachel.Controllers
{
    [Route("api/temperatures")]
    public class TemperaturesController : ControllerBase
    {
        private ITemperatureRepository _repository;
        private INoteRepository _noteRepository;

        public TemperaturesController(ITemperatureRepository repository, INoteRepository noteRepository)
        {
            _repository = repository;
            _noteRepository = noteRepository;
        }


        [HttpPost]
        public IActionResult Post([FromBody]TemperatureCreationModel value)
        {
            if (value == null) return BadRequest("Posted data is invalid");

            if (value.NoteId <= 0)
                ModelState.AddModelError(nameof(value.NoteId), "Invalid value");
            
            if (value.IsFahrenheit && (value.Value < HumanLimits.MIN_BODY_TEMPERATURE_FAHRENHEIT || value.Value > HumanLimits.MAX_BODY_TEMPERATURE_FAHRENHEIT))
                ModelState.AddModelError(nameof(value.Value), "Out of range value for Fahrenheit");

            if (!value.IsFahrenheit && (value.Value < HumanLimits.MIN_BODY_TEMPERATURE_CELSIUS || value.Value > HumanLimits.MAX_BODY_TEMPERATURE_CELSIUS))
                ModelState.AddModelError(nameof(value.Value), "Out of range value for Celsius");

            if (!ModelState.IsValid) return BadRequest(ModelState);
            

            return null;
        }
    }
}