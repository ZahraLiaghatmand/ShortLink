using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.UseCases.Links.Queries.GetAll;

using MediatR;
namespace ShortLink.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController(ISender sender) : BaseController(sender)
    {
        [HttpGet]
        public async Task<IActionResult> GetAllLinksAsync([FromQuery]GetAllLinksQuery getAllLinksQuery,
            CancellationToken cancellationToken = default) 
            => OK(await MediatR.Send(getAllLinksQuery, cancellationToken));
    }
}
