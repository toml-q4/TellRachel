using System;

namespace TellRachel.Models.Temperature
{
    public class TemperatureModel
    {
        public Guid Id { get; set; }

        public double Value { get; set; }

        public bool IsF { get; set; }
    }
}
