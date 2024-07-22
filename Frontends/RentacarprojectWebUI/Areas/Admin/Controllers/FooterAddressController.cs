using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentacarproject.Dto.ContactDtos;
using Rentacarproject.Dto.FooterAddressDtos;
using System.Text;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterAddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterAddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {


            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7247/api/FooterAddresses");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var footerAddressList = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(result);
                return View(footerAddressList);
            }
            else
            {
                // Hata durumunda uygun bir işlem yapabilirsiniz, örneğin bir hata sayfasına yönlendirme veya hata mesajı gösterme
                ModelState.AddModelError(string.Empty, "Footer addresses could not be retrieved.");
            }

            // Eğer bir hata oluşursa veya istek başarısız olursa, boş bir liste dönebiliriz
            return View(new List<ResultFooterAddressDto>());
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7247/api/FooterAddresses/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var footerAddress = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(result);
                return View(footerAddress);
            }
            else
            {
                // Hata durumunda uygun bir işlem yapabilirsiniz, örneğin bir hata sayfasına yönlendirme veya hata mesajı gösterme
                ModelState.AddModelError(string.Empty, "Footer address could not be retrieved.");
            }
            return View(new UpdateFooterAddressDto());

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFooterAddressDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7247/api/FooterAddresses", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumunda uygun bir işlem yapabilirsiniz, örneğin bir hata sayfasına yönlendirme veya hata mesajı gösterme
                ModelState.AddModelError(string.Empty, "Footer address could not be updated.");
            }
            return View(model);
        }

    }
}
