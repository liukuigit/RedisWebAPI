using BQ_Core.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BQ.CacheStrategy.Redis
{
    [BQ.Core.Attributes.Configuration()]
    public class RedisConfig :IConfigMapper
    {
        //public static readonly string config = ConfigurationManager.AppSettings["redisConnection"];
        //public static readonly string redisKey = ConfigurationManager.AppSettings["redisKey"] ?? "";
        //public static string Config()
        //{
        //    return config;
        //}
        //public static string Key()
        //{
        //    return redisKey;
        //}

        public  RedisConfig()
        {
            
             Type objType=  this.GetType();
             var noMappingProperty = new List<string>();
             foreach (PropertyInfo propInfo in objType.GetProperties())
             {
                 if (propInfo.GetCustomAttributes(typeof(BQ.Core.Attributes.ConfigurationAttribute), true).Any())
                 {
                     var ConfigurationAttributes = propInfo.GetCustomAttributes(typeof(BQ.Core.Attributes.ConfigurationAttribute), true);
                     string configStr = ((BQ.Core.Attributes.ConfigurationAttribute)ConfigurationAttributes[0]).Key;
                     if(string.IsNullOrEmpty(configStr))
                     {
                         propInfo.SetValue(this, ConfigurationManager.AppSettings[propInfo.Name]);
                     }
                     else {
                         propInfo.SetValue(this, ConfigurationManager.AppSettings[configStr]);
                     }
                     
                 
                 }
             }
        }

        [BQ.Core.Attributes.Configuration(Key = "redisConnection")]
        public  string Connection { get; set; }

        [BQ.Core.Attributes.Configuration(Key = "redisKey")]
        public  string PrefixKey { get; set; }

    }
}
