using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BQ_WEBAPI.App_Code
{
    public class JsonpResult : JsonResult
    {
        object data = null;
        public JsonpResult()
        {
        }
        public JsonpResult(object data)
        {
            this.data = data;
        }

        public override void ExecuteResult(ControllerContext controllerContext)
        {
            if (controllerContext != null)
            {
                HttpResponseBase Response = controllerContext.HttpContext.Response;
                HttpRequestBase Request = controllerContext.HttpContext.Request;

                string callbackfunction = Request["callback"];
                if (string.IsNullOrEmpty(callbackfunction))
                {
                    throw new Exception("Callback function name must be provided in the request!");
                }
                Response.ContentType = "application/x-javascript";
                if (data != null)
                {
                    
                    var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };

                    string json= JsonConvert.SerializeObject(data, Formatting.Indented, timeConverter);

                    Response.Write(string.Format("{0}({1});", callbackfunction, json));
                }
            }
        }
    }
}