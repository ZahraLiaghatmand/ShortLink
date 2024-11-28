namespace ShortLink.Models
{
    public class UrlAddress
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public string? ShortCode { get; set; }
        public required User Owner { get; set; }
    }
}
