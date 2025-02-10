using MediatR;
using ShortLink.Application.Common.Interfaces;
using ShortLink.Application.Dtos;
using ShortLink.Domain.Entities;
using ShortLink.Shared.Result;

namespace ShortLink.Application.UseCases.Links.Commands.AddLink
{
    public class AddLinkCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<AddLinkCommand, Result<LinksDto>>
    {
        private readonly IApplicationDbContext _dbContext = dbContext;
        public async Task<Result<LinksDto>> Handle(AddLinkCommand request, CancellationToken cancellationToken = default)
        {
            Link link = new()
            {
                Owner = new() { UserName = "zz" },
                ShortCode = "www",
                Url = request.Url
            };
            var newLink = _dbContext.Links.Add(link);
            Result saveChangesResult = await _dbContext.SaveChangesAsync(cancellationToken);
            return saveChangesResult.IsFailure
                    ? Result.Failure<LinksDto>(Error.Failure("Save changes failed", "Save changes failed"))
                    : Result.Success(new LinksDto { ShortCode = "www", Url = "www.gg.com" });
        }
    }
}