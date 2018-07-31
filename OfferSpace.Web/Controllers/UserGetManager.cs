using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace OfferSpace.Web.Controllers
{
  public class UserGetManager : Controller
  {
    private ApplicationSignInManager _signInManager;
    private ApplicationUserManager _userManager;
    ICustomerRepository _customerRepository;
    IRequestRepository _requestRepository;


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
    public UserGetManager(ICustomerRepository customerRepository, IRequestRepository requestRepository)
    {
      _customerRepository = customerRepository;
      _requestRepository = requestRepository;
    }


    public async Task<List<Request>> GetRequestsAsync()
    {
      var user =  await UserManager.FindByIdAsync(User.Identity.GetUserId());
      var customer = _customerRepository.GetAll().FirstOrDefault(userCust => userCust.UserId == user.Id);
      var requests = _requestRepository.GetAll().Where(custId => custId.CustomerId == customer.Id).ToList();
      return requests;
    }
    public async Task<UserProfile> GetUserProfileAsync()
    {
      var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
      var customer = _customerRepository.GetAll().FirstOrDefault(userCust => userCust.UserId == user.Id);
      return customer;
    }
  }
}
