using ClubApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Infrastructure.Fixtures
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ClubAppDb-testing;Trusted_Connection=True;MultipleActiveResultSets=true";
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public TestPostDbContext CreateContext()
            => new TestPostDbContext(
                new DbContextOptionsBuilder<PostDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
}
