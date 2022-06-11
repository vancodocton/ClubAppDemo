using ClubApp.Core.Entities.PostAggregate;
using ClubApp.Core.Exceptions;
using ClubApp.Core.Interfaces;
using ClubApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository, IDisposable, IAsyncDisposable
    {
        private bool disposedValue;
        private readonly PostDbContext dbContext;

        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Comment> AddCommentToPostByIdAsync(string postId, Comment comment, CancellationToken token = default)
        {
            var post = await GetByIdAsync(postId);
            if (post == null)
                throw new PostNotFoundException(postId);

            post.Comments.Add(comment);
            await UpdateAsync(post, token);

            return comment;
        }

        public async Task<ICollection<Comment>> GetCommentsByIdAsync(string postId, int takeLastNum, CancellationToken token = default)
        {
            var query = dbContext.Comments
                .AsNoTracking()
                .Where(c => c.PostId == postId)
                .TakeLast(takeLastNum);                

            var comments = await query.ToListAsync(token);
            return comments;
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }

                disposedValue = true;
            }

            base.Dispose(disposing);
        }

        protected override async ValueTask DisposeAsyncCore()
        {
            await dbContext.DisposeAsync();
        }

        ~PostRepository()
        {
            Dispose(disposing: false);
        }
    }
}
