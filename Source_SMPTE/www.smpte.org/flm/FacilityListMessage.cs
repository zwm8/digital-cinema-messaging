namespace www.smpte.org.flm
{
    using System.Xml.Serialization;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Security.Cryptography.X509Certificates;

    using www.smpte.org.dcmlTypes;
    using www.smpte.org.flm;
    using www.w3.org.dsig;

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    [System.Xml.Serialization.XmlRootAttribute("FLMRequiredExtensions", Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM", IsNullable=false)]
    public partial class FLMRequiredExtensionsType {
        
        private bool fLMPartialField;
        
        private bool fLMPartialFieldSpecified;
        
        private FLMRequiredExtensionsTypeFacilityInfo facilityInfoField;
        
        private SecurityDeviceListType securityDeviceListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool FLMPartial {
            get {
                return this.fLMPartialField;
            }
            set {
                this.fLMPartialField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FLMPartialSpecified {
            get {
                return this.fLMPartialFieldSpecified;
            }
            set {
                this.fLMPartialFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public FLMRequiredExtensionsTypeFacilityInfo FacilityInfo {
            get {
                return this.facilityInfoField;
            }
            set {
                this.facilityInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public SecurityDeviceListType SecurityDeviceList {
            get {
                return this.securityDeviceListField;
            }
            set {
                this.securityDeviceListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class FLMRequiredExtensionsTypeFacilityInfo {
        
        private string facilityIDField;
        
        private www.smpte.org.dcmlTypes.UserTextType annotationTextField;

        private www.smpte.org.dcmlTypes.UserTextType facilityNameField;
        
        private UTCOffsetType uTCOffsetField;
        
        private ContactInfoType contactInfoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI", Order=0)]
        public string FacilityID {
            get {
                return this.facilityIDField;
            }
            set {
                this.facilityIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public www.smpte.org.dcmlTypes.UserTextType AnnotationText
        {
            get {
                return this.annotationTextField;
            }
            set {
                this.annotationTextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public www.smpte.org.dcmlTypes.UserTextType FacilityName
        {
            get {
                return this.facilityNameField;
            }
            set {
                this.facilityNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public UTCOffsetType UTCOffset {
            get {
                return this.uTCOffsetField;
            }
            set {
                this.uTCOffsetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public ContactInfoType ContactInfo {
            get {
                return this.contactInfoField;
            }
            set {
                this.contactInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class UTCOffsetType {
        
        private string offsetField;
        
        private UTCOffsetTypeDSTException dSTExceptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Offset {
            get {
                return this.offsetField;
            }
            set {
                this.offsetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public UTCOffsetTypeDSTException DSTException {
            get {
                return this.dSTExceptionField;
            }
            set {
                this.dSTExceptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class UTCOffsetTypeDSTException {
        
        private string dSTOffsetField;
        
        private System.DateTime dSTStartField;
        
        private System.DateTime dSTEndField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string DSTOffset {
            get {
                return this.dSTOffsetField;
            }
            set {
                this.dSTOffsetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime DSTStart {
            get {
                return this.dSTStartField;
            }
            set {
                this.dSTStartField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.DateTime DSTEnd {
            get {
                return this.dSTEndField;
            }
            set {
                this.dSTEndField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class ForensicMarkIdType {
        
        private string algorithmIdField;
        
        private string markIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI", Order=0)]
        public string AlgorithmId {
            get {
                return this.algorithmIdField;
            }
            set {
                this.algorithmIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=1)]
        public string MarkId {
            get {
                return this.markIdField;
            }
            set {
                this.markIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CombinedType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class CertOnlyType {

        private www.w3.org.dsig.KeyInfoType keyInfoField;
        
        private ForensicMarkIdType[] forensicMarkIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public www.w3.org.dsig.KeyInfoType KeyInfo
        {
            get {
                return this.keyInfoField;
            }
            set {
                this.keyInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ForensicMarkId", Order=1)]
        public ForensicMarkIdType[] ForensicMarkId {
            get {
                return this.forensicMarkIdField;
            }
            set {
                this.forensicMarkIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class CombinedType : CertOnlyType {
        
        private www.smpte.org.dcmlTypes.deviceDescriptionType deviceDescriptionField;
        
        private ForensicMarkIdType[] forensicMarkId1Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public www.smpte.org.dcmlTypes.deviceDescriptionType DeviceDescription
        {
            get {
                return this.deviceDescriptionField;
            }
            set {
                this.deviceDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ForensicMarkId", Order=1)]
        public ForensicMarkIdType[] ForensicMarkId1 {
            get {
                return this.forensicMarkId1Field;
            }
            set {
                this.forensicMarkId1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class SecurityDeviceListType {
        
        private CertOnlyType[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SecurityDevice", typeof(CombinedType), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("SecurityDeviceCertificate", typeof(CertOnlyType), Order=0)]
        public CertOnlyType[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class ContactInfoType
    {

        private www.smpte.org.dcmlTypes.UserTextType nameField;

        private www.smpte.org.dcmlTypes.UserTextType countryCodeField;

        private www.smpte.org.dcmlTypes.UserTextType phone1Field;

        private www.smpte.org.dcmlTypes.UserTextType phone2Field;

        private www.smpte.org.dcmlTypes.UserTextType emailField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public www.smpte.org.dcmlTypes.UserTextType Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public www.smpte.org.dcmlTypes.UserTextType CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public www.smpte.org.dcmlTypes.UserTextType Phone1
        {
            get
            {
                return this.phone1Field;
            }
            set
            {
                this.phone1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public www.smpte.org.dcmlTypes.UserTextType Phone2
        {
            get
            {
                return this.phone2Field;
            }
            set
            {
                this.phone2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public www.smpte.org.dcmlTypes.UserTextType Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }
}
