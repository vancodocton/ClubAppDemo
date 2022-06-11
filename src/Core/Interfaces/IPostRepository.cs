using ClubApp.Core.Entities.PostAggregate;

namespace ClubApp.Core.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Comment> AddCommentToPostByIdAsync(PostId postId, Comment comment);

        Task<ICollection<Comment>> GetCommentsById(PostId postId, int take);
    }
}
