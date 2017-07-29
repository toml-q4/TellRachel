using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TellRachel.Enums;

namespace TellRachel.Models
{
    public class Temperature
    {
        public double Value { get; set; }
        public TemperatureUnit Unit { get; set; }
    }
}
