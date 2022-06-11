using ClubApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace IntegrationTests.Infrastructure.Identity
{
    
    public class CreateNewApplicationUserTest
    {
        
        public CreateNewApplicationUserTest()
        {            
        }

        [Fact]
        public void CreateNewUserInstance()
        {
            var user1 = new ApplicationUser("newusername");

            var user2 = new ApplicationUser();

            Assert.IsType<ApplicationUser>(user1);
            Assert.IsType<ApplicationUser>(user2);
        }
    }
}
