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
                NFeSIR.nfd.tbfatura = new tbnfdNfdFatura[3];

                NFeSIR.nfd.tbfatura[0] = new tbnfdNfdFatura
                {
                    numfatura = "1",
                    vencimentofatura = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                    valorfatura = 350                 
                };
                
                NFeSIR.nfd.tbservico = new tbnfdNfdServico[3];

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

                string Xml = ParseXmlNFeS(NFeSIR);
                string RetXmlSerra = new NFeS.API.Serra.Entrada.WSEntradaClient()
                    .nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3, Xml);

                return RetXmlSerra;      
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 

        private string ParseXmlNFeS(tbnfd NFeSIR)
        {
            try
            {
                String Xml = Functions.ClassForStringXml(NFeSIR);
                Xml = Functions.XmlSignature.Sign(Xml);
                return Xml;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}