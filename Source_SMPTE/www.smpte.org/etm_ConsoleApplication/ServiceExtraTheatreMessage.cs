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
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IServiceExtraTheatreMessage")]
public interface IServiceExtraTheatreMessage
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceExtraTheatreMessage/ETM", ReplyAction="http://tempuri.org/IServiceExtraTheatreMessage/ETMResponse")]
    string ETM(www.smpte.org.etm.DCinemaSecurityMessageType value);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IServiceExtraTheatreMessageChannel : IServiceExtraTheatreMessage, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ServiceExtraTheatreMessageClient : System.ServiceModel.ClientBase<IServiceExtraTheatreMessage>, IServiceExtraTheatreMessage
{
    
    public ServiceExtraTheatreMessageClient()
    {
    }
    
    public ServiceExtraTheatreMessageClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServiceExtraTheatreMessageClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceExtraTheatreMessageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceExtraTheatreMessageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }

    public string ETM(www.smpte.org.etm.DCinemaSecurityMessageType value)
    {
        return base.Channel.ETM(value);
    }
}
