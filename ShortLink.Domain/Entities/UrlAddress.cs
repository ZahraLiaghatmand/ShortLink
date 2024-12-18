using ShortLink.Domain.Common;

namespace ShortLink.Domain.Entities
{
    public class UrlAddress : BaseEntity
    {
        public required string Url { get; set; }
        public string? ShortCode { get; set; }
        public User Owner { get; set; }
    }
}
