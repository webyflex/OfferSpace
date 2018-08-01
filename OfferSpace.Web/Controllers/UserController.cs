using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OfferSpace.Web.Controllers
{
    public class UserController : Controller
    {
          private ApplicationSignInManager _signInManager;
          private ApplicationUserManager _userManager;
          ICustomerRepository _customerRepository;
          ICompanyRepository _companyRepository;
          public UserController(ICustomerRepository customerRepository, ICompanyRepository companyRepository)
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

          private IAuthenticationManager AuthenticationManager
          {
            get
            {
              return HttpContext.GetOwinContext().Authentication;
            }
          }
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserProfile()
        {
          return View();
        }  

  }
}

