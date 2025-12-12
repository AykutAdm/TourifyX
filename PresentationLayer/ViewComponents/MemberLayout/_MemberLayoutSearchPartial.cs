using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MemberLayout
{
    public class _MemberLayoutSearchPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
