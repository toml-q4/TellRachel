using System.Collections.Generic;
using TellRachel.Models.Medicine;
using TellRachel.Models.Symptom;

namespace TellRachel.Models.Note
{
    public class NoteWithDetailsModel : NoteModel
    {
        public ICollection<NoteEntryModel> Entries { get; set; } = new List<NoteEntryModel>();
    }
}
