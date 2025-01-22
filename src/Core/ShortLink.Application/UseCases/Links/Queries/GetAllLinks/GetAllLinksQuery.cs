using ShortLink.Application.Dtos;
using MediatR;
using ShortLink.Shared.Result;

namespace ShortLink.Application.UseCases.Links.Queries.GetAll
{
    public record GetAllLinksQuery : IRequest<Result<IEnumerable<LinksDto>>>
    {
    }
}
