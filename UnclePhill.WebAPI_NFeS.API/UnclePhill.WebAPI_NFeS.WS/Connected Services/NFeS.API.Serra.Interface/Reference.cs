﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservices.sil.com/", ConfigurationName="NFeS.API.Serra.Interface.WSInterface")]
    public interface WSInterface {
        
        // CODEGEN: Gerando contrato de mensagem porque o nome do elemento usuario no namespace  não está marcado como nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSInterface/executeRequest", ReplyAction="http://webservices.sil.com/WSInterface/executeResponse")]
        UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponse execute(UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSInterface/executeRequest", ReplyAction="http://webservices.sil.com/WSInterface/executeResponse")]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponse> executeAsync(UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class executeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="execute", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequestBody Body;
        
        public executeRequest() {
        }
        
        public executeRequest(UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class executeRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string hashSenha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string xml;
        
        public executeRequestBody() {
        }
        
        public executeRequestBody(string usuario, string hashSenha, string xml) {
            this.usuario = usuario;
            this.hashSenha = hashSenha;
            this.xml = xml;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class executeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="executeResponse", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponseBody Body;
        
        public executeResponse() {
        }
        
        public executeResponse(UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class executeResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public executeResponseBody() {
        }
        
        public executeResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSInterfaceChannel : UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.WSInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSInterfaceClient : System.ServiceModel.ClientBase<UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.WSInterface>, UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.WSInterface {
        
        public WSInterfaceClient() {
        }
        
        public WSInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponse UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.WSInterface.execute(UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest request) {
            return base.Channel.execute(request);
        }
        
        public string execute(string usuario, string hashSenha, string xml) {
            UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest inValue = new UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequestBody();
            inValue.Body.usuario = usuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.xml = xml;
            UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponse retVal = ((UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.WSInterface)(this)).execute(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponse> UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.WSInterface.executeAsync(UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest request) {
            return base.Channel.executeAsync(request);
        }
        
        public System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeResponse> executeAsync(string usuario, string hashSenha, string xml) {
            UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest inValue = new UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.executeRequestBody();
            inValue.Body.usuario = usuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.xml = xml;
            return ((UnclePhill.WebAPI_NFeS.WS.NFeS.API.Serra.Interface.WSInterface)(this)).executeAsync(inValue);
        }
    }
}
