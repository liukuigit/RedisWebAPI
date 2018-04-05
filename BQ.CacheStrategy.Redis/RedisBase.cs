using BQ_Core.Config;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BQ.CacheStrategy.Redis
{
    public class RedisBase 
    {
        private static ConnectionMultiplexer db = null;
        private static string key = null;
        private RedisConfig config  = new RedisConfig();

        private int DbNumber { get; set; }
        public RedisBase(int dbnum = 0)
            : this(dbnum, null)
        {
            
        }

        public RedisBase(int dbnum, string connectionString)
        {
            DbNumber = dbnum;
            db = string.IsNullOrWhiteSpace(connectionString) ? RedisManager.Instance : RedisManager.GetConForMap(connectionString);
        }

        #region 辅助方法
        /// <summary>
        /// 获得Key名称
        /// </summary>
        /// <param name="old"></param>
        /// <returns></returns>
        public string GetKey(string old)
        {
            var fixkey = key ?? config.PrefixKey;
            return fixkey + old;
              
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public T Invoke<T>(Func<IDatabase, T> func)
        { 
            return func(db.GetDatabase(DbNumber));
        }
        public string ConvertJson<T>(T val)
        {
            return val is string ? val.ToString() : JsonConvert.SerializeObject(val);
        }

        public T ConvertObj<T>(RedisValue val)
        {
            return JsonConvert.DeserializeObject<T>(val);
        }

        public List<T> ConvertList<T>(RedisValue[] val)
        {
            List<T> result = new List<T>();
            foreach (var item in val)
            {
                var model = ConvertObj<T>(item);
                result.Add(model);
            }
            return result;
        }

        public RedisKey[] ConvertRedisKeys(List<string> val)
        {
            return val.Select(k => (RedisKey)k).ToArray();
        }
        #endregion
    }
}
