using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.TestimonialDtos;

namespace RentacarprojectWebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult >InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/Testimonials");
            if(response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<TestimonialDto>>(jsonData);
                return View(values);
            }
            
            return View();
        }
    }
}
