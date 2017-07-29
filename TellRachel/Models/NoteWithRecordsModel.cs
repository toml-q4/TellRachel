using System.Collections.Generic;

namespace TellRachel.Models
{
    public class NoteWithRecordsModel : NoteModel
    {
        public ICollection<RecordModel> Records { get; set; } = new List<RecordModel>();

        public int RecordsCount => Records.Count;
    }
}
