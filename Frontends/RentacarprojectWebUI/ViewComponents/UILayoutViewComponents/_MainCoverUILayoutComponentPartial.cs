using Microsoft.AspNetCore.Mvc;

namespace RentacarprojectWebUI.ViewComponents.UILayoutViewComponents
{
    public class _MainCoverUILayoutComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
