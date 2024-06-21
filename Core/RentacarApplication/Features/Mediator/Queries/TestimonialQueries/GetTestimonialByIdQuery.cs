using MediatR;
using RentacarApplication.Features.Mediator.Results.TestimonialResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery: IRequest<GetTestimonialByIdQueryResult>
    {
        public int TestimonialID { get; set; }

        public GetTestimonialByIdQuery(int testimonialID)
        {
            TestimonialID = testimonialID;
        }
    }
}
