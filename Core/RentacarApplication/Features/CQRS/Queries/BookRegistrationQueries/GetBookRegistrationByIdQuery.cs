namespace RentacarApplication.Features.CQRS.Queries.BookRegistrationQueries
{
    public class GetBookRegistrationByIdQuery
    {
        public int Id { get; set; }
        public GetBookRegistrationByIdQuery(int bookRegistrationID)
        {
            Id = bookRegistrationID;
        }
    }
}
