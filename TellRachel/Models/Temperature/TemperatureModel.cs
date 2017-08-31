using System;
using TellRachel.Models.Note;

namespace TellRachel.Models.Temperature
{
    public class TemperatureModel
    {
        public Guid Id { get; set; }

        public double Value { get; set; }

        public bool IsFahrenheit { get; set; }

        public DateTime TakenDate { get; set; }

        public NoteEntryModel EntryModel
        {
            get
            {
                var entry = new NoteEntryModel
                {
                    Name = $"{Value:N1}",
                    TakenDate = TakenDate,
                    EntryType = EntryType.Temperature
                };
                return entry;
            }
            private set { }

        }

    }
}
