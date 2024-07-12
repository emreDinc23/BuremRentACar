using Microsoft.AspNetCore.Mvc;
using Rentacarproject.Dto.BannerDtos;
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
    }
}
