using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.ViewComponents.AdminDashboard
{
    public class _Card1StatisticPartial : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.destination = context.Destinations.Count();
            ViewBag.users = context.Users.Count();
            return View();
        }
    }
}
