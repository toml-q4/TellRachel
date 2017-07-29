using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TellRachel.Entities;

namespace TellRachel.Controllers
{
    [Route("api/hernotes")]
    public class HerNotesController : ControllerBase
    {
        private TellRachelContext _context;

        public HerNotesController(TellRachelContext context)
        {
            _context = context;
        }

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
