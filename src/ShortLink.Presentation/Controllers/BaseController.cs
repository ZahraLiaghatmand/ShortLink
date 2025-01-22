using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Presentation.Extensions;
using ShortLink.Shared.Result;

namespace ShortLink.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController(ISender sender) : Controller
    {
        protected readonly ISender MediatR = sender;
        public IActionResult OK<T>(Result<T> result)
        {
            if (result.Error.Type == ErrorType.None) 
                return Ok(result);

            var problemDetail = result.MapToProblemDetails();
            return Problem(problemDetail.Detail, problemDetail.Instance, problemDetail.Status, problemDetail.Title, problemDetail.Type);
        }
    }
}
