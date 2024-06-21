using Microsoft.AspNetCore.Mvc;

namespace RentacarprojectWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
