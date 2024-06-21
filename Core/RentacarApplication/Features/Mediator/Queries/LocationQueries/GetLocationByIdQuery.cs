using MediatR;
using RentacarApplication.Features.Mediator.Results.LocationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery: IRequest<GetLocationByIdQueryResult>
    {
        public GetLocationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
