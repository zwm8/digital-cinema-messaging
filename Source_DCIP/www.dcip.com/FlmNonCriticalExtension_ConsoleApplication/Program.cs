using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using www.dcipllc.com.flm_ext;
using www.smpte.org.dcmlTypes;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace FlmNonCriticalExtension_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            X509Certificate2 x509Certificate2 = GetCertificate("0EFB7EEBDCDA4F64A718DB3FF908B085", StoreLocation.CurrentUser); // *.dcipllc.com

            FLMNonCriticalExtensionsType flmNonCriticalExtension = new FLMNonCriticalExtensionsType();

            #region Device List

            flmNonCriticalExtension.DeviceList = new FLMNonCriticalExtensionsTypeDeviceList();
            flmNonCriticalExtension.DeviceList.Device = new DeviceType[2];

            Guid smsGuid = Guid.NewGuid();
            flmNonCriticalExtension.DeviceList.Device[0] = new DeviceType();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription = new deviceDescriptionType();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceIdentifier = new deviceIdentifierPolyType();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceIdentifier.idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceIdentifier.Value = "urn:uid:" + smsGuid.ToString();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceTypeID = new deviceTypeType();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceTypeID.scope = "http://www.dcipllc.com/schemas/430-7/2009/FLM#deviceTypes";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceTypeID.Value = "SMS";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceSerial = "000000";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.ManufacturerName = "Doremi";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.ModelNumber = "DCP0000";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceComment = new UserTextType();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceDescription.DeviceComment.Value = "Not a Real Device";

            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList = new DeviceTypeDeviceAttributeList();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList.DeviceAttribute = new AttributeType[2];
            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList.DeviceAttribute[0] = new AttributeType();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList.DeviceAttribute[0].Name = "Ghostbusting";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList.DeviceAttribute[0].Value = "Installed";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList.DeviceAttribute[1] = new AttributeType();
            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList.DeviceAttribute[1].Name = "Storage";
            flmNonCriticalExtension.DeviceList.Device[0].DeviceAttributeList.DeviceAttribute[1].Value = "2TB";

            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList = new DeviceTypeIPAddressList();
            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList.IPAddress = new IPAddressType[2];
            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList.IPAddress[0] = new IPAddressType();
            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList.IPAddress[0].Address = "127.0.0.1";
            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList.IPAddress[0].Host = "localhost";
            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList.IPAddress[1] = new IPAddressType();
            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList.IPAddress[1].Address = "192.168.1.1";
            flmNonCriticalExtension.DeviceList.Device[0].IPAddressList.IPAddress[1].Host = "private.IPv4.network";

            flmNonCriticalExtension.DeviceList.Device[0].InstallDate = DateTime.Now;

            flmNonCriticalExtension.DeviceList.Device[0].DecommissionDateSpecified = true;
            flmNonCriticalExtension.DeviceList.Device[0].DecommissionDate = DateTime.Now;

            flmNonCriticalExtension.DeviceList.Device[0].IsActive = true;

            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList = new DeviceTypeSoftwareList();
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software = new SoftwareType[2];
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[0] = new SoftwareType();
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[0].SoftwareProducer = "Doremi";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[0].Description = "Playback Engine";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[0].Version = "0.0.1";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[0].FileName = "playback.dll";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[0].FileSize = 123456;
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[0].FileDateTime = DateTime.Now;
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[1] = new SoftwareType();
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[1].SoftwareProducer = "Doremi";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[1].Description = "Security Log Generator";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[1].Version = "0.0.1";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[1].FileName = "securitylog.dll";
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[1].FileSize = 123456;
            flmNonCriticalExtension.DeviceList.Device[0].SoftwareList.Software[1].FileDateTime = DateTime.Now;

            flmNonCriticalExtension.DeviceList.Device[0].OtherSecurity = new object[2];
            flmNonCriticalExtension.DeviceList.Device[0].OtherSecurity[0] = new SecurityTypeWatermarkingList[1];
            SecurityTypeWatermarkingList waterMarkingList = new SecurityTypeWatermarkingList();
            waterMarkingList.Watermarking = new SecurityTypeWatermarkingListWatermarking[1];
            waterMarkingList.Watermarking[0] = new SecurityTypeWatermarkingListWatermarking();
            waterMarkingList.Watermarking[0].WatermarkManufacturer = "Thompson";
            waterMarkingList.Watermarking[0].WatermarkModel = "SMS";
            waterMarkingList.Watermarking[0].WatermarkVersion = "0.0.1";
            flmNonCriticalExtension.DeviceList.Device[0].OtherSecurity[0] = waterMarkingList;
            SecurityTypeCertificateList smsCertificateList = new SecurityTypeCertificateList();
            smsCertificateList.Certificate = new SecurityTypeCertificateListCertificate[1];
            smsCertificateList.Certificate[0] = new SecurityTypeCertificateListCertificate();
            smsCertificateList.Certificate[0].CertificateClass = "Signature";
            smsCertificateList.Certificate[0].X509Certificate = x509Certificate2.GetRawCertData();
            flmNonCriticalExtension.DeviceList.Device[0].OtherSecurity[1] = smsCertificateList;

            Guid tmsGuid = Guid.NewGuid();
            flmNonCriticalExtension.DeviceList.Device[1] = new DeviceType();
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription = new deviceDescriptionType();
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceIdentifier = new deviceIdentifierPolyType();
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceIdentifier.idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceIdentifier.Value = "urn:uid:" + tmsGuid;
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceTypeID = new deviceTypeType();
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceTypeID.scope = "http://www.dcipllc.com/schemas/430-7/2009/FLM#deviceTypes";
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceTypeID.Value = "TMS";
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceSerial = "000001";
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.ManufacturerName = "Doremi";
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.ModelNumber = "DCP0001";
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceComment = new UserTextType();
            flmNonCriticalExtension.DeviceList.Device[1].DeviceDescription.DeviceComment.Value = "Not a Real Device";

            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList = new DeviceTypeIPAddressList();
            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList.IPAddress = new IPAddressType[2];
            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList.IPAddress[0] = new IPAddressType();
            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList.IPAddress[0].Address = "127.0.0.1";
            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList.IPAddress[0].Host = "localhost";
            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList.IPAddress[1] = new IPAddressType();
            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList.IPAddress[1].Address = "192.168.1.2";
            flmNonCriticalExtension.DeviceList.Device[1].IPAddressList.IPAddress[1].Host = "private.IPv4.network";

            flmNonCriticalExtension.DeviceList.Device[1].InstallDate = DateTime.Now;
            flmNonCriticalExtension.DeviceList.Device[1].IsActive = true;

            flmNonCriticalExtension.DeviceList.Device[1].OtherSecurity = new object[1];
            flmNonCriticalExtension.DeviceList.Device[1].OtherSecurity[0] = new SecurityTypeCertificateList[1];
            SecurityTypeCertificateList tmsCertificateList = new SecurityTypeCertificateList();
            tmsCertificateList.Certificate = new SecurityTypeCertificateListCertificate[1];
            tmsCertificateList.Certificate[0] = new SecurityTypeCertificateListCertificate();
            tmsCertificateList.Certificate[0].CertificateClass = "PublicKey";
            tmsCertificateList.Certificate[0].X509Certificate = x509Certificate2.GetPublicKey();
            flmNonCriticalExtension.DeviceList.Device[1].OtherSecurity[0] = tmsCertificateList;

            #endregion

            #region Facility Information

            flmNonCriticalExtension.NonCriticalFacilityInfo = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfo();
            flmNonCriticalExtension.NonCriticalFacilityInfo.Circuit = "anyCircuit";
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoDistributionCapabilitiyList();
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability = new CapabilityType[2];
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[0] = new CapabilityType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[0].Method = "Satellite";
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[0].Provider = "SatService";
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[0].Detail = "Dish on Roof";
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[1] = new CapabilityType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[1].Method = "Internet";
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[1].Provider = "InternetService";
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList.Capability[1].Detail = "T1";
            flmNonCriticalExtension.NonCriticalFacilityInfo.TotalScreenCount = 2;
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityName = "AnyFacility";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoAddressList();
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address = new AddressType[2];
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0] = new AddressType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].AddressClass = AddressClassType.PHYSICAL;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].StreetAddress = "111 Main Street";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].City = "Any City";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].State = "Any State";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].PostalCode = "Any Postal Code";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].Country = "Any Country";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[1] = new AddressType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[1].AddressClass = AddressClassType.SHIPPING;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[1].StreetAddress = "112 Main Street";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[1].City = "Any City";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[1].State = "Any State";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[1].PostalCode = "Any Postal Code";
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[1].Country = "Any Country";
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityUriList = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityUriList();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityUriList.FacilityUri = new string[1];
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityUriList.FacilityUri[0] = "urn:x-facilityID:dcipllc.com:256";
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityDeviceList = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityDeviceList();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityDeviceList.DeviceIdentifier = new deviceIdentifierPolyType[1];
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityDeviceList.DeviceIdentifier[0] = new deviceIdentifierPolyType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityDeviceList.DeviceIdentifier[0].idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityDeviceList.DeviceIdentifier[0].Value = "urn:uid:" + tmsGuid.ToString();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityAttributeList();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList.FacilityAttribute = new AttributeType[2];
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList.FacilityAttribute[0] = new AttributeType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList.FacilityAttribute[0].Name = "Elevator";
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList.FacilityAttribute[0].Value = "4' x 6' x 10' Tall";
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList.FacilityAttribute[1] = new AttributeType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList.FacilityAttribute[1].Name = "Loading Dock";
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityAttributeList.FacilityAttribute[1].Value = "North Side";
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityTimeZone = "CST";

            #endregion

            #region Auditorium Information

            flmNonCriticalExtension.NonCriticalAuditoriumInfo = new FLMNonCriticalExtensionsTypeNonCriticalAuditoriumInfo();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium = new AuditoriumType[1];
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0] = new AuditoriumType();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumNumber = 1;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumDeviceList = new AuditoriumTypeAuditoriumDeviceList();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumDeviceList.DeviceIdentifier = new deviceIdentifierPolyType[1];
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumDeviceList.DeviceIdentifier[0] = new deviceIdentifierPolyType();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumDeviceList.DeviceIdentifier[0].idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumDeviceList.DeviceIdentifier[0].Value = "urn:uid:" + smsGuid.ToString();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem = new Digital3DSystemType();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.IsActive = false;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.Digital3DConfiguration = "RealD";
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.InstallDateSpecified = true;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.InstallDate = DateTime.Now;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.DecommissionDateSpecified = true;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.DecommissionDate = DateTime.Now;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.ScreenColorSpecified = true;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.ScreenColor = ScreenColorType.WHITE;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.GhostbustingSpecified = true;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.Ghostbusting = true;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Digital3DSystem.GhostbustingConfiguration = "In Server";
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].ServiceProvider = "DCIP";
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].InstallationId = Guid.NewGuid().ToString();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList = new AuditoriumTypeAuditoriumAttributeList();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList.AuditoriumAttribute = new AttributeType[2];
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList.AuditoriumAttribute[0] = new AttributeType();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList.AuditoriumAttribute[0].Name = "Masking";
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList.AuditoriumAttribute[0].Value = "Side";
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList.AuditoriumAttribute[1] = new AttributeType();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList.AuditoriumAttribute[1].Name = "Audio";
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumAttributeList.AuditoriumAttribute[1].Value = "Dolby 5.1";
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumInstallationDateSpecified = true;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].AuditoriumInstallationDate = System.DateTime.UtcNow;
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[0].Integrator = "DCIP";

            #endregion

            TextWriter WriteFileStream = new StreamWriter(@"\Source_SMPTE\Output\FLMNonCriticalExtension.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FLMNonCriticalExtensionsType));
            xmlSerializer.Serialize(WriteFileStream, flmNonCriticalExtension);
            WriteFileStream.Close();
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
    }
}
