using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure
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

        private ushort numeronfdField;

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
        public ushort numeronfd
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

        private tbnfdNfdokNewDataSetFATURA fATURAField;

        private tbnfdNfdokNewDataSetITENS iTENSField;

        private tbnfdNfdokNewDataSetSignerData signerDataField;

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

        /// <remarks/>
        public tbnfdNfdokNewDataSetFATURA FATURA
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
        public tbnfdNfdokNewDataSetITENS ITENS
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

        /// <remarks/>
        public tbnfdNfdokNewDataSetSignerData SignerData
        {
            get
            {
                return this.signerDataField;
            }
            set
            {
                this.signerDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdokNewDataSetNOTA_FISCAL
    {

        private ushort caeField;

        private System.DateTime dataEmissaoField;

        private string naturezaOperacaoField;

        private ushort numeroNotaField;

        private string clienteNomeRazaoSocialField;

        private string clienteNomeFantasiaField;

        private string clienteEnderecoField;

        private string clienteBairroField;

        private ushort clienteNumeroLogradouroField;

        private string clienteCidadeField;

        private string clienteUFField;

        private string clientePaisField;

        private uint clienteFoneField;

        private object clienteFaxField;

        private object clienteInscricaoMunicipalField;

        private uint clienteCEPField;

        private string clienteEmailField;

        private ulong clienteCNPJCPFField;

        private object clienteInscricaoEstadualField;

        private byte baseCalculoField;

        private byte iSSQNClienteField;

        private decimal iSSQNSemRetencaoField;

        private byte vlraproximpostoField;

        private byte aliquotaimpostoaproxField;

        private string fonteimpostoaproxField;

        private decimal iSSQNTotalField;

        private byte valorTotalNotaField;

        private object freteCNPJField;

        private object freteRazaoSocialField;

        private object freteEnderecoField;

        private bool freteEmitenteField;

        private bool freteDestinatarioField;

        private byte freteQuantidadeField;

        private byte freteEspecieField;

        private byte fretePesoLiquidoField;

        private byte fretePesoBrutoField;

        private string serieField;

        private bool serieSimplificadaField;

        private byte codigoSerieField;

        private string timbreContribuinteLogoField;

        private string timbreContribuinteLinha1Field;

        private string timbreContribuinteLinha2Field;

        private string timbreContribuinteLinha3Field;

        private string timbreContribuinteLinha4Field;

        private string timbrePrefeituraLogoField;

        private string timbrePrefeituraLinha1Field;

        private string timbrePrefeituraLinha2Field;

        private string timbrePrefeituraLinha3Field;

        /// <remarks/>
        public ushort Cae
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
        public System.DateTime DataEmissao
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
        public ushort NumeroNota
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
        public ushort ClienteNumeroLogradouro
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
        public uint ClienteFone
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
        public object ClienteFax
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
        public object ClienteInscricaoMunicipal
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
        public uint ClienteCEP
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
        public ulong ClienteCNPJCPF
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
        public object ClienteInscricaoEstadual
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
        public byte BaseCalculo
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
        public byte ISSQNCliente
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
        public decimal ISSQNSemRetencao
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
        public byte vlraproximposto
        {
            get
            {
                return this.vlraproximpostoField;
            }
            set
            {
                this.vlraproximpostoField = value;
            }
        }

        /// <remarks/>
        public byte aliquotaimpostoaprox
        {
            get
            {
                return this.aliquotaimpostoaproxField;
            }
            set
            {
                this.aliquotaimpostoaproxField = value;
            }
        }

        /// <remarks/>
        public string fonteimpostoaprox
        {
            get
            {
                return this.fonteimpostoaproxField;
            }
            set
            {
                this.fonteimpostoaproxField = value;
            }
        }

        /// <remarks/>
        public decimal ISSQNTotal
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
        public byte ValorTotalNota
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
        public object FreteCNPJ
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
        public object FreteRazaoSocial
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
        public object FreteEndereco
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
        public bool FreteEmitente
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
        public bool FreteDestinatario
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
        public byte FreteQuantidade
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
        public byte FreteEspecie
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
        public byte FretePesoLiquido
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
        public byte FretePesoBruto
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
        public bool SerieSimplificada
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
        public byte CodigoSerie
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
        public string TimbreContribuinteLogo
        {
            get
            {
                return this.timbreContribuinteLogoField;
            }
            set
            {
                this.timbreContribuinteLogoField = value;
            }
        }

        /// <remarks/>
        public string TimbreContribuinteLinha1
        {
            get
            {
                return this.timbreContribuinteLinha1Field;
            }
            set
            {
                this.timbreContribuinteLinha1Field = value;
            }
        }

        /// <remarks/>
        public string TimbreContribuinteLinha2
        {
            get
            {
                return this.timbreContribuinteLinha2Field;
            }
            set
            {
                this.timbreContribuinteLinha2Field = value;
            }
        }

        /// <remarks/>
        public string TimbreContribuinteLinha3
        {
            get
            {
                return this.timbreContribuinteLinha3Field;
            }
            set
            {
                this.timbreContribuinteLinha3Field = value;
            }
        }

        /// <remarks/>
        public string TimbreContribuinteLinha4
        {
            get
            {
                return this.timbreContribuinteLinha4Field;
            }
            set
            {
                this.timbreContribuinteLinha4Field = value;
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdokNewDataSetFATURA
    {

        private string numeroField;

        private System.DateTime vencimentoField;

        private byte valorField;

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
        public System.DateTime Vencimento
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
        public byte Valor
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
    public partial class tbnfdNfdokNewDataSetITENS
    {

        private byte quantidadeField;

        private ushort codigoAtividadeField;

        private string servicoField;

        private byte valorUnitarioField;

        private ushort valorTotalField;

        private bool impostoRetidoField;

        private decimal aliquotaField;

        /// <remarks/>
        public byte Quantidade
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
        public ushort CodigoAtividade
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
        public byte ValorUnitario
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
        public ushort ValorTotal
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
        public bool ImpostoRetido
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
        public decimal Aliquota
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdokNewDataSetSignerData
    {

        private string assinaturaField;

        /// <remarks/>
        public string Assinatura
        {
            get
            {
                return this.assinaturaField;
            }
            set
            {
                this.assinaturaField = value;
            }
        }
    }
}