using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Commands.AuthorCommands
{
    public class RemoveAuthorCommand:IRequest
    {
        public RemoveAuthorCommand(int authorID)
        {
            AuthorID = authorID;
        }

        public int AuthorID { get; set; }
    }
}
