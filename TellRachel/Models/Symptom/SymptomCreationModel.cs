using System;

namespace TellRachel.Models.Symptom
{
    public class SymptomCreationModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TakenDate { get; set; }
        public Guid NoteId { get; set; }
    }
}
