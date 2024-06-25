using MediatR;
using RentacarApplication.Features.Mediator.Queries.BlogQueries;
using RentacarApplication.Features.Mediator.Results.BlogResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            return  new GetBlogByIdQueryResult
            {

                BlogID = value.BlogID,
                CreatedDate = value.CreatedDate,                
                Title = value.Title,
                Description = value.Description,
                CoverImageUrl = value.CoverImageUrl,
                AuthorID = value.AuthorID,
                CategoryId = value.CategoryId


            };
        }
    }
}
