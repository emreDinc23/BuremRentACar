using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.Mediator.Commands.ServiceCommands;
using RentacarApplication.Features.Mediator.Queries.ServiceQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Başarıyla oluşturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var result = await _mediator.Send(new GetServiceQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Service Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var result = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(result);
        }
    }
}
