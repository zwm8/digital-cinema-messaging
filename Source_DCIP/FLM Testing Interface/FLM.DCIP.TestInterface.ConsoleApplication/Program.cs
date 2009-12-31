using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using tempuri.org.CheckConnectionReply.xsd;
using www.smpte.org.etm;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Xml.Serialization;

namespace FLM.DCIP.TestInterface.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FlmServiceClient client = new FlmServiceClient();

            CheckConnectionReplyType checkConnectionParameter = new CheckConnectionReplyType();
            checkConnectionParameter.Originator = new Uri("urn:publicid:" + System.Environment.UserDomainName);
            checkConnectionParameter.SystemName = System.Environment.MachineName.ToString();
            checkConnectionParameter.FeedIdentifier = Guid.NewGuid().ToString();
            checkConnectionParameter.DateTimeCreated = DateTime.Now;

            CheckConnectionReplyType checkConnectionReply = client.CheckConnection(checkConnectionParameter);

            XmlElement xmlElement = client.GetFacilityList();
            WriteToDisk(xmlElement, "GetFacilityList");

            xmlElement = client.GetUpdatedFacilityListSince("Since:12/12/2009");
            WriteToDisk(xmlElement, "GetUpdatedFacilityListSince");

            DCinemaSecurityMessageType extraTheatreMessage = client.GetFLM("urn:publicid:facility:regalcinemas.com:108");

            XmlSerializer xmlSerializer = new XmlSerializer(extraTheatreMessage.GetType());
            MemoryStream memStream = new MemoryStream();
            xmlSerializer.Serialize(memStream, extraTheatreMessage);
            memStream.Seek(0, System.IO.SeekOrigin.Begin);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(memStream);
            memStream.Close();
            WriteToDisk(xmlDocument.DocumentElement, "GetFLM");

        }

        private static void WriteToDisk(XmlElement FLM, string fileName)
        {
            try
            {
                String DataDirectory = ConfigurationManager.AppSettings.Get("DataDirectory");

                string fileNamePath = DataDirectory + "\\" + fileName + ".xml";

                DataContractSerializer ser = new DataContractSerializer(typeof(XmlElement));
                FileStream fs = new FileStream(fileNamePath, FileMode.Create);
                ser.WriteObject(fs, FLM);
                fs.Close();
            }
            catch (Exception e)
            {
                try
                {
                    EventLog.WriteEntry(System.Environment.UserName, "Write File Failed:" + e.Message, EventLogEntryType.Error);
                }
                catch (Exception eEventLog)
                {
                    Exception eEventLogThrow = new Exception("Cannot write to event log: Check service permissions and EventSource exists", eEventLog);
                    throw eEventLogThrow;
                }

                Exception eWriteError = new Exception("Cannot write to FLM to file", e);
                throw eWriteError;
            }
        }
    }
}
