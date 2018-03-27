using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Web;
using BQ.Core.Cache;
namespace BQ.CacheStrategy.Redis
{
    public class RedisCacheStrategy : ICacheStrategy
    {
        private RedisBase _cache = null;

        #region 过期策略

        /// <summary>
        /// 默认缓存过期时间 1小时
        /// </summary>
        /// <value></value>
        private TimeSpan _defaultTimeSpan
        {
            get
            {
                return new TimeSpan(1, 0, 0);
            }
        }
        /// <summary>
        /// 单位秒
        /// </summary>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        private TimeSpan GetTimeSpan(int cacheTime)
        {
            return new TimeSpan(0, 0, cacheTime);
        }

        #endregion

        public RedisCacheStrategy()
        {
            _cache = new RedisBase(1);

        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public object Get(string key)
        {
            key = _cache.GetKey(key);

            return _cache.Invoke(db => db.StringGet(key));
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        public void Insert(string key, object data)
        {
            Insert(key, data, _defaultTimeSpan);
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="expireMinutes">缓存过期时间，单位分钟</param>
        public void Insert(string key, object data, int expireMinutes = 0)
        {
            if (expireMinutes > 0)
            {
                TimeSpan time = TimeSpan.FromMinutes(expireMinutes);
                Insert(key, data, time);
            }
            else
            {
                Insert(key, data, null);
            }


        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public void Insert(string key, object data, TimeSpan? exp = default(TimeSpan?))
        {
            key = _cache.GetKey(key);
            string json = _cache.ConvertJson(data);
            _cache.Invoke(db => db.StringSet(key, json, exp));
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key)
        {
            key = _cache.GetKey(key);
            _cache.Invoke(db => db.KeyDelete(key));
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isLike">是否模糊匹配 true:模糊匹配 false:全文匹配</param>
        public void Remove(string key, bool isLike)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 判断Key是否存在
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            key = _cache.GetKey(key);
            return _cache.Invoke(db => db.KeyExists(key));
        }


        public T Get<T>(string key)
        {
            key = _cache.GetKey(key);
            var val = _cache.Invoke(db => db.StringGet(key));
            if (!string.IsNullOrEmpty(val))
            {
                return _cache.ConvertObj<T>(val);
            }
            else
            {
                return default(T);
            }
        }



        /// <summary>
        /// 异步获取对象
        /// </summary>
        /// <typeparam name="T">目标对象</typeparam>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<T> GetAsync<T>(string key)
        {
            key = _cache.GetKey(key);
            var val = await _cache.Invoke(db => db.StringGetAsync(key));
            return _cache.ConvertObj<T>(val);
        }

        public async System.Threading.Tasks.Task<bool> InsertAsync(string key, object data)
        {
            return await InsertAsync(key, data, _defaultTimeSpan);
        }

        public async System.Threading.Tasks.Task<bool> InsertAsync(string key, object data, TimeSpan? exp = default(TimeSpan?))
        {
            key = _cache.GetKey(key);
            string json = _cache.ConvertJson(data);
            return await _cache.Invoke(db => db.StringSetAsync(key, json, exp));
        }

        public async System.Threading.Tasks.Task<bool> InsertAsync(string key, object data, int expireMinutes = 0)
        {
            if (expireMinutes > 0)
            {
                TimeSpan time = TimeSpan.FromMinutes(expireMinutes);
                return await InsertAsync(key, data, time);
            }
            else
            {
                return await InsertAsync(key, data, null);
            }
        }
    }
}
