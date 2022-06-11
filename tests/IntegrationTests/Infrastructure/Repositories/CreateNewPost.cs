using ClubApp.Core.Entities.PostAggregate;
using ClubApp.Infrastructure.Repositories;
using IntegrationTests.Infrastructure.Fixtures;

namespace IntegrationTests.Infrastructure.Repositories
{
    public class CreateNewPost : IntegrationTestBase
    {

        public CreateNewPost() : base()
        {
        }

        [Fact]
        public async void CreateNewPostByRepository()
        {
            PostRepository repos = new PostRepository(dbContext);

            var post = new Post("userId", "post title");

            var createdPost = await repos.AddAsync(post);
        }
    }
}
