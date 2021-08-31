using Krystal.Services.Admin.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krystal.Services.Admin.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder o)
        {
            o.Entity<Link>().HasKey(i => i.Id);
            o.Entity<Link>().Property(i => i.UserId).IsRequired();
            o.Entity<Link>().Property(i => i.Enabled).IsRequired();
            o.Entity<Link>().Property(i => i.Slug).IsRequired().HasMaxLength(256);
            o.Entity<Link>().Property(i => i.Url).IsRequired().HasMaxLength(1024);
        }
    }
}