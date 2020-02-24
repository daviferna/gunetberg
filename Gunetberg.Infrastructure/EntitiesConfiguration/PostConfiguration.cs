using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gunetberg.Infrastructure.EntitiesConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.PostId);
            builder.Property(x => x.PostId).ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .HasMaxLength(PostRestrictions.TitleMaxLength)
                .IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.HasMany(x => x.Sections).WithOne(x => x.Post).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Commentaries).WithOne(x => x.Post).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
