namespace RentacarApplication.Features.CQRS.Results.BookRegistrationResults
{
    public class GetBookRegistrationQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public string CarPlate { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentKm { get; set; }
        public int ReturnKm { get; set; }

        public string Description { get; set; }

    }
}
