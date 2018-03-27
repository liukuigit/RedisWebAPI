using System;
using BQ.Core.Components;

namespace BQ.Core.Configurations
{
    public class Configuration
    {
        public static Configuration Instance { get; private set; }

        private Configuration() { }

        public static Configuration Create()
        {
            if (Instance != null)
            {
                throw new Exception("该对象已经实例化！");
            }
            Instance = new Configuration();
            return Instance;
        }

        public Configuration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            ComponentContainer.Register<TService, TImplementer>(serviceName, life);
            return this;
        }
        public Configuration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            ComponentContainer.RegisterInstance<TService, TImplementer>(instance, serviceName);
            return this;
        }

        public Configuration RegisterCommonComponents()
        {
            //SetDefault<ILoggerFactory, EmptyLoggerFactory>();
            //SetDefault<IBinarySerializer, DefaultBinarySerializer>();
            //SetDefault<IJsonSerializer, NotImplementedJsonSerializer>();
            //SetDefault<IUnitOfWork, DefaultUnitOfWork>();
            return this;
        }

        public Configuration RegisterUnhandledExceptionHandler()
        {
            //var logger = ComponentContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
            //AppDomain.CurrentDomain.UnhandledException += (sender, e) => logger.ErrorFormat("Unhandled exception: {0}", e.ExceptionObject);
            return this;
        }
    }
}
