using MediatR;

using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentacarApplication.Features.Mediator.Results.TestimonialResults;
using RentacarApplication.Features.Mediator.Queries.TestimonialQueries;

namespace RentacarApplication.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
           var values = await _repository.GetByIdAsync(request.TestimonialID);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = values.TestimonialID,
               Comment = values.Comment,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                Title = values.Title

            };
        }
    }
}
