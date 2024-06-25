using MediatR;
using RentacarApplication.Features.Mediator.Results.BlogResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.BlogQueries
{
    public class GetAuthorDetailByBlogQuery:IRequest<GetAuthorDetailByBlogQueryResult>
    {
        public GetAuthorDetailByBlogQuery(int blogID)
        {
            BlogID = blogID;
        }

        public int BlogID { get; set; }

    }
}
