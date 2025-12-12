using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.AdminDashboard
{
    public class _AdminGuideListPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
