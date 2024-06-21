using RentacarApplication.Features.CQRS.Queries.BannerQueries;
using RentacarApplication.Features.CQRS.Results.BannerResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var banner = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID = banner.BannerID,
                Title = banner.Title,
                Description = banner.Description,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl
            };
        }
    }
}