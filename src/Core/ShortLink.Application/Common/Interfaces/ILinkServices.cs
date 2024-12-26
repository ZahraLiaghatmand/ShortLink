using ShortLink.Domain.Entities;

namespace ShortLink.Application.Common.Interfaces
{
    public interface ILinkServices
    {
        public IEnumerable<Link> GetAll();
    }
}
