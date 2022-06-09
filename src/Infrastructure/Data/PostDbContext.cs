using ClubApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Infrastructure.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post>? Post { get; set; }
    }
}
