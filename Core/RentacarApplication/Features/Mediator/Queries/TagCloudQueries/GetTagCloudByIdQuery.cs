using MediatR;
using RentacarApplication.Features.Mediator.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery:IRequest<GetTagCloudByIdQueryResult>
    {
        public GetTagCloudByIdQuery(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }

        public int TagCloudId { get; set; }

    }
}
