using MediatR;
using Microsoft.EntityFrameworkCore;
using ShortLink.Application.Common.Interfaces;
using ShortLink.Application.Dtos;
using ShortLink.Application.UseCases.Links.Queries.GetAll;
using ShortLink.Shared.Result;


namespace ShortLink.Application.UseCases.Links.Queries.GetAllLinks
{
    public class GetAllLinksQueryHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<GetAllLinksQuery, Result<IEnumerable<LinksDto>>>
    {
        private readonly IApplicationDbContext _dbContext = applicationDbContext;

        public async Task<Result<IEnumerable<LinksDto>>> Handle(GetAllLinksQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<LinksDto> result = await _dbContext.links.Select(link => new LinksDto
            {
                Id = link.Id,
                Owner = link.Owner,
                ShortCode = link.ShortCode,
                Url = link.Url
            }).ToListAsync(cancellationToken);
            return Result.Success(result);
        }
    }
}
