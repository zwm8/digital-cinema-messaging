﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://www.smpte-ra.org/schemas/430-7/2008/FLM", ClrNamespace="www.smptera.org.schemas._4307._2008.FLM")]

namespace www.smptera.org.schemas._4307._2008.FLM
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FLMRequiredExtensionsType", Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class FLMRequiredExtensionsType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool FLMPartialField;
        
        private www.smptera.org.schemas._4307._2008.FLM.FLMRequiredExtensionsType.FacilityInfoType FacilityInfoField;
        
        private www.smptera.org.schemas._4307._2008.FLM.SecurityDeviceListType SecurityDeviceListField;
        
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
        public bool FLMPartial
        {
            get
            {
                return this.FLMPartialField;
            }
            set
            {
                this.FLMPartialField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public www.smptera.org.schemas._4307._2008.FLM.FLMRequiredExtensionsType.FacilityInfoType FacilityInfo
        {
            get
            {
                return this.FacilityInfoField;
            }
            set
            {
                this.FacilityInfoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public www.smptera.org.schemas._4307._2008.FLM.SecurityDeviceListType SecurityDeviceList
        {
            get
            {
                return this.SecurityDeviceListField;
            }
            set
            {
                this.SecurityDeviceListField = value;
            }
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("ExportSchema")]
        [System.Xml.Serialization.XmlRootAttribute(IsNullable=false)]
        public partial class FacilityInfoType : object, System.Xml.Serialization.IXmlSerializable
        {
            
            private System.Xml.XmlNode[] nodesField;
            
            private static System.Xml.XmlQualifiedName typeName = new System.Xml.XmlQualifiedName("FLMRequiredExtensionsType.FacilityInfoType", "http://www.smpte-ra.org/schemas/430-7/2008/FLM");
            
            public System.Xml.XmlNode[] Nodes
            {
                get
                {
                    return this.nodesField;
                }
                set
                {
                    this.nodesField = value;
                }
            }
            
            public void ReadXml(System.Xml.XmlReader reader)
            {
                this.nodesField = System.Runtime.Serialization.XmlSerializableServices.ReadNodes(reader);
            }
            
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                System.Runtime.Serialization.XmlSerializableServices.WriteNodes(writer, this.Nodes);
            }
            
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }
            
            public static System.Xml.XmlQualifiedName ExportSchema(System.Xml.Schema.XmlSchemaSet schemas)
            {
                System.Runtime.Serialization.XmlSerializableServices.AddDefaultSchema(schemas, typeName);
                return typeName;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("ExportSchema")]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable=false)]
    public partial class SecurityDeviceListType : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Xml.XmlNode[] nodesField;
        
        private static System.Xml.XmlQualifiedName typeName = new System.Xml.XmlQualifiedName("SecurityDeviceListType", "http://www.smpte-ra.org/schemas/430-7/2008/FLM");
        
        public System.Xml.XmlNode[] Nodes
        {
            get
            {
                return this.nodesField;
            }
            set
            {
                this.nodesField = value;
            }
        }
        
        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.nodesField = System.Runtime.Serialization.XmlSerializableServices.ReadNodes(reader);
        }
        
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Runtime.Serialization.XmlSerializableServices.WriteNodes(writer, this.Nodes);
        }
        
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        
        public static System.Xml.XmlQualifiedName ExportSchema(System.Xml.Schema.XmlSchemaSet schemas)
        {
            System.Runtime.Serialization.XmlSerializableServices.AddDefaultSchema(schemas, typeName);
            return typeName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("ExportSchema")]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable=false)]
    public partial class CertOnlyType : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Xml.XmlNode[] nodesField;
        
        private static System.Xml.XmlQualifiedName typeName = new System.Xml.XmlQualifiedName("CertOnlyType", "http://www.smpte-ra.org/schemas/430-7/2008/FLM");
        
        public System.Xml.XmlNode[] Nodes
        {
            get
            {
                return this.nodesField;
            }
            set
            {
                this.nodesField = value;
            }
        }
        
        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.nodesField = System.Runtime.Serialization.XmlSerializableServices.ReadNodes(reader);
        }
        
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Runtime.Serialization.XmlSerializableServices.WriteNodes(writer, this.Nodes);
        }
        
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        
        public static System.Xml.XmlQualifiedName ExportSchema(System.Xml.Schema.XmlSchemaSet schemas)
        {
            System.Runtime.Serialization.XmlSerializableServices.AddDefaultSchema(schemas, typeName);
            return typeName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("ExportSchema")]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable=false)]
    public partial class CombinedType : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Xml.XmlNode[] nodesField;
        
        private static System.Xml.XmlQualifiedName typeName = new System.Xml.XmlQualifiedName("CombinedType", "http://www.smpte-ra.org/schemas/430-7/2008/FLM");
        
        public System.Xml.XmlNode[] Nodes
        {
            get
            {
                return this.nodesField;
            }
            set
            {
                this.nodesField = value;
            }
        }
        
        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.nodesField = System.Runtime.Serialization.XmlSerializableServices.ReadNodes(reader);
        }
        
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Runtime.Serialization.XmlSerializableServices.WriteNodes(writer, this.Nodes);
        }
        
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        
        public static System.Xml.XmlQualifiedName ExportSchema(System.Xml.Schema.XmlSchemaSet schemas)
        {
            System.Runtime.Serialization.XmlSerializableServices.AddDefaultSchema(schemas, typeName);
            return typeName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ForensicMarkIdType", Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class ForensicMarkIdType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Uri AlgorithmIdField;
        
        private long MarkIdField;
        
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
        public System.Uri AlgorithmId
        {
            get
            {
                return this.AlgorithmIdField;
            }
            set
            {
                this.AlgorithmIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long MarkId
        {
            get
            {
                return this.MarkIdField;
            }
            set
            {
                this.MarkIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("ExportSchema")]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable=false)]
    public partial class ContactInfoType : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Xml.XmlNode[] nodesField;
        
        private static System.Xml.XmlQualifiedName typeName = new System.Xml.XmlQualifiedName("ContactInfoType", "http://www.smpte-ra.org/schemas/430-7/2008/FLM");
        
        public System.Xml.XmlNode[] Nodes
        {
            get
            {
                return this.nodesField;
            }
            set
            {
                this.nodesField = value;
            }
        }
        
        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.nodesField = System.Runtime.Serialization.XmlSerializableServices.ReadNodes(reader);
        }
        
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Runtime.Serialization.XmlSerializableServices.WriteNodes(writer, this.Nodes);
        }
        
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        
        public static System.Xml.XmlQualifiedName ExportSchema(System.Xml.Schema.XmlSchemaSet schemas)
        {
            System.Runtime.Serialization.XmlSerializableServices.AddDefaultSchema(schemas, typeName);
            return typeName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UTCOffsetType", Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
    public partial class UTCOffsetType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string OffsetField;
        
        private www.smptera.org.schemas._4307._2008.FLM.UTCOffsetType.DSTExceptionType DSTExceptionField;
        
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
        public string Offset
        {
            get
            {
                return this.OffsetField;
            }
            set
            {
                this.OffsetField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public www.smptera.org.schemas._4307._2008.FLM.UTCOffsetType.DSTExceptionType DSTException
        {
            get
            {
                return this.DSTExceptionField;
            }
            set
            {
                this.DSTExceptionField = value;
            }
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="UTCOffsetType.DSTExceptionType", Namespace="http://www.smpte-ra.org/schemas/430-7/2008/FLM")]
        public partial class DSTExceptionType : object, System.Runtime.Serialization.IExtensibleDataObject
        {
            
            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
            
            private string DSTOffsetField;
            
            private System.DateTime DSTStartField;
            
            private System.DateTime DSTEndField;
            
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
            public string DSTOffset
            {
                get
                {
                    return this.DSTOffsetField;
                }
                set
                {
                    this.DSTOffsetField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
            public System.DateTime DSTStart
            {
                get
                {
                    return this.DSTStartField;
                }
                set
                {
                    this.DSTStartField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
            public System.DateTime DSTEnd
            {
                get
                {
                    return this.DSTEndField;
                }
                set
                {
                    this.DSTEndField = value;
                }
            }
        }
    }
}
