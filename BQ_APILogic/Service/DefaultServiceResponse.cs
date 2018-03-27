using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Service
{
    public class DefaultServiceResponse<TData> : IServiceResponse<TData>
    {
        public DefaultServiceResponse()
        {
            this.Data = default(TData);
            this.Status = new ResponseStatus()
            {
                Success = true,
                ErrorCode = 200
            };

        }

        public ResponseStatus Status
        {
            get;
            set;
        }

        public TData Data
        {
            get;
            set;
        }
    }
}
