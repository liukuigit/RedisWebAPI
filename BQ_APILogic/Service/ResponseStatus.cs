using System;
using System.Collections.Generic;
using System.Text;

namespace BQ_APILogic.Service
{
    [Serializable]
    public class ResponseStatus
    {
        // Methods
        public ResponseStatus()
        {
        }

        // Properties
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }




}
