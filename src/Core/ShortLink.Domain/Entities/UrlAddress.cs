namespace ShortLink.Domain.Entities
{
    public class UrlAddress
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public string? ShortCode { get; set; }
        public User Owner { get; set; }
    }
}
