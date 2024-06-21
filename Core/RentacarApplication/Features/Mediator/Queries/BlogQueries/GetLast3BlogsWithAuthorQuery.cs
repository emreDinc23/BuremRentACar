using MediatR;
using RentacarApplication.Features.Mediator.Results.BlogResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.BlogQueries
{
    public class GetLast3BlogsWithAuthorQuery : IRequest<List<GetLast3BlogsWithAuthorQueryResult>>
    {
    }
}
