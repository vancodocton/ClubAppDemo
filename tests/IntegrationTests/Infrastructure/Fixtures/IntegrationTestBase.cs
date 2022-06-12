namespace IntegrationTests.Infrastructure.Fixtures
{
    public abstract class IntegrationTestBase : IDisposable
    {
        protected TestPostDbContext dbContext;
        private bool disposedValue;

        protected static bool isDropped = false;
        public IntegrationTestBase()
        {
            dbContext = new TestPostDbContext();

            Initialize(false);
        }

        protected virtual void Initialize(bool isDeleted)
        {
            //try
            {
                if (!isDropped || isDeleted)
                {
                    dbContext.Database.EnsureDeleted();
                    isDropped = true;
                }
            }
            //catch (Exception ex) { Console.WriteLine(ex.Message); }

            dbContext.Database.EnsureCreated();
        }

        public void Initialize() => Initialize(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
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
