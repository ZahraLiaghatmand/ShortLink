using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Entities;
using ShortLink.Shared.Result;

namespace ShortLink.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Link> Links { get; }
        DbSet<User> Users { get; }
        Task<Result> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
