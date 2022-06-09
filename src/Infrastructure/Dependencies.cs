using ClubApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClubApp.Infrastructure
{
    public static class Dependencies
    {
        public static IdentityBuilder AddAppIdentity(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            })
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }
    }
}
