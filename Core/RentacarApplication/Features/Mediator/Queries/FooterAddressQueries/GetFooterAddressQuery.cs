using MediatR;
using RentacarApplication.Features.Mediator.Results.FooterAddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery:IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
