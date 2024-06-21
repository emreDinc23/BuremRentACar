using MediatR;
using RentacarApplication.Features.Mediator.Queries.SocialMediaQueries;
using RentacarApplication.Features.Mediator.Results.SocialMediaResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.SocialMediaID);
            return  new GetSocialMediaByIdQueryResult
            {
                SocialMediaID = value.SocialMediaID,

                Name = value.Name,
                Url = value.Url,
                Icon = value.Icon




            };
        }
    }
}
