using MediatR;
using RentacarApplication.Features.Mediator.Queries.CarPricingQueries;
using RentacarApplication.Features.Mediator.Results.CarPricingResults;
using Rentacarproject.RentacarApplication.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace RentacarApplication.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            
           var values=_carPricingRepository.GetCarPricingsWithCar().Select(x => new GetCarPricingQueryResult
            {
                CarPricingId = x.CarPricingID,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                Amount = x.Amount,
                CoverImageUrl = x.Car.CoverImageUrl
            }).ToList();
            return Task.FromResult(values);
        }
    }
}
