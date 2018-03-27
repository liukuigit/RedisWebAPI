using BQ_APILogic.Helper;
using BQ_APILogic.Model;
using BQ_APILogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BQ_WEBAPI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }


        public ActionResult UnZip()
        {
            string path1 = Server.MapPath("/Uploads/log.zip");
            string path2 = Server.MapPath("/Uploads/" + DateTime.Now.ToString("yyyyMMddHHssmm") + "/");
            ClassZip.UnZip(path1, path2);

            return View("Index");
        }

        public ActionResult Zip()
        {
            string path1 = Server.MapPath("/Uploads/20180123113737/");
            string path2 = Server.MapPath("/Uploads/" + DateTime.Now.ToString("yyyyMMddHHssmm")+".zip");
            ClassZip.Zip(path1, path2,6);

            return View("Index");
        }

        public ActionResult JsonConvert(string jsonStr, string convertType)
        {
            dynamic data;
            if (convertType == "专家")
            {
              data=  Newtonsoft.Json.JsonConvert.DeserializeObject<List<GroupEntity>>(jsonStr);
            }
            else if (convertType == "项目")
            {
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectEntity>>(jsonStr);
            }
            else if (convertType == "评审")
            {
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectRequest>(jsonStr);
            }

            return View("Index");
        }


        /// <summary>
        /// 获取专家信息
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public JsonResult SearchPersonList()
        {

            GroupPersonInfoServiceResponse<IEnumerable<GroupEntity>> result = new GroupPersonInfoServiceResponse<IEnumerable<GroupEntity>>();
            List<PersonEntity> personList = new List<PersonEntity>();
            personList.Add(new PersonEntity()
            {
                ID = "1",
                Dept = "大客户服务部门",
                GroupName = "坦克评审组",
                Name = "客户研究专家",
                Tel = "134XXXXXXXXX",
                Title = "客户研究专家教授"
            });
            List<GroupEntity> groupList = new List<GroupEntity>();
            groupList.Add(new GroupEntity()
            {
                ID = 1,
                Name = "坦克评审组",
                ListPerson = personList,
            });
            result.ListGroup = groupList;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult WordConvert()
        {
            WordConverterNpoi helper = new WordConverterNpoi();


            string filepath = HttpContext.Server.MapPath(@"/uploads/Contract/aaa.docx");


            string filename = HttpContext.Server.MapPath("/uploads/Contract/aaa-1.docx");
            
            WordConverterNpoi convert = new WordConverterNpoi();
            convert.Convert(filepath, filename, "合并编号XXX001");

            return Json(true, JsonRequestBehavior.AllowGet);
        }



        public JsonResult SyncData(PersonEntity person)
        {
            
            return Json(person, JsonRequestBehavior.AllowGet);
        
        }

    }



}
