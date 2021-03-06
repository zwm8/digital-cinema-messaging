﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://tempuri.org/CheckConnectionReply.xsd", ClrNamespace="tempuri.org.CheckConnectionReply.xsd")]

namespace tempuri.org.CheckConnectionReply.xsd
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CheckConnectionReplyType", Namespace="http://tempuri.org/CheckConnectionReply.xsd")]
    public partial class CheckConnectionReplyType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Uri OriginatorField;
        
        private string SystemNameField;
        
        private string FeedIdentifierField;
        
        private System.DateTime DateTimeCreatedField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public System.Uri Originator
        {
            get
            {
                return this.OriginatorField;
            }
            set
            {
                this.OriginatorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string SystemName
        {
            get
            {
                return this.SystemNameField;
            }
            set
            {
                this.SystemNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public string FeedIdentifier
        {
            get
            {
                return this.FeedIdentifierField;
            }
            set
            {
                this.FeedIdentifierField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.DateTime DateTimeCreated
        {
            get
            {
                return this.DateTimeCreatedField;
            }
            set
            {
                this.DateTimeCreatedField = value;
            }
        }
    }
}
namespace www.smpte.org.etm
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DCinemaSecurityMessageType", Namespace="http://schemas.datacontract.org/2004/07/www.smpte.org.etm")]
    public partial class DCinemaSecurityMessageType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private www.smpte.org.etm.AuthenticatedPrivateType authenticatedPrivateFieldField;
        
        private www.smpte.org.etm.AuthenticatedPublicType authenticatedPublicFieldField;
        
        private System.Xml.XmlElement signatureFieldField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public www.smpte.org.etm.AuthenticatedPrivateType authenticatedPrivateField
        {
            get
            {
                return this.authenticatedPrivateFieldField;
            }
            set
            {
                this.authenticatedPrivateFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public www.smpte.org.etm.AuthenticatedPublicType authenticatedPublicField
        {
            get
            {
                return this.authenticatedPublicFieldField;
            }
            set
            {
                this.authenticatedPublicFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Xml.XmlElement signatureField
        {
            get
            {
                return this.signatureFieldField;
            }
            set
            {
                this.signatureFieldField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticatedPrivateType", Namespace="http://schemas.datacontract.org/2004/07/www.smpte.org.etm")]
    public partial class AuthenticatedPrivateType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Xml.XmlElement encryptedDataFieldField;
        
        private System.Xml.XmlElement[] encryptedKeyFieldField;
        
        private string idFieldField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Xml.XmlElement encryptedDataField
        {
            get
            {
                return this.encryptedDataFieldField;
            }
            set
            {
                this.encryptedDataFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Xml.XmlElement[] encryptedKeyField
        {
            get
            {
                return this.encryptedKeyFieldField;
            }
            set
            {
                this.encryptedKeyFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string idField
        {
            get
            {
                return this.idFieldField;
            }
            set
            {
                this.idFieldField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticatedPublicType", Namespace="http://schemas.datacontract.org/2004/07/www.smpte.org.etm")]
    public partial class AuthenticatedPublicType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private www.smpte.org.etm.UserText annotationTextFieldField;
        
        private string idFieldField;
        
        private System.DateTime issueDateFieldField;
        
        private string messageIdFieldField;
        
        private string messageTypeFieldField;
        
        private System.Xml.XmlElement nonCriticalExtensionsFieldField;
        
        private System.Xml.XmlElement requiredExtensionsFieldField;
        
        private System.Security.Cryptography.Xml.X509IssuerSerial signerFieldField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public www.smpte.org.etm.UserText annotationTextField
        {
            get
            {
                return this.annotationTextFieldField;
            }
            set
            {
                this.annotationTextFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string idField
        {
            get
            {
                return this.idFieldField;
            }
            set
            {
                this.idFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime issueDateField
        {
            get
            {
                return this.issueDateFieldField;
            }
            set
            {
                this.issueDateFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string messageIdField
        {
            get
            {
                return this.messageIdFieldField;
            }
            set
            {
                this.messageIdFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string messageTypeField
        {
            get
            {
                return this.messageTypeFieldField;
            }
            set
            {
                this.messageTypeFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Xml.XmlElement nonCriticalExtensionsField
        {
            get
            {
                return this.nonCriticalExtensionsFieldField;
            }
            set
            {
                this.nonCriticalExtensionsFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Xml.XmlElement requiredExtensionsField
        {
            get
            {
                return this.requiredExtensionsFieldField;
            }
            set
            {
                this.requiredExtensionsFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Security.Cryptography.Xml.X509IssuerSerial signerField
        {
            get
            {
                return this.signerFieldField;
            }
            set
            {
                this.signerFieldField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserText", Namespace="http://schemas.datacontract.org/2004/07/www.smpte.org.etm")]
    public partial class UserText : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string languageFieldField;
        
        private string valueFieldField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string languageField
        {
            get
            {
                return this.languageFieldField;
            }
            set
            {
                this.languageFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string valueField
        {
            get
            {
                return this.valueFieldField;
            }
            set
            {
                this.valueFieldField = value;
            }
        }
    }
}
namespace System.Security.Cryptography.Xml
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="X509IssuerSerial", Namespace="http://schemas.datacontract.org/2004/07/System.Security.Cryptography.Xml")]
    public partial struct X509IssuerSerial : System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string IssuerNameField;
        
        private string SerialNumberField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IssuerName
        {
            get
            {
                return this.IssuerNameField;
            }
            set
            {
                this.IssuerNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SerialNumber
        {
            get
            {
                return this.SerialNumberField;
            }
            set
            {
                this.SerialNumberField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IFlmService")]
public interface IFlmService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlmService/CheckConnection", ReplyAction="http://tempuri.org/IFlmService/CheckConnectionResponse")]
    tempuri.org.CheckConnectionReply.xsd.CheckConnectionReplyType CheckConnection(tempuri.org.CheckConnectionReply.xsd.CheckConnectionReplyType parameter);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlmService/GetFLM", ReplyAction="http://tempuri.org/IFlmService/GetFLMResponse")]
    www.smpte.org.etm.DCinemaSecurityMessageType GetFLM(string parameters);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlmService/GetUpdatedFacilityListSince", ReplyAction="http://tempuri.org/IFlmService/GetUpdatedFacilityListSinceResponse")]
    System.Xml.XmlElement GetUpdatedFacilityListSince(string parameters);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlmService/GetFacilityList", ReplyAction="http://tempuri.org/IFlmService/GetFacilityListResponse")]
    System.Xml.XmlElement GetFacilityList();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IFlmServiceChannel : IFlmService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class FlmServiceClient : System.ServiceModel.ClientBase<IFlmService>, IFlmService
{
    
    public FlmServiceClient()
    {
    }
    
    public FlmServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public FlmServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public FlmServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public FlmServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public tempuri.org.CheckConnectionReply.xsd.CheckConnectionReplyType CheckConnection(tempuri.org.CheckConnectionReply.xsd.CheckConnectionReplyType parameter)
    {
        return base.Channel.CheckConnection(parameter);
    }
    
    public www.smpte.org.etm.DCinemaSecurityMessageType GetFLM(string parameters)
    {
        return base.Channel.GetFLM(parameters);
    }
    
    public System.Xml.XmlElement GetUpdatedFacilityListSince(string parameters)
    {
        return base.Channel.GetUpdatedFacilityListSince(parameters);
    }
    
    public System.Xml.XmlElement GetFacilityList()
    {
        return base.Channel.GetFacilityList();
    }
}
