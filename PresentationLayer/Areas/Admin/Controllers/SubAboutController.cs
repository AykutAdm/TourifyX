using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SubAbout")]
    public class SubAboutController : Controller
    {
        private readonly ISubAboutService _subAboutService;

        public SubAboutController(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _subAboutService.TGetList();
            return View(values);
        }

        [Route("AddSubAbout")]
        [HttpGet]
        public IActionResult AddSubAbout()
        {
            return View();
        }

        [Route("AddSubAbout")]
        [HttpPost]
        public IActionResult AddSubAbout(SubAbout subAbout)
        {
            if (ModelState.IsValid)
            {
                _subAboutService.TAdd(subAbout);
                return RedirectToAction("Index");
            }
            return View(subAbout);
        }

        [Route("EditSubAbout/{id}")]
        [HttpGet]
        public IActionResult EditSubAbout(int id)
        {
            var values = _subAboutService.TGetById(id);
            if (values == null)
            {
                return RedirectToAction("Index");
            }
            return View(values);
        }

        [Route("EditSubAbout/{id}")]
        [HttpPost]
        public IActionResult EditSubAbout(SubAbout subAbout)
        {
            if (ModelState.IsValid)
            {
                _subAboutService.TUpdate(subAbout);
                return RedirectToAction("Index");
            }
            return View(subAbout);
        }

        [Route("DeleteSubAbout/{id}")]
        public IActionResult DeleteSubAbout(int id)
        {
            var values = _subAboutService.TGetById(id);
            if (values != null)
            {
                _subAboutService.TDelete(values);
            }
            return RedirectToAction("Index");
        }
    }
}

