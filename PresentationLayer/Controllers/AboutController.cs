using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            using var c = new Context();
            
            // İstatistikleri ViewBag'e ekle
            ViewBag.destination = c.Destinations.Count();
            ViewBag.guide = c.Guides.Count();
            ViewBag.customer = "285"; // Müşteri sayısı
            ViewBag.experience = "25"; // Yıllık deneyim
            
            var values = _aboutService.TGetList();
            // Status true olan ilk kaydı al (aktif olan)
            var about = values.FirstOrDefault(x => x.Status == true);
            return View(about);
        }
    }
}

