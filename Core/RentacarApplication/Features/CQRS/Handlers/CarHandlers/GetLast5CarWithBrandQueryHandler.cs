using RentacarApplication.Features.CQRS.Results.CarResults;
using RentacarApplication.Interfaces;
using RentacarApplication.Interfaces.CarInterfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public  List<GetLast5CarsWithBrandQueryResult> Handle()
        {
            var values =  _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandQueryResult
            {
                BrandName= x.Brand.Name,
                CarID = x.CarID,
                BrandID = x.BrandID,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Fuel = x.Fuel,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Transmission = x.Transmission,
                BigImageUrl = x.BigImageUrl


            }).ToList();
        }
    }
}
