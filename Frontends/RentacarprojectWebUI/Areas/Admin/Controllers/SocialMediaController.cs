using Microsoft.AspNetCore.Mvc;
using Rentacarproject.Dto.SocialMediaDtos;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/SocialMedias");
            if (response.IsSuccessStatusCode)
            {
                var SocialMedias = await response.Content.ReadFromJsonAsync<List<ResultSocialMediaDto>>();
                return View(SocialMedias);
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
            var response = await client.GetAsync($"https://localhost:7247/api/SocialMedias/{id}");
            if (response.IsSuccessStatusCode)
            {
                var SocialMedia = await response.Content.ReadFromJsonAsync<UpdateSocialMediaDto>();
                return View(SocialMedia);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7247/api/SocialMedias", createSocialMediaDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync($"https://localhost:7247/api/SocialMedias/{updateSocialMediaDto.SocialMediaID}", updateSocialMediaDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7247/api/SocialMedias?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
