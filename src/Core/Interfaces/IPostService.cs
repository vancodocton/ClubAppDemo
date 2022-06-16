using ClubApp.Core.Entities.PostAggregate;

namespace ClubApp.Core.Interfaces
{
    public interface IPostService : IDisposable
    {
        Task<Post> CreatePostAsync(UserId userId, string title, CancellationToken token = default);
        
        Task<Comment> CreateCommentAsync(string userId, int postId, string content, CancellationToken token = default);
        
        Task<ICollection<Comment>> GetCommentsByPostId(int postId, int take = 10, CancellationToken token = default);
    }
}
