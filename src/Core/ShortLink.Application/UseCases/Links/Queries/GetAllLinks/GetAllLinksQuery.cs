using ShortLink.Application.Dtos;
using MediatR;

namespace ShortLink.Application.UseCases.Links.Queries.GetAll
{
    public record GetAllLinksQuery : IRequest<List<LinksDto>>
    {
    }
}
