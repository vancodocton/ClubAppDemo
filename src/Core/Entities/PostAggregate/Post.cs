using ClubApp.Core.Interfaces;

namespace ClubApp.Core.Entities.PostAggregate
{
    public class Post : EntityBase<int>, IAggregateRoot
    {
        public UserId UserId { get; private set; }

        public string Title { get; private set; }

        public virtual ICollection<Comment> Comments { get; private set; }

        public Post(UserId userId, string title)
        {
            UserId = userId;
            Title = title;
            Comments = new HashSet<Comment>();
        }
    }
}
