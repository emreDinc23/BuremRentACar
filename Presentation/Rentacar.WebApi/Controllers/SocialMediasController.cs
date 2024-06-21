using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.Mediator.Commands.SocialMediaCommands;
using RentacarApplication.Features.Mediator.Queries.SocialMediaQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("SocialMedia Başarıyla oluşturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var result = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("SocialMedia Başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("SocialMedia Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var result = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(result);
        }
    }
}
