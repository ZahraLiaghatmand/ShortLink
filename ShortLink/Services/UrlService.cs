using ShortLink.Models;

namespace ShortLink.Services
{
    public class UrlService
    {
        static List<UrlAddress> Urls { get; }
        static UrlService() 
        {
            Urls = new List<UrlAddress>();
        }
        public static List<UrlAddress> GetUrls() => Urls;
        public static UrlAddress? GetUrlById(int id) 
            => Urls.FirstOrDefault(u => u.Id == id );
        public static UrlAddress? GetUrlByShortCode(string shortCode)
            => Urls.FirstOrDefault(u => u.ShortCode == shortCode);
        public static void AddUrl(UrlAddress url) => Urls.Add(url);
        public static void deleteUrlByUrl(int id) 
        { 
            UrlAddress? urlD = GetUrlById(id);
            if (urlD != null)
            {
                Urls.Remove(urlD);
            }
        }
        public static void updateUrl(UrlAddress url)
        {
            UrlAddress? urlU = GetUrlById(url.Id);
            if (urlU != null)
            {
                urlU = url;
            }
        }
    }
}