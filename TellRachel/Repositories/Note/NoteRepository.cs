using TellRachel.Entities;

namespace TellRachel.Repositories.Note
{
    public class NoteRepository : EntityBaseRepository<Entities.Note>, INoteRepository
    {
        public NoteRepository(TellRachelContext context) : base(context)
        {
        }
    }
}
