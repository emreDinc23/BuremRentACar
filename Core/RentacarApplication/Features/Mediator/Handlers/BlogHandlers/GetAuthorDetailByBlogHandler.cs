using MediatR;
using RentacarApplication.Features.Mediator.Queries.BlogQueries;
using RentacarApplication.Features.Mediator.Results.BlogResults;
using RentacarApplication.Interfaces.BlogInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAuthorDetailByBlogHandler : IRequestHandler<GetAuthorDetailByBlogQuery, GetAuthorDetailByBlogQueryResult>
    {
        private readonly IBlogRepository _blogRepository;
        public GetAuthorDetailByBlogHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetAuthorDetailByBlogQueryResult> Handle(GetAuthorDetailByBlogQuery request, CancellationToken cancellationToken)
        {
                var values = _blogRepository.GetAuthorDetailByBlog(request.BlogID);
            var result = new GetAuthorDetailByBlogQueryResult();
            foreach (var item in values)
            {
                result.BlogID = item.BlogID;
                result.AuthorID = item.AuthorID;
                result.AuthorName = item.Author.Name;
                result.AuthorImage = item.Author.ImageUrl;
                result.AuthorDescription = item.Author.Description;
            }
            return result;
           
            

        }
    }
}
