using Microsoft.AspNetCore.Mvc;
using Rentacarproject.Dto.CategoryDtos;

namespace RentacarprojectWebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSideBarCategoriesComponentPartial: ViewComponent
    {
        private readonly  IHttpClientFactory _httpClientFactory;

        public _BlogDetailSideBarCategoriesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult >InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Categories");
            if(response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
                return View(categories);
            }
            return View();
        }
    }
}
