using MediatR;
using RentacarApplication.Features.Mediator.Queries.TagCloudQueries;
using RentacarApplication.Features.Mediator.Results.TagCloudResults;
using RentacarApplication.Interfaces.TagCloudInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _tagCloudRepository.GetAllTagCloudById(request.BlogId).Select(x => new GetTagCloudByBlogIdQueryResult
            {
                TagCloudId = x.TagCloudId,
                Name = x.Name,
                BlogID = x.BlogID
            }).ToList();
            return values;
        }
    }
}
