namespace ClubApp.Core.Entities.PostAggregate
{
    public class Comment : EntityBase<int>
    {
        public UserId UserId { get; init; }

        public PostId PostId { get; init; }

        public Post Post { get; private set; } = null!;

        public string Content { get; init; }

        public Comment(UserId userId, string content, CommentId id = default!)
        {
            Id = id;
            UserId = userId;
            Content = content;
        }
    }
}
