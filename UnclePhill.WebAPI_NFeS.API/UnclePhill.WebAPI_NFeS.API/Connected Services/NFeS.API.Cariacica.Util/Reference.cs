﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservices.sil.com/", ConfigurationName="NFeS.API.Cariacica.Util.WSUtil")]
    public interface WSUtil {
        
        // CODEGEN: Gerando contrato de mensagem porque o nome do elemento inscricaoMunicipal no namespace  não está marcado como nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSUtil/urlNfdRequest", ReplyAction="http://webservices.sil.com/WSUtil/urlNfdResponse")]
        UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponse urlNfd(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webservices.sil.com/WSUtil/urlNfdRequest", ReplyAction="http://webservices.sil.com/WSUtil/urlNfdResponse")]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponse> urlNfdAsync(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class urlNfdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="urlNfd", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequestBody Body;
        
        public urlNfdRequest() {
        }
        
        public urlNfdRequest(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class urlNfdRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int codigoMunicipio;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int numeroNfd;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int serieNfd;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string inscricaoMunicipal;
        
        public urlNfdRequestBody() {
        }
        
        public urlNfdRequestBody(int codigoMunicipio, int numeroNfd, int serieNfd, string inscricaoMunicipal) {
            this.codigoMunicipio = codigoMunicipio;
            this.numeroNfd = numeroNfd;
            this.serieNfd = serieNfd;
            this.inscricaoMunicipal = inscricaoMunicipal;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class urlNfdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="urlNfdResponse", Namespace="http://webservices.sil.com/", Order=0)]
        public UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponseBody Body;
        
        public urlNfdResponse() {
        }
        
        public urlNfdResponse(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class urlNfdResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public urlNfdResponseBody() {
        }
        
        public urlNfdResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSUtilChannel : UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.WSUtil, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSUtilClient : System.ServiceModel.ClientBase<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.WSUtil>, UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.WSUtil {
        
        public WSUtilClient() {
        }
        
        public WSUtilClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSUtilClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSUtilClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSUtilClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponse UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.WSUtil.urlNfd(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest request) {
            return base.Channel.urlNfd(request);
        }
        
        public string urlNfd(int codigoMunicipio, int numeroNfd, int serieNfd, string inscricaoMunicipal) {
            UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest inValue = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequestBody();
            inValue.Body.codigoMunicipio = codigoMunicipio;
            inValue.Body.numeroNfd = numeroNfd;
            inValue.Body.serieNfd = serieNfd;
            inValue.Body.inscricaoMunicipal = inscricaoMunicipal;
            UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponse retVal = ((UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.WSUtil)(this)).urlNfd(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponse> UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.WSUtil.urlNfdAsync(UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest request) {
            return base.Channel.urlNfdAsync(request);
        }
        
        public System.Threading.Tasks.Task<UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdResponse> urlNfdAsync(int codigoMunicipio, int numeroNfd, int serieNfd, string inscricaoMunicipal) {
            UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest inValue = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequest();
            inValue.Body = new UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.urlNfdRequestBody();
            inValue.Body.codigoMunicipio = codigoMunicipio;
            inValue.Body.numeroNfd = numeroNfd;
            inValue.Body.serieNfd = serieNfd;
            inValue.Body.inscricaoMunicipal = inscricaoMunicipal;
            return ((UnclePhill.WebAPI_NFeS.API.NFeS.API.Cariacica.Util.WSUtil)(this)).urlNfdAsync(inValue);
        }
    }
}
