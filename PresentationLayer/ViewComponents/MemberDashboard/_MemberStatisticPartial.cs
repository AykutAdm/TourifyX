using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MemberDashboard
{
    public class _MemberStatisticPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
