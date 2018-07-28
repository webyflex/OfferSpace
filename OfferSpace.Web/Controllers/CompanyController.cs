using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OfferSpace.Web.Controllers
{
    public class CompanyController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ICompanyRepository _companyRepository;
        ICustomerRepository _customerRepository;
        public CompanyController(ICompanyRepository companyRepository, ICustomerRepository customerRepository)
        {
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var customer = _customerRepository.GetAll().FirstOrDefault(userCust => userCust.UserId == user.Id);
                //_companyRepository.Create(company);
                customer.Company = company;
                _customerRepository.Update(customer);
                //_companyRepository.SaveChanges();
                _customerRepository.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(company);
        }
    }
}
