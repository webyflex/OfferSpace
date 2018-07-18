using Ninject;
using Ninject.Web.Mvc;
using OfferSpace.App_Data;
using OfferSpace.BL.Core;
using OfferSpace.BL.Interfaces;
using OfferSpace.DAL.Core;
using OfferSpace.DAL.Repositories;
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
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(FilePaths.connectionString);

            ninjectKernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            ninjectKernel.Bind<IExecutorRepository>().To<ExecutorRepository>();
            ninjectKernel.Bind<ILocationRepository>().To<LocationRepository>();
            ninjectKernel.Bind<ICatalogRepository>().To<CatalogRepository>();
            ninjectKernel.Bind<IRequestRepository>().To<RequestRepository>();
            ninjectKernel.Bind<IRequestCustomerRepository>().To<RequestCustomerRepository>();
            ninjectKernel.Bind<IRequestCustomerDiscusionRepository>().To<RequestCustomerDiscusionRepository>();
        }
    }
}
