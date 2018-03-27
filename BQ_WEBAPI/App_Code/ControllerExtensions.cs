using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BQ_WEBAPI;
using System.Web.Mvc;
namespace BQ_WEBAPI.App_Code
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Extension methods for the controller to allow jsonp.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static JsonpResult Jsonp(this Controller controller, object data)
        {
            JsonpResult result = new JsonpResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            
            return result;
        }
    }
}