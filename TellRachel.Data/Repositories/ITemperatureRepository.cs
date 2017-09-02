using System;
using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public interface ITemperatureRepository : IEntityBaseRepository<Temperature>
    {
        bool Exist(Guid noteId, Guid temperatureId);
    }
}
