using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Service
{
    public interface IServiceResponse<TData>
    {
        ResponseStatus Status { get; set; }

        TData Data { get; set; }
    }
}
