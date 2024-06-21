using RentacarApplication.Features.CQRS.Queries.AboutQueries;
using RentacarApplication.Features.CQRS.Results.AboutResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var about = await _repository.GetByIdAsync(query.Id);

            return new GetAboutByIdQueryResult
            {
                AboutID = about.AboutID,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };
        }
    }
}