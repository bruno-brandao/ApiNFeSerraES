using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Serra.Entrada;
using UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure.NFeSIssueRequest;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class NFeSDomain : MasterDomain
    {
        public string EmitirNFeS()
        {
            try
            {
                tbnfd NFeSIR = new tbnfd();

                NFeSIR.nfd.numeronfd = 0; 
                NFeSIR.nfd.codseriedocumento = 7; 
                NFeSIR.nfd.codnaturezaoperacao = 511;
                NFeSIR.nfd.codigocidade = 3;
                NFeSIR.nfd.inscricaomunicipalemissor = 99999;
                NFeSIR.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSIR.nfd.razaotomador = "SMARapd - ltda";
                NFeSIR.nfd.nomefantasiatomador = "SMARapd";
                NFeSIR.nfd.enderecotomador = "Rua Aurora";
                NFeSIR.nfd.numeroendereco = 446;
                NFeSIR.nfd.cidadetomador = "Ribeirão Preto";
                NFeSIR.nfd.estadotomador = "SP";
                NFeSIR.nfd.paistomador = "Brasil";
                NFeSIR.nfd.fonetomador = 21119898;
                NFeSIR.nfd.faxtomador = string.Empty;
                NFeSIR.nfd.ceptomador = 79010100;
                NFeSIR.nfd.bairrotomador = "Centro";
                NFeSIR.nfd.emailtomador = "teste@smarapd.com.br";
                NFeSIR.nfd.tppessoa = "J";
                NFeSIR.nfd.cpfcnpjtomador = 30669959085741;
                NFeSIR.nfd.inscricaoestadualtomador = string.Empty;
                NFeSIR.nfd.inscricaomunicipaltomador = string.Empty;
                NFeSIR.nfd.tbfatura = new tbnfdNfdFatura[3];
                NFeSIR.nfd.tbfatura[0] = new tbnfdNfdFatura
                {
                    numfatura = "10/2018",
                    vencimentofatura = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                    valorfatura = 100                   
                };
                NFeSIR.nfd.tbfatura[1] = new tbnfdNfdFatura
                {
                    numfatura = "11/2018",
                    vencimentofatura = DateTime.Now.AddMonths(2).ToString("dd/MM/yyyy"),
                    valorfatura = 100
                };
                NFeSIR.nfd.tbfatura[2] = new tbnfdNfdFatura
                {
                    numfatura = "12/2018",
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
                    aliquota = "5.5",
                    impostoretido = "False"
                };
                NFeSIR.nfd.tbservico[1] = new tbnfdNfdServico
                {
                    quantidade = 1,
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = 200,
                    aliquota = "5.5",
                    impostoretido = "False"
                };
                NFeSIR.nfd.tbservico[2] = new tbnfdNfdServico
                {
                    quantidade = 5,
                    descricao = "Serviços de Criação de Logomarca",
                    codatividade = 0101,
                    valorunitario = 150,
                    aliquota = "5.5",
                    impostoretido = "False"
                };
                NFeSIR.nfd.observacao = "Observação";
                NFeSIR.nfd.razaotransportadora = string.Empty;
                NFeSIR.nfd.cpfcnpjtransportadora = string.Empty;
                NFeSIR.nfd.enderecotransportadora = string.Empty;
                NFeSIR.nfd.pis = 0;
                NFeSIR.nfd.cofins = 0;
                NFeSIR.nfd.csll = 0;
                NFeSIR.nfd.irrf = 0;
                NFeSIR.nfd.inss = 0;
                NFeSIR.nfd.descdeducoesconstrucao = string.Empty;
                NFeSIR.nfd.totaldeducoesconstrucao = string.Empty;
                NFeSIR.nfd.tributadonomunicipio = true;
                NFeSIR.nfd.numerort = string.Empty;
                NFeSIR.nfd.fatorgerador = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                
                WSEntrada wsEntrada = new WSEntradaClient();
                nfdEntradaRequest nfdEntradaRequest = new nfdEntradaRequest();
                nfdEntradaRequestBody nfdEntradaRequestBody = new nfdEntradaRequestBody();
                nfdEntradaResponse nfdEntradaResponse = new nfdEntradaResponse();

                nfdEntradaRequestBody.codigoMunicipio = 3;
                nfdEntradaRequestBody.cpfUsuario = "55555555555";
                nfdEntradaRequestBody.hashSenha = "cRDtpNCeBiql5KOQsKVyrA0sAiA=";
                nfdEntradaRequestBody.nfd = ParseXml(NFeSIR);
                nfdEntradaRequest.Body = nfdEntradaRequestBody;
                
                nfdEntradaResponse = wsEntrada.nfdEntrada(nfdEntradaRequest);
                return nfdEntradaResponse.Body.@return;            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}