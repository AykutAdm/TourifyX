using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminAppBrandDemoPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminSideBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminScriptsPartial()
        {
            return PartialView();
        }
    }
}
