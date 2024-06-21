using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.Mediator.Commands.AuthorCommands;
using RentacarApplication.Features.Mediator.Queries.AuthorQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Author Başarıyla oluşturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var result = await _mediator.Send(new GetAuthorQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Author Başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Author Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var result = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(result);
        }
    }
}
