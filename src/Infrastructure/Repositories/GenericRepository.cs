using Ardalis.Specification.EntityFrameworkCore;
using ClubApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> , IDisposable, IAsyncDisposable
        where T : class, IAggregateRoot
    {
        private bool disposedValue;
        private readonly DbContext dbContext;

        public GenericRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~GenericRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            // Perform async cleanup.
            await DisposeAsyncCore();

            // Dispose of unmanaged resources.
            Dispose(false);

            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            await dbContext.DisposeAsync();
        }
    }
}
