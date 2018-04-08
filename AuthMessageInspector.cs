using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace AuthMapper
{
    public class AuthMessageInspector : IClientMessageInspector 
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Console.WriteLine("AfterReceiveReply called");
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            // Implement this method to inspect/modify messages before they   
            // are sent to the service 

            Console.WriteLine("BeforeSendRequest called");
            return null;
        }


    }
}
