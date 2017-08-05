using TellRachel.Entities;

namespace TellRachel.Repositories.Symptom
{
    public class SymptomRepository : EntityBaseRepository<Entities.Symptom>, ISymptomRepository
    {
        public SymptomRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
