using Gunetberg.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Infrastructure.EntitiesConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.PostId);
            builder.Property(x => x.PostId).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.HasMany(x => x.Sections).WithOne(x => x.Post).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
