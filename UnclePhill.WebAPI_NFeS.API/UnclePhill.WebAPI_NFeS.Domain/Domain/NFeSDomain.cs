using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Serra.Entrada;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

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
                NFeSIR.nfd.inscricaomunicipalemissor = 99999;
                NFeSIR.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSIR.nfd.razaotomador = "SMARapd - ltda";
                NFeSIR.nfd.nomefantasiatomador = "SMARapd";
                NFeSIR.nfd.enderecotomador = "Rua Aurora";
                NFeSIR.nfd.cidadetomador = "Ribeirão Preto";
                NFeSIR.nfd.estadotomador = "SP";
                NFeSIR.nfd.paistomador = "Brasil";
                NFeSIR.nfd.fonetomador = "21119898";
                NFeSIR.nfd.faxtomador = string.Empty;
                NFeSIR.nfd.ceptomador = "79010100";
                NFeSIR.nfd.bairrotomador = "Centro";
                NFeSIR.nfd.emailtomador = "teste@smarapd.com.br";
                NFeSIR.nfd.cpfcnpjtomador = "30669959085741";
                NFeSIR.nfd.inscricaoestadualtomador = string.Empty;
                NFeSIR.nfd.inscricaomunicipaltomador = string.Empty;
                NFeSIR.nfd.tbfatura = new tbnfdNfdFatura[3];
                NFeSIR.nfd.tbfatura[0] = new tbnfdNfdFatura
                {
                    numfatura = 1,
                    vencimentofatura = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                    valorfatura = "100"                 
                };
                NFeSIR.nfd.tbfatura[1] = new tbnfdNfdFatura
                {
                    numfatura = 2,
                    vencimentofatura = DateTime.Now.AddMonths(2).ToString("dd/MM/yyyy"),
                    valorfatura = "100"
                };
                NFeSIR.nfd.tbfatura[2] = new tbnfdNfdFatura
                {
                    numfatura =3,
                    vencimentofatura = DateTime.Now.AddMonths(3).ToString("dd/MM/yyyy"),
                    valorfatura = "100"
                };
                NFeSIR.nfd.tbservico = new tbnfdNfdServico[3];
                NFeSIR.nfd.tbservico[0] = new tbnfdNfdServico
                {
                    quantidade = "2",
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = "150",
                    aliquota = "5,5",
                    impostoretido = "f"
                };
                NFeSIR.nfd.tbservico[1] = new tbnfdNfdServico
                {
                    quantidade = "1",
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = "200",
                    aliquota = "5,5",
                    impostoretido = "f"
                };
                NFeSIR.nfd.tbservico[2] = new tbnfdNfdServico
                {
                    quantidade = "5",
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = "150",
                    aliquota = "5,5",
                    impostoretido = "f"
                };
                NFeSIR.nfd.observacao = "Observação";
                NFeSIR.nfd.razaotransportadora = string.Empty;
                NFeSIR.nfd.cpfcnpjtransportadora = string.Empty;
                NFeSIR.nfd.enderecotransportadora = string.Empty;
                NFeSIR.nfd.tipofrete = "O";
                NFeSIR.nfd.quantidade = "0,00";
                NFeSIR.nfd.especie = "CAIXA";
                NFeSIR.nfd.pesoliquido = "0,00";
                NFeSIR.nfd.pesobruto = "0,00";
                NFeSIR.nfd.pis = "0,00";
                NFeSIR.nfd.cofins = "0,00";
                NFeSIR.nfd.csll = "0,00";
                NFeSIR.nfd.irrf = "0,00";
                NFeSIR.nfd.inss = "0,00";
                NFeSIR.nfd.descdeducoesconstrucao = string.Empty;
                NFeSIR.nfd.totaldeducoesconstrucao = string.Empty;
                NFeSIR.nfd.tributadonomunicipio = "true";
                NFeSIR.nfd.numerort = string.Empty;
                NFeSIR.nfd.codigoseriert = string.Empty;
                NFeSIR.nfd.dataemissaort = string.Empty;
                NFeSIR.nfd.numerofatura = 0;                

                String Xml = "<?xml version='1.0' encoding='UTF-8'?>";
                Xml += Functions.ClassForStringXml(NFeSIR);

                if (ValidateXml(XSDInput, Xml))
                {
                    string RetXml = string.Empty;
                    NFeS.API.Serra.Entrada.WSEntradaClient wsEntradaSerra = new NFeS.API.Serra.Entrada.WSEntradaClient();
                    wsEntradaSerra.Open();
                    RetXml = wsEntradaSerra.nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3, Xml);

                    NFeS.API.Cariacica.Entrada.WSEntradaClient wsEntradaCariacica = new NFeS.API.Cariacica.Entrada.WSEntradaClient();
                    RetXml = wsEntradaCariacica.nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3, Xml);

                    return RetXml;
                }
                throw new Exception("Nota fiscal inválida!");               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }          
    }
}