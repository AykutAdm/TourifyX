using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
