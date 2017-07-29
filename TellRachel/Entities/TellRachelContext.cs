using Microsoft.EntityFrameworkCore;

namespace TellRachel.Entities
{
    public class TellRachelContext : DbContext
    {
        public TellRachelContext(DbContextOptions<TellRachelContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<HerNote> HerNotes { get; set; }

        public DbSet<HerRecord> HerRecords { get; set; }
    }
}
