using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.UseCases.Links.Commands.AddLink;
using ShortLink.Application.UseCases.Links.Queries.GetAll;

namespace ShortLink.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController(ISender sender) : BaseController(sender)
    {
        [HttpGet]
        public async Task<IActionResult> GetAllLinksAsync([FromQuery] GetAllLinksQuery getAllLinksQuery,
            CancellationToken cancellationToken = default)
            => OK(await MediatR.Send(getAllLinksQuery, cancellationToken));
        [HttpPost]
        public async Task<IActionResult> AddLinkAsync([FromBody] AddLinkCommand addLinkCommand,
            CancellationToken cancellationToken = default)
            => OK(await MediatR.Send(addLinkCommand, cancellationToken));
    }
}
