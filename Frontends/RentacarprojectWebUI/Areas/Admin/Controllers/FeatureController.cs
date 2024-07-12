using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.FeatureDtos;
using System.Text;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7247/api/features");
            if (!responseMessage.IsSuccessStatusCode) return View();
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            return View(values);

        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7247/api/features", content);
            if (!responseMessage.IsSuccessStatusCode) return View();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7247/api/features/" + id);
            if (!responseMessage.IsSuccessStatusCode) return View();
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultFeatureDto>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ResultFeatureDto resultFeatureDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultFeatureDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7247/api/features", content);
            if (!responseMessage.IsSuccessStatusCode) return View();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7247/api/features/" + id);
            if (!responseMessage.IsSuccessStatusCode) return View();
            return RedirectToAction("Index");
        }

    }
}
