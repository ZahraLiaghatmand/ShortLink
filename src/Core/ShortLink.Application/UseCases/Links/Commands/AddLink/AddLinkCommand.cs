using MediatR;
using ShortLink.Application.Dtos;
using ShortLink.Shared.Result;

namespace ShortLink.Application.UseCases.Links.Commands.AddLink
{
    public record class AddLinkCommand : IRequest<Result<LinksDto>>
    {
        public string Url { get; init; }
    }
}