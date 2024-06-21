using MediatR;
using RentacarApplication.Features.Mediator.Commands.ServiceCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateSocialMediaCommandHandler:IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
                
            var value = await _repository.GetByIdAsync(request.ServiceID);

            value.Title = request.Title;
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(value);
        }
    }
    
    }

