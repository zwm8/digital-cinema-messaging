using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

using DCIP.FLM;
using www.smpte.org.etm;
using System.Security.Cryptography;

namespace FLM.ConsoleTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //int siteId = 1210; //Cinemark
            //int siteId = 473; //Regal
            int siteId = 271; //AMC

            string connectionString = "Data Source=SEMBERLEY;Initial Catalog=AMS.TSTDB01;Persist Security Info=True;User ID=sa;Password=Iw2wfm2d";
            //string connectionString = "Data Source=SEMBERLEY;Initial Catalog=AMS.12.23.2009;Data Source=SEMBERLEY;Initial Catalog=AMS.2009.12.23;Persist Security Info=True;User ID=sa;Password=";
            //string connectionString = "Data Source=WEBSERVER;Initial Catalog=AMS.2009.12.23;Integrated Security=True";
           
            #region Pull the certificate from the store
            X509Certificate2 x509Certificate2 = null;
            try
            {
                x509Certificate2 = GetCertificate("0EFB7EEBDCDA4F64A718DB3FF908B085", StoreLocation.CurrentUser); // *.dcipllc.com
            }
            catch (Exception e)
            {
                Exception throwableException = new Exception("Failed to get certificate, see inner exception for details", e);
                throw throwableException;
            }
            if (null == x509Certificate2)
            {
                Exception throwableException = new Exception("Failed to get certificate");
                throw throwableException;
            }
            #endregion

            try
            {
                XmlDocument xmlDocument = FacilityListMessageUtilities.FLM_Create(siteId, x509Certificate2, connectionString);
                xmlDocument.Save(@"\_Testing Output\DCIP.FLM.ConsoleTestApplication\FLM_DCinemaSecurityMessage.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                XmlDocument xmlDocumentExtended = FacilityListMessageUtilities.FLMEXT_Create(siteId, x509Certificate2, connectionString);
                xmlDocumentExtended.Save(@"\_Testing Output\DCIP.FLM.ConsoleTestApplication\FLMEXT_DCinemaSecurityMessage.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static private X509Certificate2 GetCertificate(string serialNumber, StoreLocation storeLocation)
        {
            X509Certificate2 x509Certificate2 = null;

            try
            {
                X509Store store = new X509Store(storeLocation);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;

                X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindBySerialNumber, serialNumber, false);
                if (fcollection.Count > 0)
                    x509Certificate2 = fcollection[0];

                store.Close();
            }
            catch (CryptographicException eCrypt)
            {
                Exception throwableException = new Exception("Error Reading Certificate, see inner exception for details", eCrypt);
            }

            return x509Certificate2;
        }
    }
}
