﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IServiceFacilityListMessage")]
public interface IServiceFacilityListMessage
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceFacilityListMessage/FLM", ReplyAction="http://tempuri.org/IServiceFacilityListMessage/FLMResponse")]
    string FLM(www.smpte.org.etm.DCinemaSecurityMessageType value);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IServiceFacilityListMessageChannel : IServiceFacilityListMessage, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ServiceFacilityListMessageClient : System.ServiceModel.ClientBase<IServiceFacilityListMessage>, IServiceFacilityListMessage
{
    
    public ServiceFacilityListMessageClient()
    {
    }
    
    public ServiceFacilityListMessageClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServiceFacilityListMessageClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceFacilityListMessageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceFacilityListMessageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }

    public string FLM(www.smpte.org.etm.DCinemaSecurityMessageType value)
    {
        return base.Channel.FLM(value);
    }
}
