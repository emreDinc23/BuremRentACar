using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.LocationDtos;
using System.Text;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Locations");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(result);
                return View(locations);



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
            var response = await client.GetAsync($"https://localhost:7247/api/Locations/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var location = JsonConvert.DeserializeObject<UpdateLocationDto>(result);
                return View(location);
            }
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationDto createLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createLocationDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7247/api/Locations", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createLocationDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateLocationDto updateLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateLocationDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7247/api/Locations", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateLocationDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7247/api/Locations?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
