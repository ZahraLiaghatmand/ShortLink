using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Entities;

namespace ShortLink.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Link> UrlAddresses { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Database=ShortLink; Trusted_Connection=True;");
        }
    }
}