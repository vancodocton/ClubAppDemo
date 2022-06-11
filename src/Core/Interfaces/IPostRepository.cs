using ClubApp.Core.Entities.PostAggregate;

namespace ClubApp.Core.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Comment> AddCommentToPostByIdAsync(PostId postId, Comment comment, CancellationToken token = default);
        
        Task<ICollection<Comment>> GetCommentsByIdAsync(PostId postId, int take, CancellationToken token = default);
    }
}
