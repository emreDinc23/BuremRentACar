using MediatR;

using RentacarApplication.Features.Mediator.Queries.PricingQueries;

using RentacarApplication.Features.Mediator.Results.PricingResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value=_repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                PricingID = value.Result.PricingID,
                Name = value.Result.Name,
            };
        }
    }
}
