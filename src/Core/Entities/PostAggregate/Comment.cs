namespace ClubApp.Core.Entities.PostAggregate
{
    public class Comment : EntityBase<int>
    {
        public UserId UserId { get; private set; }

        public PostId PostId { get; private set; } = null!;

        public Post Post { get; private set; } = null!;

        public string Content { get; private set; }

        public Comment(UserId userId, string content)
        {
            UserId = userId;
            Content = content;
        }
    }
}
