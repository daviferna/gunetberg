using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Infrastructure.EntitiesConfiguration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => x.NotificationId);
            builder.Property(x => x.NotificationId).ValueGeneratedOnAdd();
            builder.Property(x => x.Kind).IsRequired()
                                         .HasConversion<string>()
                                         .HasMaxLength(NotificationRestrictions.KindMaxLength);
        }
    }
}
