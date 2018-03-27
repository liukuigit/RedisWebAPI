using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BQ.Core.Components;

using BQ.Core.Autofac;
using BQ.Core.Cache;


namespace BQ.Core.Configurations
{
    public static class ConfigurationExtensions
    {
        /// <summary>Use Autofac as the object container.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseAutofac(this Configuration configuration)
        {
            return UseAutofac(configuration, new ContainerBuilder());
        }
        /// <summary>Use Autofac as the object container.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseAutofac(this Configuration configuration, ContainerBuilder containerBuilder)
        {
            ComponentContainer.SetContainer(new AutofacObjectContainer(containerBuilder));
            return configuration;
        }
        /// <summary>Use Json.Net as the json serializer.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseJsonNet(this Configuration configuration)
        {
            //configuration.SetDefault<IJsonSerializer, NewtonsoftJsonSerializer>(new NewtonsoftJsonSerializer());
            return configuration;
        }
        /// <summary>Use Log4Net as the logger.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseLog4Net(this Configuration configuration)
        {
            return UseLog4Net(configuration, "Config/log4net.config");
        }
        /// <summary>Use Log4Net as the logger.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseLog4Net(this Configuration configuration, string configFile)
        {
            //configuration.SetDefault<ILoggerFactory, Log4NetLoggerFactory>(new Log4NetLoggerFactory(configFile));
            return configuration;
        }
        /// <summary>Use ProtocolBufSerializer as the binary serializer.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseProtoBufSerializer(this Configuration configuration)
        {
            //configuration.SetDefault<IBinarySerializer, ProtocolBufSerializer>(new ProtocolBufSerializer());
            return configuration;
        }

        /// <summary>Use UseUnitOfWork as
        /// </summary>
        /// <returns></returns>
        public static Configuration UseSqlUnitOfWork(this Configuration configuration)
        {
            //configuration.SetDefault<IUnitOfWork_Ething_News, MsSqlUnitOfWork_Ething_News>(null, LifeStyle.Transient);
            //configuration.SetDefault<IUnitOfWork_Ething_Car, MsSqlUnitOfWork_Ething_Car>(null, LifeStyle.Transient);
            //configuration.SetDefault<IUnitOfWork_Ething_Shop, MsSqlUnitOfWork_Ething_Shop>(null, LifeStyle.Transient);
            //configuration.SetDefault<IUnitOfWork_Ething_News_Collection, MsSqlUnitOfWork_Ething_News_Collect>(null, LifeStyle.Transient);
            return configuration;
        }
        
    }
}
