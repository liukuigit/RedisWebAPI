using Autofac;
using Autofac.Integration.Mvc;
using BQ.Core.Autofac;
using BQ.Core.Components;
using BQ.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BQ_WEBAPI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Initialize();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void Initialize()
        {
            

            //var assembliesService = new[]
            //{
            //    Assembly.Load("BeeCre.EThing.Service")
            //};

            //var assembliesRepository = new[]
            //{
            //    Assembly.Load("BeeCre.EThing.Repository")
            //};

            var assembliesCacheStrategy = new[]{
                Assembly.Load("BQ.CacheStrategy.Redis")
            };

            Configuration
                  .Create()
                  .UseAutofac()
                  .RegisterCommonComponents()
                  .UseLog4Net()
                  .UseSqlUnitOfWork()
                  .RegisterUnhandledExceptionHandler()
                  .CreateKina()
                  .RegisterCacheComponents(assembliesCacheStrategy);
                  //.RegisterServicesComponents(assembliesService)
                  //.RegisterRepositoryComponents(assembliesRepository);

            RegisterControllers();

            //ILogger _logger = ComponentContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
            //_logger.Info("Kina initialized.");
        }

        private void RegisterControllers()
        {
            var webAssembly = Assembly.GetExecutingAssembly();

            var container = (ComponentContainer.Current as AutofacObjectContainer).Container;
            var builder = new ContainerBuilder();
            builder.RegisterControllers(webAssembly).PropertiesAutowired();
            builder.Update(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}