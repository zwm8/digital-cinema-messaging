using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using www.smpte.org.etm;

namespace etm_WcfService
{
    [ServiceContract]
    public interface IServiceExtraTheatreMessage
    {
        [OperationContract]
        string ETM(DCinemaSecurityMessageType value);
    }
}
