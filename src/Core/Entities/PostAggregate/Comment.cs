namespace ClubApp.Core.Entities.PostAggregate
{
    public class Comment : EntityBase<int>
    {
        public string Content { get; private set; }

        public Comment(string content)
        {
            Content = content;
        }
    }
}
