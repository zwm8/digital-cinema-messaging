using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;

using System.Runtime.Serialization;

using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

using www.smpte.org.etm;
using System.IO;

namespace etm_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            X509Certificate2 x509Certificate2 = GetCertificate("990B25F50DC7E2B548BE75AFED579448");
            //X509Certificate2 x509Certificate2 = GetCertificate("0efb7eebdcda4f64a718db3ff908b085");
            //X509Certificate2 x509Certificate2 = GetCertificate("2E0A6058EA90DB8C46D1FD3513A877F8");

            DCinemaSecurityMessageType extraTheatreMessage = new DCinemaSecurityMessageType();
            XmlSerializer xmlSerializer = new XmlSerializer(extraTheatreMessage.GetType());

            extraTheatreMessage.AuthenticatedPublic = new AuthenticatedPublicType();
            extraTheatreMessage.AuthenticatedPublic.Id = "AuthenticatedPublic.Id." + Guid.NewGuid().ToString();
            extraTheatreMessage.AuthenticatedPublic.MessageId = "urn:uuid:" + Guid.NewGuid().ToString();
            extraTheatreMessage.AuthenticatedPublic.MessageType = "http://www.smpte-ra.org/schemas/430-3/2006/ETM";
            extraTheatreMessage.AuthenticatedPublic.AnnotationText = new UserText();
            extraTheatreMessage.AuthenticatedPublic.AnnotationText.Value = "Empty Extra-Theatre Message";
            extraTheatreMessage.AuthenticatedPublic.AnnotationText.language = "en-us";
            extraTheatreMessage.AuthenticatedPublic.IssueDate = DateTime.Now;

            X509IssuerSerial issuerSerial = new X509IssuerSerial();
            issuerSerial.IssuerName = x509Certificate2.IssuerName.Name;
            issuerSerial.SerialNumber = x509Certificate2.SerialNumber;
            extraTheatreMessage.AuthenticatedPublic.Signer = issuerSerial;

            extraTheatreMessage.AuthenticatedPrivate = new AuthenticatedPrivateType();
            extraTheatreMessage.AuthenticatedPrivate.Id = "AuthenticatedPrivate.Id." + Guid.NewGuid().ToString();

            #region Build the signature elements

            SignedXml signedXml = null;
            try
            {
                signedXml = new SignedXml();
                signedXml.SigningKey = x509Certificate2.PrivateKey;
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/ 2001/04/xmldsig-more#rsasha256";
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmlenc#sha256";
                signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments";

                StringWriter stringWriter = new StringWriter();
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
                StreamWriter signedWriter = new StreamWriter("D:\\signedSerializer.Test.xml");
                signedSerializer.Serialize(signedWriter, singedElement);
                signedWriter.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region Fill in the signature element

            extraTheatreMessage.Signature = signedXml.Signature.GetXml();

            #endregion

            xmlSerializer.Serialize(Console.Out, extraTheatreMessage);
            Console.WriteLine("\r\n");

            TextWriter WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\ExtraTheatreMessage.xml");
            xmlSerializer.Serialize(WriteFileStream, extraTheatreMessage);
            WriteFileStream.Close();

            ServiceExtraTheatreMessageClient client = new ServiceExtraTheatreMessageClient();
            string response = client.ETM(extraTheatreMessage);

            DCinemaSecurityMessageType existingETM = new DCinemaSecurityMessageType();

            TextReader readFileStream = new StreamReader(@"\Source_SMPTE\Input\DCinemaSecurityMessageType_AMC.xml");
            existingETM = (DCinemaSecurityMessageType)xmlSerializer.Deserialize(readFileStream);
            readFileStream.Close();

            existingETM.AuthenticatedPrivate = new AuthenticatedPrivateType();

            existingETM.Signature = signedXml.Signature.GetXml();

            WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\Read_ExtraTheatreMessage.xml");
            xmlSerializer.Serialize(WriteFileStream, existingETM);
            WriteFileStream.Close();

            response = client.ETM(existingETM);
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

        static X509Certificate2 GetCertificate(string serialNumber)
        {
            X509Certificate2Collection fcollection = null;
            X509Certificate2 x509Certificate2 = null;

            try
            {
                X509Store store = new X509Store(StoreLocation.CurrentUser);//.LocalMachine);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;

                fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindBySerialNumber, serialNumber, false);
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
    }
}
