using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Serra.Entrada;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Cariacica.Entrada;
using UnclePhill.WebAPI_NFeS.Utils.Utils;
using UnclePhill.WebAPI_NFeS.Models.Models;
using System.Text;
using UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels;
using System.Security.Cryptography;
using System.Xml.Linq;
using UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure.NFeSIssueRequest;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class NFeSDomain : MasterDomain
    {
        public string EmitirNFeS(NFeSRequest NFeS)
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
                NFeSIR.nfd.codigocidade = 3;
                NFeSIR.nfd.inscricaomunicipalemissor = 4546565;
                NFeSIR.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSIR.nfd.razaotomador = "EVERALDO CARDOSO DE ARAUJO 14644293750";                
                NFeSIR.nfd.nomefantasiatomador = "NEW OUTSOURCING";
                NFeSIR.nfd.enderecotomador = "R DOM PEDRO II";
                NFeSIR.nfd.numeroendereco = "312";
                NFeSIR.nfd.cidadetomador = "SERRA";
                NFeSIR.nfd.estadotomador = "ES";
                NFeSIR.nfd.paistomador = "BRASIL";
                NFeSIR.nfd.fonetomador = "33214963";
                NFeSIR.nfd.faxtomador = "";
                NFeSIR.nfd.ceptomador = 29167168;
                NFeSIR.nfd.bairrotomador = "COLINA DE LARANJEIRAS";
                NFeSIR.nfd.emailtomador = "everaldocardosodearaujo@gmail.com";
                NFeSIR.nfd.tppessoa = "J";
                NFeSIR.nfd.cpfcnpjtomador = 30797063000181;
                NFeSIR.nfd.inscricaoestadualtomador = "356646565";
                NFeSIR.nfd.inscricaomunicipaltomador = string.Empty;                
                NFeSIR.nfd.tbfatura = new tbnfdNfdFatura[1];

                NFeSIR.nfd.tbfatura[0] = new tbnfdNfdFatura
                {
                    numfatura = "1",
                    vencimentofatura = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                    valorfatura = 350                 
                };
                
                NFeSIR.nfd.tbservico = new tbnfdNfdServico[1];

                NFeSIR.nfd.tbservico[0] = new tbnfdNfdServico
                {
                    quantidade = 2,
                    descricao = "Aula de Programação",
                    codatividade = 0101,
                    valorunitario = 350,
                    aliquota = "3",
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

                string NFsXml = ToNFeS(NFeSIR);
                string RequestXml = new NFeS.API.Serra.Entrada.WSEntradaClient()
                    .nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3, NFsXml);
                
                if (Functions.XmlFunctions.IsXml(RequestXml))
                {
                    string NFsXmlAuth = new NFeS.API.Serra.Saida.WSSaidaClient().nfdSaida("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", "4546565", RequestXml);
                    if (Functions.XmlFunctions.IsXml(NFsXmlAuth))
                    {
                        Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd NFeSAuth =
                            Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd>(NFsXmlAuth);

                        string UrlXml = new NFeS.API.Serra.Util.WSUtilClient()
                            .urlNfd(3, int.Parse(NFeSAuth.nfdok.NewDataSet.NOTA_FISCAL.NumeroNota), 
                            int.Parse(NFeSAuth.nfdok.NewDataSet.NOTA_FISCAL.CodigoSerie), "4546565");
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 

        private string ToNFeS(tbnfd NFeSIR)
        {
            try
            {                                      
                return Functions.XmlFunctions.ClassForStringXml(
                        Functions.XmlFunctions.StringXmlForClass<tbnfd>(
                            Functions.XmlFunctions.Signature.Sign(
                                Functions.XmlFunctions.ClassForStringXml(NFeSIR)
                                )
                            )
                        );
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}