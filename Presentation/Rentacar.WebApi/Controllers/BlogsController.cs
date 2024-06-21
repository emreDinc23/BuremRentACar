using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.Mediator.Commands.BlogCommands;
using RentacarApplication.Features.Mediator.Queries.BlogQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Başarıyla oluşturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var result = await _mediator.Send(new GetBlogQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetLast3BlogsWithAuthorQueryResult")]
        public async Task<IActionResult> GetLast3BlogsWithAuthorQueryResult()
        {
            var result = await _mediator.Send(new GetLast3BlogsWithAuthorQuery());
            return Ok(result);
        }
    }
}
