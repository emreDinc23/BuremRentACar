using RentacarApplication.Features.CQRS.Commands.CategoryCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.CategoryHandlers
{
   
        public class RemoveCategoryCommandHandler
        {
            private readonly IRepository<Category> _repository;

            public RemoveCategoryCommandHandler(IRepository<Category> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveCategoryCommand command)
            {
                var car = await _repository.GetByIdAsync(command.Id);
                await _repository.RemoveAsync(car);
            }
        }
    }

