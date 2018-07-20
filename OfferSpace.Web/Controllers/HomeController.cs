using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfferSpace.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ILocationRepository locationRepository;
        public HomeController(ILocationRepository loc)
        {
            locationRepository = loc;
        }
        public ActionResult Index()
        {
            //locationRepository.Create(new Location { Name = "chernivtsi" });
            //locationRepository.Create(new Location { Name = "chernivtsi", ParentId = 1 });
            //locationRepository.Create(new Location { Name = "kyiv" });
            //locationRepository.Create(new Location { Name = "lviv" });
            //locationRepository.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //locationRepository.Create(new Location { Name = "chernivtsi" });
            //locationRepository.Create(new Location { Name = "chernivtsi", ParentId = 1 });
            //locationRepository.Create(new Location { Name = "kyiv" });
            //locationRepository.Create(new Location { Name = "lviv" });
            //locationRepository.SaveChanges();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}