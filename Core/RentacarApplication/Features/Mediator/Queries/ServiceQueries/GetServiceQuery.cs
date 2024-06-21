using MediatR;
using RentacarApplication.Features.Mediator.Results.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery: IRequest<List<GetServiceQueryResult>>
    {
    }
}
