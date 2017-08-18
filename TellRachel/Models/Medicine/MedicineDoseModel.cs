using System;
using Humanizer;

namespace TellRachel.Models.Medicine
{
    public class MedicineDoseModel
    {
        public Guid Id { get; set; }

        public double Amount { get; set; }

        public string Unit { get; set; }

        public DateTime TakenDate { get; set; }

        public string TakenDateAgo => TakenDate.Humanize();
    }
}
