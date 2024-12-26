using Microsoft.EntityFrameworkCore;
using ShortLink.Application.Common.Interfaces;
using ShortLink.Domain.Entities;

namespace ShortLink.Application
{
    public class LinkServices(IApplicationDbContext dbContext) : ILinkServices
    {
        private IApplicationDbContext _dbContext = dbContext;
        public IEnumerable<Link> GetAll()
        {
            return _dbContext.links.ToList();
        }
    }
}
