using MediatR;
using RentacarApplication.Features.Mediator.Commands.BlogCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {

            await _repository.CreateAsync(new Blog
            {

                Title = request.Title,
                Description = request.Description,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = DateTime.Now,
                AuthorID = request.AuthorID,
                CategoryId = request.CategoryId





            });

        }
    }
}
