using BQ.Core.Cache;
using BQ.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BQ.Core.Utilities
{
    public static class TypeUtils
    {
        public static bool IsComponent(Type type)
        {
            return type != null && type.IsClass && type.GetCustomAttributes(typeof(ComponentAttribute), false).Any();
        }

        public static bool IsServiceComponent(Type type)
        {
           // return type != null && type.IsClass && !type.IsAbstract && typeof(IService).IsAssignableFrom(type);
            return false;
        }

        public static bool IsRepositoryComponent(Type type)
        {
            //return type != null && type.IsClass && !type.IsAbstract && typeof(IRepository).IsAssignableFrom(type);
            return false;
        }

        public static bool isCacheComponent(Type type)
        {
            return type != null && type.IsClass && !type.IsAbstract && typeof(ICacheStrategy).IsAssignableFrom(type);
        }
    }
}
