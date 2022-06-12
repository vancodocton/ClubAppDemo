using ClubApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Infrastructure.Fixtures
{

    public class IntegrationTestBase : IDisposable
    {
        public TestPostDbContext DbContext { get; }
        private bool disposedValue;
        protected static bool isIntialized = false;

        public IntegrationTestBase()
        {

            DbContext = Initialize();
        }

        protected virtual TestPostDbContext Initialize()
        {
            var testDbConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ClubAppDb-testing;Trusted_Connection=True;MultipleActiveResultSets=true";

            var optionsBuilder = new DbContextOptionsBuilder<PostDbContext>();
            optionsBuilder.UseSqlServer(testDbConnectionString, o =>
            {
                o.EnableRetryOnFailure();
            });

            var dbContext = new TestPostDbContext(optionsBuilder.Options);

            if (!isIntialized)
            {
                isIntialized = true;
                _ = dbContext.Database.EnsureDeletedAsync().Result;
                _ = dbContext.Database.EnsureCreatedAsync().Result;
            }

            return dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~IntegrationTestBase()
        {
            Dispose(disposing: false);
        }
    }
}
