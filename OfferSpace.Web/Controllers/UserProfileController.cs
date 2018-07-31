using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Repositories;
using OfferSpace.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OfferSpace.Web.Controllers
{
  public class UserProfileController : Controller
  {
    private ApplicationSignInManager _signInManager;
    private ApplicationUserManager _userManager;
    ICustomerRepository _customerRepository;
    ICompanyRepository _companyRepository;
    public UserProfileController(ICustomerRepository customerRepository, ICompanyRepository companyRepository)
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

    public ActionResult Create()
    {
      return View();
    }


    public ActionResult ChangePassword()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserCompanyRegisterViewModel userProfile)
    {
      if (ModelState.IsValid)
      {
        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        var roles = await UserManager.GetRolesAsync(user.Id);
        _customerRepository.Create(new UserProfile() { UserId = user.Id, FirstName = userProfile.FirstName, LastName = userProfile.LastName, Image = userProfile.UserImage });
        _customerRepository.SaveChanges();
        if (roles.Contains("customer"))
          return RedirectToAction("UserProfile", "User");
        if (roles.Contains("owner"))
        {
          _companyRepository.Create(new Company(){Name = userProfile.CompanyName, Image = userProfile.CompanyImage});
          _companyRepository.SaveChanges();
          return RedirectToAction("Index", "Home");
        }
      }
      return View(userProfile);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
      if (result.Succeeded)
      {
        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        if (user != null)
        {
          await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        }
        return RedirectToAction("UserProfile", "User");
      }

      return View(model);
    }


    public async Task<ActionResult> Edit(string ph)
    {
      var c = await UserManager.FindByIdAsync(User.Identity.GetUserId());
      if (c != null)
      {
        UserProfile a = _customerRepository.FindUserProfileById(c.Id);

        EditProfileModel model = new EditProfileModel
        {
          Email = c.UserName,
          FirstName = a.FirstName,
          LastName = a.LastName,
          Image = a.Image,
          MarkAsDeleted = false
        };
        return View(model);
      }
      return RedirectToAction("Login", "Account");
    }

    [HttpPost]
    public async Task<ActionResult> Edit(EditProfileModel model, HttpPostedFileBase ImageFile)
    {
      var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
      if (user != null)
      {
       
        UserProfile customer =_customerRepository.FindUserProfileById(user.Id);

        var photo = customer.Image;

        if (ImageFile == null)
        {
          customer.Image = photo;
          user.Email = model.Email;
          customer.FirstName = model.FirstName;
          customer.LastName = model.LastName;
          
        }

        else
        {
          string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
          string extension = Path.GetExtension(ImageFile.FileName);
          fileName = user.UserName + extension;
          customer.Image = "~/Images/UserProfile/" + fileName;
          fileName = Path.Combine(Server.MapPath("~/Images/UserProfile/"), fileName);
          ImageFile.SaveAs(fileName);
          user.Email = model.Email;
          customer.FirstName = model.FirstName;
          customer.LastName = model.LastName;
        }


        IdentityResult result = await UserManager.UpdateAsync(user);
        _customerRepository.Update(customer);
        _customerRepository.SaveChanges();

        if (result.Succeeded)
        {
          return RedirectToAction("UserProfile", "User");
        }
        else
        {
          ModelState.AddModelError("", "failed to update user...");
        }
      }
      else
      {
        ModelState.AddModelError("", "The user was not found");
      }

      return View(model);
    }


  }
}
