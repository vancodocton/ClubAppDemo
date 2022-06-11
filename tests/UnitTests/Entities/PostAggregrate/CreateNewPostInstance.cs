using ClubApp.Core.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Entities.PostAggregrate
{
    public class CreateNewPostInstance
    {
        [Fact]
        public void CreateNewPost()
        {
            string userId = "userId";
            string title = "Post Title";
            var post = new Post(userId, title);
        }
    }
}
