using BQ.CacheStrategy.Redis;
using BQ.Core.Cache;
using BQ_APILogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BQ_WEBAPI.Controllers
{
    public class CacheController : Controller
    {

        public ICacheStrategy _cacheHelper { get; set; }

        //
        // GET: /Cache/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddKey(string key, string val, string addType, int ticks)
        {

            DoRedisStringCache _cache = new DoRedisStringCache();


            RedisConfig config = new RedisConfig();

            _cache.StringSet(config.Connection, config.PrefixKey);



            if (addType.Equals("1"))
            {
                _cache.StringSet(key, val, new TimeSpan(1, 0, 0));

                _cacheHelper.Insert("Autowired_" + key, val, 5);
            }
            else
            {
                var list = GetGroupList();
                // _cache.StringSetAsync<List<GroupEntity>>(key, list);
                _cache.StringSet(key, list, new TimeSpan(1, 0, 0));

            }


            return RedirectToAction("Index");
        }

        public ActionResult SyncAddKey(string key, string val, string addType, int ticks)
        {
            DoRedisStringCache _cache = new DoRedisStringCache();

            _cache.StringSetAsync(key, val);

            _cacheHelper.InsertAsync("自动注入_" + key, val);


            return RedirectToAction("Index");
        }

        public ActionResult SyncAddKeyObj(string key)
        {
            List<GroupEntity> list = GetGroupList();
            //_cacheHelper.InsertAsync(key, list);

            RedisListCache cache = new RedisListCache();
            RedisHashCache hashCache = new RedisHashCache(0);

            foreach (GroupEntity m in list)
            {

                cache.ListLeftPush(key, m);

                cache.ListRightPushAsync(key + "Async", m);

                hashCache.HashSet(key + "Hash", m.ID.ToString(), m);

                hashCache.HashSetAsync(key + "HashAsync", m.ID.ToString(), m);

            }
            return RedirectToAction("Index");
        }

        public JsonResult GetObjList(string key)
        {
            RedisListCache cache = new RedisListCache();
            RedisHashCache hashCache = new RedisHashCache(0);

            //List<GroupEntity> list = cache.ListRange<GroupEntity>(key);

            GroupEntity m = cache.ListLeftPop<GroupEntity>(key);

            GroupEntity m1 = hashCache.HashGet<GroupEntity>(key+"Hash", "50");

            List<GroupEntity> list = new List<GroupEntity>();
            list.Add(m);
            list.Add(m1);

            return Json(list);

        }

        public JsonResult GetKey(string key)
        {
            DoRedisStringCache _cache = new DoRedisStringCache();

            var result = _cache.StringGet<List<GroupEntity>>(key);
            return Json(result);
        }


        public List<GroupEntity> GetGroupList()
        {
            List<GroupEntity> groupList = new List<GroupEntity>();

            for (int i = 0; i < 2000; i++)
            {
                groupList.Add(new GroupEntity()
                {
                    ID = i,
                    Name = "坦克评审组" + i

                });
            }



            return groupList;
        }

    }
}
