using RentacarApplication.Features.CQRS.Results.CategoryResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryID,
                Name = x.Name
            }).ToList();
        }

    }
}
