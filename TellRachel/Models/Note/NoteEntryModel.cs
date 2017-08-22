using System;
using Humanizer;

namespace TellRachel.Models.Note
{
    public class NoteEntryModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime TakenDateTime { get; set; }

        public string TakenDateTimeAgo => TakenDateTime.Humanize();
    }
}
