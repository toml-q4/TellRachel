using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class SymptomRepository : EntityBaseRepository<Symptom>, ISymptomRepository
    {
        public SymptomRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
