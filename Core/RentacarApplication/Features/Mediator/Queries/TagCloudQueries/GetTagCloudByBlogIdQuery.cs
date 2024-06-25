using MediatR;
using RentacarApplication.Features.Mediator.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery:IRequest<List<GetTagCloudByBlogIdQueryResult>>

    {
        public GetTagCloudByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }

        public int BlogId { get; set; }
    }
}
