using Microsoft.AspNetCore.Mvc;

namespace RentacarprojectWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
