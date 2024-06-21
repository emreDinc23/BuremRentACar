using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.CQRS.Commands.ContactCommands;
using RentacarApplication.Features.CQRS.Handlers.ContactHandlers;
using RentacarApplication.Features.CQRS.Queries.ContactQueries;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactsQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;

        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removerContactCommandHandler;

        public ContactsController(GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactsQueryHandler, CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removerContactCommandHandler)
        {
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactsQueryHandler = getContactsQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removerContactCommandHandler = removerContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var banners = await _getContactsQueryHandler.Handle();
            return Ok(banners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var banner = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(banner);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removerContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact removed");
        }
    }
}