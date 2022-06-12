using ClubApp.Infrastructure.Data;
using IntegrationTests.Infrastructure.Fixtures.Seeds;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Infrastructure.Fixtures
{
    public class TestPostDbContext : PostDbContext
    {
        public TestPostDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var testDbConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ClubAppDb-testing;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(testDbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SeedPost());
            modelBuilder.ApplyConfiguration(new SeedComment());
        }
    }
}
