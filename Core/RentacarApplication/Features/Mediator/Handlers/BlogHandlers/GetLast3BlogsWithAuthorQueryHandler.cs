using MediatR;
using RentacarApplication.Features.Mediator.Queries.BlogQueries;
using RentacarApplication.Features.Mediator.Results.BlogResults;
using RentacarApplication.Interfaces;
using RentacarApplication.Interfaces.BlogInterfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
    {private readonly IBlogRepository _repository;

        public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {

            var values = _repository.GetLast3BlogsWithAuthor();
            return values.Select(x => new GetLast3BlogsWithAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                CategoryId = x.CategoryId,
                BlogID = x.BlogID,
                Title = x.Title,
                Description = x.Description,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                AuthorName=x.Author.Name,
                

                
            }).ToList();
        }
    }
}
