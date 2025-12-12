using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.AdminDashboard
{
    public class _TotalRevenuePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
