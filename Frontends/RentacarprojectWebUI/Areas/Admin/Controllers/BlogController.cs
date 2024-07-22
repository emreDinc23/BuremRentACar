using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.BlogDtos;
using Rentacarproject.Dto.CommentsDto;
using System.Text;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Blogs/GetAllBlogsWithAuthorQueryResult");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorDto>>(data);
                return View(blogs);
            }
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }



        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Blogs/" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var blog = JsonConvert.DeserializeObject<UpdateBlogDto>(data);
                return View(blog);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBlogDto updateBlogDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7247/api/Blogs", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7247/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Comments(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7247/api/Comments/GetBlogCommentsByBlogId/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(data))
                {
                    return View(new List<ResultCommentDto>());
                }
                var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(data);
                return View(comments);
            }
            return View(new List<ResultCommentDto>());
        }

    }
}
