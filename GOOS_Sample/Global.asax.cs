using Autofac;
using Autofac.Integration.Mvc;
using GOOS_Sample.Controllers;
using GOOS_Sample.Interface;
using GOOS_Sample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GOOS_Sample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(BudgetController).Assembly);
            builder.RegisterType<BudgetService>().As<IBudgetService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
