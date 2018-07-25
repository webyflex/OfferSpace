using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.Web.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OfferSpace.Web.Controllers
{
    public class UserProfileController : Controller
    {
      // GET: UserProfile
      private ApplicationSignInManager _signInManager;
      private ApplicationUserManager _userManager;
      ICustomerRepository _customerRepository;
      //public UserProfileController() { }
      public UserProfileController(ICustomerRepository customerRepository)
      {
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
        public async Task<ActionResult> Create(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var roles = await UserManager.GetRolesAsync(user.Id);
                userProfile.UserId = user.Id;
                _customerRepository.Create(userProfile);
                _customerRepository.SaveChanges();
                if (roles.Contains("customer"))
                  return RedirectToAction("Index", "Home");
                else if (roles.Contains("owner"))
                  return RedirectToAction("Create", "Company");
            }
            return View(userProfile);
        }
    }
}
