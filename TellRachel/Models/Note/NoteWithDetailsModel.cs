using System.Collections.Generic;
using System.Linq;
using TellRachel.Domain.Enums;

namespace TellRachel.Models.Note
{
    public class NoteWithDetailsModel : NoteModel
    {
        public List<NoteEntryModel> Entries { get; set; } = new List<NoteEntryModel>();

        public TemperatureIndicator TemperatureIndicator { get; set; } = TemperatureIndicator.Unknown;
    }
}
