using Microsoft.EntityFrameworkCore;
using ShortLink.Application.Common.Interfaces;
using ShortLink.Domain.Entities;

namespace ShortLink.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Link> links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Database=ShortLink; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        int IApplicationDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}