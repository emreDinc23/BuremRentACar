using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.Mediator.Commands.LocationCommands;
using RentacarApplication.Features.Mediator.Queries.LocationQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Başarıyla oluşturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var result = await _mediator.Send(new GetLocationQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var result = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(result);
        }
    }
}
