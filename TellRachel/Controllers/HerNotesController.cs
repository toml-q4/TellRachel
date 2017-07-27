using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
