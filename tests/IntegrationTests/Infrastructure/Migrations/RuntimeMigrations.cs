using ClubApp.Core.Entities.PostAggregate;
using ClubApp.Infrastructure;
using ClubApp.Infrastructure.Data;
using ClubApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Infrastructure.Migrations
{
    public static class RuntimeMigrations
    {
        private static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ClubAppDb-runtime-migration;Trusted_Connection=True;MultipleActiveResultSets=true";

        [Fact]
        public static async Task TestDependenciesAsync()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddAppIdentity(connectionString);

            builder.Services.AddPostDbContext(connectionString);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
                await db.Database.EnsureDeletedAsync();
                await db.Database.MigrateAsync();

                //Assert.True(typeof(ApplicationRole).FullName == db.Roles.EntityType.Name);
                //Assert.True(typeof(ApplicationUser).FullName == db.Users.EntityType.Name);
                Assert.True(db.Roles is DbSet<ApplicationRole>);
                Assert.True(db.Users is DbSet<ApplicationUser>);
            }

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<PostDbContext>();
                await db.Database.MigrateAsync();

                Assert.True(typeof(Post).FullName == db.Posts.EntityType.Name);
                Assert.True(typeof(Comment).FullName == db.Comments.EntityType.Name);
            }
        }
    }
}
