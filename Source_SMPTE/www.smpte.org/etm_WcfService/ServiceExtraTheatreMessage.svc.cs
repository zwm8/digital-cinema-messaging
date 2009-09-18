using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using www.smpte.org.etm;
using System.Xml.Serialization;
using System.IO;

namespace etm_WcfService
{
    public class ServiceExtraTheatreMessage : IServiceExtraTheatreMessage
    {
        public string ETM(DCinemaSecurityMessageType value)
        {
            string outputFilename = "WCF_ExtraTheatreMessage." + value.AuthenticatedPublic.MessageId.Replace("urn:uuid:", "") + ".xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
            TextWriter WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\" + outputFilename);
            xmlSerializer.Serialize(WriteFileStream, value);
            WriteFileStream.Close();

            return string.Format("Received ETM: {0}", value.AuthenticatedPublic.MessageId);
        }
    }
}
