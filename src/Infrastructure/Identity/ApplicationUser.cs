using Microsoft.AspNetCore.Identity;

namespace ClubApp.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
}
