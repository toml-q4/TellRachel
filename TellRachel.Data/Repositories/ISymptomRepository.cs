using System;
using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public interface ISymptomRepository : IEntityBaseRepository<Symptom>
    {
        bool Exist(Guid noteId, Guid symptomId);
    }
}
