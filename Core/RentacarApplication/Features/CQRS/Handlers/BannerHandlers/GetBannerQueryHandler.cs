using RentacarApplication.Features.CQRS.Results.BannerResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;

namespace RentacarApplication.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var banners = await _repository.GetAllAsync();
            return banners.Select(banner => new GetBannerQueryResult
            {
                BannerID = banner.BannerID,
                Title = banner.Title,
                Description = banner.Description,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl
            }).ToList();
        }
    }
}