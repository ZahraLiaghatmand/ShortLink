using MediatR;
using ShortLink.Application.Common.Interfaces;
using ShortLink.Application.Dtos;
using ShortLink.Domain.Entities;
using ShortLink.Shared.Result;

namespace ShortLink.Application.UseCases.Links.Commands.AddLink
{
    public class AddLinkCommandHandler(IApplicationDbContext dbContext,
        IShortCodeGenerator shortCodeGenerator) : IRequestHandler<AddLinkCommand, Result<LinksDto>>
    {
        private readonly IApplicationDbContext _dbContext = dbContext;
        private readonly IShortCodeGenerator _shortCodeGenerator = shortCodeGenerator;
        public async Task<Result<LinksDto>> Handle(AddLinkCommand request, CancellationToken cancellationToken = default)
        {
            string shortCode = _shortCodeGenerator.Generator(request.Url);
            Link link = new()
            {
                Owner = new() { UserName = "Zahra" },
                ShortCode = shortCode,
                Url = request.Url
            };
            var newLink = _dbContext.Links.Add(link);
            Result saveChangesResult = await _dbContext.SaveChangesAsync(cancellationToken);
            return saveChangesResult.IsFailure
                    ? Result.Failure<LinksDto>(Error.Failure("Save changes failed", "Save changes failed"))
                    : Result.Success(new LinksDto { ShortCode = shortCode, Url = request.Url });
        }
    }
}