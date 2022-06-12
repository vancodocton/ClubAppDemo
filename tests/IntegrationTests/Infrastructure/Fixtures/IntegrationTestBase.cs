using ClubApp.Core.Interfaces;
using ClubApp.Core.Services;
using ClubApp.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace IntegrationTests.Infrastructure.Fixtures
{
    public class IntegrationTestBase : IClassFixture<TestDatabaseFixture>, IDisposable
    {
        protected readonly TestPostDbContext dbContext;
        protected Lazy<IPostRepository> postRepos;
        protected Lazy<IPostService> postService;

        private bool disposedValue;

        public IntegrationTestBase(TestDatabaseFixture fixture)
        {
            dbContext = fixture.CreateContext();
            postRepos = new(() => new PostRepository(dbContext));
            postService = new(() => new PostService(
                LoggerFactoryProvider.LoggerFactoryInstance.CreateLogger<PostService>(),
                postRepos.Value)
            );
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                    if (postRepos.IsValueCreated == true)
                        postRepos.Value.Dispose();

                    if (postService.IsValueCreated == true)
                        postService.Value.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            await dbContext.DisposeAsync();
        }

        ~IntegrationTestBase()
        {
            Dispose(disposing: false);
        }
    }
}
