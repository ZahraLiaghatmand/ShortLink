using ShortLink.Domain.Common;

namespace ShortLink.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string UserName { get; set; }
    }
}