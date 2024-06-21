using RentacarApplication.Features.CQRS.Queries.BrandQueries;
using RentacarApplication.Features.CQRS.Queries.CarQueries;
using RentacarApplication.Features.CQRS.Results.BrandResults;
using RentacarApplication.Features.CQRS.Results.CarResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery carId)
        {
            var car = await _repository.GetByIdAsync(carId.Id);
            return new GetCarByIdQueryResult
            {
                BrandID = car.BrandID,
                BigImageUrl = car.BigImageUrl,
                CarID = car.CarID,
                CoverImageUrl = car.CoverImageUrl,
                Fuel = car.Fuel,
                Km = car.Km,
                Luggage = car.Luggage,
                Model = car.Model,
                Seat = car.Seat,
                Transmission    = car.Transmission,
                

            };
        }
    }
}
