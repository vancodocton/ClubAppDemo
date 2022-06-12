using ClubApp.Core.Entities.PostAggregate;
using ClubApp.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ClubApp.Core.Services
{
    public class PostService : IPostService, IDisposable
    {
        private readonly ILogger<PostService> logger;
        private readonly IPostRepository postRepository;
        private bool disposedValue;

        public PostService(
            ILogger<PostService> logger,
            IPostRepository postRepository
            )
        {
            this.logger = logger;
            this.postRepository = postRepository;
        }

        public Task<Post> CreatePostAsync(UserId userId, string title)
        {
            var post = new Post(userId: userId, title: title);

            return postRepository.AddAsync(post);
        }

        public Task<Comment> CreateCommentAsync(UserId userId, PostId postId, string content, CancellationToken token = default)
        {
            var comment = new Comment(userId, content);

            return postRepository.AddCommentToPostByIdAsync(postId, comment, token);
        }

        public Task<ICollection<Comment>> GetCommentsByPostId(PostId postId, int take = 10, CancellationToken token = default)
        {
            return postRepository.GetCommentsByIdAsync(postId, take, token);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    postRepository.Dispose();
                }

                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~PostService()
        {
            Dispose(disposing: false);
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
