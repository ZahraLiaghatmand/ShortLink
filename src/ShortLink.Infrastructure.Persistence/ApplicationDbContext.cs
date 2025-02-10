using Microsoft.EntityFrameworkCore;
using ShortLink.Application.Common.Interfaces;
using ShortLink.Domain.Entities;
using ShortLink.Shared.Result;

namespace ShortLink.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Link> Links { get; set; }

        public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken) <= 0 //the number of affected rows
                ? Result.Failure(Error.Failure("SaveChangesFailed", "Database operation failed :("))
                : Result.Success();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Database=ShortLink; Trusted_Connection=True; TrustServerCertificate=True;");
        }

    }
}