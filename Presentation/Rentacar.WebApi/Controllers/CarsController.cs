using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.CQRS.Commands.CarCommands;
using RentacarApplication.Features.CQRS.Handlers.CarHandlers;
using RentacarApplication.Features.CQRS.Queries.CarQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarsQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removerCarCommandHandler;
        private readonly GetLast5CarWithBrandQueryHandler _getLast5CarWithBrandQueryHandler;



        public CarsController(GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler,GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarsQueryHandler, CreateCarCommandHandler createCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removerCarCommandHandler)
        {
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarsQueryHandler = getCarsQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removerCarCommandHandler = removerCarCommandHandler;
            _getLast5CarWithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
        }

        

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var banners = await _getCarsQueryHandler.Handle();
            return Ok(banners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var banner = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(banner);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Car created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removerCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car removed");
        }
        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var values =  _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("GetCarLast5")]
        public IActionResult GetCarLast5()
        {
            var values = _getLast5CarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}