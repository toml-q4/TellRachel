using System;
using Humanizer;

namespace TellRachel.Models.Symptom
{
    public class SymptomModel
    {
        public int Id { get; set; }

        public DateTime TakenDate { get; set; }

        public string TakenDateAgo => TakenDate.Humanize();

        public string Name { get; set; }

        public string Description { get; set; }

        public double? TemperatureInCelsius { get; set; }
    }
}
