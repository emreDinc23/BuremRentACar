using MediatR;
using RentacarApplication.Features.Mediator.Results.CarPricingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingQuery:IRequest<List<GetCarPricingQueryResult>>
    {
    }
}
