﻿using MediatR;

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
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {

            var value = await _repository.GetByIdAsync(request.TestimonialID);
            await _repository.RemoveAsync(value);
        }
    }
}
