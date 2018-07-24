using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;

namespace OfferSpace.Web.Models
{
    public class ApplicationUserManager : UserManager<User>
    {
        private static ApplicationUserManager _userManager;

        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static void Destroy(IdentityFactoryOptions<ApplicationUserManager> options, ApplicationUserManager manager)
        {
            //We don't ever want to destroy our singleton - so just ignore
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            if (_userManager == null)
            {
                lock (typeof(ApplicationUserManager))
                {
                    if (_userManager == null)
                        _userManager = CreateManager(options, context);
                }
            }

            return _userManager;
        }
        private static ApplicationUserManager CreateManager(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            OfferSpaceContext db = context.Get<OfferSpaceContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<User>(db));
            //var manager = new ApplicationUserManager(new UserStore<User>(context.Get<OfferSpaceContext>()));
            //var manager = new ApplicationUserManager(new UserStore<User>(new OfferSpaceContext()));
            //manager.UserValidator = new UserValidator<User>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true,

            //};
            manager.EmailService = new App_Start.IdentityConfig.EmailService();
            return manager;
        }
    }

        /*public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                                                IOwinContext context)
        {
            OfferSpaceContext db = context.Get<OfferSpaceContext>();
            //ApplicationUserManager manager = new ApplicationUserManager(new UserStore<User>(db));
            //var manager = new ApplicationUserManager(new UserStore<User>(context.Get<OfferSpaceContext>()));
            //var manager = new ApplicationUserManager(new UserStore<User>(new OfferSpaceContext()));
            //manager.UserValidator = new UserValidator<User>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true,

            //};
            manager.EmailService = new App_Start.IdentityConfig.EmailService();
            return manager;
        }*/
    }
