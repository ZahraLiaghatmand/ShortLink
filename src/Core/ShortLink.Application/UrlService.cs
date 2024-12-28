using ShortLink.Domain.Entities;

namespace ShortLink.Application.Services
{
    public class UrlService
    {
        static List<Link> Urls { get; }
        static List<User> Users { get; }
        static readonly Random random = new Random();
        static readonly string baseUrl = "http://short.ly";
        static UrlService()
        {
            Users = new List<User> {
                new User { Id = 1, UserName = "Zahra" }
            };
            Urls = new List<Link>
            {
                new Link { Id = 1, ShortCode = "zz",
                    Url = "www.google.com", Owner = Users[0]
                },
                new Link { Id = 2, ShortCode = "gg",
                    Url = "www.bankgisoo.ir", Owner = Users[0]
                },
                
            };
        }
        public static string GenerateShortCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] code = new char[6];
            for (int i = 0; i < code.Length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }
            return new string(code);
        }
        public static string GenerateShortUrl(string url)
        {
            string shortCode = string.Empty;
            shortCode = GenerateShortCode();
            string shortUrl = baseUrl + shortCode;
            return shortUrl;
        }
        public static List<Link> GetUrls() => Urls;
        public static Link? GetUrlById(int id) 
            => Urls.FirstOrDefault(u => u.Id == id );
        public static Link? GetUrlByShortCode(string shortCode)
            => Urls.FirstOrDefault(u => u.ShortCode == shortCode);
        public static int AddUrl(string url)
        {
            Link newUrlAddress = new() { Url = url };
            string shortCode = GenerateShortCode();
            newUrlAddress.ShortCode = shortCode;
            Urls.Add(newUrlAddress);
            return newUrlAddress.Id;
        }
        public static void DeleteUrlByUrl(Link url) 
        { 
            Link? deletedUrl = GetUrlById(url.Id);
            if (deletedUrl != null)
            {
                Urls.Remove(deletedUrl);
            }
        }
        public static void UpdateUrl(string shortCode, Link url)
        {
            var index = Urls.FindIndex(u => u.Id == url.Id);
            if (index != -1)
            {
                Urls[index] = url;
            }
        }
    }
}