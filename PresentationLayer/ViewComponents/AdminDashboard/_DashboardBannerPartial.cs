using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.AdminDashboard
{
    public class _DashboardBannerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
