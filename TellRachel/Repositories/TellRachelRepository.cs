using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TellRachel.Entities;

namespace TellRachel.Repositories
{
    public class TellRachelRepository : ITellRachelRepository
    {
        private readonly TellRachelContext _context;

        public TellRachelRepository(TellRachelContext context)
        {
            _context = context;
        }

        public IEnumerable<HerNote> GetHerNotes()
        {
            return _context.HerNotes.OrderBy(herNote => herNote.CreatedDateTime).ToList();
        }

        public HerNote GetHerNote(int herNoteId, bool includeHerRecords)
        {
            if (includeHerRecords)
                return _context.HerNotes.Include(herNote => herNote.HerRecords).FirstOrDefault(herNote => herNote.Id == herNoteId);

            return _context.HerNotes.FirstOrDefault(x => x.Id == herNoteId);
        }

        public IEnumerable<HerRecord> GetHerRecords(int herNoteId)
        {
            return _context.HerRecords.Where(herRecord => herRecord.HerNoteId == herNoteId).ToList();
        }

        public HerRecord GetHerRecord(int herNoteId, int herRecordId)
        {
            return _context.HerRecords.FirstOrDefault(herRecord => herRecord.HerNoteId == herNoteId && herRecord.Id == herRecordId);
        }
    }
}
