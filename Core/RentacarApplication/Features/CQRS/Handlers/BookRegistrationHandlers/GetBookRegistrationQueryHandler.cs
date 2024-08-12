using RentacarApplication.Features.CQRS.Results.BookRegistrationResults;
using RentacarApplication.Interfaces;
using RentacarDomain.Entity;

namespace RentacarApplication.Features.CQRS.Handlers.BookRegistrationHandlers
{
    public class GetBookRegistrationQueryHandler
    {
        private readonly IRepository<BookRegistration> _repository;

        public GetBookRegistrationQueryHandler(IRepository<BookRegistration> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBookRegistrationQueryResult>> Handle()
        {
            var bookRegistrations = await _repository.GetAllAsync();
            return bookRegistrations.Select(x => new GetBookRegistrationQueryResult
            {
                Id = x.Id,
                CarPlate = x.CarPlate,
                Description = x.Description,
                IdentityNumber = x.IdentityNumber,
                Name = x.Name,
                Phone = x.Phone,
                Surname = x.Surname,
                RentKm = x.RentKm,
                ReturnKm = x.ReturnKm,
                RentDate = x.RentDate,
                ReturnDate = x.ReturnDate
            }).ToList();
        }
    }
}
