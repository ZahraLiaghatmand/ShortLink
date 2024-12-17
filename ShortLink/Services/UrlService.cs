using ShortLink.Models;

namespace ShortLink.Services
{
    public class UrlService
    {
        static List<UrlAddress> Urls { get; }
        static List<User> Users { get; }
        static UrlService()
        {
            Users = new List<User> {
                new User { Id = 1, UserName = "Zahra" }
            };
            Urls = new List<UrlAddress>
            {
                new UrlAddress { Id = 1, ShortCode = "zz",
                    Url = "www.google.com", Owner = Users[0]
                },
                new UrlAddress { Id = 2, ShortCode = "gg",
                    Url = "www.bankgisoo.ir", Owner = Users[0]
                },
                
            };
        }
        public static List<UrlAddress> GetUrls() => Urls;
        public static UrlAddress? GetUrlById(int id) 
            => Urls.FirstOrDefault(u => u.Id == id );
        public static UrlAddress? GetUrlByShortCode(string shortCode)
            => Urls.FirstOrDefault(u => u.ShortCode == shortCode);
        public static void AddUrl(UrlAddress url) => Urls.Add(url);
        public static void DeleteUrlByUrl(UrlAddress url) 
        { 
            UrlAddress? deletedUrl = GetUrlById(url.Id);
            if (deletedUrl != null)
            {
                Urls.Remove(deletedUrl);
            }
        }
        public static void UpdateUrl(string shortCode, UrlAddress url)
        {
            var index = Urls.FindIndex(u => u.Id == url.Id);
            if (index != -1)
            {
                Urls[index] = url;
            }
        }
    }
}