using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using www.smpte.org.etm;

namespace flm_WcfService
{
    [ServiceContract]
    public interface IServiceFacilityListMessage
    {
        [OperationContract]
        string FLM(DCinemaSecurityMessageType value);
    }

}
