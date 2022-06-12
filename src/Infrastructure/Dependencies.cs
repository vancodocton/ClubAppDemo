using ClubApp.Infrastructure.Data;
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
            var migrationsAssembly = typeof(Dependencies).Assembly.GetName().Name;

            return services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString, o => o.MigrationsAssembly(migrationsAssembly));
            })
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }

        public static IServiceCollection AddPostDbContext(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(Dependencies).Assembly.GetName().Name;

            return services.AddDbContext<PostDbContext>(options =>
            {
                options.UseSqlServer(connectionString, o => o.MigrationsAssembly(migrationsAssembly));
            });
        }
    }
}
