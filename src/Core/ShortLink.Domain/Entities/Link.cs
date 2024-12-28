namespace ShortLink.Domain.Entities
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortCode { get; set; }
        public User Owner { get; set; }
    }
}
