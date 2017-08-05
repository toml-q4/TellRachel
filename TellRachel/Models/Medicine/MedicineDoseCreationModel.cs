using System;

namespace TellRachel.Models.Medicine
{
    public class MedicineDoseCreationModel
    {
        public double Amount { get; set; }

        public string Unit { get; set; }

        public DateTime TakenDate { get; set; }
    }
}
