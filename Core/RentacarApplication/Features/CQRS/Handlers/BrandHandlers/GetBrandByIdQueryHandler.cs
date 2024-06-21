
using RentacarApplication.Features.CQRS.Queries.BrandQueries;
using RentacarApplication.Features.CQRS.Results.BrandResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery brandID)
        {
           var brand = await _repository.GetByIdAsync(brandID.Id);
            return new GetBrandByIdQueryResult
            {
                BrandID = brand.BrandID,
                Name = brand.Name
            };
        }
    }
}
