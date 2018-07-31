using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using OfferSpace.Web.Models;
using OfferSpace.BL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OfferSpace.BL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Text;

namespace OfferSpace.Web.Controllers
{
  public class AccountController : Controller
  {
    private ApplicationSignInManager _signInManager;
    private ApplicationUserManager _userManager;
    ICustomerRepository _customerRepository;

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

    //public AccountController() { }
    /*public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
    {
        UserManager = userManager;
        SignInManager = signInManager;
    }*/
    public AccountController(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }


    public ActionResult RegisterCustomer()
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> RegisterCustomer(RegisterModel model)
    {
      if (ModelState.IsValid)
      {
        var user = new User() { Email = model.Email, UserName = model.Email/*, UserProfile = new UserProfile()*/};
        IdentityResult result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          await UserManager.AddToRoleAsync(user.Id, "customer");
          var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("OfferSpace.Web");
          UserManager.UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create("EmailConfirmation"));
          var token = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

          var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = token },
              protocol: Request.Url.Scheme);

          await UserManager.SendEmailAsync(user.Id, "Подтверждение электронной почты",
              "Для завершения регистрации перейдите по ссылке:: <a href=\""
              + callbackUrl + "\">завершить регистрацию</a>");

          return View("DisplayEmail");
        }
        AddErrors(result);
      }
      return View(model);
    }
    public ActionResult RegisterCompany()
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> RegisterCompany(RegisterModel model)
    {
      if (ModelState.IsValid)
      {
        var user = new User() { Email = model.Email, UserName = model.Email };
        IdentityResult result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          await UserManager.AddToRoleAsync(user.Id, "owner");
          var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("OfferSpace.Web");
          UserManager.UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create("EmailConfirmation"));
          var token = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

          var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = token },
              protocol: Request.Url.Scheme);

          await UserManager.SendEmailAsync(user.Id, "Подтверждение электронной почты",
              "Для завершения регистрации перейдите по ссылке:: <a href=\""
              + callbackUrl + "\">завершить регистрацию</a>");

          return View("DisplayEmail");
        }
        AddErrors(result);
      }
      return View(model);
    }

    [AllowAnonymous]
    public async Task<ActionResult> ConfirmEmail(string userId, string code)
    {
      if (userId == null || code == null)
      {
        return View("Error");
      }
      //var emailConfirmationCode = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
      //var res = UserManager.ConfirmEmailAsync(userId, emailConfirmationCode);
      var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("OfferSpace.Web");
      UserManager.UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create("EmailConfirmation"));
      var result = await UserManager.ConfirmEmailAsync(userId, code);
      return View(result.Succeeded ? "ConfirmEmail" : "Error");
    }

    public ActionResult Login(string returnUrl)
    {
      ViewBag.returnUrl = returnUrl;
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(CompanyLoginModel model, string returnUrlSite)
    {
      string returnUrl = "/Home/Index";
      if (returnUrlSite != null)
      {
        returnUrl = returnUrlSite;
      }

      var user = await UserManager.FindAsync(model.Email, model.Password);
      if (user != null)
      {
        if (user.EmailConfirmed == true)
        {
          await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
          var customer = _customerRepository.GetAll().FirstOrDefault(custUser => custUser.UserId == user.Id);
          if (customer == null)
          {
            return RedirectToAction("Create", "UserProfile");
          }
          //await Token(model);
          return Redirect(returnUrl);
        }
        else
        {
          ModelState.AddModelError("", "Не подтвержден email.");
        }
      }
      else
      {
        ModelState.AddModelError("", "Неверный логин или пароль");
      }
      return View(model);
    }

    //[HttpPost]
    public /*async Task*/string Token(/*CompanyLoginModel loginViewModel*/)
    {
      //ClaimsIdentity identity = GetIdentity(loginViewModel.Email, loginViewModel.Password);
      ClaimsIdentity identity = GetIdentity(UserManager.FindById(User.Identity.GetUserId()));
      if (identity == null)
      {
        //Response.StatusCode = 400;
        //Response.Write("Invalid username or password.");
        return "invalid";
        //return;
      }

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(CreateToken(identity));

      var response = new
      {
        access_token = encodedJwt,
        //expires = AuthOptions.LIFETIME,
        //status = StatusCode(200).StatusCode
      };

      //Response.ContentType = "application/json";
      //Response.Write(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
      string token = response.access_token;
      return token;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Logout()
    {
      AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
      return RedirectToAction("Index","Home");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_userManager != null)
        {
          _userManager.Dispose();
          _userManager = null;
        }

        if (_signInManager != null)
        {
          _signInManager.Dispose();
          _signInManager = null;
        }
      }

      base.Dispose(disposing);
    }

    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError("", error);
      }
    }



    public ClaimsIdentity GetIdentity(/*string email, string password*/User user)
    {
      //var user = UserManager.FindAsync(email, password);

      if (user != null)
      {
        var claims = new List<Claim>
        {
        };

        ClaimsIdentity claimsIdentity =
        new ClaimsIdentity(
            claims: claims,
            authenticationType: "Token",
            nameType: ClaimsIdentity.DefaultNameClaimType,
            roleType: ClaimsIdentity.DefaultRoleClaimType
            );

        return claimsIdentity;
      }
      return null;
    }
    public JwtSecurityToken CreateToken(ClaimsIdentity identity)
    {
      var now = DateTime.Now;
      JwtSecurityToken jwt = new JwtSecurityToken(
              issuer: AuthOptions.ISSUER,
              audience: AuthOptions.AUDIENCE,
              notBefore: now,
              claims: identity.Claims,
              expires: now.Add(TimeSpan.FromSeconds(AuthOptions.LIFETIME)),
              signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
              SecurityAlgorithms.HmacSha256));
      return jwt;
    }

    public class AuthOptions
    {
      public const string ISSUER = "MyAuthServer";
      public const string AUDIENCE = "http://localhost:49971/";
      const string KEY = "scrummakerscrummakerscrummaker";
      public const int LIFETIME = 1800;
      public static SymmetricSecurityKey GetSymmetricSecurityKey()
      {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
      }
    }
  }
}
