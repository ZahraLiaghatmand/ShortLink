using Microsoft.AspNetCore.Mvc;
using ShortLink.Domain.Entities;
using ShortLink.src.Services;

namespace ShortLink.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : Controller
    {
        public LinkController()
        {
        }

        [HttpGet]
        public ActionResult<List<UrlAddress>> GetAll() => UrlService.GetUrls();

        [HttpGet("{ShortCode}")]
        public ActionResult<UrlAddress> GetByShortCode(string ShortCode)
        {
            var url = UrlService.GetUrlByShortCode(ShortCode);
            if (url == null) { return NotFound(); }
            return url;
        }

        [HttpPost]
        public ActionResult<UrlAddress> AddUrl(string url)
        {
            return UrlService.GetUrlById(UrlService.AddUrl(url));
        }

        [HttpPut]
        public ActionResult<UrlAddress> UpdateByShortCode(string shortCode, UrlAddress url)
        {
            UrlService.UpdateUrl(shortCode, url);
            return GetByShortCode(url.ShortCode);
        }

        [HttpDelete]
        public ActionResult<List<UrlAddress>> DeleteByUrl(string shortCode)
        {
            var ExistingUrl = UrlService.GetUrlByShortCode(shortCode);
            if (ExistingUrl == null)
                return NotFound();
            UrlService.DeleteUrlByUrl(ExistingUrl);
            return GetAll();
        }
    }
}
