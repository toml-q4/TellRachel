using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class MedicineRepository : EntityBaseRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
