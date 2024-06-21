using MediatR;
using RentacarApplication.Features.Mediator.Commands.FooterCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {

            var footerAddress = new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                Phone = request.Phone,
                Email = request.Email
            };

            await _repository.CreateAsync(footerAddress);

            

        }
    }
}
