using ClubApp.Core.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Infrastructure.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
