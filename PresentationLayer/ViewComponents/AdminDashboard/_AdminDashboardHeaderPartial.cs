using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.AdminDashboard
{
    public class _AdminDashboardHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
