using BQ.Core.Components;
using BQ.Core.Utilities;
using System;
using System.Linq;
using System.Reflection;


namespace BQ.Core.Configurations
{
    public class KinaConfiguration
    {

        public static KinaConfiguration Instance { get; private set; }

        private KinaConfiguration()
        {
        }

        public static KinaConfiguration CreateKina()
        {
            if (Instance != null)
            {
                throw new Exception("该对象已经实例化！");
            }
            Instance = new KinaConfiguration();
            return Instance;
        }

        // 注册服务组件
        public KinaConfiguration RegisterServicesComponents(params Assembly[] assemblies)
        {
            //foreach (var assembly in assemblies)
            //{
            //    foreach (var type in assembly.GetTypes().Where(TypeUtils.IsComponent).Where(TypeUtils.IsServiceComponent))
            //    {
            //        var life = ParseLife(type);
            //        ComponentContainer.RegisterType(type, null, life);
            //        foreach (var interfaceType in type.GetInterfaces())
            //        {
            //            ComponentContainer.RegisterType(interfaceType, type, null, life);
            //        }
            //    }
            //}
            return this;
        }

        // 注册仓储组件
        public KinaConfiguration RegisterRepositoryComponents(params Assembly[] assemblies)
        {
            //foreach (var assembly in assemblies)
            //{
            //    foreach (var type in assembly.GetTypes().Where(TypeUtils.IsComponent).Where(TypeUtils.IsRepositoryComponent))
            //    {
            //        var life = ParseLife(type);
            //        ComponentContainer.RegisterType(type, null, life);
            //        foreach (var interfaceType in type.GetInterfaces())
            //        {
            //            ComponentContainer.RegisterType(interfaceType, type, null, life);
            //        }
            //    }
            //}
            return this;
        }

        // 注册缓存组件
        public KinaConfiguration RegisterCacheComponents(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes().Where(TypeUtils.isCacheComponent))
                {
                    var life = ParseLife(type);
                    ComponentContainer.RegisterType(type, null, life);
                    foreach (var interfaceType in type.GetInterfaces())
                    {
                        ComponentContainer.RegisterType(interfaceType, type, null, life);
                    }
                }
            }
            return this;
        }

        private static LifeStyle ParseLife(Type type)
        {
            var componentAttributes = type.GetCustomAttributes(typeof(ComponentAttribute), false);
            return !componentAttributes.Any() ? LifeStyle.Transient : ((ComponentAttribute)componentAttributes[0]).LifeStyle;
        }
    }
}
