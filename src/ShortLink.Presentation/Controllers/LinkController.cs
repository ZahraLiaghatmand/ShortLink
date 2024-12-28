using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.Common.Interfaces;
using ShortLink.Domain.Entities;

namespace ShortLink.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : Controller
    {
        private ILinkServices _linkService;
        public LinkController(ILinkServices linkService) => _linkService = linkService;

        [HttpGet]
        public IEnumerable<Link> GetAllLinks() 
        {
            return _linkService.GetAll();
        }
    }
}
