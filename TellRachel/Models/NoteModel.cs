using System;
using Humanizer;

namespace TellRachel.Models
{
    public class NoteModel
    {
        public int Id { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string Ago => CreatedDateTime.Humanize();
    }
}

