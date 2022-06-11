using ClubApp.Core.Entities.PostAggregate;
using ClubApp.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ClubApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> logger;
        private readonly IPostRepository postRepository;

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

        public Task<Comment> CreateCommentAsync(UserId userId, PostId postId, string content)
        {
            var comment = new Comment(userId, content);

            return postRepository.AddCommentToPostByIdAsync(postId, comment);
        }

        public Task<ICollection<Comment>> GetCommentsByPostId(PostId postId, int take = 10)
        {
            return postRepository.GetCommentsById(postId, take);
        }
    }
}
