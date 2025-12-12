using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IGuideService _guideService;

        public DestinationController(IDestinationService destinationService, IGuideService guideService)
        {
            _destinationService = destinationService;
            _guideService = guideService;
        }


        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            List<SelectListItem> guides = (from x in _guideService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.GuideId.ToString()
                                           }).ToList();
            ViewBag.Guides = guides;
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.Status = true;
            destination.Date = DateTime.Now;
            _destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetById(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationService.TGetById(id);
            List<SelectListItem> guides = (from x in _guideService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.GuideId.ToString(),
                                               Selected = x.GuideId == values.GuideId
                                           }).ToList();
            ViewBag.Guides = guides;
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            var existingDestination = _destinationService.TGetById(destination.DestinationId);
            if (existingDestination != null)
            {
                destination.Date = existingDestination.Date;
                destination.Status = true;
                _destinationService.TUpdate(destination);
            }
            return RedirectToAction("Index");
        }
    }
}
