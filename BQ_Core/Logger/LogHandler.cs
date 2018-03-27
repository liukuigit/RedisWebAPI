using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BQ_Core.Logger
{
    public class LogHandler : IContextProperty, IContributeObjectSink
    {
        public IMessageSink GetObjectSink(MarshalByRefObject o, IMessageSink next)
        {
            return new LogTrack(o, next);
        }
        public bool IsNewContextOK(Context newCtx)
        {
            return true;
        }
        public void Freeze(Context newContext)
        {
        }

        public string Name
        {
            get
            {
                return "LogHandler";
            }
        }
    }
}
