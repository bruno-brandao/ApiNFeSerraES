using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure.NFeSProcessingResult
{


    // OBSERVAÇÃO: o código gerado pode exigir pelo menos .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class tbnfd
    {

        private tbnfdNfdok nfdokField;

        /// <remarks/>
        public tbnfdNfdok nfdok
        {
            get
            {
                return this.nfdokField;
            }
            set
            {
                this.nfdokField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdok
    {

        private tbnfdNfdokNewDataSet newDataSetField;

        private string numeronfdField;

        /// <remarks/>
        public tbnfdNfdokNewDataSet NewDataSet
        {
            get
            {
                return this.newDataSetField;
            }
            set
            {
                this.newDataSetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string numeronfd
        {
            get
            {
                return this.numeronfdField;
            }
            set
            {
                this.numeronfdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdokNewDataSet
    {

        private tbnfdNfdokNewDataSetNOTA_FISCAL nOTA_FISCALField;

        /// <remarks/>
        public tbnfdNfdokNewDataSetNOTA_FISCAL NOTA_FISCAL
        {
            get
            {
                return this.nOTA_FISCALField;
            }
            set
            {
                this.nOTA_FISCALField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdokNewDataSetNOTA_FISCAL
    {

        private string caeField;

        private string dataEmissaoField;

        private string naturezaOperacaoField;

        private string numeroNotaField;

        private string numeroRpsField;

        private string situacaoNfField;

        private string chaveValidacaoField;

        private string clienteNomeRazaoSocialField;

        private string clienteNomeFantasiaField;

        private string clienteCNPJCPFField;

        private string clienteEnderecoField;

        private string clienteBairroField;

        private string clienteNumeroLogradouroField;

        private string clienteCidadeField;

        private string clienteUFField;

        private string clientePaisField;

        private string clienteFoneField;

        private string clienteFaxField;

        private string clienteInscricaoMunicipalField;

        private string clienteCEPField;

        private string clienteEmailField;

        private string clienteInscricaoEstadualField;

        private string baseCalculoField;

        private string iSSQNClienteField;

        private string iSSQNSemRetencaoField;

        private string iSSQNTotalField;

        private string irrfField;

        private string cofinsField;

        private string inssField;

        private string csllField;

        private string pisField;

        private string valorTotalNotaField;

        private string freteCNPJField;

        private string freteRazaoSocialField;

        private string freteEnderecoField;

        private string freteEmitenteField;

        private string freteDestinatarioField;

        private string freteQuantidadeField;

        private string freteEspecieField;

        private string fretePesoLiquidoField;

        private string fretePesoBrutoField;

        private string serieField;

        private string serieSimplificadaField;

        private string codigoSerieField;

        private string observacaoField;

        private string servicoCidadeField;

        private string servicoEstadoField;

        private string timbreContribstringeLogoField;

        private string timbreContribstringeLinha1Field;

        private string timbreContribstringeLinha2Field;

        private string timbreContribstringeLinha3Field;

        private string timbreContribstringeLinha4Field;

        private string timbrePrefeituraLogoField;

        private string timbrePrefeituraLinha1Field;

        private string timbrePrefeituraLinha2Field;

        private string timbrePrefeituraLinha3Field;

        private tbnfdNfdokNewDataSetNOTA_FISCALFATURA fATURAField;

        private tbnfdNfdokNewDataSetNOTA_FISCALITENS iTENSField;

        /// <remarks/>
        public string Cae
        {
            get
            {
                return this.caeField;
            }
            set
            {
                this.caeField = value;
            }
        }

        /// <remarks/>
        public string DataEmissao
        {
            get
            {
                return this.dataEmissaoField;
            }
            set
            {
                this.dataEmissaoField = value;
            }
        }

        /// <remarks/>
        public string NaturezaOperacao
        {
            get
            {
                return this.naturezaOperacaoField;
            }
            set
            {
                this.naturezaOperacaoField = value;
            }
        }

        /// <remarks/>
        public string NumeroNota
        {
            get
            {
                return this.numeroNotaField;
            }
            set
            {
                this.numeroNotaField = value;
            }
        }

        /// <remarks/>
        public string NumeroRps
        {
            get
            {
                return this.numeroRpsField;
            }
            set
            {
                this.numeroRpsField = value;
            }
        }

        /// <remarks/>
        public string SituacaoNf
        {
            get
            {
                return this.situacaoNfField;
            }
            set
            {
                this.situacaoNfField = value;
            }
        }

        /// <remarks/>
        public string ChaveValidacao
        {
            get
            {
                return this.chaveValidacaoField;
            }
            set
            {
                this.chaveValidacaoField = value;
            }
        }

        /// <remarks/>
        public string ClienteNomeRazaoSocial
        {
            get
            {
                return this.clienteNomeRazaoSocialField;
            }
            set
            {
                this.clienteNomeRazaoSocialField = value;
            }
        }

        /// <remarks/>
        public string ClienteNomeFantasia
        {
            get
            {
                return this.clienteNomeFantasiaField;
            }
            set
            {
                this.clienteNomeFantasiaField = value;
            }
        }

        /// <remarks/>
        public string ClienteCNPJCPF
        {
            get
            {
                return this.clienteCNPJCPFField;
            }
            set
            {
                this.clienteCNPJCPFField = value;
            }
        }

        /// <remarks/>
        public string ClienteEndereco
        {
            get
            {
                return this.clienteEnderecoField;
            }
            set
            {
                this.clienteEnderecoField = value;
            }
        }

        /// <remarks/>
        public string ClienteBairro
        {
            get
            {
                return this.clienteBairroField;
            }
            set
            {
                this.clienteBairroField = value;
            }
        }

        /// <remarks/>
        public string ClienteNumeroLogradouro
        {
            get
            {
                return this.clienteNumeroLogradouroField;
            }
            set
            {
                this.clienteNumeroLogradouroField = value;
            }
        }

        /// <remarks/>
        public string ClienteCidade
        {
            get
            {
                return this.clienteCidadeField;
            }
            set
            {
                this.clienteCidadeField = value;
            }
        }

        /// <remarks/>
        public string ClienteUF
        {
            get
            {
                return this.clienteUFField;
            }
            set
            {
                this.clienteUFField = value;
            }
        }

        /// <remarks/>
        public string ClientePais
        {
            get
            {
                return this.clientePaisField;
            }
            set
            {
                this.clientePaisField = value;
            }
        }

        /// <remarks/>
        public string ClienteFone
        {
            get
            {
                return this.clienteFoneField;
            }
            set
            {
                this.clienteFoneField = value;
            }
        }

        /// <remarks/>
        public string ClienteFax
        {
            get
            {
                return this.clienteFaxField;
            }
            set
            {
                this.clienteFaxField = value;
            }
        }

        /// <remarks/>
        public string ClienteInscricaoMunicipal
        {
            get
            {
                return this.clienteInscricaoMunicipalField;
            }
            set
            {
                this.clienteInscricaoMunicipalField = value;
            }
        }

        /// <remarks/>
        public string ClienteCEP
        {
            get
            {
                return this.clienteCEPField;
            }
            set
            {
                this.clienteCEPField = value;
            }
        }

        /// <remarks/>
        public string ClienteEmail
        {
            get
            {
                return this.clienteEmailField;
            }
            set
            {
                this.clienteEmailField = value;
            }
        }

        /// <remarks/>
        public string ClienteInscricaoEstadual
        {
            get
            {
                return this.clienteInscricaoEstadualField;
            }
            set
            {
                this.clienteInscricaoEstadualField = value;
            }
        }

        /// <remarks/>
        public string BaseCalculo
        {
            get
            {
                return this.baseCalculoField;
            }
            set
            {
                this.baseCalculoField = value;
            }
        }

        /// <remarks/>
        public string ISSQNCliente
        {
            get
            {
                return this.iSSQNClienteField;
            }
            set
            {
                this.iSSQNClienteField = value;
            }
        }

        /// <remarks/>
        public string ISSQNSemRetencao
        {
            get
            {
                return this.iSSQNSemRetencaoField;
            }
            set
            {
                this.iSSQNSemRetencaoField = value;
            }
        }

        /// <remarks/>
        public string ISSQNTotal
        {
            get
            {
                return this.iSSQNTotalField;
            }
            set
            {
                this.iSSQNTotalField = value;
            }
        }

        /// <remarks/>
        public string Irrf
        {
            get
            {
                return this.irrfField;
            }
            set
            {
                this.irrfField = value;
            }
        }

        /// <remarks/>
        public string Cofins
        {
            get
            {
                return this.cofinsField;
            }
            set
            {
                this.cofinsField = value;
            }
        }

        /// <remarks/>
        public string Inss
        {
            get
            {
                return this.inssField;
            }
            set
            {
                this.inssField = value;
            }
        }

        /// <remarks/>
        public string Csll
        {
            get
            {
                return this.csllField;
            }
            set
            {
                this.csllField = value;
            }
        }

        /// <remarks/>
        public string Pis
        {
            get
            {
                return this.pisField;
            }
            set
            {
                this.pisField = value;
            }
        }

        /// <remarks/>
        public string ValorTotalNota
        {
            get
            {
                return this.valorTotalNotaField;
            }
            set
            {
                this.valorTotalNotaField = value;
            }
        }

        /// <remarks/>
        public string FreteCNPJ
        {
            get
            {
                return this.freteCNPJField;
            }
            set
            {
                this.freteCNPJField = value;
            }
        }

        /// <remarks/>
        public string FreteRazaoSocial
        {
            get
            {
                return this.freteRazaoSocialField;
            }
            set
            {
                this.freteRazaoSocialField = value;
            }
        }

        /// <remarks/>
        public string FreteEndereco
        {
            get
            {
                return this.freteEnderecoField;
            }
            set
            {
                this.freteEnderecoField = value;
            }
        }

        /// <remarks/>
        public string FreteEmitente
        {
            get
            {
                return this.freteEmitenteField;
            }
            set
            {
                this.freteEmitenteField = value;
            }
        }

        /// <remarks/>
        public string FreteDestinatario
        {
            get
            {
                return this.freteDestinatarioField;
            }
            set
            {
                this.freteDestinatarioField = value;
            }
        }

        /// <remarks/>
        public string FreteQuantidade
        {
            get
            {
                return this.freteQuantidadeField;
            }
            set
            {
                this.freteQuantidadeField = value;
            }
        }

        /// <remarks/>
        public string FreteEspecie
        {
            get
            {
                return this.freteEspecieField;
            }
            set
            {
                this.freteEspecieField = value;
            }
        }

        /// <remarks/>
        public string FretePesoLiquido
        {
            get
            {
                return this.fretePesoLiquidoField;
            }
            set
            {
                this.fretePesoLiquidoField = value;
            }
        }

        /// <remarks/>
        public string FretePesoBruto
        {
            get
            {
                return this.fretePesoBrutoField;
            }
            set
            {
                this.fretePesoBrutoField = value;
            }
        }

        /// <remarks/>
        public string Serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <remarks/>
        public string SerieSimplificada
        {
            get
            {
                return this.serieSimplificadaField;
            }
            set
            {
                this.serieSimplificadaField = value;
            }
        }

        /// <remarks/>
        public string CodigoSerie
        {
            get
            {
                return this.codigoSerieField;
            }
            set
            {
                this.codigoSerieField = value;
            }
        }

        /// <remarks/>
        public string Observacao
        {
            get
            {
                return this.observacaoField;
            }
            set
            {
                this.observacaoField = value;
            }
        }

        /// <remarks/>
        public string servicoCidade
        {
            get
            {
                return this.servicoCidadeField;
            }
            set
            {
                this.servicoCidadeField = value;
            }
        }

        /// <remarks/>
        public string servicoEstado
        {
            get
            {
                return this.servicoEstadoField;
            }
            set
            {
                this.servicoEstadoField = value;
            }
        }

        /// <remarks/>
        public string TimbreContribstringeLogo
        {
            get
            {
                return this.timbreContribstringeLogoField;
            }
            set
            {
                this.timbreContribstringeLogoField = value;
            }
        }

        /// <remarks/>
        public string TimbreContribstringeLinha1
        {
            get
            {
                return this.timbreContribstringeLinha1Field;
            }
            set
            {
                this.timbreContribstringeLinha1Field = value;
            }
        }

        /// <remarks/>
        public string TimbreContribstringeLinha2
        {
            get
            {
                return this.timbreContribstringeLinha2Field;
            }
            set
            {
                this.timbreContribstringeLinha2Field = value;
            }
        }

        /// <remarks/>
        public string TimbreContribstringeLinha3
        {
            get
            {
                return this.timbreContribstringeLinha3Field;
            }
            set
            {
                this.timbreContribstringeLinha3Field = value;
            }
        }

        /// <remarks/>
        public string TimbreContribstringeLinha4
        {
            get
            {
                return this.timbreContribstringeLinha4Field;
            }
            set
            {
                this.timbreContribstringeLinha4Field = value;
            }
        }

        /// <remarks/>
        public string TimbrePrefeituraLogo
        {
            get
            {
                return this.timbrePrefeituraLogoField;
            }
            set
            {
                this.timbrePrefeituraLogoField = value;
            }
        }

        /// <remarks/>
        public string TimbrePrefeituraLinha1
        {
            get
            {
                return this.timbrePrefeituraLinha1Field;
            }
            set
            {
                this.timbrePrefeituraLinha1Field = value;
            }
        }

        /// <remarks/>
        public string TimbrePrefeituraLinha2
        {
            get
            {
                return this.timbrePrefeituraLinha2Field;
            }
            set
            {
                this.timbrePrefeituraLinha2Field = value;
            }
        }

        /// <remarks/>
        public string TimbrePrefeituraLinha3
        {
            get
            {
                return this.timbrePrefeituraLinha3Field;
            }
            set
            {
                this.timbrePrefeituraLinha3Field = value;
            }
        }

        /// <remarks/>
        public tbnfdNfdokNewDataSetNOTA_FISCALFATURA FATURA
        {
            get
            {
                return this.fATURAField;
            }
            set
            {
                this.fATURAField = value;
            }
        }

        /// <remarks/>
        public tbnfdNfdokNewDataSetNOTA_FISCALITENS ITENS
        {
            get
            {
                return this.iTENSField;
            }
            set
            {
                this.iTENSField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdokNewDataSetNOTA_FISCALFATURA
    {

        private string numeroField;

        private string vencimentoField;

        private string valorField;

        /// <remarks/>
        public string Numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <remarks/>
        public string Vencimento
        {
            get
            {
                return this.vencimentoField;
            }
            set
            {
                this.vencimentoField = value;
            }
        }

        /// <remarks/>
        public string Valor
        {
            get
            {
                return this.valorField;
            }
            set
            {
                this.valorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdokNewDataSetNOTA_FISCALITENS
    {

        private string quantidadeField;

        private string codigoAtividadeField;

        private string servicoField;

        private string valorUnitarioField;

        private string valorTotalField;

        private string impostoRetidoField;

        private string aliquotaField;

        /// <remarks/>
        public string Quantidade
        {
            get
            {
                return this.quantidadeField;
            }
            set
            {
                this.quantidadeField = value;
            }
        }

        /// <remarks/>
        public string CodigoAtividade
        {
            get
            {
                return this.codigoAtividadeField;
            }
            set
            {
                this.codigoAtividadeField = value;
            }
        }

        /// <remarks/>
        public string Servico
        {
            get
            {
                return this.servicoField;
            }
            set
            {
                this.servicoField = value;
            }
        }

        /// <remarks/>
        public string ValorUnitario
        {
            get
            {
                return this.valorUnitarioField;
            }
            set
            {
                this.valorUnitarioField = value;
            }
        }

        /// <remarks/>
        public string ValorTotal
        {
            get
            {
                return this.valorTotalField;
            }
            set
            {
                this.valorTotalField = value;
            }
        }

        /// <remarks/>
        public string ImpostoRetido
        {
            get
            {
                return this.impostoRetidoField;
            }
            set
            {
                this.impostoRetidoField = value;
            }
        }

        /// <remarks/>
        public string Aliquota
        {
            get
            {
                return this.aliquotaField;
            }
            set
            {
                this.aliquotaField = value;
            }
        }
    }


}