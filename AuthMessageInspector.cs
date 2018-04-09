using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace AuthMapper
{
    public class AuthMessageInspector : IClientMessageInspector 
    {
        private readonly string _username = "olegk";
        private readonly string _password = "dfnc94^*";

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Console.WriteLine("AfterReceiveReply called");
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            // Implement this method to inspect/modify messages before they   
            // are sent to the service 

            HttpRequestMessageProperty httpRequest = null;
            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                httpRequest = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            }

            //Make sure we have a valid property, or create one
            if (httpRequest == null)
            {
                httpRequest = new HttpRequestMessageProperty();
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequest);
            }

            using (OperationContextScope scope = new OperationContextScope((IContextChannel)channel))
            {
            
            }

            Console.WriteLine("BeforeSendRequest called");

            string encodedCredentials = EncodeCredentials(_username, _password);
            httpRequest.Headers[HttpRequestHeader.Authorization] = "Basic " + encodedCredentials;

            return null;
        }

        private string EncodeCredentials(string username, string password)
        {
            string clearTextCredentials = string.Format("{0}:{1}", username, password);
            var inArray = Encoding.UTF8.GetBytes(clearTextCredentials);
            return Convert.ToBase64String(inArray);
        }


    }
}
