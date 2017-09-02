using System;
using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class SymptomRepository : EntityBaseRepository<Symptom>, ISymptomRepository
    {
        public SymptomRepository(TellRachelContext context) : base(context)
        {
        }

        public bool Exist(Guid noteId, Guid entryId)
        {
            return ExistWhere(symptom => symptom.Id == entryId && symptom.NoteId == noteId);
        }

    }
}
