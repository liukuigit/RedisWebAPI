using BQ_APILogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Service
{
    public class ProjectRequest : RequestBase
    {
        
        public List<RequestProject> ListProject { get; set; }

        public List<PersonEntity> ListPerson { get; set; }
    }
}
