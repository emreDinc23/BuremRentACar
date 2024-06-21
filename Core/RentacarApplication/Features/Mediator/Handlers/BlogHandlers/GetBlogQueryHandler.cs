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
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult
            {
                Title = x.Title,
                Description = x.Description,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                AuthorID = x.AuthorID,
                CategoryId = x.CategoryId,
                BlogID = x.BlogID
                
                




            }).ToList();
        }
    }
}
