using System;
using System.ComponentModel.DataAnnotations;

namespace TellRachel.Models.Temperature
{
    public class TemperatureCreationModel
    {
        [Required]
        public double Value { get; set; }

        public bool IsFahrenheit { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }
    }
}
