using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/MailList")]
    public class MailListController : Controller
    {
        private readonly ISentMailService _sentMailService;

        public MailListController(ISentMailService sentMailService)
        {
            _sentMailService = sentMailService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _sentMailService.TGetList();
            return View(values);
        }

        [Route("MailDetails/{id}")]
        public IActionResult MailDetails(int id)
        {
            var values = _sentMailService.TGetById(id);
            if (values == null)
            {
                return RedirectToAction("Index");
            }
            return View(values);
        }

        [Route("DeleteMail/{id}")]
        public IActionResult DeleteMail(int id)
        {
            var values = _sentMailService.TGetById(id);
            if (values != null)
            {
                _sentMailService.TDelete(values);
            }
            return RedirectToAction("Index");
        }
    }
}

