using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TellRachel.Controllers
{
    [Route("api/hernotes")]
    public class HerNotesController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetNotes()
        {
            return Ok(new List<object> {
                new
                {
                    id = 1,
                    content = Guid.NewGuid().ToString()
                }
            });
        }
    }
}
