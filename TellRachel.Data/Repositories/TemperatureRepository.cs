using System;
using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class TemperatureRepository : EntityBaseRepository<Temperature>, ITemperatureRepository
    {
        public TemperatureRepository(TellRachelContext context) : base(context)
        {
        }

        public bool Exist(Guid noteId, Guid entryId)
        {
            return ExistWhere(temperature => temperature.Id == entryId && temperature.NoteId == noteId);
        }
    }
}
