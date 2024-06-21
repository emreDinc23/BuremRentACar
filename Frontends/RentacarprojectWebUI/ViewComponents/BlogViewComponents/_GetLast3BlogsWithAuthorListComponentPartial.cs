using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.BlogDtos;

namespace RentacarprojectWebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorListComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _GetLast3BlogsWithAuthorListComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Blogs/GetLast3BlogsWithAuthorQueryResult");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            
            return View();
        }
    }
}
