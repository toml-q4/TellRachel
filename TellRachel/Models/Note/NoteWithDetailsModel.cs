using System.Collections.Generic;

namespace TellRachel.Models.Note
{
    public class NoteWithDetailsModel : NoteModel
    {
        public List<NoteEntryModel> Entries { get; set; } = new List<NoteEntryModel>();
    }
}
