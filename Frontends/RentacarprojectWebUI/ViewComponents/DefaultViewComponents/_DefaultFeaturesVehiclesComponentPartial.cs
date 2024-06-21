using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.CarDtos;

namespace RentacarprojectWebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeaturesVehiclesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultFeaturesVehiclesComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task< IViewComponentResult>InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7247/api/Cars/GetCarLast5");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrand>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
