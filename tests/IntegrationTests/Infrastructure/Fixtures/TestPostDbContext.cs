using ClubApp.Infrastructure.Data;
using IntegrationTests.Infrastructure.Fixtures.Seeds;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Infrastructure.Fixtures
{
    public class TestPostDbContext : PostDbContext
    {
        public TestPostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SeedPost());
            modelBuilder.ApplyConfiguration(new SeedComment());
        }
    }
}
