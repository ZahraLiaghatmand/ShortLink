using ShortLink.Domain.Entities;

namespace ShortLink.Application.Dtos
{
    public record LinksDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortCode { get; set; }
        public User Owner { get; set; }
    }
}
