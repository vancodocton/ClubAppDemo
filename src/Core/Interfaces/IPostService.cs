using ClubApp.Core.Entities.PostAggregate;

namespace ClubApp.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(UserId userId, string title);
    }
}
