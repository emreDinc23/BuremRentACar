using Microsoft.AspNetCore.Mvc;
using Rentacarproject.Dto.BrandDtos;
using System.Text;
using System.Text.Json;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Brands");
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var brands = JsonSerializer.Deserialize<List<ResultBrandDto>>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return View(brands);
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(createBrandDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7247/api/Brands", content);
            if (!responseMessage.IsSuccessStatusCode) return View();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7247/api/Brands/" + id);
            if (!responseMessage.IsSuccessStatusCode) return View("Error");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7247/api/Brands/" + id);
            if (!responseMessage.IsSuccessStatusCode) return View();
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonSerializer.Deserialize<UpdateBrandDto>(jsonData, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDto resultBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(resultBrandDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7247/api/Brands", content);
            if (!responseMessage.IsSuccessStatusCode) return View();
            return RedirectToAction("Index");
        }


    }
}
