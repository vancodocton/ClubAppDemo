using ClubApp.Core.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationTests.Infrastructure.Fixtures.Seeds
{
    public class SeedComment : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(new List<Comment>()
            {
                new Comment("1", "Agree", 1)
                {
                    PostId = 1,
                },
                new Comment("2", "Agree", 2)
                {
                    PostId = 1,
                },
            });
        }
    }
}
