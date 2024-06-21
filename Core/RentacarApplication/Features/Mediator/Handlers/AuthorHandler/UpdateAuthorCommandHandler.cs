using MediatR;
using RentacarApplication.Features.Mediator.Commands.AuthorCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentacarApplication.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler:IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
                
            var value = await _repository.GetByIdAsync(request.AuthorID);

            value.Name = request.Name;
            value.Description = request.Description;
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
    
    }

