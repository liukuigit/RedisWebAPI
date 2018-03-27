using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Service
{
   public class ProjectRequestServiceResponse<TData>
    {

       public ProjectRequestServiceResponse()
        {
           
        }

       public string mType { get; set; }

       public TData ListProject { get; set; }
    }
}
