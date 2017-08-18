using System;
using Humanizer;

namespace TellRachel.Models.Note
{
    public class NoteModel
    {
        public Guid Id { get; set; }

        public DateTime? Birthday { get; set; }

        public int? WeightInGrams { get; set; }

        public bool? IsMale { get; set; }

        public DateTime TakenDate { get; set; }

        public string TakenDateAgo => TakenDate.Humanize();
    }
}

