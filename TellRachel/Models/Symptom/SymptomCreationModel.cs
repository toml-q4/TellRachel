using System;

namespace TellRachel.Models.Symptom
{
    public class SymptomCreationModel
    {
        public DateTime TakenDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double? TemperatureInCelsius { get; set; }
    }
}
