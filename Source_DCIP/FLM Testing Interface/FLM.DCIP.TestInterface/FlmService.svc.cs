using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using www.smpte.org.etm;
using System.Xml;
using DCIP.FLM;
using System.Security.Cryptography.X509Certificates;

namespace FLM.DCIP.TestInterface
{
    public class FacilityListMessage : IFlmService
    {
        private static string eventSource = "FLMTestingService";

        public CheckConnectionReplyType CheckConnection(CheckConnectionReplyType parameter)
        {
            CheckConnectionReplyType reply = null;
            try
            {
                reply = new CheckConnectionReplyType();
                reply.Originator = new Uri("urn:publicid:" + System.Environment.UserDomainName.ToString());
                reply.FeedIdentifier = parameter.FeedIdentifier;
                reply.SystemName = System.Environment.MachineName.ToString();
                reply.DateTimeCreated = DateTime.Now;
            }
            catch (Exception e)
            {
                try
                {
                    EventLog.WriteEntry(eventSource, "Could not create reply:" + e.Message, EventLogEntryType.Error);
                }
                catch (Exception eEventLog)
                {
                    Exception eEventLogThrow = new Exception("Cannot write to event log: Check service permissions and EventSource exists", eEventLog);
                    throw eEventLogThrow;
                }

                Exception eThrow = null;
                if (parameter == null)
                {
                    eThrow = new Exception("Parameter is null", e);
                }
                else
                {
                    eThrow = new Exception("Could not create reply", e);
                }

                throw (eThrow);
            }

            return reply;

        }

        public XmlElement GetFacilityList()
        {
            SiteDataContext siteData = new SiteDataContext();

            XmlDocument xmlDocument = new XmlDocument();

            XmlDeclaration dec = xmlDocument.CreateXmlDeclaration("1.0", null, null);
            xmlDocument.AppendChild(dec);// Create the root element

            XmlElement root = xmlDocument.CreateElement("FLMSiteList", "http://dcipllc.com/2009/07/FLMSiteList");
            xmlDocument.AppendChild(root);

            XmlElement ListIdentiifer = xmlDocument.CreateElement("ListIdentiifer", "http://dcipllc.com/2009/07/FLMSiteList");
            ListIdentiifer.InnerText = Guid.NewGuid().ToString();
            root.AppendChild(ListIdentiifer);

            XmlElement DateTimeCreated = xmlDocument.CreateElement("DateTimeCreated", "http://dcipllc.com/2009/07/FLMSiteList");
            DateTimeCreated.InnerText = XmlConvert.ToString(DateTime.Now, "yyyy-MM-ddTHH:mm:sszzzzzz");
            root.AppendChild(DateTimeCreated);

            XmlElement SystemName = xmlDocument.CreateElement("SystemName", "http://dcipllc.com/2009/07/FLMSiteList");
            SystemName.InnerText = System.Environment.MachineName;
            root.AppendChild(SystemName);

            XmlElement SiteList = xmlDocument.CreateElement("SiteList", "http://dcipllc.com/2009/07/FLMSiteList");
            root.AppendChild(SiteList);

            XmlElement Site = null;
            foreach (Site site in siteData.Sites)
            {
                if ((null != site.Exhibitor.URI_Mapping) || (site.Exhibitor.URI_Mapping.Length > 0))
                {
                    Site = xmlDocument.CreateElement("Site", "http://dcipllc.com/2009/07/FLMSiteList");
                    Site.InnerText = string.Format("urn:publicid:facility:{0}:{1}", site.Exhibitor.URI_Mapping, site.Site_Code);
                }
                //else
                //{
                //    SysteLogging.WriteToEventLog("Unknown Exhibitor in Site Status Collection", System.Diagnostics.EventLogEntryType.Error, "Configuration file missing appSetting for exhibitor '" + fss.ExhibitorAbbreviation + "'");
                //}
                SiteList.AppendChild(Site);
            }

            return xmlDocument.DocumentElement;
        }

        public XmlElement GetUpdatedFacilityListSince(string parameters)
        {
            // validate the it is a SINCE command
            string[] paramList = parameters.Split(':');
            if(paramList[0].ToUpper().CompareTo("SINCE") != 0)
            {
                throw new NotSupportedException(String.Format("'{0}' is not a valid parameter.", paramList[0]));
            }

            //validate that its a good date
            DateTime sinceDate = DateTime.MinValue;
            bool isValidDate = DateTime.TryParse(paramList[1], out sinceDate);
            if (!isValidDate)
            {
                throw new InvalidCastException("Invalid date provided.");
            }

            SiteDataContext siteData = new SiteDataContext();
            var siteQuery =
                from site in siteData.Sites
                where site.Record_Updated > sinceDate
                select site;

            XmlDocument xmlDocument = new XmlDocument();

            XmlDeclaration dec = xmlDocument.CreateXmlDeclaration("1.0", null, null);
            xmlDocument.AppendChild(dec);// Create the root element

            XmlElement root = xmlDocument.CreateElement("FLMSiteList", "http://dcipllc.com/2009/07/FLMSiteList");
            xmlDocument.AppendChild(root);

            XmlElement ListIdentiifer = xmlDocument.CreateElement("ListIdentiifer", "http://dcipllc.com/2009/07/FLMSiteList");
            ListIdentiifer.InnerText = Guid.NewGuid().ToString();
            root.AppendChild(ListIdentiifer);

            XmlElement DateTimeCreated = xmlDocument.CreateElement("DateTimeCreated", "http://dcipllc.com/2009/07/FLMSiteList");
            DateTimeCreated.InnerText = XmlConvert.ToString(DateTime.Now, "yyyy-MM-ddTHH:mm:sszzzzzz");
            root.AppendChild(DateTimeCreated);

            XmlElement SystemName = xmlDocument.CreateElement("SystemName", "http://dcipllc.com/2009/07/FLMSiteList");
            SystemName.InnerText = System.Environment.MachineName;
            root.AppendChild(SystemName);

            XmlElement SiteList = xmlDocument.CreateElement("SiteList", "http://dcipllc.com/2009/07/FLMSiteList");
            root.AppendChild(SiteList);

            XmlElement Site = null;
            foreach (Site site in siteQuery)
            {
                if ((null != site.Exhibitor.URI_Mapping) || (site.Exhibitor.URI_Mapping.Length > 0))
                {
                    Site = xmlDocument.CreateElement("Site", "http://dcipllc.com/2009/07/FLMSiteList");
                    Site.InnerText = string.Format("urn:publicid:facility:{0}:{1}", site.Exhibitor.URI_Mapping, site.Site_Code);
                }
                //else
                //{
                //    SysteLogging.WriteToEventLog("Unknown Exhibitor in Site Status Collection", System.Diagnostics.EventLogEntryType.Error, "Configuration file missing appSetting for exhibitor '" + fss.ExhibitorAbbreviation + "'");
                //}
                SiteList.AppendChild(Site);
            }

            return xmlDocument.DocumentElement;
        }

        public DCinemaSecurityMessageType GetFLM(string parameters)
        {
            DCinemaSecurityMessageType dCinemaSecurityMessage = null;

            string[] paramList = parameters.Split(':');
            if (paramList[0].ToUpper().CompareTo("URN") != 0)
            {
                throw new NotSupportedException(String.Format("'{0}' is not a valid parameter.", parameters));
            }

            if (paramList[1].ToUpper().CompareTo("PUBLICID") != 0)
            {
                throw new NotSupportedException(String.Format("'{0}' is not a valid parameter.", parameters));
            }

            if (paramList[2].ToUpper().CompareTo("FACILITY") != 0)
            {
                throw new NotSupportedException(String.Format("'{0}' is not a valid parameter.", parameters));
            }

            string exhibitorURI = paramList[3];

            int siteCode = 0;
            bool isValidSite = int.TryParse(paramList[4], out siteCode);
            if (!isValidSite)
            {
                throw new InvalidCastException("Invalid site code provided.");
            }
            
            string certificateSerialNumber = "0EFB7EEBDCDA4F64A718DB3FF908B085";

            SiteDataContext siteData = new SiteDataContext();
            var siteQuery =
                from site in siteData.Sites
                where ((site.Site_Code == siteCode) && (site.Exhibitor.URI_Mapping.ToUpper().CompareTo(exhibitorURI.ToUpper()) == 0))
                select site;

            if (siteQuery.Count() < 1)
            {
                throw new NotSupportedException("Site not found.");
            }

            dCinemaSecurityMessage = FacilityListMessageUtilities.FLM_Create(siteQuery.First().Site_Id, certificateSerialNumber, StoreLocation.CurrentUser, siteData.Connection.ConnectionString);
            return dCinemaSecurityMessage;
        }

    }
}
