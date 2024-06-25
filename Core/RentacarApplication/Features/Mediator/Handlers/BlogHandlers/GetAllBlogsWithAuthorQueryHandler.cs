using MediatR;
using RentacarApplication.Features.Mediator.Queries.BlogQueries;
using RentacarApplication.Features.Mediator.Results.BlogResults;
using RentacarApplication.Interfaces;
using RentacarApplication.Interfaces.BlogInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetAllBlogsWithAuthor();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                Id = x.BlogID,
                Title = x.Title,
                Description = x.Description,
                CreatedAt = x.CreatedDate,
                CoverImageUrl = x.CoverImageUrl,
                AuthorId = x.AuthorID,
                Author = x.Author.Name,
                CategoryId = x.CategoryId,

            }).ToList();
        }
    }
}
