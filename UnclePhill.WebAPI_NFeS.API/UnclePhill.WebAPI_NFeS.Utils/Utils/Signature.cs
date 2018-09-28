using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UnclePhill.WebAPI_NFeS.Utils.Utils
{    
    public class Signature
    {
        public string Sign(string Xml,string CertificateSerie = "522ac7756187d976")
        {
            try
            {
                return SignXml(Xml, new Certificate().SearchBySerie(CertificateSerie));
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public Boolean VerifySignXml(string Xml, string CertificateSerie = "522ac7756187d976")
        {
            try
            {
                XmlDocument DocXml = new XmlDocument();
                DocXml.PreserveWhitespace = false;
                DocXml.LoadXml(Xml);

                SignedXml signedXml = new SignedXml(DocXml);
                XmlNodeList nodeList = DocXml.GetElementsByTagName("Signature");

                if (nodeList.Count <= 0)
                {
                    throw new CryptographicException("Não foi encontrada assinatura!");
                }

                if (nodeList.Count >= 2)
                {
                    throw new CryptographicException("Existe mais de uma assinatura!");
                }

                signedXml.LoadXml((XmlElement)nodeList[0]);
                return signedXml.CheckSignature(new Certificate().SearchBySerie(CertificateSerie).PrivateKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SignXml(string Xml, X509Certificate2 X509Cert)
        {
            try
            {
                XmlDocument XMLDoc;
                string _xnome = string.Empty;
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
                    throw new Exception("Problemas no certificado digital");
                }
                else
                {
                    _X509Cert = collection1[0];

                    XmlDocument doc = new XmlDocument();
                    doc.PreserveWhitespace = false;
                    doc.LoadXml(Xml);

                    SignedXml signedXml = new SignedXml(doc);
                    signedXml.SigningKey = _X509Cert.PrivateKey;
                    signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";

                    Reference reference = new Reference();
                    reference.Uri = "";
                    reference.DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1";

                    reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                    //reference.AddTransform(new XmlDsigC14NTransform());

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
                return XMLDoc.OuterXml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }              
    }
    
    public class Certificate
    {
        public X509Certificate2 SearchByName(string Nome)
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
                        throw new Exception("Nenhum certificado escolhido");
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
                        _X509Cert.Reset();
                        throw new Exception("Nenhum certificado válido foi encontrado com o nome informado: " + Nome);
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

        public X509Certificate2 SearchBySerie(string NroSerie)
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
                        throw new Exception("Nenhum certificado válido foi encontrado com o número de série informado: " + NroSerie);
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
                        throw new Exception("Nenhum certificado válido foi encontrado com o número de série informado: " + NroSerie);
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
