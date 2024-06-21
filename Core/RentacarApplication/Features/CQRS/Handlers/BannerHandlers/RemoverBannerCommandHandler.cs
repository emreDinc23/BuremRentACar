using RentacarApplication.Features.CQRS.Commands.BannerCommands;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoverBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoverBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var banner = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(banner);
        }
    }
}