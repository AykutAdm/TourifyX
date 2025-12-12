using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MemberLayout
{
    public class _MemberLayoutHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
