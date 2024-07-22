using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.PricingDtos;
using System.Text;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Pricings");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultPricingDto>>(content);
                return View(result);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingDto createPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(createPricingDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7247/api/Pricings", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createPricingDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7247/api/Pricings/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdatePricingDto>(content);
                return View(result);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Update(UpdatePricingDto updatePricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(updatePricingDto), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7247/api/Pricings", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updatePricingDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7247/api/Pricings?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
