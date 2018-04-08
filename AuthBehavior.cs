using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace AuthMapper
{
    class AuthBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            EventLog.WriteEntry("OEP Relay", "AddBindingParameters", EventLogEntryType.Information, 778);
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            EventLog.WriteEntry("OEP Relay", "ApplyClientBehavior", EventLogEntryType.Information, 778);
            clientRuntime.MessageInspectors.Add(new AuthMessageInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            EventLog.WriteEntry("OEP Relay", "ApplyDispatchBehavior", EventLogEntryType.Information, 779);
            //endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new AuthMessageInspector());
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            EventLog.WriteEntry("OEP Relay", "Validate", EventLogEntryType.Information, 778);
            return;
        }

    }
}
