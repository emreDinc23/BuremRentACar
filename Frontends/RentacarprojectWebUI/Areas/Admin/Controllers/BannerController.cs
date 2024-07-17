using Microsoft.AspNetCore.Mvc;
using Rentacarproject.Dto.BannerDtos;
using System.Text;
using System.Text.Json;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Banners");
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var banners = JsonSerializer.Deserialize<List<ResultBannerDto>>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return View(banners);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var stringContent = new StringContent(JsonSerializer.Serialize(createBannerDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7247/api/Banners", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createBannerDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7247/api/Banners/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonSerializer.Deserialize<UpdateBannerDto>(jsonData, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return View(value);
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var stringContent = new StringContent(JsonSerializer.Serialize(updateBannerDto), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7247/api/Banners", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateBannerDto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7247/api/Banners?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
