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
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public  List<GetCarWithBrandQueryResult> Handle()
        {
            var values =  _repository.GerCarsListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
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
