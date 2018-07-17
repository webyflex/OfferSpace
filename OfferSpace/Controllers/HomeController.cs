using OfferSpace.BL.Models;
using OfferSpace.DAL.Context;
using OfferSpace.DAL.Interfaces;
using OfferSpace.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfferSpace.Controllers
{
    public class HomeController : Controller
    {
        ILocationRepository _customerRepository;
        IRequestRepository _executorRepository;

        public HomeController(ILocationRepository repository, IRequestRepository executorRepository)
        {
            _executorRepository = executorRepository;
            _customerRepository = repository;
        }

        public ActionResult Index()
        {
            Location location = _customerRepository.GetById(2);
            _executorRepository.Create(new Request() { ScheduleFrom = DateTime.Now, ScheduleTo = DateTime.Now, Location = location });
            //_customerRepository.MarkAsDeleted(_customerRepository.GetById(2));

            //Customer customer = _customerRepository.GetById(11);
            //customer.Name = "AAA";
            //_customerRepository.Update(customer);

            //Customer customer2 = _customerRepository.GetById(12);
            //_customerRepository.Delete(customer2);

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