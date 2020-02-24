using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gunetberg.Infrastructure.EntitiesConfiguration
{
    public class CommentaryConfiguration : IEntityTypeConfiguration<Commentary>
    {
        public void Configure(EntityTypeBuilder<Commentary> builder)
        {
            builder.HasKey(x => x.CommentaryId);
            builder.Property(x => x.CommentaryId).ValueGeneratedOnAdd();
            builder.Property(x => x.Content)
                .HasMaxLength(CommentaryRestrictions.ContentMaxLength)
                .IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
        }
    }
}
