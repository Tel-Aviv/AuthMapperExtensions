using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace AuthMapper
{
    class AuthBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                Type type = typeof(AuthBehavior);
                string str = String.Format("Getting type of AuthBehavior {0}", type.ToString());
                EventLog.WriteEntry("OEP Relay", str, EventLogEntryType.Information, 777);
                return type;
            }
        }

        protected override object CreateBehavior()
        {
            EventLog.WriteEntry("OEP Relay", "CreateBehavior", EventLogEntryType.Information, 778);
            return new AuthBehavior();
        }
    }
}
