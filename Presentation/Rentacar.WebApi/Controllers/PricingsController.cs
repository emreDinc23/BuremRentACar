using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.Mediator.Commands.PricingCommands;
using RentacarApplication.Features.Mediator.Queries.PricingQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing Başarıyla oluşturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var result = await _mediator.Send(new GetPricingQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing Başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Pricing Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var result = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(result);
        }
    }
}
