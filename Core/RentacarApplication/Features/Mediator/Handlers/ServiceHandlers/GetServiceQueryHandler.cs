using MediatR;
using RentacarApplication.Features.Mediator.Queries.ServiceQueries;
using RentacarApplication.Features.Mediator.Results.ServiceResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetSocialMediaQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                ServiceID = x.ServiceID,
                Title = x.Title,
                Description = x.Description,
                IconUrl = x.IconUrl


            }).ToList();
        }
    }
}
