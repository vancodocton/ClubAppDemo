namespace ClubApp.Core.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(PostId postId) : base($"No Post found with id '{postId}'")
        {
        }                
    }
}
