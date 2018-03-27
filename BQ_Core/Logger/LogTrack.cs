using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BQ_Core.Logger
{
    public class LogTrack : IMessageSink
    {
        private IMessageSink m_imNext;
        private Object obj;

        public LogTrack(MarshalByRefObject o, IMessageSink next)
        {
            obj = o;
            m_imNext = next;
        }

        public IMessageSink NextSink
        {
            get
            {
                return m_imNext;
            }
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            BeforeMethodStart(msg);
            IMessage returnMethod = m_imNext.SyncProcessMessage(msg);
            AfterMethodEnd(msg, returnMethod);
            return returnMethod;
        }

        public IMessage CtrlAsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            throw new Exception("noAsyncProcessMessage");
        }

        private void BeforeMethodStart(IMessage msg)
        {
            if (!(msg is IMethodMessage))
            {
                return;
            }

            IMethodMessage ifcMsg = msg as IMethodMessage;
            System.Console.WriteLine("LogTrack: " + obj.GetType().ToString() + "." + ifcMsg.MethodName + " Started");
        }


        private void AfterMethodEnd(IMessage msg, IMessage msgReturn)
        {
            if (!((msg is IMethodMessage) && (msgReturn is IMethodReturnMessage)))
            {
                return;
            }

            IMethodMessage ifcMsg = msg as IMethodMessage;
            System.Console.WriteLine("LogTrack: " + obj.GetType().ToString() + "." + ifcMsg.MethodName + " Ended");
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
