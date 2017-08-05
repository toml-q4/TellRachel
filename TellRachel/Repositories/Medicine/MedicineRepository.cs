using TellRachel.Entities;

namespace TellRachel.Repositories.Medicine
{
    public class MedicineRepository : EntityBaseRepository<Entities.Medicine>, IMedicineRepository
    {
        public MedicineRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
