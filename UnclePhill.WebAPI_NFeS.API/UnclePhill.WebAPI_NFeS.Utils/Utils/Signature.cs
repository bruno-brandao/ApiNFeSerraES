using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UnclePhill.WebAPI_NFeS.Utils.Utils
{    
    public class Signature
    {
        public string SignXml(string Xml,string Certificado, string URI )
        {
            try
            {
                AssinaturaDigital SignDigital = new AssinaturaDigital();
                X509Certificate2 Certificate = new X509Certificate2();

                Certificado certificado = new Certificado();
                Certificate = certificado.BuscaNome("");
                if (SignDigital.SignXml(Xml, URI, Certificate) == 0)
                {
                    return SignDigital.XMLStringAssinado;
                }
                throw new Exception("Não foi possivel assinar o XML");
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
    }

    public class AssinaturaDigital
    {
        /*
                * Entradas:
                * XMLString: string XML a ser assinada
                * RefUri : Referência da URI a ser assinada (Ex. infNFe
                * X509Cert : certificado digital a ser utilizado na assinatura digital
                *
                * Retornos:
                * Assinar : 0 - Assinatura realizada com sucesso
                * 1 - Erro: Problema ao acessar o certificado digital - %exceção%
                * 2 - Problemas no certificado digital
                * 3 - XML mal formado + exceção
                * 4 - A tag de assinatura %RefUri% inexiste
                * 5 - A tag de assinatura %RefUri% não é unica
                * 6 - Erro Ao assinar o documento - ID deve ser string %RefUri(Atributo)%
                * 7 - Erro: Ao assinar o documento - %exceção%
                *
                * XMLStringAssinado : string XML assinada
                *
                * XMLDocAssinado : XMLDocument do XML assinado
                */
        public int SignXml(string XMLString, string RefUri, X509Certificate2 X509Cert)
        {
            int resultado = 0;
            msgResultado = "Assinatura realizada com sucesso";
            try
            {
                string _xnome = "";
                if (X509Cert != null)
                {
                    _xnome = X509Cert.Subject.ToString();
                }
                X509Certificate2 _X509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, _xnome, false);
                if (collection1.Count == 0)
                {
                    resultado = 2;
                    msgResultado = "Problemas no certificado digital";
                }
                else
                {
                    _X509Cert = collection1[0];
                    string x = _X509Cert.GetKeyAlgorithm().ToString();
                    XmlDocument doc = new XmlDocument();
                    doc.PreserveWhitespace = false;
                    try
                    {
                        doc.LoadXml(XMLString);
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            resultado = 4;
                            msgResultado = "A tag de assinatura " + RefUri.Trim() + " inexiste";
                        }
                        else
                        {
                            if (qtdeRefUri > 1)
                            {
                                resultado = 5;
                                msgResultado = "A tag de assinatura " + RefUri.Trim() + " não é unica";

                            }
                            else
                            {
                                try
                                {

                                    SignedXml signedXml = new SignedXml(doc);
                                    signedXml.SigningKey = _X509Cert.PrivateKey;
                                    Reference reference = new Reference();                                    
                                    reference.Uri = "";

                                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);

                                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);

                                    signedXml.AddReference(reference);

                                    KeyInfo keyInfo = new KeyInfo();
                                    keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));
                                    signedXml.KeyInfo = keyInfo;

                                    signedXml.ComputeSignature();

                                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                                    doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                                    XMLDoc = new XmlDocument();
                                    XMLDoc.PreserveWhitespace = false;
                                    XMLDoc = doc;
                                }
                                catch (Exception caught)
                                {
                                    resultado = 7;
                                    msgResultado = "Erro: Ao assinar o documento - " + caught.Message;
                                }
                            }
                        }
                    }
                    catch (Exception caught)
                    {
                        resultado = 3;
                        msgResultado = "Erro: XML mal formado - " + caught.Message;
                    }
                }
            }
            catch (Exception caught)
            {
                resultado = 1;
                msgResultado = "Erro: Problema ao acessar o certificado digital" + caught.Message;
            }

            return resultado;
        }

        private string msgResultado;
        private XmlDocument XMLDoc;

        public XmlDocument XMLDocAssinado
        {
            get { return XMLDoc; }
        }

        public string XMLStringAssinado
        {
            get { return XMLDoc.OuterXml; }
        }

        public string mensagemResultado
        {
            get { return msgResultado; }
        }
    }

    public class Certificado
    {
        public X509Certificate2 BuscaNome(string Nome)
        {
            X509Certificate2 _X509Cert = new X509Certificate2();
            try
            {

                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection collection2 = (X509Certificate2Collection)collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);
                if (Nome == "")
                {
                    X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                        Console.WriteLine("Nenhum certificado escolhido", "Atenção");
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                else
                {
                    X509Certificate2Collection scollection = (X509Certificate2Collection)collection2.Find(X509FindType.FindBySubjectDistinguishedName, Nome, false);
                    if (scollection.Count == 0)
                    {
                        Console.WriteLine("Nenhum certificado válido foi encontrado com o nome informado: " + Nome, "Atenção");
                        _X509Cert.Reset();
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                store.Close();
                return _X509Cert;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _X509Cert;
            }
        }

        public X509Certificate2 BuscaNroSerie(string NroSerie)
        {
            X509Certificate2 _X509Cert = new X509Certificate2();
            try
            {

                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, true);
                X509Certificate2Collection collection2 = (X509Certificate2Collection)collection1.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);
                if (NroSerie == "")
                {
                    X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificados Digitais", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                        Console.WriteLine("Nenhum certificado válido foi encontrado com o número de série informado: " + NroSerie, "Atenção");
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                else
                {
                    X509Certificate2Collection scollection = (X509Certificate2Collection)collection2.Find(X509FindType.FindBySerialNumber, NroSerie, true);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                        Console.WriteLine("Nenhum certificado válido foi encontrado com o número de série informado: " + NroSerie, "Atenção");
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                store.Close();
                return _X509Cert;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _X509Cert;
            }
        }
    }
}
