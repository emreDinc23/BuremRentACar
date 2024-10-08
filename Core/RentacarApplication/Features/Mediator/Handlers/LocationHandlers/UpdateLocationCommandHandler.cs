﻿using MediatR;
using RentacarApplication.Features.Mediator.Commands.LocationCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler:IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
                
            var value = await _repository.GetByIdAsync(request.LocationId);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
    
    }

