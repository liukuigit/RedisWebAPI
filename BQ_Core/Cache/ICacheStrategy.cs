using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BQ.Core.Cache
{
    public interface ICacheStrategy
    {



        /// <summary>
        /// ���ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns>����ֵ</returns>
        object Get(string key);

        /// <summary>
        /// ���ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns>����ֵ</returns>
        T Get<T>(string key);

        /// <summary>
        /// �ӻ������Ƴ�ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        void Remove(string key);

        /// <summary>
        /// �ӻ������Ƴ�ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="isLike">�Ƿ�ģ��ƥ��</param>
        void Remove(string key, bool isLike);

        /// <summary>
        /// ������л������
        /// </summary>
        void Clear();

        /// <summary>
        /// ��ָ�����Ķ�����ӵ�������
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        void Insert(string key, object data);

        /// <summary>
        /// ��ָ�����Ķ�����ӵ������У���ָ������ʱ��
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        /// <param name="cacheTime">�������ʱ��</param>
        void Insert(string key, object data, TimeSpan? exp = default(TimeSpan?));

        /// <summary>
        /// ��ָ�����Ķ�����ӵ������У���ָ������ʱ��
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        /// <param name="cacheTime">�������ʱ��,��λ����</param>
        void Insert(string key, object data, int expireMinutes = 0);


        /// <summary>
        /// �ж�Key�Ƿ����
        /// </summary>
        /// <param name="key">�����</param>
        bool Exists(string key);



        /// <summary>
        /// ���ָ�����Ļ���ֵ
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns>����ֵ</returns>
        Task<T> GetAsync<T>(string key);


        /// <summary>
        /// ��ָ�����Ķ�����ӵ�������
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        Task<bool> InsertAsync(string key, object data);

        /// <summary>
        /// ��ָ�����Ķ�����ӵ������У���ָ������ʱ��
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        /// <param name="cacheTime">�������ʱ��</param>
        Task<bool> InsertAsync(string key, object data, TimeSpan? exp = default(TimeSpan?));

        /// <summary>
        /// ��ָ�����Ķ�����ӵ������У���ָ������ʱ��
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����ֵ</param>
        /// <param name="cacheTime">�������ʱ��,��λ����</param>
        Task<bool> InsertAsync(string key, object data, int expireMinutes = 0);


        

    }
}
