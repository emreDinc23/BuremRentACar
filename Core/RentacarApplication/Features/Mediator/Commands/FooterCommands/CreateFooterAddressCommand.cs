using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Commands.FooterCommands
{
    public class CreateFooterAddressCommand: IRequest
    {
      
        public string Address { get; set; }
        public string Description { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
