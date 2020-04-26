using Gunetberg.Domain;
using Gunetberg.Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Infrastructure
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new CommentaryConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
