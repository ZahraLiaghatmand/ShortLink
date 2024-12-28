using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Entities;

namespace ShortLink.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Link> links { get; set; }
        DbSet<User> users { get; set; }
        public int SaveChanges();
    }
}
