using ClubApp.Core.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationTests.Infrastructure.Fixtures.Seeds
{
    public class SeedPost : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(new List<Post>()
            {
                new Post("1", "Well 1", 1),
                new Post("1", "Well 2", 2),
                new Post("1", "Well 3", 3),
            });
        }
    }
}
