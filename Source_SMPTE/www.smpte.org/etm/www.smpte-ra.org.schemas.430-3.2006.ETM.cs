﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://www.smpte-ra.org/schemas/430-3/2006/ETM", ClrNamespace="www.smptera.org.schemas._4303._2006.ETM")]

namespace www.smptera.org.schemas._4303._2006.ETM
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DCinemaSecurityMessageType", Namespace="http://www.smpte-ra.org/schemas/430-3/2006/ETM")]
    public partial class DCinemaSecurityMessageType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string AuthenticatedPublicField;
        
        private string AuthenticatedPrivateField;
        
        private string SignatureField;
        
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
        public string AuthenticatedPublic
        {
            get
            {
                return this.AuthenticatedPublicField;
            }
            set
            {
                this.AuthenticatedPublicField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public string AuthenticatedPrivate
        {
            get
            {
                return this.AuthenticatedPrivateField;
            }
            set
            {
                this.AuthenticatedPrivateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public string Signature
        {
            get
            {
                return this.SignatureField;
            }
            set
            {
                this.SignatureField = value;
            }
        }
    }
}
