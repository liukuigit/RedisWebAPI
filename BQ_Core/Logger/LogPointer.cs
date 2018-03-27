using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BQ_Core.Logger
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LogPointer : ContextAttribute
    {


        private String pointName = null;

        public LogPointer(string pName)
            : base(pName)
        {
            this.pointName = pName;
        }

        public override void GetPropertiesForNewContext(IConstructionCallMessage ccm)
        {
            if (pointName == "Log")
            {
                ccm.ContextProperties.Add(new LogHandler());
            }
        }
    }
}
