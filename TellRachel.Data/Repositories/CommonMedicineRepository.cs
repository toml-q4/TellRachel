using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class CommonMedicineRepository : EntityBaseRepository<CommonMedicine>, ICommonMedicineRepository
    {
        public CommonMedicineRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
