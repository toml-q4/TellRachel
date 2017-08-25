using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class NoteRepository : EntityBaseRepository<Note>, INoteRepository
    {
        public NoteRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
