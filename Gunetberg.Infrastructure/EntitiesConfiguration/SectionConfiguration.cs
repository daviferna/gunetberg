using Gunetberg.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Infrastructure.EntitiesConfiguration
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.SectionId);
            builder.Property(x => x.SectionId).ValueGeneratedOnAdd();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Type).HasConversion<string>().IsRequired();
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
