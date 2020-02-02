using Gunetberg.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Infrastructure.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique().HasName("Email_Index");
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Alias).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Role).HasConversion<string>();
            builder.HasMany(x => x.Posts).WithOne(x => x.Author).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
