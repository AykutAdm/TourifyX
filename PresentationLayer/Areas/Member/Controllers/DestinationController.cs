using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        public IActionResult GetCitiesSearchByName(string searchstring)
        {
            ViewData["CurrentFilter"] = searchstring;
            var values = from x in destinationManager.TGetList() select x;
            if (!string.IsNullOrEmpty(searchstring))
            {
                values = values.Where(y => y.City.Contains(searchstring));
            }
            return View(values.ToList());
        }
    }
}
