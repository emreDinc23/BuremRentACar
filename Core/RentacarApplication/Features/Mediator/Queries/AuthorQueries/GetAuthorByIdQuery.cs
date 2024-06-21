using MediatR;
using RentacarApplication.Features.Mediator.Results.AuthorResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery:IRequest<GetAuthorByIdQueryResult>
    {
        public GetAuthorByIdQuery(int authorID)
        {
            AuthorID = authorID;
        }

        public int AuthorID { get; set; }

    }
}
