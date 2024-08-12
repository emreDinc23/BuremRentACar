using Microsoft.AspNetCore.Mvc;
using Rentacarproject.Dto.ServiceDtos;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/services");
            if (response.IsSuccessStatusCode)
            {
                var services = await response.Content.ReadFromJsonAsync<List<ResultServiceDto>>();
                return View(services);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7247/api/services/{id}");
            if (response.IsSuccessStatusCode)
            {
                var service = await response.Content.ReadFromJsonAsync<UpdateServiceDto>();
                return View(service);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7247/api/services", createServiceDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync($"https://localhost:7247/api/services/{updateServiceDto.ServiceId}", updateServiceDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7247/api/services?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
