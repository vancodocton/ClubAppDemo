using ClubApp.Infrastructure.Identity;

namespace IntegrationTests.Infrastructure.Identity
{

    public class IdentityUnitTest
    {

        public IdentityUnitTest()
        {
        }

        [Fact]
        public void Identity_CreateNewUserInstance_Success()
        {
            var user1 = new ApplicationUser("newusername");

            var user2 = new ApplicationUser();

            Assert.IsType<ApplicationUser>(user1);
            Assert.IsType<ApplicationUser>(user2);
        }

        [Fact]
        public void Identity_CreateNewRoleInstance_Success()
        {
            var role1 = new ApplicationRole("newRoleName");

            var role2 = new ApplicationRole();

            Assert.IsType<ApplicationRole>(role1);
            Assert.IsType<ApplicationRole>(role2);
        }
    }
}
