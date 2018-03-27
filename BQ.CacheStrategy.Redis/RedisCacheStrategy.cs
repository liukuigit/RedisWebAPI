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

        #region ���ڲ���

        /// <summary>
        /// Ĭ�ϻ������ʱ�� 1Сʱ
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
        /// ��λ��
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
        /// ���ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns>����ֵ</returns>
        public object Get(string key)
        {
            key = _cache.GetKey(key);

            return _cache.Invoke(db => db.StringGet(key));
        }

        /// <summary>
        /// ��ָ�����Ķ�����ӵ�������
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        public void Insert(string key, object data)
        {
            Insert(key, data, _defaultTimeSpan);
        }

        /// <summary>
        /// ��ָ�����Ķ�����ӵ������У���ָ������ʱ��
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        /// <param name="expireMinutes">�������ʱ�䣬��λ����</param>
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
        /// ��ָ�����Ķ�����ӵ������У���ָ������ʱ��
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        /// <param name="cacheTime">�������ʱ��</param>
        public void Insert(string key, object data, TimeSpan? exp = default(TimeSpan?))
        {
            key = _cache.GetKey(key);
            string json = _cache.ConvertJson(data);
            _cache.Invoke(db => db.StringSet(key, json, exp));
        }

        /// <summary>
        /// �ӻ������Ƴ�ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        public void Remove(string key)
        {
            key = _cache.GetKey(key);
            _cache.Invoke(db => db.KeyDelete(key));
        }

        /// <summary>
        /// �ӻ������Ƴ�ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="isLike">�Ƿ�ģ��ƥ�� true:ģ��ƥ�� false:ȫ��ƥ��</param>
        public void Remove(string key, bool isLike)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ������л������
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// �ж�Key�Ƿ����
        /// </summary>
        /// <param name="key">�����</param>
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
        /// �첽��ȡ����
        /// </summary>
        /// <typeparam name="T">Ŀ�����</typeparam>
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
