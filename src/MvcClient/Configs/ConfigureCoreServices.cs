using ClubApp.Core.Interfaces;
using ClubApp.Core.Services;
using ClubApp.Infrastructure.Repositories;

namespace ClubApp.MvcClient.Configs
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();

            return services;
        }
    }
}
