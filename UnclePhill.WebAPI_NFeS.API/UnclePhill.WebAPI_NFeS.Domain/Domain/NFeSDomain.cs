using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Serra.Entrada;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada;
using UnclePhill.WebAPI_NFeS.Utils.Utils;
using UnclePhill.WebAPI_NFeS.Models.Models;
using System.Text;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class NFeSDomain : MasterDomain
    {
        public string EmitirNFeS()
        {
            try
            {
                //**Objeto para emissão de NF**//
                //Emissor;
                //Tomador do serviço;
                //Natureza da operação (CFPS);
                //Faturas:{Numero,Vencimento,Valor};
                //serviços:{Id,Atividade,Quantidade,ValorUnit};
                //Observação;
                //Transportadora{TipoFrete,Especie,PesoL,PesoB};

                tbnfd NFeSIR = new tbnfd();
                NFeSIR.nfd = new tbnfdNfd();

                NFeSIR.nfd.numeronfd = 0; 
                NFeSIR.nfd.codseriedocumento = 7; 
                NFeSIR.nfd.codnaturezaoperacao = 511;
                NFeSIR.nfd.codigocidade = 3;
                NFeSIR.nfd.inscricaomunicipalemissor = 4546565;
                NFeSIR.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSIR.nfd.razaotomador = "SMARapd - ltda";
                NFeSIR.nfd.tppessoa = "J";
                NFeSIR.nfd.nomefantasiatomador = "SMARapd";
                NFeSIR.nfd.enderecotomador = "Rua Aurora";
                NFeSIR.nfd.numeroendereco = 118;
                NFeSIR.nfd.cidadetomador = "Ribeirão Preto";
                NFeSIR.nfd.estadotomador = "SP";
                NFeSIR.nfd.paistomador = "Brasil";
                NFeSIR.nfd.fonetomador = 21119898;
                NFeSIR.nfd.faxtomador = string.Empty;
                NFeSIR.nfd.ceptomador = 79010100;
                NFeSIR.nfd.bairrotomador = "Centro";
                NFeSIR.nfd.emailtomador = "teste@smarapd.com.br";
                NFeSIR.nfd.cpfcnpjtomador = 30669959085741;
                NFeSIR.nfd.inscricaoestadualtomador = string.Empty;
                NFeSIR.nfd.inscricaomunicipaltomador = string.Empty;
                NFeSIR.nfd.observacao = "OBS";
                NFeSIR.nfd.tbfatura = new tbnfdNfdFatura[3];
                NFeSIR.nfd.tbfatura[0] = new tbnfdNfdFatura
                {
                    numfatura = "1",
                    vencimentofatura = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                    valorfatura = 100                 
                };
                NFeSIR.nfd.tbfatura[1] = new tbnfdNfdFatura
                {
                    numfatura = "2",
                    vencimentofatura = DateTime.Now.AddMonths(2).ToString("dd/MM/yyyy"),
                    valorfatura = 100
                };
                NFeSIR.nfd.tbfatura[2] = new tbnfdNfdFatura
                {
                    numfatura ="3",
                    vencimentofatura = DateTime.Now.AddMonths(3).ToString("dd/MM/yyyy"),
                    valorfatura = 100
                };
                NFeSIR.nfd.tbservico = new tbnfdNfdServico[3];
                NFeSIR.nfd.tbservico[0] = new tbnfdNfdServico
                {
                    quantidade = 2,
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = 150,
                    aliquota = "5,5",
                    impostoretido = "False"
                };
                NFeSIR.nfd.tbservico[1] = new tbnfdNfdServico
                {
                    quantidade = 1,
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = 200,
                    aliquota = "5,5",
                    impostoretido = "False"
                };
                NFeSIR.nfd.tbservico[2] = new tbnfdNfdServico
                {
                    quantidade = 5,
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = 150,
                    aliquota = "5,5",
                    impostoretido = "False"
                };
                NFeSIR.nfd.razaotransportadora = string.Empty;
                NFeSIR.nfd.cpfcnpjtransportadora = string.Empty;
                NFeSIR.nfd.enderecotransportadora = string.Empty;
                //NFeSIR.nfd.tipofrete = "O";
                //NFeSIR.nfd.quantidade = "0,00";
                //NFeSIR.nfd.especie = "CAIXA";
                //NFeSIR.nfd.pesoliquido = "0,00";
                //NFeSIR.nfd.pesobruto = "0,00";
                NFeSIR.nfd.pis = string.Empty;
                NFeSIR.nfd.cofins = string.Empty;
                NFeSIR.nfd.csll = string.Empty;
                NFeSIR.nfd.irrf = string.Empty;
                NFeSIR.nfd.inss = string.Empty;
                NFeSIR.nfd.descdeducoesconstrucao = string.Empty;
                NFeSIR.nfd.totaldeducoesconstrucao = string.Empty;
                NFeSIR.nfd.tributadonomunicipio = true;
                NFeSIR.nfd.numerort = string.Empty;
                NFeSIR.nfd.codigoseriert = string.Empty;
                NFeSIR.nfd.dataemissaort = string.Empty;                
                //NFeSIR.nfd.numerofatura = 0;
                NFeSIR.nfd.fatorgerador = "09/2018";

                String Xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" ;
                Xml += Functions.ClassForStringXml(NFeSIR);
                Xml = Xml.Replace("</tbnfd>", "");
                Xml += Assinatura();
                Xml += "</tbnfd>";

                //if (ValidateXml(XSDInput, Xml))
                //{
                    string RetXml = string.Empty;
                    NFeS.API.Serra.Entrada.WSEntradaClient wsEntradaSerra = new NFeS.API.Serra.Entrada.WSEntradaClient();
                    RetXml = wsEntradaSerra.nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3,Xml);

                    NFeS.API.Cariacica.Entrada.WSEntradaClient wsEntradaCariacica = new NFeS.API.Cariacica.Entrada.WSEntradaClient();
                    RetXml = wsEntradaCariacica.nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3, Xml);

                
                    return RetXml;
                //}
                throw new Exception("Nota fiscal inválida!");               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        
        private string Assinatura()
        {
            StringBuilder Signature = new StringBuilder();
            Signature.AppendLine("<Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\"> ");
            Signature.AppendLine("  <SignedInfo> ");
            Signature.AppendLine("	 <CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\" /> ");
            Signature.AppendLine("	 <SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\" /> ");
            Signature.AppendLine("	 <Reference URI=\"\"> ");
            Signature.AppendLine("		<Transforms> ");
            Signature.AppendLine("		   <Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\" /> ");
            Signature.AppendLine("		</Transforms> ");
            Signature.AppendLine("		<DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\" /> ");
            Signature.AppendLine("		<DigestValue>CB+KLlADv0+p9gwUJZYDyIoPiB8=</DigestValue> ");
            Signature.AppendLine("	 </Reference> ");
            Signature.AppendLine("  </SignedInfo> ");
            Signature.AppendLine("  <SignatureValue>Qem78QuGuPueshxgRis7SZTfF86LFv8fXzMTUN9JKqQt9haZDZonbHjW8YCjZ3 JL6WDL6khHNdxB29B8AIk55C5noDF3YCiez5TmJFc98qQWgtXdLUODtHXPwzAIJH4tys50xFgoPLUkQusx 2qh9ZP62C19cTjUOWu8u7AHk+cM=</SignatureValue> ");
            Signature.AppendLine("  <KeyInfo> ");
            Signature.AppendLine("	 <X509Data> ");
            Signature.AppendLine("		<X509Certificate>MIIFNzCCBKCgAwIBAgIKN7ufiQAAAAAAEDANBgkqhkiG9w0BAQUFADBQMR UwEwYKCZImiZPyLGQBGRYFbG9jYWwxHzAdBgoJkiaJk/IsZAEZFg9kZXNlbnZvbHZpbWVudG8xFjAUBg NVBAMTDU5PVEFDT05UUk9MQ0EwHhcNMDYwNDA0MTU1MTM1WhcNMDcwNDA0MTYwMTM1WjCBlz ELMAkGA1UEBhMCQlIxCzAJBgNVBAgTAk1TMRUwEwYDVQQHEwxDYW1wbyBHcmFuZGUxGTAXBgN ");
            Signature.AppendLine("VBAoTEEVtcHJlc2EgZGUgVGVzdGUxCzAJBgNVBAsTAlRJMRkwFwYDVQQDExBVc3VhcmlvIGRlIFRlc3R lMSEwHwYJKoZIhvcNAQkBFhJ0ZXN0ZUB0ZXN0ZS5jb20uYnIwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMI ");
            Signature.AppendLine("GJAoGBALVlKBaY30GHXsfUSmZmdl+atvSC5AwJKRQ3881ZShV0iOS37UI9aGkabZ3ybfIU6TfXnglIvGZqv WOBoJLIx2wUOWz073RVifw3pbJ5bDliqHMqgNc7NXfSS1i6DTfrz53DA/yuIak23w+bjlb1cTxw6ACy4uoitcR W0944nOPfAgMBAAGjggLOMIICyjAOBgNVHQ8BAf8EBAMCBsAwHQYDVR0OBBYEFDPijz6ygXfE3a9QG ");
            Signature.AppendLine("tIlxdupb7N8MBMGA1UdJQQMMAoGCCsGAQUFBwMCMB8GA1UdIwQYMBaAFCDppJYB+Hmg/y0/6jd1fY XcMpNnMIIBIQYDVR0fBIIBGDCCARQwggEQoIIBDKCCAQiGgcBsZGFwOi8vL0NOPU5PVEFDT05UUk9M ");
            Signature.AppendLine("Q0EsQ049c2VydmVyY3BkLENOPUNEUCxDTj1QdWJsaWMlMjBLZXklMjBTZXJ2aWNlcyxDTj1TZXJ2aWNl m9jYXRpb25MaXN0P2Jhc2U/b2JqZWN0Q2xhc3M9Y1JMRGlzdHJpYnV0aW9uUG9pbnSGQ2h0dHA6Ly9z ZXJ2ZXJjcGQuZGVzZW52b2x2aW1lbnRvLmxvY2FsL0NlcnRFbnJvbGwvTk9UQUNPTlRST0xDQS5jcmww ggE8BggrBgEFBQcBAQSCAS4wggEqMIG2BggrBgEFBQcwAoaBqWxkYXA6Ly8vQ049Tk9UQUNPTlRST0 xDQSxDTj1BSUEsQ049UHVibGljJTIwS2V5JTIwU2VydmljZXMsQ049U2VydmljZXMsQ049Q29uZmlndXJhd ");
            Signature.AppendLine(" ");
            Signature.AppendLine("GlvbixEQz1kZXNlbnZvbHZpbWVudG8sREM9bG9jYWw/Y0FDZXJ0aWZpY2F0ZT9iYXNlP29iamVjdENsYX NzPWNlcnRpZmljYXRpb25BdXRob3JpdHkwbwYIKwYBBQUHMAKGY2h0dHA6Ly9zZXJ2ZXJjcGQuZGVzZ W52b2x2aW1lbnRvLmxvY2FsL0NlcnRFbnJvbGwvc2VydmVyY3BkLmRlc2Vudm9sdmltZW50by5sb2NhbF9 OT1RBQ09OVFJPTENBLmNydDANBgkqhkiG9w0BAQUFAAOBgQAEwiMeC2OkseEp7HkZnKRLD8SrUBL ");
            Signature.AppendLine("4tEoG0QnyNi4nYD59idIOGiDjBLZEqDqfikR9VVLZS8Z0XqFd1EM633HnaembO08Z7pbyX3OuhkRXOidsjIe Cljv9zPecMVyrDFQ12iyTqxr1T2vs/WRlVO/GI3AH7D8OhIVGdEmCb7e8qw==</X509Certificate> ");
            Signature.AppendLine("	 </X509Data> ");
            Signature.AppendLine("  </KeyInfo> ");
            Signature.AppendLine("</Signature>");
            return Signature.ToString();

        }
    }
}