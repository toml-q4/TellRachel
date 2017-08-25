using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class TemperatureRepository : EntityBaseRepository<Temperature>, ITemperatureRepository
    {
        public TemperatureRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
