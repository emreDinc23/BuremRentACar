using MediatR;

using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentacarApplication.Features.Mediator.Commands.TestimonialCommands;

namespace RentacarApplication.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {

           await _repository.CreateAsync(new Testimonial
           {

               Name = request.Name,
               Comment = request.Comment,
               ImageUrl = request.ImageUrl,
               Title = request.Title,


           });
        }
    }
}
