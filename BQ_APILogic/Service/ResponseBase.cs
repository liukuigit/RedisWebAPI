using System;
using System.Collections.Generic;
using System.Text;

namespace BQ_APILogic.Service
{
    [Serializable]
    public class ResponseBase
    {
        // Methods
        public ResponseBase()
        { 
        }

        // Properties
        public ResponseStatus Status { get; set; }
    }

 

}
