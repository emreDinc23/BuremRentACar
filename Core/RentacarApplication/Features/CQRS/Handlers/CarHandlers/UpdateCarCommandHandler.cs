using RentacarApplication.Features.CQRS.Commands.BrandCommands;
using RentacarApplication.Features.CQRS.Commands.CarCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand car)
        {
            var carToUpdate = await _repository.GetByIdAsync(car.CarID);
            carToUpdate.BigImageUrl = car.BigImageUrl;
            carToUpdate.CoverImageUrl = car.CoverImageUrl;
            carToUpdate.Fuel = car.Fuel;
            carToUpdate.Km = car.Km;
            carToUpdate.Luggage = car.Luggage;
            carToUpdate.Model = car.Model;
            carToUpdate.Seat = car.Seat;
            carToUpdate.Transmission = car.Transmission;
            carToUpdate.BrandID = car.BrandID;

            await _repository.UpdateAsync(carToUpdate);
        }
    }
}
