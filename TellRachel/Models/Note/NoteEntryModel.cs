using System;

namespace TellRachel.Models.Note
{
    public class NoteEntryModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string RachelSense { get; set; }

        public DateTime TakenDate { get; set; }

        public EntryType EntryType { get; set; }
    }
}
