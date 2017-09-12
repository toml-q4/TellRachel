using Microsoft.AspNetCore.Mvc;
using TellRachel.Data.Repositories;

namespace TellRachel.Controllers
{
    [Route("api/[controller]")]
    public class CommonMedicinesController : ControllerBase
    {
        private readonly ICommonMedicineRepository _commonMedicineRepository;

        public CommonMedicinesController(ICommonMedicineRepository commonMedicineRepository)
        {
            _commonMedicineRepository = commonMedicineRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return null;
        }
    }
}
