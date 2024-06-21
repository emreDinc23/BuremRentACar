﻿using MediatR;
using RentacarApplication.Features.Mediator.Commands.PricingCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
         
            var value = await _repository.GetByIdAsync(request.PricingID);

            value.Name = request.Name;
            await _repository.UpdateAsync(value);



        }
    }
}
