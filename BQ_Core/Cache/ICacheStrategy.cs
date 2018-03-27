using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BQ.Core.Cache
{
    public interface ICacheStrategy
    {



        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        object Get(string key);

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        T Get<T>(string key);

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isLike">是否模糊匹配</param>
        void Remove(string key, bool isLike);

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        void Clear();

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        void Insert(string key, object data);

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        void Insert(string key, object data, TimeSpan? exp = default(TimeSpan?));

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间,单位分钟</param>
        void Insert(string key, object data, int expireMinutes = 0);


        /// <summary>
        /// 判断Key是否存在
        /// </summary>
        /// <param name="key">缓存键</param>
        bool Exists(string key);



        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        Task<T> GetAsync<T>(string key);


        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        Task<bool> InsertAsync(string key, object data);

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        Task<bool> InsertAsync(string key, object data, TimeSpan? exp = default(TimeSpan?));

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间,单位分钟</param>
        Task<bool> InsertAsync(string key, object data, int expireMinutes = 0);


        

    }
}
