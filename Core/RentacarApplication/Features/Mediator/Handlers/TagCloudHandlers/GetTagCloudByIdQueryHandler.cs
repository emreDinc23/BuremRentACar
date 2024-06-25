using MediatR;
using RentacarApplication.Features.Mediator.Queries.TagCloudQueries;
using RentacarApplication.Features.Mediator.Results.TagCloudResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.TagCloudId);
            return  new GetTagCloudByIdQueryResult
            {
                TagCloudId = value.TagCloudId,

                Name = value.Name,
                BlogID = value.BlogID

                




            };
        }
    }
}
