using BQ_APILogic.Model;
using BQ_APILogic.Service;
using BQ_WEBAPI.App_Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BQ_WEBAPI.Controllers
{
    public class BqApiController : Controller
    {
        //
        // GET: /BqApi/

        public ActionResult Index()
        {
            return View();
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

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProjectList(string mType)
        {
            ProjectInfoServiceResponse<IEnumerable<ProjectEntity>> result = new ProjectInfoServiceResponse<IEnumerable<ProjectEntity>>();


            List<FileEntity> fileList = new List<FileEntity>();

            fileList.Add(new FileEntity()
            {
                ID = 1,
                IsDir = true,
                Name = "文档资料1",
                FileURL = "/Docs/文档资料1.xlsx",

            });
            fileList.Add(new FileEntity()
            {
                ID = 2,
                IsDir = true,
                Name = "文档资料2",
                FileURL = "/Docs/文档资料2.xlsx",

            });

            List<ProjectEntity> proList = new List<ProjectEntity>();

            proList.Add(new ProjectEntity()
            {
                ID = 1,
                Name = "XXX科研项目001",
                GroupId = 1,
                GroupName = "坦克评审组1",
                DeptName = "服务部门XXX",
                OnlyDX = false,
                Jllb = "成果物1",
                Jz = "进步奖",
                Jldj = "特等奖",
                Cglb = "成果类别1",
                Cgdjh = "成果登记号1",
                ListFile = fileList

            });

            proList.Add(new ProjectEntity()
            {
                ID = 2,
                Name = "XXX科研项目002",
                GroupId = 1,
                GroupName = "坦克评审组1",
                DeptName = "服务部门XXX",
                OnlyDX = false,
                Jllb = "成果物1",
                Jz = "进步奖",
                Jldj = "特等奖",
                Cglb = "型号及类别研究",
                Cgdjh = "成果登记号2",
                ListFile = fileList

            });

            result.ListProject = proList;
            return Json(proList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult PutProjectList(ProjectRequest request)
        {

            return Json(new ResponseStatus()
            {
                ErrorCode = 200,
                Success = true
            });
        }

        public JsonResult GetProjectInfoList()
        {

            ProjectRequest result = new ProjectRequest();
            List<RequestProject> projectList = new List<RequestProject>();
            List<PersonEntity> personList1 = new List<PersonEntity>();
            personList1.Add(new PersonEntity()
            {
                ID = "Z001",
                Dept = "服务部门XXX",
                GroupName = "坦克评审组1",
                Name = "专家001",
                Tel = "134XXXXXXXXX",
                Title = "专家001"
            });
            personList1.Add(new PersonEntity()
            {
                ID = "Z002",
                Dept = "服务部门XXX",
                GroupName = "坦克评审组1",
                Name = "专家002",
                Tel = "134XXXXXXXXX",
                Title = "专家002"
            });

            projectList.Add(new RequestProject()
            {
                RType = "1",
                ID = 1,
                Name = "XXX科研项目001",
                ReviewLevel = "特等",
                NoticeUrl = "/NoticeImg/项目编号001/notice.png",

            });

            projectList.Add(new RequestProject()
            {
                RType = "1",
                ID = 2,
                Name = "XXX科研项目002",
                ReviewLevel = "一",
                NoticeUrl = "/NoticeImg/项目编号002/notice.png",

            });

            result.ListProject = projectList;
            result.ListPerson = personList1;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGroupList()
        {

            List<GroupEntity> groupList = new List<GroupEntity>();
            List<PersonEntity> personList1 = new List<PersonEntity>();
            personList1.Add(new PersonEntity()
            {
                ID = "Z001",
                Dept = "服务部门XXX",
                GroupName = "坦克评审组1",
                Name = "专家001",
                Tel = "134XXXXXXXXX",
                Title = "专家001"
            });
            personList1.Add(new PersonEntity()
            {
                ID = "Z002",
                Dept = "服务部门XXX",
                GroupName = "坦克评审组1",
                Name = "专家002",
                Tel = "134XXXXXXXXX",
                Title = "专家002"
            });

            List<PersonEntity> personList2 = new List<PersonEntity>();
            personList2.Add(new PersonEntity()
            {
                ID = "Z003",
                Dept = "服务部门XXX",
                GroupName = "坦克评审组1",
                Name = "专家003",
                Tel = "134XXXXXXXXX",
                Title = "专家001"
            });
            personList2.Add(new PersonEntity()
            {
                ID = "Z004",
                Dept = "服务部门XXX",
                GroupName = "坦克评审组1",
                Name = "专家004",
                Tel = "134XXXXXXXXX",
                Title = "专家002"
            });

            groupList.Add(new GroupEntity()
            {
                ID = 1,
                Name = "坦克评审组1",
                ListPerson = personList1,
            });

            groupList.Add(new GroupEntity()
            {
                ID = 2,
                Name = "坦克评审组2",
                ListPerson = personList2,
            });
            groupList.Add(new GroupEntity()
            {
                ID = 3,
                Name = "坦克评审组3",
            });

            return Json(groupList, JsonRequestBehavior.AllowGet);
        }


        public JsonpResult GetGroupListJsonp(string callback)
        {
            List<GroupEntity> groupList = new List<GroupEntity>();
            

            groupList.Add(new GroupEntity()
            {
                ID = 1,
                Name = "坦克评审组1"
              
            });

            groupList.Add(new GroupEntity()
            {
                ID = 2,
                Name = "坦克评审组2"
               
            });
            groupList.Add(new GroupEntity()
            {
                ID = 3,
                Name = "坦克评审组3",
            });

            
            

            JsonpResult reuslt = new JsonpResult(groupList);
            return reuslt;
            //return Json(json, JsonRequestBehavior.AllowGet); 
        }

    }
}
