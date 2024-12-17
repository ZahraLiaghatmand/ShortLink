using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Models;
using ShortLink.Services;
using System;

namespace ShortLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
       public BaseController() 
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
        public IActionResult AddUrl(UrlAddress url)
        {
            UrlService.AddUrl(url);
            return CreatedAtAction(nameof(GetByShortCode),new {shortCode = url.ShortCode });
        }

        [HttpPut]
        public ActionResult<UrlAddress> UpdateByShortCode(string shortCode,UrlAddress url)
        {
            UrlService.UpdateUrl(shortCode, url);
            return GetByShortCode(url.ShortCode);
        }

        [HttpDelete]
        public ActionResult<List<UrlAddress>> DeleteByUrl(string shortCode) 
        {
            var ExistingUrl = UrlService.GetUrlByShortCode(shortCode);
            if(ExistingUrl == null)
                return NotFound();
            UrlService.DeleteUrlByUrl(ExistingUrl);
            return GetAll();
        }
    }
}
