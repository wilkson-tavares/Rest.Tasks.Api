using Microsoft.EntityFrameworkCore;
using Tasks.Entities.Entities;

namespace Tasks.Infra.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options):base(options)
        {
        }

        public DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ObterConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tarefa>().ToTable("Tarefa").HasKey(k => k.Id);

            base.OnModelCreating(builder);
        }

        public string ObterConnectionString()
            => "Data Source = Tarefa.DB";
    }
}