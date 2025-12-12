using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MemberDashboard
{
    public class _PlatformSettingsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
