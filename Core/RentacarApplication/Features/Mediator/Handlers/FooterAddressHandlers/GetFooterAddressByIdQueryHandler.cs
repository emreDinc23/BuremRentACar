using MediatR;
using RentacarApplication.Features.Mediator.Queries.FooterAddressQueries;
using RentacarApplication.Features.Mediator.Results.FooterAddressResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {

            var footerAddress = await _repository.GetByIdAsync(request.Id);

            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID = footerAddress.FooterAddressID,
                Address = footerAddress.Address,
                Description = footerAddress.Description,
                Phone = footerAddress.Phone,
                Email = footerAddress.Email
            };
        }
    }
}
