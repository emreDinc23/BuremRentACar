using MediatR;
using RentacarApplication.Features.Mediator.Commands.FeatureCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public CreateTestimonialCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {

           await _repository.CreateAsync(new Feature
           {
               Name = request.Name
           });
        }
    }
}
