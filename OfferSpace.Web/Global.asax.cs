using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using OfferSpace.App_Data;
using OfferSpace.BL.Core;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Interfaces.Services;
using OfferSpace.BL.Models;
using OfferSpace.BL.Services;
using OfferSpace.DAL.Core;
using OfferSpace.DAL.Repositories;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiContrib.IoC.Ninject;

namespace OfferSpace.Web
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      GlobalConfiguration.Configure(WebApiConfig.Register);
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
      ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(FilePaths.connectionString);
      ninjectKernel.Bind<ICustomerRepository>().To<CustomerRepository>();
      ninjectKernel.Bind<ICompanyRepository>().To<CompanyRepository>();
      ninjectKernel.Bind<ILocationRepository>().To<LocationRepository>();
      ninjectKernel.Bind<ICatalogRepository>().To<CatalogRepository>();
      ninjectKernel.Bind<IRequestService>().To<RequestService>();
      ninjectKernel.Bind<IRequestRepository>().To<RequestRepository>();
      ninjectKernel.Bind<IRequestCustomerRepository>().To<RequestCustomerRepository>();
      ninjectKernel.Bind<IRequestCustomerDiscusionRepository>().To<RequestCustomerDiscusionRepository>();

      GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(ninjectKernel);
    }
  }
}
