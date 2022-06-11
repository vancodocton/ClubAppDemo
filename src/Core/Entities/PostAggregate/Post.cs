using ClubApp.Core.Interfaces;

namespace ClubApp.Core.Entities.PostAggregate
{
    public class Post : EntityBase<int>, IAggregateRoot
    {
        public string Title { get; private set; }

        public virtual ICollection<Comment> Comments { get; private set; }

        public Post(string title, ICollection<Comment>? comments = null)
        {
            Title = title;
            Comments = comments ?? new List<Comment>();
        }
    }
}
