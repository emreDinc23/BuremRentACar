using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.CQRS.Commands.BannerCommands;
using RentacarApplication.Features.CQRS.Handlers.BannerHandlers;
using RentacarApplication.Features.CQRS.Queries.BannerQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannersQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;

        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoverBannerCommandHandler _removerBannerCommandHandler;

        public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannersQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoverBannerCommandHandler removerBannerCommandHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannersQueryHandler = getBannersQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removerBannerCommandHandler = removerBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var banners = await _getBannersQueryHandler.Handle();
            return Ok(banners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var banner = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(banner);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removerBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner removed");
        }
    }
}