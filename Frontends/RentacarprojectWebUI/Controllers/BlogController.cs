using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.BlogDtos;
namespace RentacarprojectWebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult >Index()
        {
            ViewBag.deneme = "Blog";
            ViewBag.SubTitle = "Blog Sayfası";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7247/api/Blogs/GetAllBlogsWithAuthorQueryResult");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public async Task< IActionResult >Detail(int id)
        {
            ViewBag.deneme = "Blog";
            ViewBag.SubTitle = "Blog Detay Sayfası";
            ViewBag.blogid = id;

            return View();
        }
    }
}
