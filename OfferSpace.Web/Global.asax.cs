﻿using Ninject;
using OfferSpace.BL.Core;
using OfferSpace.DAL.Core;
using OfferSpace.DAL.Interfaces;
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
        }

        private void ConfigureDependencies(StandardKernel ninjectKernel)
        {
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=Y=Try;Integrated Security=True");

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
