﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservices.sil.com/", ConfigurationName="NFeS.API.Cariacica.Entrada.WSEntrada")]
    public interface WSEntrada {
        
        // CODEGEN: Gerando contrato de mensagem porque o nome do elemento cpfUsuario no namespace  não está marcado como nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSEntrada/consultarAtividadesRequest", ReplyAction="http://webservices.sil.com/WSEntrada/consultarAtividadesResponse")]
        UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponse consultarAtividades(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSEntrada/consultarAtividadesRequest", ReplyAction="http://webservices.sil.com/WSEntrada/consultarAtividadesResponse")]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponse> consultarAtividadesAsync(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest request);
        
        // CODEGEN: Gerando contrato de mensagem porque o nome do elemento cpfUsuario no namespace  não está marcado como nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSEntrada/nfdEntradaCancelarRequest", ReplyAction="http://webservices.sil.com/WSEntrada/nfdEntradaCancelarResponse")]
        UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponse nfdEntradaCancelar(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSEntrada/nfdEntradaCancelarRequest", ReplyAction="http://webservices.sil.com/WSEntrada/nfdEntradaCancelarResponse")]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponse> nfdEntradaCancelarAsync(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest request);
        
        // CODEGEN: Gerando contrato de mensagem porque o nome do elemento cpfUsuario no namespace  não está marcado como nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSEntrada/nfdEntradaRequest", ReplyAction="http://webservices.sil.com/WSEntrada/nfdEntradaResponse")]
        UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponse nfdEntrada(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSEntrada/nfdEntradaRequest", ReplyAction="http://webservices.sil.com/WSEntrada/nfdEntradaResponse")]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponse> nfdEntradaAsync(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class consultarAtividadesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="consultarAtividades", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequestBody Body;
        
        public consultarAtividadesRequest() {
        }
        
        public consultarAtividadesRequest(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class consultarAtividadesRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cpfUsuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string hashSenha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string inscricaoMunicipal;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int codigoMunicipio;
        
        public consultarAtividadesRequestBody() {
        }
        
        public consultarAtividadesRequestBody(string cpfUsuario, string hashSenha, string inscricaoMunicipal, int codigoMunicipio) {
            this.cpfUsuario = cpfUsuario;
            this.hashSenha = hashSenha;
            this.inscricaoMunicipal = inscricaoMunicipal;
            this.codigoMunicipio = codigoMunicipio;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class consultarAtividadesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="consultarAtividadesResponse", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponseBody Body;
        
        public consultarAtividadesResponse() {
        }
        
        public consultarAtividadesResponse(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class consultarAtividadesResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public consultarAtividadesResponseBody() {
        }
        
        public consultarAtividadesResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class nfdEntradaCancelarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="nfdEntradaCancelar", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequestBody Body;
        
        public nfdEntradaCancelarRequest() {
        }
        
        public nfdEntradaCancelarRequest(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class nfdEntradaCancelarRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cpfUsuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string hashSenha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string nfd;
        
        public nfdEntradaCancelarRequestBody() {
        }
        
        public nfdEntradaCancelarRequestBody(string cpfUsuario, string hashSenha, string nfd) {
            this.cpfUsuario = cpfUsuario;
            this.hashSenha = hashSenha;
            this.nfd = nfd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class nfdEntradaCancelarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="nfdEntradaCancelarResponse", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponseBody Body;
        
        public nfdEntradaCancelarResponse() {
        }
        
        public nfdEntradaCancelarResponse(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class nfdEntradaCancelarResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public nfdEntradaCancelarResponseBody() {
        }
        
        public nfdEntradaCancelarResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class nfdEntradaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="nfdEntrada", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequestBody Body;
        
        public nfdEntradaRequest() {
        }
        
        public nfdEntradaRequest(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class nfdEntradaRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cpfUsuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string hashSenha;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int codigoMunicipio;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string nfd;
        
        public nfdEntradaRequestBody() {
        }
        
        public nfdEntradaRequestBody(string cpfUsuario, string hashSenha, int codigoMunicipio, string nfd) {
            this.cpfUsuario = cpfUsuario;
            this.hashSenha = hashSenha;
            this.codigoMunicipio = codigoMunicipio;
            this.nfd = nfd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class nfdEntradaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="nfdEntradaResponse", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponseBody Body;
        
        public nfdEntradaResponse() {
        }
        
        public nfdEntradaResponse(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class nfdEntradaResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public nfdEntradaResponseBody() {
        }
        
        public nfdEntradaResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSEntradaChannel : UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSEntradaClient : System.ServiceModel.ClientBase<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada>, UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada {
        
        public WSEntradaClient() {
        }
        
        public WSEntradaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSEntradaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSEntradaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSEntradaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponse UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada.consultarAtividades(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest request) {
            return base.Channel.consultarAtividades(request);
        }
        
        public string consultarAtividades(string cpfUsuario, string hashSenha, string inscricaoMunicipal, int codigoMunicipio) {
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest inValue = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.inscricaoMunicipal = inscricaoMunicipal;
            inValue.Body.codigoMunicipio = codigoMunicipio;
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponse retVal = ((UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada)(this)).consultarAtividades(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponse> UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada.consultarAtividadesAsync(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest request) {
            return base.Channel.consultarAtividadesAsync(request);
        }
        
        public System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesResponse> consultarAtividadesAsync(string cpfUsuario, string hashSenha, string inscricaoMunicipal, int codigoMunicipio) {
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest inValue = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.consultarAtividadesRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.inscricaoMunicipal = inscricaoMunicipal;
            inValue.Body.codigoMunicipio = codigoMunicipio;
            return ((UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada)(this)).consultarAtividadesAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponse UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada.nfdEntradaCancelar(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest request) {
            return base.Channel.nfdEntradaCancelar(request);
        }
        
        public string nfdEntradaCancelar(string cpfUsuario, string hashSenha, string nfd) {
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest inValue = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.nfd = nfd;
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponse retVal = ((UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada)(this)).nfdEntradaCancelar(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponse> UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada.nfdEntradaCancelarAsync(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest request) {
            return base.Channel.nfdEntradaCancelarAsync(request);
        }
        
        public System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarResponse> nfdEntradaCancelarAsync(string cpfUsuario, string hashSenha, string nfd) {
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest inValue = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaCancelarRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.nfd = nfd;
            return ((UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada)(this)).nfdEntradaCancelarAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponse UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada.nfdEntrada(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest request) {
            return base.Channel.nfdEntrada(request);
        }
        
        public string nfdEntrada(string cpfUsuario, string hashSenha, int codigoMunicipio, string nfd) {
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest inValue = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.codigoMunicipio = codigoMunicipio;
            inValue.Body.nfd = nfd;
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponse retVal = ((UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada)(this)).nfdEntrada(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponse> UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada.nfdEntradaAsync(UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest request) {
            return base.Channel.nfdEntradaAsync(request);
        }
        
        public System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaResponse> nfdEntradaAsync(string cpfUsuario, string hashSenha, int codigoMunicipio, string nfd) {
            UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest inValue = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.nfdEntradaRequestBody();
            inValue.Body.cpfUsuario = cpfUsuario;
            inValue.Body.hashSenha = hashSenha;
            inValue.Body.codigoMunicipio = codigoMunicipio;
            inValue.Body.nfd = nfd;
            return ((UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada.WSEntrada)(this)).nfdEntradaAsync(inValue);
        }
    }
}
