using ClubApp.Core.Exceptions;
using ClubApp.Core.Interfaces;
using ClubApp.Core.Services;
using ClubApp.Infrastructure.Repositories;
using IntegrationTests.Infrastructure.Fixtures;
using Microsoft.Extensions.Logging;

namespace IntegrationTests.Infrastructure.Core.Services
{
    public class TestPostService : IntegrationTestBase
    {
        private new readonly IPostService postService;

        public TestPostService(TestDatabaseFixture fixture) : base(fixture)
        {
            postService = base.postService.Value;
        }

        [Theory, TestPriority(100)]
        [InlineData("1", "1. Post of 1")]
        [InlineData("2", "4. Post of 2")]
        [InlineData("1", "2. Post of 1")]
        public async void PostService_NewPost_CreateNewPostSuccess(string userId, string title)
        {
            var createdPost = await postService.CreatePostAsync(userId, title);

            Assert.NotNull(createdPost);
            Assert.True(createdPost.Id != 0);
        }

        [Theory, TestPriority(3)]
        [InlineData("2", "Comment of 2 to Post with id 1", 1)]
        [InlineData("1", "Comment of 1 to Post with id 1", 1)]
        [InlineData("2", "Comment of 2 to Post with id 2", 2)]
        public async void PostService_NewCommentWithValidPostId_AddCommentToPostByIdSuccess(string userId, string content, int postId)
        {
            var createdCmt = await postService.CreateCommentAsync(userId, postId, content);

            Assert.NotNull(createdCmt);
            Assert.True(createdCmt.Id != 0);
        }

        [Theory, TestPriority(3)]
        [InlineData(1)]
        [InlineData(2)]
        public async void PostService_GetCommentsByValidPostId_Success(int postId)
        {
            var comments = await postService.GetCommentsByPostId(postId);

            Assert.NotNull(comments);
            Assert.True(comments.Count <= 10);
        }

        [Theory, TestPriority(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1000)]
        public async void PostService_GetCommentByInValidPostId_ThrowPostNotFoundException(int postId)
        {
            var task = postService.GetCommentsByPostId(postId);

            await Assert.ThrowsAsync<PostNotFoundException>(() => task);
        }
    }
}
