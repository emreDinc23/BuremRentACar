﻿using MediatR;
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
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {

            await _repository.CreateAsync(new TagCloud
            {

                Name = request.Name,
                BlogID = request.BlogId
                
               


            });

        }
    }
}
