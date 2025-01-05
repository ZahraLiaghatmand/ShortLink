using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.UseCases.Links.Queries.GetAll;

using MediatR;
namespace ShortLink.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController(ISender sender) : Controller()
    {
        protected readonly ISender MediatR = sender;

        [HttpGet]
        public async Task<IActionResult> GetAllLinksAsync([FromQuery]GetAllLinksQuery getAllLinksQuery,
            CancellationToken cancellationToken = default) 
            => Ok(await MediatR.Send(getAllLinksQuery, cancellationToken));
    }
}
