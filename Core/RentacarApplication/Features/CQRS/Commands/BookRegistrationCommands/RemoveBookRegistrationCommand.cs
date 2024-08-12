namespace RentacarApplication.Features.CQRS.Commands.BookRegistrationCommands
{
    public class RemoveBookRegistrationCommand
    {
        public int Id { get; set; }

        public RemoveBookRegistrationCommand(int bookRegistrationID)
        {
            Id = bookRegistrationID;
        }
    }
}
