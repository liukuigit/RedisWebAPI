using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Service
{
    public class ProjectInfoServiceResponse<TData>
    {

        public ProjectInfoServiceResponse()
        {
            this.Status = new ResponseStatus()
            {
                Success = true,
                ErrorCode = 200,
                Message = string.Empty
            };

        }

        public ResponseStatus Status { get; set; }

        public TData ListProject { get; set; }
    }
}
