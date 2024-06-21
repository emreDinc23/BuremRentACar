using Microsoft.AspNetCore.Mvc;

namespace RentacarprojectWebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.deneme = "Hakkımda";
            ViewBag.subTitle = "Hakkımızda";

            return View();
        }
    }
}
