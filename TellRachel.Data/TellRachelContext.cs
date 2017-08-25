using Microsoft.EntityFrameworkCore;
using TellRachel.Domain.Entities;

namespace TellRachel.Data
{
    public class TellRachelContext : DbContext
    {
        public TellRachelContext(DbContextOptions<TellRachelContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineDose> MedicineDoses { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
    }
}
