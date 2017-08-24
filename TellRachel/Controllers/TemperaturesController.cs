using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TellRachel.Models.Temperature;

namespace TellRachel.Controllers
{
    [Route("api/temperatures")]
    public class TemperaturesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody]TemperatureCreationModel value)
        {
            return null;
        }
    }
}