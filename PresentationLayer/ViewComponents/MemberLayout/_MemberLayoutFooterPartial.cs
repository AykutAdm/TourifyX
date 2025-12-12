using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MemberLayout
{
    public class _MemberLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
