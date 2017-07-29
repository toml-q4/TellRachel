using System.Collections.Generic;
using TellRachel.Entities;

namespace TellRachel.Repositories
{
    public interface ITellRachelRepository
    {
        IEnumerable<HerNote> GetHerNotes();

        HerNote GetHerNote(int herNoteId, bool includeHerRecords);

        IEnumerable<HerRecord> GetHerRecords(int herNoteId);

        HerRecord GetHerRecord(int herNoteId, int herRecordId);

        void CreateNote(HerNote herNote);

        bool Save();
    }
}