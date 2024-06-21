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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByIdAsync(request.FeatureID).Result;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
