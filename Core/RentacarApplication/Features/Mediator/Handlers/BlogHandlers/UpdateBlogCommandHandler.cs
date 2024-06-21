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
    public class UpdateBlogCommandHandler:IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
                
            var value = await _repository.GetByIdAsync(request.BlogID);
            value.AuthorID = request.AuthorID;
            value.CategoryId = request.CategoryId;
            value.CoverImageUrl = request.CoverImageUrl;
            value.CreatedDate = request.CreatedDate;
            value.Description = request.Description;
            value.Title = request.Title;

            await _repository.UpdateAsync(value);
        }
    }
    
    }

