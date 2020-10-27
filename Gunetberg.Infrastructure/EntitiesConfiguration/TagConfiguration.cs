using Gunetberg.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Infrastructure.EntitiesConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(x => x.TagId);
            builder.Property(x => x.TagId).ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Name)
                .IsUnique()
                .HasName("Name_Index");

            builder.HasMany(x => x.PostTags)
                .WithOne(x => x.Tag)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
