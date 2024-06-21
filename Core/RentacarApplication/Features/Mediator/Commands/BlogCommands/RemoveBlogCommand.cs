using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand:IRequest
    {
        public RemoveBlogCommand(int blogID)
        {
            BlogID = blogID;
        }

        public int BlogID { get; set; }
    }
}
