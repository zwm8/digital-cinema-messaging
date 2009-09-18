using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using www.smpte.org.etm;
using System.Xml.Serialization;
using System.IO;

namespace flm_WcfService
{
    public class ServiceFacilityListMessage : IServiceFacilityListMessage
    {
        public string FLM(DCinemaSecurityMessageType value)
        {
            string outputFilename = "WCF_FacilityListMessage." + value.AuthenticatedPublic.MessageId.Replace("urn:uuid:", "") + ".xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
            TextWriter WriteFileStream = new StreamWriter(@"E:\Source_SMPTE\Output\" + outputFilename);
            xmlSerializer.Serialize(WriteFileStream, value);
            WriteFileStream.Close();

            return string.Format("Received FLM: {0}", value.AuthenticatedPublic.MessageId);
        }
    }
}
