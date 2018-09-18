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
                NFeSIR.nfd.codseriedocumento = "NFS"; 
                NFeSIR.nfd.codnaturezaoperacao = 511;
                NFeSIR.nfd.codigocidade = 3201308;
                NFeSIR.nfd.inscricaomunicipalemissor = 4546565;
                NFeSIR.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSIR.nfd.razaotomador = "SMARapd - ltda";                
                NFeSIR.nfd.nomefantasiatomador = "SMARapd";
                NFeSIR.nfd.enderecotomador = "Rua Aurora";
                NFeSIR.nfd.numeroendereco = "118";
                NFeSIR.nfd.cidadetomador = "Ribeirão Preto";
                NFeSIR.nfd.estadotomador = "SP";
                NFeSIR.nfd.paistomador = "Brasil";
                NFeSIR.nfd.fonetomador = "21119898";
                NFeSIR.nfd.faxtomador = "21119898";
                NFeSIR.nfd.ceptomador = 79010100;
                NFeSIR.nfd.bairrotomador = "Centro";
                NFeSIR.nfd.emailtomador = "teste@smarapd.com.br";
                NFeSIR.nfd.tppessoa = "J";
                NFeSIR.nfd.cpfcnpjtomador = 30669959085741;
                NFeSIR.nfd.inscricaoestadualtomador = "356646565";
                NFeSIR.nfd.inscricaomunicipaltomador = string.Empty;                
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
                    impostoretido = "N"
                };
                NFeSIR.nfd.tbservico[1] = new tbnfdNfdServico
                {
                    quantidade = 1,
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = 200,
                    aliquota = "5,5",
                    impostoretido = "N"
                };
                NFeSIR.nfd.tbservico[2] = new tbnfdNfdServico
                {
                    quantidade = 5,
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = 150,
                    aliquota = "5,5",
                    impostoretido = "N"
                };
                NFeSIR.nfd.observacao = "OBS";
                NFeSIR.nfd.razaotransportadora = string.Empty;
                NFeSIR.nfd.cpfcnpjtransportadora = string.Empty;
                NFeSIR.nfd.enderecotransportadora = string.Empty;                
                NFeSIR.nfd.pis = "0,00";
                NFeSIR.nfd.cofins = "0,00";
                NFeSIR.nfd.csll = "0,00";
                NFeSIR.nfd.irrf = "0,00";
                NFeSIR.nfd.inss = "0,00";
                NFeSIR.nfd.descdeducoesconstrucao = string.Empty;
                NFeSIR.nfd.totaldeducoesconstrucao = "0,00";
                NFeSIR.nfd.tributadonomunicipio = string.Empty;
                NFeSIR.nfd.vlroutros = "0,00";
                NFeSIR.nfd.numerort = string.Empty;
                NFeSIR.nfd.codigoseriert = string.Empty;
                NFeSIR.nfd.dataemissaort = string.Empty;
                NFeSIR.nfd.fatorgerador = string.Empty;
                
                String Xml = Functions.ClassForStringXml(NFeSIR); ;
                
                //if (Functions.ValidateXml(XSDInput, Xml))
                //{
                    string RetXml = string.Empty;
                    NFeS.API.Serra.Entrada.WSEntradaClient wsEntradaSerra = new NFeS.API.Serra.Entrada.WSEntradaClient();
                    RetXml = wsEntradaSerra.nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3,Xml);

                    NFeS.API.Cariacica.Entrada.WSEntradaClient wsEntradaCariacica = new NFeS.API.Cariacica.Entrada.WSEntradaClient();
                    RetXml = wsEntradaCariacica.nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3201308, Xml);
                                
                    return RetXml;
                //}
                throw new Exception("Nota fiscal inválida!");               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
    }
}