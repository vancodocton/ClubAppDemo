using ClubApp.Core.Interfaces;

namespace ClubApp.Core.Entities.PostAggregate
{
    public class Post : EntityBase<int>, IAggregateRoot
    {
        public UserId UserId { get; init; }

        public string Title { get; init; }

        public virtual ICollection<Comment> Comments { get; private set; }

        public Post(UserId userId, string title, PostId id = default!)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Comments = new HashSet<Comment>();
        }
    }
}
