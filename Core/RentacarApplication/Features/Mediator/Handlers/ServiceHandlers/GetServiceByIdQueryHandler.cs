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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {private readonly IRepository<Service> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            return  new GetServiceByIdQueryResult
            {
                ServiceID = value.ServiceID,
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl



            };
        }
    }
}
