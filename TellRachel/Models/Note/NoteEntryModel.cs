using System;

namespace TellRachel.Models.Note
{
    public class NoteEntryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string RachelSense { get; set; }

        public DateTime TakenDate { get; set; }

        public EntryType EntryType { get; set; }
    }
}
