using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure.NFeSIssueRequest
{
    // OBSERVAÇÃO: o código gerado pode exigir pelo menos .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class tbnfd
    {

        public tbnfd()
        {
            nfdField = new tbnfdNfd();
            signatureField = new Signature();
        }

        private tbnfdNfd nfdField;

        private Signature signatureField;

        /// <remarks/>
        public tbnfdNfd nfd
        {
            get
            {
                return this.nfdField;
            }
            set
            {
                this.nfdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfd
    {

        private byte numeronfdField;

        private byte codseriedocumentoField;

        private ushort codnaturezaoperacaoField;

        private byte codigocidadeField;

        private uint inscricaomunicipalemissorField;

        private string dataemissaoField;

        private string razaotomadorField;

        private string nomefantasiatomadorField;

        private string enderecotomadorField;

        private ushort numeroenderecoField;

        private string cidadetomadorField;

        private string estadotomadorField;

        private string paistomadorField;

        private uint fonetomadorField;

        private object faxtomadorField;

        private uint ceptomadorField;

        private string bairrotomadorField;

        private string emailtomadorField;

        private string tppessoaField;

        private ulong cpfcnpjtomadorField;

        private object inscricaoestadualtomadorField;

        private object inscricaomunicipaltomadorField;

        private tbnfdNfdFatura[] tbfaturaField;

        private tbnfdNfdServico[] tbservicoField;

        private string observacaoField;

        private object razaotransportadoraField;

        private object cpfcnpjtransportadoraField;

        private object enderecotransportadoraField;

        private object pisField;

        private object cofinsField;

        private object csllField;

        private object irrfField;

        private object inssField;

        private object descdeducoesconstrucaoField;

        private object totaldeducoesconstrucaoField;

        private bool tributadonomunicipioField;

        private object numerortField;

        private object codigoseriertField;

        private object dataemissaortField;

        private string fatorgeradorField;

        /// <remarks/>
        public byte numeronfd
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

        /// <remarks/>
        public byte codseriedocumento
        {
            get
            {
                return this.codseriedocumentoField;
            }
            set
            {
                this.codseriedocumentoField = value;
            }
        }

        /// <remarks/>
        public ushort codnaturezaoperacao
        {
            get
            {
                return this.codnaturezaoperacaoField;
            }
            set
            {
                this.codnaturezaoperacaoField = value;
            }
        }

        /// <remarks/>
        public byte codigocidade
        {
            get
            {
                return this.codigocidadeField;
            }
            set
            {
                this.codigocidadeField = value;
            }
        }

        /// <remarks/>
        public uint inscricaomunicipalemissor
        {
            get
            {
                return this.inscricaomunicipalemissorField;
            }
            set
            {
                this.inscricaomunicipalemissorField = value;
            }
        }

        /// <remarks/>
        public string dataemissao
        {
            get
            {
                return this.dataemissaoField;
            }
            set
            {
                this.dataemissaoField = value;
            }
        }

        /// <remarks/>
        public string razaotomador
        {
            get
            {
                return this.razaotomadorField;
            }
            set
            {
                this.razaotomadorField = value;
            }
        }

        /// <remarks/>
        public string nomefantasiatomador
        {
            get
            {
                return this.nomefantasiatomadorField;
            }
            set
            {
                this.nomefantasiatomadorField = value;
            }
        }

        /// <remarks/>
        public string enderecotomador
        {
            get
            {
                return this.enderecotomadorField;
            }
            set
            {
                this.enderecotomadorField = value;
            }
        }

        /// <remarks/>
        public ushort numeroendereco
        {
            get
            {
                return this.numeroenderecoField;
            }
            set
            {
                this.numeroenderecoField = value;
            }
        }

        /// <remarks/>
        public string cidadetomador
        {
            get
            {
                return this.cidadetomadorField;
            }
            set
            {
                this.cidadetomadorField = value;
            }
        }

        /// <remarks/>
        public string estadotomador
        {
            get
            {
                return this.estadotomadorField;
            }
            set
            {
                this.estadotomadorField = value;
            }
        }

        /// <remarks/>
        public string paistomador
        {
            get
            {
                return this.paistomadorField;
            }
            set
            {
                this.paistomadorField = value;
            }
        }

        /// <remarks/>
        public uint fonetomador
        {
            get
            {
                return this.fonetomadorField;
            }
            set
            {
                this.fonetomadorField = value;
            }
        }

        /// <remarks/>
        public object faxtomador
        {
            get
            {
                return this.faxtomadorField;
            }
            set
            {
                this.faxtomadorField = value;
            }
        }

        /// <remarks/>
        public uint ceptomador
        {
            get
            {
                return this.ceptomadorField;
            }
            set
            {
                this.ceptomadorField = value;
            }
        }

        /// <remarks/>
        public string bairrotomador
        {
            get
            {
                return this.bairrotomadorField;
            }
            set
            {
                this.bairrotomadorField = value;
            }
        }

        /// <remarks/>
        public string emailtomador
        {
            get
            {
                return this.emailtomadorField;
            }
            set
            {
                this.emailtomadorField = value;
            }
        }

        /// <remarks/>
        public string tppessoa
        {
            get
            {
                return this.tppessoaField;
            }
            set
            {
                this.tppessoaField = value;
            }
        }

        /// <remarks/>
        public ulong cpfcnpjtomador
        {
            get
            {
                return this.cpfcnpjtomadorField;
            }
            set
            {
                this.cpfcnpjtomadorField = value;
            }
        }

        /// <remarks/>
        public object inscricaoestadualtomador
        {
            get
            {
                return this.inscricaoestadualtomadorField;
            }
            set
            {
                this.inscricaoestadualtomadorField = value;
            }
        }

        /// <remarks/>
        public object inscricaomunicipaltomador
        {
            get
            {
                return this.inscricaomunicipaltomadorField;
            }
            set
            {
                this.inscricaomunicipaltomadorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("fatura", IsNullable = false)]
        public tbnfdNfdFatura[] tbfatura
        {
            get
            {
                return this.tbfaturaField;
            }
            set
            {
                this.tbfaturaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("servico", IsNullable = false)]
        public tbnfdNfdServico[] tbservico
        {
            get
            {
                return this.tbservicoField;
            }
            set
            {
                this.tbservicoField = value;
            }
        }

        /// <remarks/>
        public string observacao
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
        public object razaotransportadora
        {
            get
            {
                return this.razaotransportadoraField;
            }
            set
            {
                this.razaotransportadoraField = value;
            }
        }

        /// <remarks/>
        public object cpfcnpjtransportadora
        {
            get
            {
                return this.cpfcnpjtransportadoraField;
            }
            set
            {
                this.cpfcnpjtransportadoraField = value;
            }
        }

        /// <remarks/>
        public object enderecotransportadora
        {
            get
            {
                return this.enderecotransportadoraField;
            }
            set
            {
                this.enderecotransportadoraField = value;
            }
        }

        /// <remarks/>
        public object pis
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
        public object cofins
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
        public object csll
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
        public object irrf
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
        public object inss
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
        public object descdeducoesconstrucao
        {
            get
            {
                return this.descdeducoesconstrucaoField;
            }
            set
            {
                this.descdeducoesconstrucaoField = value;
            }
        }

        /// <remarks/>
        public object totaldeducoesconstrucao
        {
            get
            {
                return this.totaldeducoesconstrucaoField;
            }
            set
            {
                this.totaldeducoesconstrucaoField = value;
            }
        }

        /// <remarks/>
        public bool tributadonomunicipio
        {
            get
            {
                return this.tributadonomunicipioField;
            }
            set
            {
                this.tributadonomunicipioField = value;
            }
        }

        /// <remarks/>
        public object numerort
        {
            get
            {
                return this.numerortField;
            }
            set
            {
                this.numerortField = value;
            }
        }

        /// <remarks/>
        public object codigoseriert
        {
            get
            {
                return this.codigoseriertField;
            }
            set
            {
                this.codigoseriertField = value;
            }
        }

        /// <remarks/>
        public object dataemissaort
        {
            get
            {
                return this.dataemissaortField;
            }
            set
            {
                this.dataemissaortField = value;
            }
        }

        /// <remarks/>
        public string fatorgerador
        {
            get
            {
                return this.fatorgeradorField;
            }
            set
            {
                this.fatorgeradorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdFatura
    {

        private string numfaturaField;

        private string vencimentofaturaField;

        private byte valorfaturaField;

        /// <remarks/>
        public string numfatura
        {
            get
            {
                return this.numfaturaField;
            }
            set
            {
                this.numfaturaField = value;
            }
        }

        /// <remarks/>
        public string vencimentofatura
        {
            get
            {
                return this.vencimentofaturaField;
            }
            set
            {
                this.vencimentofaturaField = value;
            }
        }

        /// <remarks/>
        public byte valorfatura
        {
            get
            {
                return this.valorfaturaField;
            }
            set
            {
                this.valorfaturaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfdServico
    {

        private byte quantidadeField;

        private string descricaoField;

        private byte codatividadeField;

        private byte valorunitarioField;

        private string aliquotaField;

        private string impostoretidoField;

        /// <remarks/>
        public byte quantidade
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
        public string descricao
        {
            get
            {
                return this.descricaoField;
            }
            set
            {
                this.descricaoField = value;
            }
        }

        /// <remarks/>
        public byte codatividade
        {
            get
            {
                return this.codatividadeField;
            }
            set
            {
                this.codatividadeField = value;
            }
        }

        /// <remarks/>
        public byte valorunitario
        {
            get
            {
                return this.valorunitarioField;
            }
            set
            {
                this.valorunitarioField = value;
            }
        }

        /// <remarks/>
        public string aliquota
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

        /// <remarks/>
        public string impostoretido
        {
            get
            {
                return this.impostoretidoField;
            }
            set
            {
                this.impostoretidoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class Signature
    {

        private SignatureSignedInfo signedInfoField;

        private string signatureValueField;

        private SignatureKeyInfo keyInfoField;

        /// <remarks/>
        public SignatureSignedInfo SignedInfo
        {
            get
            {
                return this.signedInfoField;
            }
            set
            {
                this.signedInfoField = value;
            }
        }

        /// <remarks/>
        public string SignatureValue
        {
            get
            {
                return this.signatureValueField;
            }
            set
            {
                this.signatureValueField = value;
            }
        }

        /// <remarks/>
        public SignatureKeyInfo KeyInfo
        {
            get
            {
                return this.keyInfoField;
            }
            set
            {
                this.keyInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfo
    {

        private SignatureSignedInfoCanonicalizationMethod canonicalizationMethodField;

        private SignatureSignedInfoSignatureMethod signatureMethodField;

        private SignatureSignedInfoReference referenceField;

        /// <remarks/>
        public SignatureSignedInfoCanonicalizationMethod CanonicalizationMethod
        {
            get
            {
                return this.canonicalizationMethodField;
            }
            set
            {
                this.canonicalizationMethodField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoSignatureMethod SignatureMethod
        {
            get
            {
                return this.signatureMethodField;
            }
            set
            {
                this.signatureMethodField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoReference Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoCanonicalizationMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoSignatureMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReference
    {

        private SignatureSignedInfoReferenceTransforms transformsField;

        private SignatureSignedInfoReferenceDigestMethod digestMethodField;

        private string digestValueField;

        private string uRIField;

        /// <remarks/>
        public SignatureSignedInfoReferenceTransforms Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoReferenceDigestMethod DigestMethod
        {
            get
            {
                return this.digestMethodField;
            }
            set
            {
                this.digestMethodField = value;
            }
        }

        /// <remarks/>
        public string DigestValue
        {
            get
            {
                return this.digestValueField;
            }
            set
            {
                this.digestValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceTransforms
    {

        private SignatureSignedInfoReferenceTransformsTransform transformField;

        /// <remarks/>
        public SignatureSignedInfoReferenceTransformsTransform Transform
        {
            get
            {
                return this.transformField;
            }
            set
            {
                this.transformField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceTransformsTransform
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceDigestMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfo
    {

        private SignatureKeyInfoX509Data x509DataField;

        /// <remarks/>
        public SignatureKeyInfoX509Data X509Data
        {
            get
            {
                return this.x509DataField;
            }
            set
            {
                this.x509DataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoX509Data
    {

        private string x509CertificateField;

        /// <remarks/>
        public string X509Certificate
        {
            get
            {
                return this.x509CertificateField;
            }
            set
            {
                this.x509CertificateField = value;
            }
        }
    }
}
