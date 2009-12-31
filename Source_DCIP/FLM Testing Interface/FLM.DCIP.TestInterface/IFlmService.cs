using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using www.smpte.org.etm;
using System.Xml;

namespace FLM.DCIP.TestInterface
{
    [ServiceContract]
    public interface IFlmService
    {
        [OperationContract]
        CheckConnectionReplyType CheckConnection(CheckConnectionReplyType parameter);

        [OperationContract]
        DCinemaSecurityMessageType GetFLM(string parameters);

        [OperationContract]
        XmlElement GetUpdatedFacilityListSince(string parameters);

        [OperationContract]
        XmlElement GetFacilityList();
    }

}
