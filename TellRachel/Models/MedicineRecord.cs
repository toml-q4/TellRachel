using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TellRachel.Enums;

namespace TellRachel.Models
{
    public class MedicineRecord : Record
    {
        public string Name { get; set; }
        public double Dose { get; set; }
        public FluidUnit Unit { get; set; }
    }
}
