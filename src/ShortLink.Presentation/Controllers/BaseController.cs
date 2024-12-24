using Microsoft.AspNetCore.Mvc;
using ShortLink.Domain.Entities;
using ShortLink.Application.Services;

namespace ShortLink.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
       public BaseController() 
        {
        }

        [HttpGet]
        public ActionResult<List<Link>> GetAll() => UrlService.GetUrls();

        [HttpGet("{ShortCode}")]
        public ActionResult<Link> GetByShortCode(string ShortCode)
        {
            var url = UrlService.GetUrlByShortCode(ShortCode);
            if (url == null) { return NotFound(); }
            return url;
        }

        [HttpPost]
        public ActionResult<Link> AddUrl(string url)
        {
            return UrlService.GetUrlById(UrlService.AddUrl(url));
        }

        [HttpPut]
        public ActionResult<Link> UpdateByShortCode(string shortCode,Link url)
        {
            UrlService.UpdateUrl(shortCode, url);
            return GetByShortCode(url.ShortCode);
        }

        [HttpDelete]
        public ActionResult<List<Link>> DeleteByUrl(string shortCode) 
        {
            var ExistingUrl = UrlService.GetUrlByShortCode(shortCode);
            if(ExistingUrl == null)
                return NotFound();
            UrlService.DeleteUrlByUrl(ExistingUrl);
            return GetAll();
        }
    }
}
