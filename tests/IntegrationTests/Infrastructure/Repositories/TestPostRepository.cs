using ClubApp.Core.Entities.PostAggregate;
using ClubApp.Core.Exceptions;
using ClubApp.Infrastructure.Repositories;
using IntegrationTests.Infrastructure.Fixtures;

namespace IntegrationTests.Infrastructure.Repositories
{
    public class TestPostRepository : IClassFixture<IntegrationTestBase>
    {
        private readonly PostRepository postRepos;

        public TestPostRepository(IntegrationTestBase testBase)
        {
            postRepos = new PostRepository(testBase.DbContext);
        }

        [Theory, TestPriority(100)]
        [InlineData("1", "1. Post of 1")]
        [InlineData("1", "2. Post of 1")]
        [InlineData("1", "3. Post of 1")]
        [InlineData("2", "4. Post of 2")]
        public async void PostRepository_NewPost_CreateNewPostSuccess(string userId, string title)
        {
            var post = new Post(userId, title);

            var createdPost = await postRepos.AddAsync(post);

            Assert.True(createdPost is not null);
            Assert.True(createdPost!.Id != 0);
        }

        [Theory, TestPriority(3)]
        [InlineData("2", "Comment of 2 to Post with id 1", 1)]
        [InlineData("1", "Comment of 1 to Post with id 1", 1)]
        [InlineData("2", "Comment of 2 to Post with id 2", 2)]
        public async void PostRepository_NewCommentWithValidPostId_AddCommentToPostByIdSuccess(string userId, string title, int postId)
        {
            var comment = new Comment(userId, title);

            var createdCmt = await postRepos.AddCommentToPostByIdAsync(postId, comment);

            Assert.True(createdCmt is not null);
            Assert.True(createdCmt!.Id != 0);
        }

        [Theory, TestPriority(2)]
        [InlineData("2", "Comment of 2 to Post with id 100", 100)]
        [InlineData("1", "Comment of 1 to Post with id -1", -1)]
        [InlineData("2", "Comment of 2 to Post with id 0", 0)]
        public async void PostRepository_NewCommentWithInvalidPostId_AddCommentToPostByIdFail(string userId, string title, int postId)
        {
            var comment = new Comment(userId, title);

            await Assert.ThrowsAsync<PostNotFoundException>(() => postRepos.AddCommentToPostByIdAsync(postId, comment));
        }
    }
}
