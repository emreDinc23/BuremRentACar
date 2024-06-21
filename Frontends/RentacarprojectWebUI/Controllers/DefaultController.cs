using Microsoft.AspNetCore.Mvc;

namespace RentacarprojectWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
