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
            Location loc = new Location() { Name="Cv"};
            Location loc1 = new Location() { Name = "Lv" };
            Location loc2 = new Location() { Name = "Kyiv" };
            locationRepository.Create(loc);
            locationRepository.Create(loc1);
            locationRepository.Create(loc2);
            locationRepository.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}