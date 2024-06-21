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
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand category)
        {
            var carToUpdate = await _repository.GetByIdAsync(category.CategoryId);
            carToUpdate.Name = category.Name;

            await _repository.UpdateAsync(carToUpdate);
        }
    }
}
