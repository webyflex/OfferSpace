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
        public ApplicationUserManager(IUserStore<User> store)
                : base(store)
        {
        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                                                IOwinContext context)
        {
            OfferSpaceContext db = context.Get<OfferSpaceContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<User>(db));
            //manager.UserValidator = new UserValidator<User>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true,

            //};
            manager.EmailService = new App_Start.IdentityConfig.EmailService();
            return manager;
        }
    }
}