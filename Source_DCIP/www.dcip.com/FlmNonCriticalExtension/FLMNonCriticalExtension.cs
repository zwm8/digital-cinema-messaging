namespace www.dcipllc.com.flm_ext {
    using System.Xml.Serialization;
    using www.smpte.org.dcmlTypes;
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    [System.Xml.Serialization.XmlRootAttribute("FLMNonCriticalExtensions", Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext", IsNullable=false)]
    public partial class FLMNonCriticalExtensionsType {
        
        private FLMNonCriticalExtensionsTypeDeviceList deviceListField;
        
        private FLMNonCriticalExtensionsTypeNonCriticalFacilityInfo nonCriticalFacilityInfoField;
        
        private FLMNonCriticalExtensionsTypeNonCriticalAuditoriumInfo nonCriticalAuditoriumInfoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public FLMNonCriticalExtensionsTypeDeviceList DeviceList {
            get {
                return this.deviceListField;
            }
            set {
                this.deviceListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public FLMNonCriticalExtensionsTypeNonCriticalFacilityInfo NonCriticalFacilityInfo {
            get {
                return this.nonCriticalFacilityInfoField;
            }
            set {
                this.nonCriticalFacilityInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public FLMNonCriticalExtensionsTypeNonCriticalAuditoriumInfo NonCriticalAuditoriumInfo {
            get {
                return this.nonCriticalAuditoriumInfoField;
            }
            set {
                this.nonCriticalAuditoriumInfoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeDeviceList {
        
        private DeviceType[] deviceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Device", Order=0)]
        public DeviceType[] Device {
            get {
                return this.deviceField;
            }
            set {
                this.deviceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class DeviceType {
        
        private deviceDescriptionType deviceDescriptionField;
        
        private DeviceTypeDeviceAttributeList deviceAttributeListField;
        
        private DeviceTypeIPAddressList iPAddressListField;
        
        private System.DateTime installDateField;
        
        private System.DateTime decommissionDateField;
        
        private bool decommissionDateFieldSpecified;
        
        private bool isActiveField;
        
        private DeviceTypeSoftwareList softwareListField;
        
        private object[] otherSecurityField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public deviceDescriptionType DeviceDescription {
            get {
                return this.deviceDescriptionField;
            }
            set {
                this.deviceDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public DeviceTypeDeviceAttributeList DeviceAttributeList {
            get {
                return this.deviceAttributeListField;
            }
            set {
                this.deviceAttributeListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public DeviceTypeIPAddressList IPAddressList {
            get {
                return this.iPAddressListField;
            }
            set {
                this.iPAddressListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.DateTime InstallDate {
            get {
                return this.installDateField;
            }
            set {
                this.installDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public System.DateTime DecommissionDate {
            get {
                return this.decommissionDateField;
            }
            set {
                this.decommissionDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DecommissionDateSpecified {
            get {
                return this.decommissionDateFieldSpecified;
            }
            set {
                this.decommissionDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public bool IsActive {
            get {
                return this.isActiveField;
            }
            set {
                this.isActiveField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public DeviceTypeSoftwareList SoftwareList {
            get {
                return this.softwareListField;
            }
            set {
                this.softwareListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("CertificateList", typeof(SecurityTypeCertificateList), IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("WatermarkingList", typeof(SecurityTypeWatermarkingList), IsNullable=false)]
        public object[] OtherSecurity {
            get {
                return this.otherSecurityField;
            }
            set {
                this.otherSecurityField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class Digital3DSystemType {
        
        private bool isActiveField;
        
        private string digital3DConfigurationField;
        
        private System.DateTime installDateField;
        
        private bool installDateFieldSpecified;
        
        private System.DateTime decommissionDateField;
        
        private bool decommissionDateFieldSpecified;
        
        private ScreenColorType screenColorField;
        
        private bool screenColorFieldSpecified;
        
        private bool ghostbustingField;
        
        private bool ghostbustingFieldSpecified;
        
        private string ghostbustingConfigurationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool IsActive {
            get {
                return this.isActiveField;
            }
            set {
                this.isActiveField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Digital3DConfiguration {
            get {
                return this.digital3DConfigurationField;
            }
            set {
                this.digital3DConfigurationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.DateTime InstallDate {
            get {
                return this.installDateField;
            }
            set {
                this.installDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InstallDateSpecified {
            get {
                return this.installDateFieldSpecified;
            }
            set {
                this.installDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.DateTime DecommissionDate {
            get {
                return this.decommissionDateField;
            }
            set {
                this.decommissionDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DecommissionDateSpecified {
            get {
                return this.decommissionDateFieldSpecified;
            }
            set {
                this.decommissionDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public ScreenColorType ScreenColor {
            get {
                return this.screenColorField;
            }
            set {
                this.screenColorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScreenColorSpecified {
            get {
                return this.screenColorFieldSpecified;
            }
            set {
                this.screenColorFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public bool Ghostbusting {
            get {
                return this.ghostbustingField;
            }
            set {
                this.ghostbustingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GhostbustingSpecified {
            get {
                return this.ghostbustingFieldSpecified;
            }
            set {
                this.ghostbustingFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string GhostbustingConfiguration {
            get {
                return this.ghostbustingConfigurationField;
            }
            set {
                this.ghostbustingConfigurationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public enum ScreenColorType {
        
        /// <remarks/>
        SILVER,
        
        /// <remarks/>
        WHITE,
        
        /// <remarks/>
        OTHER,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class AuditoriumType {
        
        private int auditoriumNumberField;
        
        private AuditoriumTypeAuditoriumDeviceList auditoriumDeviceListField;
        
        private Digital3DSystemType digital3DSystemField;
        
        private string serviceProviderField;
        
        private string installationIdField;
        
        private AuditoriumTypeAuditoriumAttributeList auditoriumAttributeListField;
        
        private System.DateTime auditoriumInstallationDateField;
        
        private bool auditoriumInstallationDateFieldSpecified;
        
        private string integratorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int AuditoriumNumber {
            get {
                return this.auditoriumNumberField;
            }
            set {
                this.auditoriumNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public AuditoriumTypeAuditoriumDeviceList AuditoriumDeviceList {
            get {
                return this.auditoriumDeviceListField;
            }
            set {
                this.auditoriumDeviceListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public Digital3DSystemType Digital3DSystem {
            get {
                return this.digital3DSystemField;
            }
            set {
                this.digital3DSystemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ServiceProvider {
            get {
                return this.serviceProviderField;
            }
            set {
                this.serviceProviderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string InstallationId {
            get {
                return this.installationIdField;
            }
            set {
                this.installationIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public AuditoriumTypeAuditoriumAttributeList AuditoriumAttributeList {
            get {
                return this.auditoriumAttributeListField;
            }
            set {
                this.auditoriumAttributeListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public System.DateTime AuditoriumInstallationDate {
            get {
                return this.auditoriumInstallationDateField;
            }
            set {
                this.auditoriumInstallationDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AuditoriumInstallationDateSpecified {
            get {
                return this.auditoriumInstallationDateFieldSpecified;
            }
            set {
                this.auditoriumInstallationDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Integrator {
            get {
                return this.integratorField;
            }
            set {
                this.integratorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class AuditoriumTypeAuditoriumDeviceList {
        
        private deviceIdentifierPolyType[] deviceIdentifierField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeviceIdentifier", Order=0)]
        public deviceIdentifierPolyType[] DeviceIdentifier {
            get {
                return this.deviceIdentifierField;
            }
            set {
                this.deviceIdentifierField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class AuditoriumTypeAuditoriumAttributeList {
        
        private AttributeType[] auditoriumAttributeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AuditoriumAttribute", Order=0)]
        public AttributeType[] AuditoriumAttribute {
            get {
                return this.auditoriumAttributeField;
            }
            set {
                this.auditoriumAttributeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class AttributeType {
        
        private string nameField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class AddressType {
        
        private AddressClassType addressClassField;
        
        private string streetAddressField;
        
        private string cityField;
        
        private string stateField;
        
        private string postalCodeField;
        
        private string countryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AddressClassType AddressClass {
            get {
                return this.addressClassField;
            }
            set {
                this.addressClassField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string StreetAddress {
            get {
                return this.streetAddressField;
            }
            set {
                this.streetAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string PostalCode {
            get {
                return this.postalCodeField;
            }
            set {
                this.postalCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public enum AddressClassType {
        
        /// <remarks/>
        SHIPPING,
        
        /// <remarks/>
        BILLING,
        
        /// <remarks/>
        PHYSICAL,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class CapabilityType {
        
        private string methodField;
        
        private string detailField;
        
        private string providerField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Method {
            get {
                return this.methodField;
            }
            set {
                this.methodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Detail {
            get {
                return this.detailField;
            }
            set {
                this.detailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Provider {
            get {
                return this.providerField;
            }
            set {
                this.providerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class SoftwareType {
        
        private string softwareProducerField;
        
        private string descriptionField;
        
        private string versionField;
        
        private string fileNameField;
        
        private uint fileSizeField;
        
        private bool fileSizeFieldSpecified;
        
        private System.DateTime fileDateTimeField;
        
        private bool fileDateTimeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SoftwareProducer {
            get {
                return this.softwareProducerField;
            }
            set {
                this.softwareProducerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public uint FileSize {
            get {
                return this.fileSizeField;
            }
            set {
                this.fileSizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FileSizeSpecified {
            get {
                return this.fileSizeFieldSpecified;
            }
            set {
                this.fileSizeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public System.DateTime FileDateTime {
            get {
                return this.fileDateTimeField;
            }
            set {
                this.fileDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FileDateTimeSpecified {
            get {
                return this.fileDateTimeFieldSpecified;
            }
            set {
                this.fileDateTimeFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class IPAddressType {
        
        private string addressField;
        
        private string hostField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Host {
            get {
                return this.hostField;
            }
            set {
                this.hostField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class DeviceTypeDeviceAttributeList {
        
        private AttributeType[] deviceAttributeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeviceAttribute", Order=0)]
        public AttributeType[] DeviceAttribute {
            get {
                return this.deviceAttributeField;
            }
            set {
                this.deviceAttributeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class DeviceTypeIPAddressList {
        
        private IPAddressType[] iPAddressField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IPAddress", Order=0)]
        public IPAddressType[] IPAddress {
            get {
                return this.iPAddressField;
            }
            set {
                this.iPAddressField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class DeviceTypeSoftwareList {
        
        private SoftwareType[] softwareField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Software", Order=0)]
        public SoftwareType[] Software {
            get {
                return this.softwareField;
            }
            set {
                this.softwareField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class SecurityTypeCertificateList {
        
        private SecurityTypeCertificateListCertificate[] certificateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Certificate", Order=0)]
        public SecurityTypeCertificateListCertificate[] Certificate {
            get {
                return this.certificateField;
            }
            set {
                this.certificateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class SecurityTypeCertificateListCertificate {
        
        private string certificateClassField;
        
        private byte[] x509CertificateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CertificateClass {
            get {
                return this.certificateClassField;
            }
            set {
                this.certificateClassField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=1)]
        public byte[] X509Certificate {
            get {
                return this.x509CertificateField;
            }
            set {
                this.x509CertificateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class SecurityTypeWatermarkingList {
        
        private SecurityTypeWatermarkingListWatermarking[] watermarkingField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Watermarking", Order=0)]
        public SecurityTypeWatermarkingListWatermarking[] Watermarking {
            get {
                return this.watermarkingField;
            }
            set {
                this.watermarkingField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class SecurityTypeWatermarkingListWatermarking {
        
        private string watermarkManufacturerField;
        
        private string watermarkModelField;
        
        private string watermarkVersionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string WatermarkManufacturer {
            get {
                return this.watermarkManufacturerField;
            }
            set {
                this.watermarkManufacturerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string WatermarkModel {
            get {
                return this.watermarkModelField;
            }
            set {
                this.watermarkModelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string WatermarkVersion {
            get {
                return this.watermarkVersionField;
            }
            set {
                this.watermarkVersionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeNonCriticalFacilityInfo {
        
        private string circuitField;
        
        private FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoDistributionCapabilitiyList distributionCapabilitiyListField;
        
        private int totalScreenCountField;
        
        private bool totalScreenCountFieldSpecified;
        
        private string facilityNameField;
        
        private FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoAddressList addressListField;
        
        private FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityUriList facilityUriListField;
        
        private FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityDeviceList facilityDeviceListField;
        
        private FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityAttributeList facilityAttributeListField;
        
        private string facilityTimeZoneField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Circuit {
            get {
                return this.circuitField;
            }
            set {
                this.circuitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoDistributionCapabilitiyList DistributionCapabilitiyList {
            get {
                return this.distributionCapabilitiyListField;
            }
            set {
                this.distributionCapabilitiyListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int TotalScreenCount {
            get {
                return this.totalScreenCountField;
            }
            set {
                this.totalScreenCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalScreenCountSpecified {
            get {
                return this.totalScreenCountFieldSpecified;
            }
            set {
                this.totalScreenCountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string FacilityName {
            get {
                return this.facilityNameField;
            }
            set {
                this.facilityNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoAddressList AddressList {
            get {
                return this.addressListField;
            }
            set {
                this.addressListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityUriList FacilityUriList {
            get {
                return this.facilityUriListField;
            }
            set {
                this.facilityUriListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityDeviceList FacilityDeviceList {
            get {
                return this.facilityDeviceListField;
            }
            set {
                this.facilityDeviceListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityAttributeList FacilityAttributeList {
            get {
                return this.facilityAttributeListField;
            }
            set {
                this.facilityAttributeListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string FacilityTimeZone {
            get {
                return this.facilityTimeZoneField;
            }
            set {
                this.facilityTimeZoneField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoDistributionCapabilitiyList {
        
        private CapabilityType[] capabilityField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Capability", Order=0)]
        public CapabilityType[] Capability {
            get {
                return this.capabilityField;
            }
            set {
                this.capabilityField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoAddressList {
        
        private AddressType[] addressField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order=0)]
        public AddressType[] Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityUriList {
        
        private string[] facilityUriField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityUri", DataType="anyURI", Order=0)]
        public string[] FacilityUri {
            get {
                return this.facilityUriField;
            }
            set {
                this.facilityUriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityDeviceList {
        
        private deviceIdentifierPolyType[] deviceIdentifierField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeviceIdentifier", Order=0)]
        public deviceIdentifierPolyType[] DeviceIdentifier {
            get {
                return this.deviceIdentifierField;
            }
            set {
                this.deviceIdentifierField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeNonCriticalFacilityInfoFacilityAttributeList {
        
        private AttributeType[] facilityAttributeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityAttribute", Order=0)]
        public AttributeType[] FacilityAttribute {
            get {
                return this.facilityAttributeField;
            }
            set {
                this.facilityAttributeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.dcip.com/schemas/430-7/2009/flm_ext")]
    public partial class FLMNonCriticalExtensionsTypeNonCriticalAuditoriumInfo {
        
        private AuditoriumType[] auditoriumField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Auditorium", Order=0)]
        public AuditoriumType[] Auditorium {
            get {
                return this.auditoriumField;
            }
            set {
                this.auditoriumField = value;
            }
        }
    }
}
