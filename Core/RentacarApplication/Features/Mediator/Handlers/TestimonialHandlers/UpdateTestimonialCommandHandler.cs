using MediatR;

using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentacarApplication.Features.Mediator.Commands.TestimonialCommands;
using System.Xml.Linq;

namespace RentacarApplication.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByIdAsync(request.TestimonialID).Result;
            values.Name = request.Name;
            values.Comment = request.Comment;
            values.ImageUrl = request.ImageUrl;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
