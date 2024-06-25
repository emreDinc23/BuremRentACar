using MediatR;
using RentacarApplication.Features.Mediator.Commands.TagCloudCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler:IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
                
            var value = await _repository.GetByIdAsync(request.TagCloudId);

            value.Name = request.Name;
            value.BlogID = request.BlogId;


            await _repository.UpdateAsync(value);
        }
    }
    
    }

