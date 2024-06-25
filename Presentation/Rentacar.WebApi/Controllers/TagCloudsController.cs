using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.Mediator.Commands.TagCloudCommands;
using RentacarApplication.Features.Mediator.Queries.TagCloudQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Başarıyla oluşturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var result = await _mediator.Send(new GetTagCloudQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("TagCloud Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudById(int id)
        {
            var result = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(result);
        }
        [HttpGet("GetTagCloudByBlogId")]
        public async Task<IActionResult> GetTagCloudByBlogId(int blogId)
        {
            var result = await _mediator.Send(new GetTagCloudByBlogIdQuery(blogId));
            return Ok(result);
        }
    }
}
