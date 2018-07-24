﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Security.Claims;
using OfferSpace.Web.Models;
using Microsoft.Owin.Host.SystemWeb;
using OfferSpace.BL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OfferSpace.BL.Interfaces;
using System.Net;

namespace OfferSpace.Web.Controllers
{
    public class AccountController : BaseController
    {
        ICustomerRepository customerRepository;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        //public AccountController() { }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ICustomerRepository cust)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            customerRepository = cust;
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegistertrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User() {Email = model.Email,UserName=model.Email};
                var userProfile = new UserProfile() { User=user,MarkAsDeleted=false};
                customerRepository.Create(userProfile);
                customerRepository.SaveChanges();
                //user.CustomerId = userProfile.Id;
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "customer");
                    var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("OfferSpace.Web");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create("EmailConfirmation"));
                    var token = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // генерируем токен для подтверждения регистрации
                    // создаем ссылку для подтверждения
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = token },
                               protocol: Request.Url.Scheme);
                    // отправка письма
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
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            
                //var user = executorRepository.GetAll().FirstOrDefault(name => name.Email == model.Email);
                var user = await UserManager.FindAsync(model.Email, model.Password);
                if (user != null)
                {
                    if (user.EmailConfirmed == true)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
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
        
        /*public string GetEmailOrUserName(LoginModel model)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user=db.Users.FirstOrDefault(x=>model.)
            }
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

        

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}