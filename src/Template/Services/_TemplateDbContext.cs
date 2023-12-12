using Template.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Template.Services.Shared;

namespace Template.Services
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext()
        {
        }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            DataGenerator.InitializeUsers(this);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dipendente> Dipendenti { get; set; }
        public DbSet<Nave> Navi { get; set; }
        public DbSet<Orari> Orari { get; set; }
    }
}
