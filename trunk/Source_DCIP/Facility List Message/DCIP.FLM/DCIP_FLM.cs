using System;
using System.Collections;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using www.dcipllc.com.flm_ext;

using www.smpte.org.dcmlTypes;
using www.smpte.org.etm;
using www.smpte.org.flm;

namespace DCIP.FLM
{
    public class FacilityListMessageUtilities
    {
        public static XmlDocument FLM_Create(int DcipSiteIdentifier, X509Certificate2 x509Certificate2, string ConnectionString)
        {
            #region Set up the AMS data connection
            AMS_DataClassesDataContext amsData = null;
            try
            {
                amsData = new AMS_DataClassesDataContext(ConnectionString);
            }
            catch (Exception e)
            {
                throw new Exception("Could not connect to the database", e);
            }
            #endregion

            #region Build the core DCinemaSecurityMessage
            DCinemaSecurityMessageType extraTheatreMessage = null;
            try
            {
                extraTheatreMessage = BuildDCinemaSecurityMessage(x509Certificate2);
            }
            catch (Exception e)
            {
                throw new Exception("Error building base FLM", e);
            }
            #endregion

            #region Get AMS RequiredExtension data
            ISingleResult<flm_GetFacilityInfoResult> facilityInfo = null;
            try
            {
                facilityInfo = amsData.flm_GetFacilityInfo(DcipSiteIdentifier);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get required extension data", e);
            }

            ISingleResult<flm_GetFacilitySecureEquipmentResult> facilitySecureDevices = null;
            ArrayList secureDeviceArray = null;
            try
            {
                facilitySecureDevices = amsData.flm_GetFacilitySecureEquipment(DcipSiteIdentifier);
                secureDeviceArray = new ArrayList();
                foreach (flm_GetFacilitySecureEquipmentResult secureDevice in facilitySecureDevices)
                    secureDeviceArray.Add(secureDevice);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get facility secure devices", e);
            }
            #endregion

            #region Build and attach the RequiredExtension
            FLMRequiredExtensionsType flmRequiredExtention = null;
            try
            {
                flmRequiredExtention = BuildFlmRequiredExtention(x509Certificate2, facilityInfo, secureDeviceArray);
                AppendFLMRequiredExtension(extraTheatreMessage, flmRequiredExtention);
            }
            catch (Exception e)
            {
                throw new Exception("Could not build the Requred Extension", e);
            }
            #endregion

            #region Sign the DCinemaSecurityMessage
            try
            {
                SignETM(extraTheatreMessage, x509Certificate2);
                RemoveSignatureObjects(extraTheatreMessage);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to sign Facility List Message", e);
            }
            #endregion

            #region Write the Extra Theatre Message to xmlDocument
            XmlSerializer xmlSerializer = new XmlSerializer(extraTheatreMessage.GetType());
            MemoryStream memStream = new MemoryStream();
            xmlSerializer.Serialize(memStream, extraTheatreMessage);
            memStream.Seek(0, System.IO.SeekOrigin.Begin);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(memStream);
            memStream.Close();
            #endregion

            return xmlDocument;
        }

        public static XmlDocument FLMEXT_Create(int DcipSiteIdentifier, X509Certificate2 x509Certificate2, string ConnectionString)
        {
            XmlDocument xmlDocument = new XmlDocument();

            #region Set up the AMS data connection
            AMS_DataClassesDataContext amsData = null;
            try
            {
                amsData = new AMS_DataClassesDataContext(ConnectionString);
            }
            catch (Exception e)
            {
                throw new Exception("Could not connect to the database", e);
            }
            #endregion

            #region Build the core DCinemaSecurityMessage
            DCinemaSecurityMessageType extraTheatreMessage = null;
            try
            {
                extraTheatreMessage = BuildDCinemaSecurityMessage(x509Certificate2);
            }
            catch (Exception e)
            {
                throw new Exception("Error building base FLM", e);
            }
            #endregion

            #region Get AMS RequiredExtension data
            ISingleResult<flm_GetFacilityInfoResult> facilityInfo = null;
            try
            {
                facilityInfo = amsData.flm_GetFacilityInfo(DcipSiteIdentifier);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get required extension data", e);
            }

            ISingleResult<flm_GetFacilitySecureEquipmentResult> facilitySecureDevices = null;
            ArrayList secureDeviceArray = null;
            try
            {
                facilitySecureDevices = amsData.flm_GetFacilitySecureEquipment(DcipSiteIdentifier);
                secureDeviceArray = new ArrayList();
                foreach (flm_GetFacilitySecureEquipmentResult secureDevice in facilitySecureDevices)
                    secureDeviceArray.Add(secureDevice);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get facility secure devices", e);
            }
            #endregion

            #region Build and attach the RequiredExtension
            FLMRequiredExtensionsType flmRequiredExtention = null;
            try
            {
                flmRequiredExtention = BuildFlmRequiredExtention(x509Certificate2, facilityInfo, secureDeviceArray);
                AppendFLMRequiredExtension(extraTheatreMessage, flmRequiredExtention);
            }
            catch (Exception e)
            {
                throw new Exception("Could not build the Requred Extension", e);
            }
            #endregion

            #region Build the Non-Critical Extension with the Device Array
            ArrayList deviceArray = null;
            try
            {
                ISingleResult<flm_GetFacilityDeviceListResult> facilityDevices = amsData.flm_GetFacilityDeviceList(DcipSiteIdentifier);
                deviceArray = new ArrayList();
                foreach (flm_GetFacilityDeviceListResult device in facilityDevices)
                    deviceArray.Add(device);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get facility devices", e);
            }

            FLMNonCriticalExtensionsType flmNonCriticalExtension = null;
            try
            {
                flmNonCriticalExtension = BuildFlmNonCriticalExtention(deviceArray);
            }
            catch (Exception e)
            {
                throw new Exception("Could not build Non-Critical Extension", e);
            }

            try
            {
                AppendFLMNonCriticalExtension(extraTheatreMessage, flmNonCriticalExtension);
            }
            catch (Exception e)
            {
                throw new Exception("Could not update Non-Critical Extension", e);
            }
            #endregion

            #region Build and add the NonCriticalFacilityInfo
            ISingleResult<flm_GetNonCriticalFacilityInfoResult> nonCriticalFacilityInfoData = null;
            ArrayList nonCriticalFacilityInfoList = null;
            try
            {
                nonCriticalFacilityInfoData = amsData.flm_GetNonCriticalFacilityInfo(DcipSiteIdentifier);
                nonCriticalFacilityInfoList = new ArrayList();
                foreach (flm_GetNonCriticalFacilityInfoResult NonCriticalFacilityInfoResultRow in nonCriticalFacilityInfoData)
                    nonCriticalFacilityInfoList.Add(NonCriticalFacilityInfoResultRow);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get Non-Critical Facility Information", e);
            }

            flm_GetNonCriticalFacilityInfoResult nonCriticalFacilityInfoResult = (flm_GetNonCriticalFacilityInfoResult)nonCriticalFacilityInfoList[0];

            flmNonCriticalExtension.NonCriticalFacilityInfo = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfo();
            flmNonCriticalExtension.NonCriticalFacilityInfo.Circuit = nonCriticalFacilityInfoResult.Exhibitor_Name;
            flmNonCriticalExtension.NonCriticalFacilityInfo.DistributionCapabilitiyList = null;
            flmNonCriticalExtension.NonCriticalFacilityInfo.TotalScreenCount = nonCriticalFacilityInfoResult.TotalScreenCount.Value;
            flmNonCriticalExtension.NonCriticalFacilityInfo.TotalScreenCountSpecified = true;
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityName = nonCriticalFacilityInfoResult.Site_Name;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoAddressList();
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address = new AddressType[1];
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0] = new AddressType();
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].AddressClass = AddressClassType.PHYSICAL;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].StreetAddress = nonCriticalFacilityInfoResult.Street_1;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].City = nonCriticalFacilityInfoResult.City;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].State = nonCriticalFacilityInfoResult.State;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].PostalCode = nonCriticalFacilityInfoResult.Zip_Code;
            flmNonCriticalExtension.NonCriticalFacilityInfo.AddressList.Address[0].Country = nonCriticalFacilityInfoResult.Nation;

            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityUriList = new FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityUriList();
            flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityUriList.FacilityUri = new string[nonCriticalFacilityInfoList.Count];
            int faciltyInfoIndex = 0;
            foreach (flm_GetNonCriticalFacilityInfoResult FacilityInfo in nonCriticalFacilityInfoList)
            {
                if(FacilityInfo.Alternate_Identifier.Length > 1)
                    flmNonCriticalExtension.NonCriticalFacilityInfo.FacilityUriList.FacilityUri[faciltyInfoIndex] = "urn:x-facilityID:" + FacilityInfo.Authoritative_Source_Name.Replace(" ","") + ":" + FacilityInfo.Alternate_Identifier;
                faciltyInfoIndex++;
            }


            #endregion

            #region Get the Non-Critical Auditorium Information
            ISingleResult<flm_GetNonCriticalAuditoriumInfoResult> nonCriticalAuditoriumInfoData = null;
            ArrayList auditoriumArray = null;
            try
            {
                nonCriticalAuditoriumInfoData = amsData.flm_GetNonCriticalAuditoriumInfo(DcipSiteIdentifier);
                auditoriumArray = new ArrayList();
                foreach (flm_GetNonCriticalAuditoriumInfoResult nonCriticalAuditorimInfoRow in nonCriticalAuditoriumInfoData)
                    auditoriumArray.Add(nonCriticalAuditorimInfoRow);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get Non-Critical Auditorium Information", e);
            }
            #endregion

            #region Add the Non-Critial Auditorium Information
            flmNonCriticalExtension.NonCriticalAuditoriumInfo = new FLMNonCriticalExtensionsTypeNonCriticalAuditoriumInfo();
            flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium = new AuditoriumType[auditoriumArray.Count];

            int auditoriumIndex = 0;
            foreach (flm_GetNonCriticalAuditoriumInfoResult auditorium in auditoriumArray)
            {
                flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex] = new AuditoriumType();

                flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].AuditoriumNumber = (int)auditorium.Auditorium_Code;

                if (auditorium.Auditorium_3D.Value)
                {
                    flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem = new Digital3DSystemType();
                    //flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.IsActive = auditorium.Acceptance_Date;
                    flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.Digital3DConfiguration = auditorium.Type_Description;
                    flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.InstallDate = auditorium.Date_3D_Conversion.Value;
                    //flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.DecommissionDate = auditorium.
                    if(auditorium.Silver_Screen.Value)
                        flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.ScreenColor = ScreenColorType.SILVER;
                    else
                        flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.ScreenColor = ScreenColorType.WHITE;
                    //flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.Ghostbusting
                    //flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Digital3DSystem.GhostbustingConfiguration
                }

                if (auditorium.Acceptance_Date.HasValue)
                {
                    flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].AuditoriumInstallationDate = auditorium.Acceptance_Date.Value;
                }

                if ((auditorium.Auditorium_IMAX.HasValue) && (auditorium.Auditorium_IMAX.Value))
                {
                    flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Integrator = "IMAX";
                }
                else if((auditorium.Conversion.HasValue) && (auditorium.Conversion.Value))
                {
                    flmNonCriticalExtension.NonCriticalAuditoriumInfo.Auditorium[auditoriumIndex].Integrator = "DCIP";
                }

                auditoriumIndex++;
            }
            #endregion

            #region Add the Non-Critical Extension to the Facility List Message
            try
            {
                AppendFLMNonCriticalExtension(extraTheatreMessage, flmNonCriticalExtension);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to add the Non-Critical Extension to the Facility List Message", e);
            }
            #endregion

            #region Sign the DCinemaSecurityMessage
            try
            {
                SignETM(extraTheatreMessage, x509Certificate2);
                RemoveSignatureObjects(extraTheatreMessage);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to sign Facility List Message", e);
            }
            #endregion

            #region Write the Extra Theatre Message to xmlDocument
            XmlSerializer xmlSerializer = new XmlSerializer(extraTheatreMessage.GetType());
            MemoryStream memStream = new MemoryStream();
            xmlSerializer.Serialize(memStream, extraTheatreMessage);
            memStream.Seek(0, System.IO.SeekOrigin.Begin);
            xmlDocument = new XmlDocument();
            xmlDocument.Load(memStream);
            memStream.Close();
            #endregion

            return xmlDocument;
        }

        public static XmlDocument FLM_Sign(XmlDocument facilityListMessage, X509Certificate2 x509Certificate2)
        {
            MemoryStream memStream = null;
            XmlSerializer xmlSerializer = null;

            #region Convert the facilityListMessage [XmlDocument] to DCinemaSecurityMessageType
            DCinemaSecurityMessageType extraTheatreMessage = null;
            try
            {
                memStream = new MemoryStream();
                facilityListMessage.Save(memStream);
                memStream.Seek(0, System.IO.SeekOrigin.Begin);
                xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
                extraTheatreMessage = (DCinemaSecurityMessageType)xmlSerializer.Deserialize(memStream);
            }
            catch (XmlException xe)
            {
                Exception throwException = new Exception("Error reading the Facility List Message", xe);
                throw (throwException);
            }
            catch (InvalidOperationException ioe)
            {
                Exception throwException = new Exception("Error building DCinema Security Element", ioe);
                throw (throwException);
            }
            catch (Exception e)
            {
                Exception throwException = new Exception("General Error building DCinema Security Element", e);
                throw (throwException);
            }
            finally
            {
                memStream.Close();
            }
            #endregion

            #region Sign the DCinemaSecurityMessage
            try
            {
                SignETM(extraTheatreMessage, x509Certificate2);
                RemoveSignatureObjects(extraTheatreMessage);
            }
            catch (Exception e)
            {
                Exception throwException = new Exception("General Error signing the DCinema Security Element", e);
                throw (throwException);
            }
            #endregion

            #region Update the Issuer
            X509IssuerSerial issuerSerial = new X509IssuerSerial();
            try
            {
                issuerSerial.IssuerName = x509Certificate2.IssuerName.Name;
                issuerSerial.SerialNumber = x509Certificate2.SerialNumber;
                extraTheatreMessage.AuthenticatedPublic.Signer = issuerSerial;
            }
            catch (Exception e)
            {
                Exception throwException = new Exception("General Error adding Issuer to DCinema Security Element", e);
                throw (throwException);
            }
            #endregion
            
            #region Write the Extra Theatre Message to xmlDocument
            XmlDocument xmlDocument = null;
            try
            {
                xmlSerializer = new XmlSerializer(extraTheatreMessage.GetType());
                memStream = new MemoryStream();
                xmlSerializer.Serialize(memStream, extraTheatreMessage);
                memStream.Seek(0, System.IO.SeekOrigin.Begin);
                xmlDocument = new XmlDocument();
                xmlDocument.Load(memStream);
            }
            catch (XmlException xe)
            {
                Exception throwException = new Exception("Error reading the Facility List Message", xe);
                throw (throwException);
            }
            catch (InvalidOperationException ioe)
            {
                Exception throwException = new Exception("Error building DCinema Security Element", ioe);
                throw (throwException);
            }
            catch (Exception e)
            {
                Exception throwException = new Exception("General Error building DCinema Security Element", e);
                throw (throwException);
            }
            finally
            {
                memStream.Close();
            }
            #endregion

            return xmlDocument;
        }

        static private DCinemaSecurityMessageType BuildDCinemaSecurityMessage(X509Certificate2 x509Certificate2)
        {
            DCinemaSecurityMessageType dCinemaSecurityMessageType = new DCinemaSecurityMessageType();

            dCinemaSecurityMessageType.AuthenticatedPublic = new AuthenticatedPublicType();
            dCinemaSecurityMessageType.AuthenticatedPublic.Id = "AuthenticatedPublic.Id." + Guid.NewGuid().ToString();
            dCinemaSecurityMessageType.AuthenticatedPublic.MessageId = "urn:uuid:" + Guid.NewGuid().ToString();
            dCinemaSecurityMessageType.AuthenticatedPublic.MessageType = "http://www.smpte-ra.org/schemas/430-3/2006/ETM";
            dCinemaSecurityMessageType.AuthenticatedPublic.IssueDate = DateTime.Now;

            X509IssuerSerial issuerSerial = new X509IssuerSerial();
            issuerSerial.IssuerName = x509Certificate2.IssuerName.Name;
            issuerSerial.SerialNumber = x509Certificate2.SerialNumber;
            dCinemaSecurityMessageType.AuthenticatedPublic.Signer = issuerSerial;

            dCinemaSecurityMessageType.AuthenticatedPrivate = new AuthenticatedPrivateType();
            dCinemaSecurityMessageType.AuthenticatedPrivate.Id = "AuthenticatedPrivate.Id." + Guid.NewGuid().ToString();

            return dCinemaSecurityMessageType;
        }

        static private FLMRequiredExtensionsType BuildFlmRequiredExtention(X509Certificate2 x509Certificate2, ISingleResult<flm_GetFacilityInfoResult> facilityInfoCollection, ArrayList secureDeviceArray)
        {
            FLMRequiredExtensionsType flmRequiredExtention = new FLMRequiredExtensionsType();

            flm_GetFacilityInfoResult facilityInfo = facilityInfoCollection.First();

            #region Build the FacilityInfo element
            flmRequiredExtention.FacilityInfo = new FLMRequiredExtensionsTypeFacilityInfo();
            flmRequiredExtention.FacilityInfo.FacilityID = "urn:x-facilityID:" + facilityInfo.URI_Mapping + ":" + facilityInfo.Site_Code.ToString();
            flmRequiredExtention.FacilityInfo.AnnotationText = new UserTextType();
            flmRequiredExtention.FacilityInfo.AnnotationText.language = "en-us";
            flmRequiredExtention.FacilityInfo.AnnotationText.Value = "FLM for site " + facilityInfo.Site_Name;
            flmRequiredExtention.FacilityInfo.FacilityName = new UserTextType();
            flmRequiredExtention.FacilityInfo.FacilityName.Value = facilityInfo.Site_Name;

            #endregion

            #region Build the SecureDeviceList element
            flmRequiredExtention.SecurityDeviceList = new SecurityDeviceListType();

            ArrayList secureDeviceCombinedTypeArray = new ArrayList();

            flm_GetFacilitySecureEquipmentResult currentDevice = null;
            X509Certificate2 deviceCertificate = null;
            ArrayList versionInformation = null;
            foreach (flm_GetFacilitySecureEquipmentResult secureDevice in secureDeviceArray)
            {
                if ((null != currentDevice) && (currentDevice.Equipment_Id == secureDevice.Equipment_Id)) // It still the same device (get next version element)
                {
                    AddInfoType(versionInformation, secureDevice);
                    continue;
                }
                else // the next device in the list
                {
                    #region Add the last completed device to the array
                    if ((null != currentDevice) && (null != deviceCertificate))
                    {
                        CombinedType securityDevice = BuildSecurityDeviceCombinedType(currentDevice, versionInformation, deviceCertificate);
                        secureDeviceCombinedTypeArray.Add(securityDevice);
                    }
                    #endregion

                    currentDevice = null;
                    deviceCertificate = null;
                    versionInformation = null;

                    #region Get the serial number of the next device. Skip this device if we cannot get the serial number
                    if ((null == secureDevice.Serial_Number) || (secureDevice.Serial_Number.Length < 1))
                    {
                        continue;
                    }
                    #endregion

                    #region Get the certificate of the next device. Skip this device if we cannot get the certificate
                    string deviceCertificateChainString = secureDevice.Cert_String;
                    if (null == deviceCertificateChainString)
                    {
                        continue;
                    }

                    int certificateCount = X509Certificate_ClassLibrary.X509CertificateClassLibrary.GetBeginCertificateCount(deviceCertificateChainString);
                    if (certificateCount < 1)
                    {
                        continue;
                    }

                    string deviceCertificateString = X509Certificate_ClassLibrary.X509CertificateClassLibrary.GetBeginCertificate(0, deviceCertificateChainString);
                    if (null == deviceCertificateString)
                    {
                        continue;
                    }

                    deviceCertificate = X509Certificate_ClassLibrary.X509CertificateClassLibrary.BuildCertificate(deviceCertificateString);
                    if (null == deviceCertificate)
                    {
                        currentDevice = null;
                        continue;
                    }
                    #endregion

                    currentDevice = secureDevice;
                    versionInformation = new ArrayList();

                    AddInfoType(versionInformation, secureDevice);
                }
            }
            #endregion

            #region Add the Secure Device List to the Required Extention
            flmRequiredExtention.SecurityDeviceList.Items = new CombinedType[secureDeviceCombinedTypeArray.Count];
            int index = 0;
            foreach (CombinedType device in secureDeviceCombinedTypeArray)
            {
                flmRequiredExtention.SecurityDeviceList.Items[index] = device;
                index++;
            }
            #endregion

            return flmRequiredExtention;
        }
        static private CombinedType BuildSecurityDeviceCombinedType(flm_GetFacilitySecureEquipmentResult secureDevice, ArrayList versionInformation, X509Certificate2 deviceCertificate)
        {
            CombinedType securityDevice = new CombinedType();

            securityDevice.KeyInfo = new www.w3.org.dsig.KeyInfoType();
            securityDevice.KeyInfo.ItemsElementName = new www.w3.org.dsig.ItemsChoiceType3[2];
            securityDevice.KeyInfo.ItemsElementName[0] = www.w3.org.dsig.ItemsChoiceType3.KeyName;
            securityDevice.KeyInfo.ItemsElementName[1] = www.w3.org.dsig.ItemsChoiceType3.X509Data;
            securityDevice.KeyInfo.Items = new object[2];

            securityDevice.KeyInfo.Items[0] = deviceCertificate.GetNameInfo(X509NameType.SimpleName, false);

            www.w3.org.dsig.X509DataType x509Data = new www.w3.org.dsig.X509DataType();
            x509Data.ItemsElementName = new www.w3.org.dsig.ItemsChoiceType1[1];
            x509Data.ItemsElementName[0] = www.w3.org.dsig.ItemsChoiceType1.X509Certificate;
            x509Data.Items = new object[1];
            x509Data.Items[0] = deviceCertificate.RawData;

            securityDevice.KeyInfo.Items[1] = x509Data;
            securityDevice.DeviceDescription = new deviceDescriptionType();
            securityDevice.DeviceDescription.DeviceIdentifier = new deviceIdentifierPolyType();
            securityDevice.DeviceDescription.DeviceIdentifier.idtype = new deviceIdentifierPolyTypeIdtype();
            securityDevice.DeviceDescription.DeviceIdentifier.idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            if (null == secureDevice.UniqueIdentifier)
                securityDevice.DeviceDescription.DeviceIdentifier.Value = "urn:uid:" + Guid.Empty;
            else
                securityDevice.DeviceDescription.DeviceIdentifier.Value = "urn:uid:" + secureDevice.UniqueIdentifier.ToString();
            securityDevice.DeviceDescription.DeviceTypeID = new deviceTypeType();
            securityDevice.DeviceDescription.DeviceTypeID.scope = "http://www.dcipllc.com/schemas/430-7/2009/FLM#deviceTypes";
            if (null == secureDevice.FLM_DeviceType)
                securityDevice.DeviceDescription.DeviceTypeID.Value = "Other";
            else
                securityDevice.DeviceDescription.DeviceTypeID.Value = secureDevice.FLM_DeviceType;
            securityDevice.DeviceDescription.DeviceSerial = secureDevice.Serial_Number;
            if (null == secureDevice.Manufacturer_UniqueIdentifier)
                securityDevice.DeviceDescription.ManufacturerID = "urn:uid:" + Guid.Empty;
            else
                securityDevice.DeviceDescription.ManufacturerID = "urn:uid:" + secureDevice.Manufacturer_UniqueIdentifier.ToString();
            securityDevice.DeviceDescription.ManufacturerName = secureDevice.Manufacturer;
            securityDevice.DeviceDescription.ModelNumber = secureDevice.Model;

            securityDevice.DeviceDescription.VersionInfo = new versionInfoListType();
            securityDevice.DeviceDescription.VersionInfo.Items = new string[versionInformation.Count * 2];
            securityDevice.DeviceDescription.VersionInfo.ItemsElementName = new ItemsChoiceType[versionInformation.Count * 2];
            int indexVersion = 0;
            foreach (versionInfoListType versionInfo in versionInformation)
            {
                securityDevice.DeviceDescription.VersionInfo.Items[indexVersion] = versionInfo.Items[0];
                securityDevice.DeviceDescription.VersionInfo.ItemsElementName[indexVersion] = versionInfo.ItemsElementName[0];
                securityDevice.DeviceDescription.VersionInfo.Items[indexVersion + 1] = versionInfo.Items[1];
                securityDevice.DeviceDescription.VersionInfo.ItemsElementName[indexVersion + 1] = versionInfo.ItemsElementName[1];
                indexVersion += 2;
            }

            return securityDevice;
        }
        static private bool AddInfoType(ArrayList versionInformation, flm_GetFacilitySecureEquipmentResult secureDevice)
        {
            bool ValidVersionInfo = false;

            if ((null != secureDevice.Equipment_Attribute_Name) && // make sure the attribute is complete
                (secureDevice.Equipment_Attribute_Name.Length > 0) &&
                (null != secureDevice.Attribute_Value) &&
                (secureDevice.Attribute_Value.Length > 0))
            {
                if ((secureDevice.Equipment_Attribute_Name == "Hardware_Version") || // make sure it something we want
                    (secureDevice.Equipment_Attribute_Name == "Software_Version") ||
                    (secureDevice.Equipment_Attribute_Name == "Firmware_Version"))
                {
                    versionInfoListType infoType = new versionInfoListType();

                    infoType.ItemsElementName = new ItemsChoiceType[2];
                    infoType.ItemsElementName[0] = ItemsChoiceType.Name;
                    infoType.ItemsElementName[1] = ItemsChoiceType.Value;

                    infoType.Items = new string[2];
                    infoType.Items[0] = secureDevice.Equipment_Attribute_Name;
                    infoType.Items[1] = secureDevice.Attribute_Value;

                    ValidVersionInfo = true;
                    versionInformation.Add(infoType);
                }
            }

            return ValidVersionInfo;
        }
        private static deviceDescriptionType BuildSecureDeviceDescription(flm_GetFacilitySecureEquipmentResult secureDevice, ArrayList versionInformation)
        {
            deviceDescriptionType deviceDescription = new deviceDescriptionType();

            deviceDescription.DeviceIdentifier = new deviceIdentifierPolyType();
            deviceDescription.DeviceIdentifier.idtype = new deviceIdentifierPolyTypeIdtype();
            deviceDescription.DeviceIdentifier.idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            if (null == secureDevice.UniqueIdentifier)
                deviceDescription.DeviceIdentifier.Value = "urn:uid:publicid:dcipllc.com:" + Guid.Empty;
            else
                deviceDescription.DeviceIdentifier.Value = "urn:uid:publicid:dcipllc.com:" + secureDevice.UniqueIdentifier.ToString();
            deviceDescription.DeviceTypeID = new deviceTypeType();
            deviceDescription.DeviceTypeID.scope = "http://www.dcipllc.com/schemas/430-7/2009/FLM#deviceTypes";
            if (null == secureDevice.FLM_DeviceType)
                deviceDescription.DeviceTypeID.Value = "Other";
            else
                deviceDescription.DeviceTypeID.Value = secureDevice.FLM_DeviceType;
            deviceDescription.DeviceSerial = secureDevice.Serial_Number;
            if (null == secureDevice.Manufacturer_UniqueIdentifier)
                deviceDescription.ManufacturerID = "urn:uid:" + Guid.Empty;
            else
                deviceDescription.ManufacturerID = "urn:uid:" + secureDevice.Manufacturer_UniqueIdentifier.ToString();
            deviceDescription.ManufacturerName = secureDevice.Manufacturer;
            deviceDescription.ModelNumber = secureDevice.Model;

            deviceDescription.VersionInfo = new versionInfoListType();
            deviceDescription.VersionInfo.Items = new string[versionInformation.Count * 2];
            deviceDescription.VersionInfo.ItemsElementName = new ItemsChoiceType[versionInformation.Count * 2];
            int indexVersion = 0;
            foreach (versionInfoListType versionInfo in versionInformation)
            {
                deviceDescription.VersionInfo.Items[indexVersion] = versionInfo.Items[0];
                deviceDescription.VersionInfo.ItemsElementName[indexVersion] = versionInfo.ItemsElementName[0];
                deviceDescription.VersionInfo.Items[indexVersion + 1] = versionInfo.Items[1];
                deviceDescription.VersionInfo.ItemsElementName[indexVersion + 1] = versionInfo.ItemsElementName[1];
                indexVersion += 2;
            }

            return deviceDescription;
        }
        static private DCinemaSecurityMessageType AppendFLMRequiredExtension(DCinemaSecurityMessageType extraTheatreMessage, FLMRequiredExtensionsType flmRequiredExtention)
        {
            DCinemaSecurityMessageType facilityListMessage = extraTheatreMessage;

            StringWriter stringWriter = new StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FLMRequiredExtensionsType));
            xmlSerializer.Serialize(stringWriter, flmRequiredExtention);
            string serializedXML = stringWriter.ToString();
            XmlDocument docFlmRequiredExtention = new XmlDocument();
            docFlmRequiredExtention.LoadXml(serializedXML);

            facilityListMessage.AuthenticatedPublic.RequiredExtensions = docFlmRequiredExtention.DocumentElement;

            return facilityListMessage;
        }

        static private FLMNonCriticalExtensionsType BuildFlmNonCriticalExtention(ArrayList deviceArray)
        {
            FLMNonCriticalExtensionsType flmNonCriticalExtention = new FLMNonCriticalExtensionsType();

            #region Build the DeviceList element
            flmNonCriticalExtention.DeviceList = new FLMNonCriticalExtensionsTypeDeviceList();

            ArrayList deviceTypeArray = new ArrayList();

            flm_GetFacilityDeviceListResult currentDevice = null;
            ArrayList versionInformation = null;
            ArrayList IpAddresses = null;
            foreach (flm_GetFacilityDeviceListResult facilityDeviceListResultRow in deviceArray)
            {
                if ((null != currentDevice) && (currentDevice.Equipment_Id == facilityDeviceListResultRow.Equipment_Id)) // It still the same device (get next version element)
                {
                    AddDeviceInfoType(versionInformation, IpAddresses, facilityDeviceListResultRow);
                    continue;
                }
                else // the next device in the list
                {
                    #region Add the last completed device to the array
                    if (null != currentDevice)
                    {
                        DeviceType deviceType = BuildDeviceType(currentDevice, versionInformation, IpAddresses);

                        deviceTypeArray.Add(deviceType);
                    }
                    #endregion

                    currentDevice = null;
                    versionInformation = null;
                    IpAddresses = null;

                    #region Get the serial number of the next device. Skip this device if we cannot get the serial number
                    if ((null == facilityDeviceListResultRow.Serial_Number) || (facilityDeviceListResultRow.Serial_Number.Length < 1))
                    {
                        continue;
                    }
                    #endregion

                    //#region Get the certificate of the next device. Skip this device if we cannot get the certificate
                    //string deviceCertificateChainString = device.Cert_String;
                    //if (null == deviceCertificateChainString)
                    //{
                    //    continue;
                    //}

                    //int certificateCount = X509Certificate_ClassLibrary.X509CertificateClassLibrary.GetBeginCertificateCount(deviceCertificateChainString);
                    //if (certificateCount < 1)
                    //{
                    //    continue;
                    //}

                    //string deviceCertificateString = X509Certificate_ClassLibrary.X509CertificateClassLibrary.GetBeginCertificate(0, deviceCertificateChainString);
                    //if (null == deviceCertificateString)
                    //{
                    //    continue;
                    //}

                    //deviceCertificate = X509Certificate_ClassLibrary.X509CertificateClassLibrary.BuildCertificate(deviceCertificateString);
                    //if (null == deviceCertificate)
                    //{
                    //    currentDevice = null;
                    //    continue;
                    //}
                    //#endregion

                    currentDevice = facilityDeviceListResultRow;
                    versionInformation = new ArrayList();
                    IpAddresses = new ArrayList();

                    AddDeviceInfoType(versionInformation, IpAddresses, facilityDeviceListResultRow);
                }
            }
            #endregion

            #region Add the Device List to the Required Extention
            flmNonCriticalExtention.DeviceList.Device = new DeviceType[deviceTypeArray.Count];
            int index = 0;
            foreach (DeviceType device in deviceTypeArray)
            {
                flmNonCriticalExtention.DeviceList.Device[index] = device;
                index++;
            }
            #endregion

            return flmNonCriticalExtention;
        }

        private static DeviceType BuildDeviceType(flm_GetFacilityDeviceListResult currentDevice, ArrayList versionInformation, ArrayList ipAddresses)
        {
            DeviceType deviceType = new DeviceType();

            deviceType.DeviceDescription = BuildDeviceDescription(currentDevice, versionInformation);

            if (ipAddresses.Count > 0)
            {
                deviceType.IPAddressList = new DeviceTypeIPAddressList();
                deviceType.IPAddressList.IPAddress = new IPAddressType[ipAddresses.Count];
                int index = 0;
                foreach (IPAddressType ipAddressGiven in ipAddresses)
                {
                    deviceType.IPAddressList.IPAddress[index] = new IPAddressType();
                    deviceType.IPAddressList.IPAddress[index].Address = ipAddressGiven.Address;
                    index++;
                }
            }

            deviceType.InstallDate = (System.DateTime)currentDevice.Installed_Date;
            if (null == currentDevice.Decommission_Date)
            {
                if (null == currentDevice.Acceptance_Date)
                    deviceType.IsActive = false;
                else
                    deviceType.IsActive = true;
            }
            else
            {
                deviceType.DecommissionDate = (System.DateTime)currentDevice.Decommission_Date;
                deviceType.IsActive = false;
            }

            return deviceType;
        }
        private static deviceDescriptionType BuildDeviceDescription(flm_GetFacilityDeviceListResult currentDevice, ArrayList versionInformation)
        {
            deviceDescriptionType deviceDescription = new deviceDescriptionType();

            deviceDescription.DeviceIdentifier = new deviceIdentifierPolyType();
            deviceDescription.DeviceIdentifier.idtype = new deviceIdentifierPolyTypeIdtype();
            deviceDescription.DeviceIdentifier.idtype = deviceIdentifierPolyTypeIdtype.DeviceUID;
            deviceDescription.DeviceIdentifier.Value = "urn:uid:" + Guid.Empty;
            deviceDescription.DeviceTypeID = new deviceTypeType();
            deviceDescription.DeviceTypeID.scope = "http://www.dcipllc.com/schemas/430-7/2009/FLM#deviceTypes";
            if (null == currentDevice.FLM_DeviceType)
                deviceDescription.DeviceTypeID.Value = "Other";
            else
                deviceDescription.DeviceTypeID.Value = currentDevice.FLM_DeviceType;
            deviceDescription.DeviceSerial = currentDevice.Serial_Number;
            if (null == currentDevice.Manufacturer_UniqueIdentifier)
                deviceDescription.ManufacturerID = "urn:uid:" + Guid.Empty;
            else
                deviceDescription.ManufacturerID = "urn:uid:" + currentDevice.Manufacturer_UniqueIdentifier.ToString();
            deviceDescription.ManufacturerName = currentDevice.Manufacturer;
            deviceDescription.ModelNumber = currentDevice.Model;

            deviceDescription.VersionInfo = new versionInfoListType();
            deviceDescription.VersionInfo.Items = new string[versionInformation.Count * 2];
            deviceDescription.VersionInfo.ItemsElementName = new ItemsChoiceType[versionInformation.Count * 2];
            int indexVersion = 0;
            foreach (versionInfoListType versionInfo in versionInformation)
            {
                if (versionInfo.Items[indexVersion + 1].CompareTo("DeviceIdentifier") == 0)
                {
                    deviceDescription.DeviceIdentifier.Value = "urn:uid:" + versionInfo.Items[indexVersion];
                }
                else
                {
                    deviceDescription.VersionInfo.Items[indexVersion] = versionInfo.Items[0];
                    deviceDescription.VersionInfo.ItemsElementName[indexVersion] = versionInfo.ItemsElementName[0];
                    deviceDescription.VersionInfo.Items[indexVersion + 1] = versionInfo.Items[1];
                    deviceDescription.VersionInfo.ItemsElementName[indexVersion + 1] = versionInfo.ItemsElementName[1];
                }
                indexVersion += 2;
            }

            return deviceDescription;
        }

        static private bool AddDeviceInfoType(ArrayList versionInformation, ArrayList ipAddresses, flm_GetFacilityDeviceListResult device)
        {
            bool ValidVersionInfo = false;

            if ((null != device.Equipment_Attribute_Name) && // make sure the attribute is complete
                (device.Equipment_Attribute_Name.Length > 0) &&
                (null != device.Attribute_Value) &&
                (device.Attribute_Value.Length > 0))
            {
                if ((device.Equipment_Attribute_Name == "Hardware_Version") || // make sure it something we want
                    (device.Equipment_Attribute_Name == "Software_Version") ||
                    (device.Equipment_Attribute_Name == "Firmware_Version"))
                {
                    versionInfoListType infoType = new versionInfoListType();

                    infoType.ItemsElementName = new ItemsChoiceType[2];
                    infoType.ItemsElementName[0] = ItemsChoiceType.Name;
                    infoType.ItemsElementName[1] = ItemsChoiceType.Value;

                    infoType.Items = new string[2];
                    infoType.Items[0] = device.Equipment_Attribute_Name;
                    infoType.Items[1] = device.Attribute_Value;

                    ValidVersionInfo = true;
                    versionInformation.Add(infoType);
                }

                if (device.Equipment_Attribute_Name == "IP_Address") // make sure it something we want
                {
                    IPAddressType ipAddress = new IPAddressType();
                    ipAddress.Address = device.Attribute_Value;

                    ipAddresses.Add(ipAddress);
                }

            }

            return ValidVersionInfo;
        }
        static private DCinemaSecurityMessageType AppendFLMNonCriticalExtension(DCinemaSecurityMessageType extraTheatreMessage, FLMNonCriticalExtensionsType flmNonCriticalExtention)
        {
            DCinemaSecurityMessageType facilityListMessage = extraTheatreMessage;

            StringWriter stringWriter = new StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FLMNonCriticalExtensionsType));
            xmlSerializer.Serialize(stringWriter, flmNonCriticalExtention);
            string serializedXML = stringWriter.ToString();
            XmlDocument docFlmNonCriticalExtention = new XmlDocument();
            docFlmNonCriticalExtention.LoadXml(serializedXML);

            facilityListMessage.AuthenticatedPublic.NonCriticalExtensions = docFlmNonCriticalExtention.DocumentElement;

            return facilityListMessage;
        }

        static DCinemaSecurityMessageType SignETM(DCinemaSecurityMessageType extraTheatreMessage, X509Certificate2 x509Certificate2)
        {
            SignedXml signedXml = null;
            try
            {
                #region build the signature object
                signedXml = new SignedXml();
                signedXml.SigningKey = x509Certificate2.PrivateKey;
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/ 2001/04/xmldsig-more#rsasha256";
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmlenc#sha256";
                signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments";
                #endregion

                #region build a DCinemaSecurityMessage string to pull Data Objects
                StringWriter stringWriter = new StringWriter();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DCinemaSecurityMessageType));
                xmlSerializer.Serialize(stringWriter, extraTheatreMessage);
                string serializedXML = stringWriter.ToString();
                #endregion

                #region Build the AuthenticatedPublic DataObject & Reference

                string xmlAuthenticatedPublic = GetCleanElement(serializedXML, "AuthenticatedPublic");
                XmlDocument docAuthenticatedPublic = new XmlDocument();
                docAuthenticatedPublic.LoadXml(xmlAuthenticatedPublic.ToString());

                DataObject dataObjectAuthenticatedPublic = new DataObject("AuthenticatedPublic", "", "", docAuthenticatedPublic.DocumentElement);
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

                DataObject dataObjectAuthenticatedPrivate = new DataObject("AuthenticatedPrivate", "", "", docAuthenticatedPrivate.DocumentElement);

                signedXml.AddObject(dataObjectAuthenticatedPrivate);

                Reference referenceAuthenticatedPrivate = new Reference();
                referenceAuthenticatedPrivate.Uri = "#AuthenticatedPrivate";
                referenceAuthenticatedPrivate.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";

                // Add the reference to the message.
                signedXml.AddReference(referenceAuthenticatedPrivate);

                #endregion

                #region Add KeyInfo.
                KeyInfo keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(x509Certificate2, X509IncludeOption.WholeChain));
                signedXml.KeyInfo = keyInfo;
                #endregion

                // Compute the signature.
                signedXml.ComputeSignature();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

            //add the signature to the DCinemaSecurityMessage
            extraTheatreMessage.Signature = signedXml.Signature.GetXml();

            return extraTheatreMessage;
        }
        static private DCinemaSecurityMessageType RemoveSignatureObjects(DCinemaSecurityMessageType extraTheatreMessage)
        {
            DCinemaSecurityMessageType facilityListMessage = extraTheatreMessage;

            StringWriter stringWriter = new StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlElement));
            xmlSerializer.Serialize(stringWriter, extraTheatreMessage.Signature);
            string serializedXML = stringWriter.ToString();
            XmlDocument docSignature = new XmlDocument();
            docSignature.LoadXml(serializedXML);

            #region There must be a better way but for now this will do
            //TODO: Find a better way
            foreach (XmlNode nextNode in docSignature.DocumentElement)
            {
                if (nextNode.Name.CompareTo("Object") == 0)
                {
                    XmlNode parentNode = nextNode.ParentNode;
                    parentNode.RemoveChild(nextNode);
                }
            }

            foreach (XmlNode nextNode in docSignature.DocumentElement)
            {
                if (nextNode.Name.CompareTo("Object") == 0)
                {
                    XmlNode parentNode = nextNode.ParentNode;
                    parentNode.RemoveChild(nextNode);
                }
            }
            #endregion

            facilityListMessage.Signature = docSignature.DocumentElement;

            return facilityListMessage;
        }
        static private string GetCleanElement(string xmlDocument, string elementName)
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
