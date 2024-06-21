using RentacarApplication.Features.CQRS.Commands.BrandCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand brand)
        {
            var brandToUpdate = await _repository.GetByIdAsync(brand.BrandID);
            brandToUpdate.Name = brand.Name;
            await _repository.UpdateAsync(brandToUpdate);
        }
    }
}
