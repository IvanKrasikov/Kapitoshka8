using Microsoft.EntityFrameworkCore;
using Domain.Entities.Nodes;

namespace Persistence
{
    // Подключение БД
    public class NodeContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; } = null!;

        public NodeContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12341234");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new NodeConfig());
        }
    }
}
