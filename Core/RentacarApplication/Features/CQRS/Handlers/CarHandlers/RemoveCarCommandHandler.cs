using RentacarApplication.Features.CQRS.Commands.BrandCommands;
using RentacarApplication.Features.CQRS.Commands.CarCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(car);
        }
    }
}
