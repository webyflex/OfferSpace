using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using OfferSpace.App_Data;
using OfferSpace.BL.Core;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.DAL.Repositories;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OfferSpace.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var ninjectKernel = new StandardKernel();

            ConfigureDependencies(ninjectKernel);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(ninjectKernel));
        }

        private void ConfigureDependencies(StandardKernel ninjectKernel)
        {
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(@"Data Source=WHO\SQLEXPRESS;AttachDbFilename=|DataDirectory|OfferSpace;Initial Catalog=OfferSpace;Integrated Security=True");
            //ninjectKernel.Bind<IAuthenticationManager>().ToMethod( c => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            ninjectKernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            ninjectKernel.Bind<IUserStore<User>>().To<UserStore<User>>();
            ninjectKernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            ninjectKernel.Bind<ICompanyRepository>().To<CompanyRepository>();
            ninjectKernel.Bind<ILocationRepository>().To<LocationRepository>();
            ninjectKernel.Bind<ICatalogRepository>().To<CatalogRepository>();
            ninjectKernel.Bind<IRequestRepository>().To<RequestRepository>();
            ninjectKernel.Bind<IRequestCustomerRepository>().To<RequestCustomerRepository>();
            ninjectKernel.Bind<IRequestCustomerDiscusionRepository>().To<RequestCustomerDiscusionRepository>();
        }
    }
}
