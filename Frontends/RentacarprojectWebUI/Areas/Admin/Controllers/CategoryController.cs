using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.CategoryDtos;
using System.Text;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryAddDto)
        {
            var client = _httpClientFactory.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryAddDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7247/api/Categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(categoryAddDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7247/api/Categories?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7247/api/Categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResultCategoryDto>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryUpdateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryUpdateDto), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7247/api/Categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(categoryUpdateDto);
        }
    }
}
