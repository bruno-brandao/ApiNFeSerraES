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
using System.Collections.Generic;
using System.Linq;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class NFeSDomain : MasterDomain
    {
        public string EmitirNFeS(NFeSRequest NFeS)
        {
            try
            {
                Validate(NFeS);

                Takers Taker = new TakerDomain().Get<Takers>(NFeS.TakerId);
                Companys Company = new CompanyDomain().Get<Companys>(NFeS.CompanyId);
                CFPS CFPS = new CFPSDomain().Get<CFPS>(NFeS.CFPSId);                
                ShippingCompany ShippingCompany = new ShippingCompanyDomain().Get<ShippingCompany>(NFeS.ShippingCompanyId);

                tbnfd NFeSIR = new tbnfd();
                NFeSIR.nfd = new tbnfdNfd();

                NFeSIR.nfd.numeronfd = Homologation.NumberNF; 
                NFeSIR.nfd.codseriedocumento = Homologation.Serie; 
                NFeSIR.nfd.codnaturezaoperacao = CFPS.CFPSCod;
                NFeSIR.nfd.codigocidade = Homologation.CityCod;
                NFeSIR.nfd.inscricaomunicipalemissor = Homologation.IMIssuer;
                NFeSIR.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSIR.nfd.razaotomador = Taker.Name;
                NFeSIR.nfd.nomefantasiatomador = Taker.NameFantasy;
                NFeSIR.nfd.enderecotomador = Taker.Street + " " + Taker.Neighborhood;
                NFeSIR.nfd.numeroendereco = Taker.Number;
                NFeSIR.nfd.cidadetomador = Taker.City;
                NFeSIR.nfd.estadotomador = Taker.State;
                NFeSIR.nfd.paistomador = Homologation.Country;
                NFeSIR.nfd.fonetomador = "";
                NFeSIR.nfd.faxtomador = "";
                NFeSIR.nfd.ceptomador = "29167168";
                NFeSIR.nfd.bairrotomador = "COLINA DE LARANJEIRAS";
                NFeSIR.nfd.emailtomador = "everaldocardosodearaujo@gmail.com";
                NFeSIR.nfd.tppessoa = "J";
                NFeSIR.nfd.cpfcnpjtomador = "30797063000181";
                NFeSIR.nfd.inscricaoestadualtomador = "356646565";
                NFeSIR.nfd.inscricaomunicipaltomador = string.Empty;                
                NFeSIR.nfd.tbfatura = new tbnfdNfdFatura[1];

                NFeSIR.nfd.tbfatura[0] = new tbnfdNfdFatura
                {
                    numfatura = "1",
                    vencimentofatura = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                    valorfatura = "350"                 
                };
                
                NFeSIR.nfd.tbservico = new tbnfdNfdServico[1];

                NFeSIR.nfd.tbservico[0] = new tbnfdNfdServico
                {
                    quantidade = "2",
                    descricao = "Aula de Programação",
                    codatividade = "0101",
                    valorunitario = "350",
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

                string NFsXml = Functions.XmlFunctions.ClassForStringXml(
                        Functions.XmlFunctions.StringXmlForClass<tbnfd>(
                            Functions.XmlFunctions.Signature.Sign(
                                Functions.XmlFunctions.ClassForStringXml(NFeSIR)
                                )
                            )
                        );

                var RequestXml = new NFeS.API.Serra.Entrada.WSEntradaClient()
                    .nfdEntrada("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 3, NFsXml);
                
                if (Functions.XmlFunctions.IsXml(RequestXml))
                {
                    var NFsXmlAuth = new NFeS.API.Serra.Saida.WSSaidaClient().nfdSaida("55555555555", "cRDtpNCeBiql5KOQsKVyrA0sAiA=", "4546565", RequestXml);
                    if (Functions.XmlFunctions.IsXml(NFsXmlAuth))
                    {
                        Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd NFeSAuth =
                            Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd>(NFsXmlAuth);

                        var UrlXml = new NFeS.API.Serra.Util.WSUtilClient()
                            .urlNfd(3, int.Parse(NFeSAuth.nfdok.NewDataSet.NOTA_FISCAL.NumeroNota), 
                            int.Parse(NFeSAuth.nfdok.NewDataSet.NOTA_FISCAL.CodigoSerie), "4546565");

                        if (Functions.XmlFunctions.IsXml(UrlXml))
                        {
                             
                        }
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        
        private void Validate(NFeSRequest NFeS)
        {
            //Empresa
            if (NFeS.CompanyId <= 0)
            {
                throw new Exception("Informe o emissor.");
            }

            //Tomador
            if (NFeS.TakerId <= 0)
            {
                throw new Exception("Informe o tomador do serviço.");
            }

            //Codigo Fiscal de Prestação de Serviços
            if (NFeS.CFPSId <= 0)
            {
                throw new Exception("Informe o Código Fiscal de Prestação de Serviço (CFPS).");
            }

            //Faturas - Quatidades
            if (NFeS.Invoices.Count <= 0)
            {
                throw new Exception("Ao menos 1 (Uma) fatura deve ser informada.");
            }

            //Faturas - Informações
            if (NFeS.Invoices.Count > 0)
            {
                foreach (NFeSRequestInvoices Invoice in NFeS.Invoices)
                {
                    if (Invoice.Number <= 0)
                    {
                        throw new Exception("Informe o número da fatura.");
                    }
                    if (string.IsNullOrEmpty(Invoice.Maturity) || !Functions.IsDate(Invoice.Maturity))
                    {
                        throw new Exception("Informe a data de vencimento da fatura.");
                    }
                    if (Invoice.Value <= 0)
                    {
                        throw new Exception("Informe o valor da fatura.");
                    }
                }
            }

            //Serviços - Quantidades
            if (NFeS.Itens.Count <= 0)
            {
                throw new Exception("Informe ao menos 1 (Um) serviço.");
            }

            //Serviços - Informações
            if (NFeS.Itens.Count > 0)
            {
                foreach (NFeSRequestItens Item in NFeS.Itens)
                {
                    if (Item.Amount <= 0)
                    {
                        throw new Exception("Informe a quantidade do serviço prestado.");
                    }
                    if (string.IsNullOrEmpty(Item.Description))
                    {
                        throw new Exception("Informe a descrição do serviço.");
                    }
                    if (Item.ActivitiesId <= 0)
                    {
                        throw new Exception("Informe o código da atividade.");
                    }
                    if (Item.Value <= 0)
                    {
                        throw new Exception("Informe o valor do serviço.");
                    }
                }
            }
        }
    }
}