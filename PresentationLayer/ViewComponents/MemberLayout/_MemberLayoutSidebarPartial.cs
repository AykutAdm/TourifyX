using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MemberLayout
{
    public class _MemberLayoutSidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
