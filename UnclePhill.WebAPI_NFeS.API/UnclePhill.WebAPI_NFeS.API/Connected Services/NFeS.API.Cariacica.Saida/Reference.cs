﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservices.sil.com/", ConfigurationName="NFeS.API.Cariacica.Saida.WSSaida")]
    public interface WSSaida {
        
        // CODEGEN: Gerando contrato de mensagem porque o nome do elemento cpfUsuario no namespace  não está marcado como nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSSaida/nfdSaidaRequest", ReplyAction="http://webservices.sil.com/WSSaida/nfdSaidaResponse")]
        UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponse nfdSaida(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSSaida/nfdSaidaRequest", ReplyAction="http://webservices.sil.com/WSSaida/nfdSaidaResponse")]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponse> nfdSaidaAsync(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class nfdSaidaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="nfdSaida", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequestBody Body;
        
        public nfdSaidaRequest() {
        }
        
        public nfdSaidaRequest(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class nfdSaidaRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cpfUsuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string hashSenha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string inscricaoMunicipal;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string recibo;
        
        public nfdSaidaRequestBody() {
        }
        
        public nfdSaidaRequestBody(string cpfUsuario, string hashSenha, string inscricaoMunicipal, string recibo) {
            this.cpfUsuario = cpfUsuario;
            this.hashSenha = hashSenha;
            this.inscricaoMunicipal = inscricaoMunicipal;
            this.recibo = recibo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class nfdSaidaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="nfdSaidaResponse", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponseBody Body;
        
        public nfdSaidaResponse() {
        }
        
        public nfdSaidaResponse(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class nfdSaidaResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public nfdSaidaResponseBody() {
        }
        
        public nfdSaidaResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSSaidaChannel : UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.WSSaida, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSSaidaClient : System.ServiceModel.ClientBase<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.WSSaida>, UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.WSSaida {
        
        public WSSaidaClient() {
        }
        
        public WSSaidaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSSaidaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSSaidaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSSaidaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponse UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.WSSaida.nfdSaida(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest request) {
            return base.Channel.nfdSaida(request);
        }
        
        public string nfdSaida(string cpfUsuario, string hashSenha, string inscricaoMunicipal, string recibo) {
            UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest inValue = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.inscricaoMunicipal = inscricaoMunicipal;
            inValue.Body.recibo = recibo;
            UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponse retVal = ((UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.WSSaida)(this)).nfdSaida(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponse> UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.WSSaida.nfdSaidaAsync(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest request) {
            return base.Channel.nfdSaidaAsync(request);
        }
        
        public System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaResponse> nfdSaidaAsync(string cpfUsuario, string hashSenha, string inscricaoMunicipal, string recibo) {
            UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest inValue = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.nfdSaidaRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.inscricaoMunicipal = inscricaoMunicipal;
            inValue.Body.recibo = recibo;
            return ((UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Saida.WSSaida)(this)).nfdSaidaAsync(inValue);
        }
    }
}
