using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.CarDtos;


namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Cars/GetCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(response.Content.ReadAsStringAsync().Result);
                return View(cars);
            }

            return View();
        }
    }
}
