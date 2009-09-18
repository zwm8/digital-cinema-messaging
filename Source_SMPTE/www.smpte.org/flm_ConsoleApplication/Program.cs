using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

using www.smpte.org.etm;
using www.smpte.org.dcmlTypes;
using www.smpte.org.flm;
using www.w3.org.dsig;

namespace flm_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //X509Certificate2 x509Certificate2 = GetCertificate("990B25F50DC7E2B548BE75AFED579448", StoreLocation.CurrentUser);
            //X509Certificate2 x509Certificate2 = GetCertificate("23B0B092F414B89745B443F2B3700039", StoreLocation.LocalMachine);
            //X509Certificate2 x509Certificate2 = GetCertificate("0efb7eebdcda4f64a718db3ff908b085", StoreLocation.LocalMachine);
            X509Certificate2 x509Certificate2 = GetCertificate("0EFB7EEBDCDA4F64A718DB3FF908B085", StoreLocation.CurrentUser); // *.dcipllc.com

            DCinemaSecurityMessageType extraTheatreMessage = BuildDCinemaSecurityMessage(x509Certificate2);
            TextWriter WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\ExtraTheatreMessage.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
            xmlSerializer.Serialize(WriteFileStream, extraTheatreMessage);
            WriteFileStream.Close();

            FLMRequiredExtensionsType flmRequiredExtention = BuildFlmRequiredExtention(x509Certificate2);
            WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\FacilityListMessageRequiredExtention.xml");
            xmlSerializer = new XmlSerializer(typeof(FLMRequiredExtensionsType));
            xmlSerializer.Serialize(WriteFileStream, flmRequiredExtention);
            WriteFileStream.Close();

            AppendFLMRequiredExtension(extraTheatreMessage, flmRequiredExtention);
            WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\FaciltyListMessage.xml");
            xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
            xmlSerializer.Serialize(WriteFileStream, extraTheatreMessage);
            WriteFileStream.Close();

            SignETM(extraTheatreMessage, x509Certificate2);
            WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\FaciltyListMessage_Signed.xml");
            xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
            xmlSerializer.Serialize(WriteFileStream, extraTheatreMessage);
            WriteFileStream.Close();

            ServiceFacilityListMessageClient client = new ServiceFacilityListMessageClient();
            System.Console.WriteLine("Sending FLM: " + extraTheatreMessage.AuthenticatedPublic.MessageId);
            string result = client.FLM(extraTheatreMessage);
            System.Console.WriteLine(result);
        }

        static DCinemaSecurityMessageType BuildDCinemaSecurityMessage(X509Certificate2 x509Certificate2)
        {
            DCinemaSecurityMessageType dCinemaSecurityMessageType = new DCinemaSecurityMessageType();

            dCinemaSecurityMessageType.AuthenticatedPublic = new AuthenticatedPublicType();
            dCinemaSecurityMessageType.AuthenticatedPublic.Id = "AuthenticatedPublic.Id." + Guid.NewGuid().ToString();
            dCinemaSecurityMessageType.AuthenticatedPublic.MessageId = "urn:uuid:" + Guid.NewGuid().ToString();
            dCinemaSecurityMessageType.AuthenticatedPublic.MessageType = "http://www.smpte-ra.org/schemas/430-3/2006/ETM";
            dCinemaSecurityMessageType.AuthenticatedPublic.AnnotationText = new UserText();
            dCinemaSecurityMessageType.AuthenticatedPublic.AnnotationText.Value = "Empty Extra-Theatre Message";
            dCinemaSecurityMessageType.AuthenticatedPublic.AnnotationText.language = "en-us";
            dCinemaSecurityMessageType.AuthenticatedPublic.IssueDate = DateTime.Now;

            X509IssuerSerial issuerSerial = new X509IssuerSerial();
            issuerSerial.IssuerName = x509Certificate2.IssuerName.Name;
            issuerSerial.SerialNumber = x509Certificate2.SerialNumber;
            dCinemaSecurityMessageType.AuthenticatedPublic.Signer = issuerSerial;

            dCinemaSecurityMessageType.AuthenticatedPrivate = new AuthenticatedPrivateType();
            dCinemaSecurityMessageType.AuthenticatedPrivate.Id = "AuthenticatedPrivate.Id." + Guid.NewGuid().ToString();

            return dCinemaSecurityMessageType;
        }

        static FLMRequiredExtensionsType BuildFlmRequiredExtention(X509Certificate2 x509Certificate2)
        {
            FLMRequiredExtensionsType flmRequiredExtention = new FLMRequiredExtensionsType();

            flmRequiredExtention.FacilityInfo = new FLMRequiredExtensionsTypeFacilityInfo();
            flmRequiredExtention.FacilityInfo.AnnotationText = new UserTextType();
            flmRequiredExtention.FacilityInfo.AnnotationText.language = "en-us";
            flmRequiredExtention.FacilityInfo.AnnotationText.Value = "Example Facility List Message";
            flmRequiredExtention.FacilityInfo.FacilityName = new UserTextType();
            flmRequiredExtention.FacilityInfo.FacilityName.Value = "urn:x-facilityID:dcipllc.com:000000";
            flmRequiredExtention.FacilityInfo.UTCOffset = new UTCOffsetType();
            flmRequiredExtention.FacilityInfo.UTCOffset.Offset = "-05:00";

            flmRequiredExtention.SecurityDeviceList = new SecurityDeviceListType();

            CombinedType securityDevice = new CombinedType();

            securityDevice.KeyInfo = new KeyInfoType();
            securityDevice.KeyInfo.ItemsElementName = new ItemsChoiceType3[2];
            securityDevice.KeyInfo.ItemsElementName[0] = ItemsChoiceType3.KeyName;
            securityDevice.KeyInfo.ItemsElementName[1] = ItemsChoiceType3.X509Data;
            securityDevice.KeyInfo.Items = new object[2];
            securityDevice.KeyInfo.Items[0] = x509Certificate2.IssuerName.Name;

            X509DataType x509Data = new X509DataType();
            x509Data.ItemsElementName = new ItemsChoiceType1[1];
            x509Data.ItemsElementName[0] = ItemsChoiceType1.X509Certificate;
            x509Data.Items = new object[1];
            x509Data.Items[0] = x509Certificate2.RawData;

            securityDevice.KeyInfo.Items[1] = x509Data;

            securityDevice.DeviceDescription = new deviceDescriptionType();
            securityDevice.DeviceDescription.DeviceIdentifier = new deviceIdentifierPolyType();
            securityDevice.DeviceDescription.DeviceIdentifier.idtype = new deviceIdentifierPolyTypeIdtype();
            securityDevice.DeviceDescription.DeviceIdentifier.idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            securityDevice.DeviceDescription.DeviceIdentifier.Value = "urn:uid:" + Guid.Empty;
            securityDevice.DeviceDescription.DeviceTypeID = new deviceTypeType();
            securityDevice.DeviceDescription.DeviceTypeID.scope = "http://www.dcipllc.com/schemas/430-7/2009/FLM#deviceTypes";
            securityDevice.DeviceDescription.DeviceTypeID.Value = "SMS";
            securityDevice.DeviceDescription.DeviceSerial = "000000";
            securityDevice.DeviceDescription.ManufacturerName = "Doremi";
            securityDevice.DeviceDescription.ModelNumber = "DCP0000";
            securityDevice.DeviceDescription.DeviceComment = new UserTextType();
            securityDevice.DeviceDescription.DeviceComment.Value = "Not a Real Device";

            flmRequiredExtention.SecurityDeviceList.Items = new CertOnlyType[1];
            flmRequiredExtention.SecurityDeviceList.Items[0] = securityDevice;

            return flmRequiredExtention;
        }

        static DCinemaSecurityMessageType AppendFLMRequiredExtension(DCinemaSecurityMessageType extraTheatreMessage, FLMRequiredExtensionsType flmRequiredExtention)
        {
            DCinemaSecurityMessageType facilityListMessage = extraTheatreMessage;

            StringWriter stringWriter = new StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FLMRequiredExtensionsType));
            xmlSerializer.Serialize(stringWriter, flmRequiredExtention);
            string serializedXML = stringWriter.ToString();
            XmlDocument docFlmRequiredExtention = new XmlDocument();
            docFlmRequiredExtention.LoadXml(serializedXML);

            facilityListMessage.AuthenticatedPublic.RequiredExtensions = docFlmRequiredExtention.DocumentElement;

            extraTheatreMessage.AuthenticatedPublic.MessageType = "http://www.smpte-ra.org/schemas/430-7/2008/FLM";
            extraTheatreMessage.AuthenticatedPublic.AnnotationText.Value = "Test Facility List Message";

            return facilityListMessage;
        }

        static DCinemaSecurityMessageType SignETM(DCinemaSecurityMessageType extraTheatreMessage, X509Certificate2 x509Certificate2)
        {
            SignedXml signedXml = null;
            try
            {
                signedXml = new SignedXml();
                signedXml.SigningKey = x509Certificate2.PrivateKey;
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/ 2001/04/xmldsig-more#rsasha256";
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmlenc#sha256";
                signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments";

                StringWriter stringWriter = new StringWriter();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
                xmlSerializer.Serialize(stringWriter, extraTheatreMessage);
                string serializedXML = stringWriter.ToString();

                #region Build the AuthenticatedPublic DataObject & Reference

                string xmlAuthenticatedPublic = GetCleanElement(serializedXML, "AuthenticatedPublic");
                XmlDocument docAuthenticatedPublic = new XmlDocument();
                docAuthenticatedPublic.LoadXml(xmlAuthenticatedPublic.ToString());

                //XmlAttribute attrAuthenticatedPublic = docAuthenticatedPublic.CreateAttribute("xmlns");
                //attrAuthenticatedPublic.Value = "http://www.smpte-ra.org/schemas/430-3/2006/ETM";
                //docAuthenticatedPublic.DocumentElement.Attributes.Append(attrAuthenticatedPublic);

                DataObject dataObjectAuthenticatedPublic = new DataObject("AuthenticatedPublic", "", "", docAuthenticatedPublic.DocumentElement);
                //DataObject dataObjectAuthenticatedPublic = new DataObject();
                dataObjectAuthenticatedPublic.Data = docAuthenticatedPublic.ChildNodes;
                dataObjectAuthenticatedPublic.Id = "AuthenticatedPublic";

                signedXml.AddObject(dataObjectAuthenticatedPublic);

                Reference referenceAuthenticatedPublic = new Reference();
                referenceAuthenticatedPublic.Uri = "#AuthenticatedPublic";
                referenceAuthenticatedPublic.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";

                signedXml.AddReference(referenceAuthenticatedPublic);

                #endregion

                #region Build the AuthenticatedPublic DataObject & Reference

                string xmlAuthenticatedPrivate = GetCleanElement(serializedXML, "AuthenticatedPrivate");
                XmlDocument docAuthenticatedPrivate = new XmlDocument();
                docAuthenticatedPrivate.LoadXml(xmlAuthenticatedPrivate.ToString());

                //XmlAttribute attrAuthenticatedPrivate = docAuthenticatedPrivate.CreateAttribute("xmlns");
                //attrAuthenticatedPrivate.Value = "http://www.smpte-ra.org/schemas/430-3/2006/FLM";
                //docAuthenticatedPrivate.DocumentElement.Attributes.Append(attrAuthenticatedPrivate);

                DataObject dataObjectAuthenticatedPrivate = new DataObject("AuthenticatedPrivate", "", "", docAuthenticatedPrivate.DocumentElement);
                //DataObject dataObjectAuthenticatedPrivate = new DataObject("AuthenticatedPrivate", "", "", docAuthenticatedPrivate.DocumentElement);
                //dataObjectAuthenticatedPrivate.Data = docAuthenticatedPrivate.ChildNodes;
                //dataObjectAuthenticatedPrivate.Id = "AuthenticatedPrivate";

                signedXml.AddObject(dataObjectAuthenticatedPrivate);

                Reference referenceAuthenticatedPrivate = new Reference();
                referenceAuthenticatedPrivate.Uri = "#AuthenticatedPrivate";
                referenceAuthenticatedPrivate.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";

                // Add the reference to the message.
                signedXml.AddReference(referenceAuthenticatedPrivate);

                #endregion

                // Add a KeyInfo.
                KeyInfo keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(x509Certificate2, X509IncludeOption.WholeChain));
                signedXml.KeyInfo = keyInfo;

                // Compute the signature.
                signedXml.ComputeSignature();

                XmlElement singedElement = signedXml.GetXml();
                XmlSerializer signedSerializer = new XmlSerializer(singedElement.GetType());
                StreamWriter signedWriter = new StreamWriter(@"\SOURCE_SMPTE\Output\signedSerializer.Test.xml");
                signedSerializer.Serialize(signedWriter, singedElement);
                signedWriter.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

            extraTheatreMessage.Signature = signedXml.Signature.GetXml();

            return extraTheatreMessage;
        }

        static X509Certificate2 GetCertificate(string serialNumber, StoreLocation storeLocation)
        {
            X509Certificate2 x509Certificate2 = null;

            try
            {
                X509Store store = new X509Store(storeLocation);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;

                X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindBySerialNumber, serialNumber, false);
                if (fcollection.Count > 0)
                {
                    x509Certificate2 = fcollection[0];

                    Console.WriteLine("Certificate Data: ******************************************************************");

                    byte[] rawdata = x509Certificate2.RawData;

                    Console.WriteLine("Content Type: {0}{1}", X509Certificate2.GetCertContentType(rawdata), Environment.NewLine);
                    Console.WriteLine("Friendly Name: {0}{1}", x509Certificate2.FriendlyName, Environment.NewLine);
                    Console.WriteLine("Certificate Verified?: {0}{1}", x509Certificate2.Verify(), Environment.NewLine);
                    Console.WriteLine("Simple Name: {0}{1}", x509Certificate2.GetNameInfo(X509NameType.SimpleName, true), Environment.NewLine);
                    Console.WriteLine("Signature Algorithm: {0}{1}", x509Certificate2.SignatureAlgorithm.FriendlyName, Environment.NewLine);
                    Console.WriteLine("Private Key: {0}{1}", x509Certificate2.PrivateKey.ToXmlString(false), Environment.NewLine);
                    Console.WriteLine("Public Key: {0}{1}", x509Certificate2.PublicKey.Key.ToXmlString(false), Environment.NewLine);
                    Console.WriteLine("Certificate Archived?: {0}{1}", x509Certificate2.Archived, Environment.NewLine);
                    Console.WriteLine("Issuer Name: {0}{1}", x509Certificate2.IssuerName.Name, Environment.NewLine);
                    Console.WriteLine("Subject Name: {0}{1}", x509Certificate2.SubjectName.Name, Environment.NewLine);
                    Console.WriteLine("Thumb Print: {0}{1}", x509Certificate2.Thumbprint, Environment.NewLine);
                    Console.WriteLine("Serial Number: {0}{1}", x509Certificate2.GetSerialNumberString(), Environment.NewLine);

                    Console.WriteLine("Length of Raw Data: {0}{1}", x509Certificate2.RawData.Length, Environment.NewLine);

                }
                else
                {
                    Console.WriteLine("Error: Certificate '" + serialNumber + "' not found.");
                    Console.WriteLine("Number of certificates in store: {0}{1}", collection.Count, Environment.NewLine);
                    foreach (X509Certificate2 x509 in collection)
                    {
                        Console.WriteLine("Certificate Data: ******************************************************************");

                        byte[] rawdata = x509.RawData;

                        Console.WriteLine("Content Type: {0}{1}", X509Certificate2.GetCertContentType(rawdata), Environment.NewLine);
                        Console.WriteLine("Friendly Name: {0}{1}", x509.FriendlyName, Environment.NewLine);
                        Console.WriteLine("Certificate Verified?: {0}{1}", x509.Verify(), Environment.NewLine);
                        Console.WriteLine("Simple Name: {0}{1}", x509.GetNameInfo(X509NameType.SimpleName, true), Environment.NewLine);
                        Console.WriteLine("Signature Algorithm: {0}{1}", x509.SignatureAlgorithm.FriendlyName, Environment.NewLine);
                        Console.WriteLine("Private Key: {0}{1}", x509.PrivateKey.ToXmlString(false), Environment.NewLine);
                        Console.WriteLine("Public Key: {0}{1}", x509.PublicKey.Key.ToXmlString(false), Environment.NewLine);
                        Console.WriteLine("Certificate Archived?: {0}{1}", x509.Archived, Environment.NewLine);
                        Console.WriteLine("Issuer Name: {0}{1}", x509.IssuerName.Name, Environment.NewLine);
                        Console.WriteLine("Subject Name: {0}{1}", x509.SubjectName.Name, Environment.NewLine);
                        Console.WriteLine("Thumb Print: {0}{1}", x509.Thumbprint, Environment.NewLine);
                        Console.WriteLine("Serial Number: {0}{1}", x509.GetSerialNumberString(), Environment.NewLine);

                        Console.WriteLine("Length of Raw Data: {0}{1}", x509.RawData.Length, Environment.NewLine);

                        x509.Reset();
                    }
                }
                store.Close();
            }
            catch (CryptographicException eCrypt)
            {
                Console.WriteLine("Information could not be written out for this certificate: " + eCrypt.Message);
            }

            return x509Certificate2;
        }

        public static string GetCleanElement(string xmlDocument, string elementName)
        {
            string cleanElement = "";
            int elementStart = 0;
            int elementEnd = 0;

            elementStart = xmlDocument.IndexOf("<" + elementName);
            if (elementStart < 1)
                return cleanElement;

            elementEnd = xmlDocument.IndexOf("</" + elementName); // <elementName>...</elementName> format?
            if (elementEnd < 1) // <elementName ... /> format?
            {
                string elementFrom = xmlDocument.Substring(elementStart);
                int singleLineElementEnd = xmlDocument.IndexOf("/>", elementStart);
                if (singleLineElementEnd < 1)
                    return cleanElement;

                // make sure its not malformed XML
                int nextClosingBracket = xmlDocument.IndexOf(">", elementStart);
                if ((singleLineElementEnd + 1) != nextClosingBracket)
                    return cleanElement;

                elementEnd = singleLineElementEnd + 2;
            }
            else
            {
                elementEnd = xmlDocument.IndexOf(">", elementEnd) + 1;
                if (elementEnd < 1)
                    return cleanElement;
            }

            cleanElement = xmlDocument.Substring(elementStart, (elementEnd - elementStart));

            //remove the non-element white space
            cleanElement = cleanElement.Replace("\r", "");
            cleanElement = cleanElement.Replace("\n", "");
            while (cleanElement.Contains(">  "))
                cleanElement = cleanElement.Replace(">  ", ">");
            while (cleanElement.Contains("> "))
                cleanElement = cleanElement.Replace("> ", ">");

            return cleanElement;
        }    
    }
}
