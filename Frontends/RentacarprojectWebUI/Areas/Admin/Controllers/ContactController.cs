using Microsoft.AspNetCore.Mvc;
using Rentacarproject.Dto.ContactDtos;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/contacts");
            if (response.IsSuccessStatusCode)
            {
                var contactList = await response.Content.ReadFromJsonAsync<List<ResultContactDto>>();
                return View(contactList);
            }
            return View();
        }



        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7247/api/Contacts?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }







    }
}
