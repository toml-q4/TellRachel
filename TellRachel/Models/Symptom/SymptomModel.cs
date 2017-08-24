using System;
using Humanizer;
using TellRachel.Models.Temperature;

namespace TellRachel.Models.Symptom
{
    public class SymptomModel
    {
        public Guid Id { get; set; }

        public DateTime TakenDate { get; set; }

        public string TakenDateAgo => TakenDate.Humanize();

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid NoteId { get; set; }
        
        public TemperatureModel Temperature { get; set; }
    }
}
