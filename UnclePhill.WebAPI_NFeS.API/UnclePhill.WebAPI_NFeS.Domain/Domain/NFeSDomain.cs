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
using System.Net;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class NFeSDomain : MasterDomain
    {
        public NFeSRequestPreview IssueNFeS(NFeSRequest NFeS)
        {
            try
            {
                //Validando Requisição//
                Validate(NFeS);

                //Criando e alimentando os objetos necessários//
                Takers Taker = new TakerDomain().Get<Takers>(NFeS.TakerId);
                Companys Company = new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company,NFeS.CompanyId);
                CFPS CFPS = new CFPSDomain().Get<CFPS>(NFeS.CFPSId);                
                ShippingCompany ShippingCompany = new ShippingCompanyDomain().Get<ShippingCompany>(NFeS.ShippingCompanyId);
                tbnfd NFeSIR = new tbnfd();
                NFeSIR.nfd = new tbnfdNfd();

                //Preenchendo a nota com os dados da requisição//
                NFeSIR.nfd.numeronfd = Homologation.NumberNF; 
                NFeSIR.nfd.codseriedocumento = Homologation.Serie; 
                NFeSIR.nfd.codnaturezaoperacao = CFPS.CFPSCod;
                NFeSIR.nfd.codigocidade = Homologation.CityCod;
                NFeSIR.nfd.inscricaomunicipalemissor = Homologation.IM;
                NFeSIR.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSIR.nfd.razaotomador = Taker.Name;
                NFeSIR.nfd.nomefantasiatomador = Taker.NameFantasy;
                NFeSIR.nfd.enderecotomador = Taker.Street;
                NFeSIR.nfd.numeroendereco = Taker.Number;
                NFeSIR.nfd.cidadetomador = Taker.City;
                NFeSIR.nfd.estadotomador = Taker.State;
                NFeSIR.nfd.paistomador = Homologation.Country;
                NFeSIR.nfd.fonetomador = Taker.Telephone;
                NFeSIR.nfd.faxtomador = Taker.Telephone;
                NFeSIR.nfd.ceptomador = Taker.CEP;
                NFeSIR.nfd.bairrotomador = Taker.Neighborhood;
                NFeSIR.nfd.emailtomador = Taker.Email;
                NFeSIR.nfd.tppessoa = Taker.TypePerson;
                NFeSIR.nfd.cpfcnpjtomador = Taker.CPF_CNPJ;
                NFeSIR.nfd.inscricaoestadualtomador = Taker.RG_IE;
                NFeSIR.nfd.inscricaomunicipaltomador = Taker.IM;         
                NFeSIR.nfd.observacao = NFeS.Note;
                NFeSIR.nfd.razaotransportadora = ShippingCompany.Name;
                NFeSIR.nfd.cpfcnpjtransportadora = ShippingCompany.CPF_CNPJ;                               
                NFeSIR.nfd.pis = Homologation.PIS;
                NFeSIR.nfd.cofins = Homologation.COFINS;
                NFeSIR.nfd.csll = Homologation.CSLL;
                NFeSIR.nfd.irrf = Homologation.IRRF;
                NFeSIR.nfd.inss = Homologation.INSS;
                NFeSIR.nfd.descdeducoesconstrucao = string.Empty;
                NFeSIR.nfd.totaldeducoesconstrucao = string.Empty;
                NFeSIR.nfd.tributadonomunicipio = string.Empty;
                NFeSIR.nfd.vlroutros = string.Empty;
                NFeSIR.nfd.numerort = string.Empty;
                NFeSIR.nfd.codigoseriert = string.Empty;
                NFeSIR.nfd.dataemissaort = string.Empty;
                NFeSIR.nfd.fatorgerador = DateTime.Now.Month + "/" + DateTime.Now.Year;                
                NFeSIR.nfd.enderecotransportadora =
                    ShippingCompany.Street + ","
                    + ShippingCompany.Neighborhood + ","
                    + ShippingCompany.City + ","
                    + ShippingCompany.State;

                //Faturas//
                NFeSIR.nfd.tbfatura = new tbnfdNfdFatura[NFeS.Invoices.Count];
                for (int X = 0; X < NFeS.Invoices.Count; X++)
                {
                    NFeSRequestInvoices Invoice = NFeS.Invoices[X];
                    NFeSIR.nfd.tbfatura[X] = new tbnfdNfdFatura
                    {
                        numfatura = Invoice.Number.ToString(),
                        vencimentofatura = DateTime.Parse(Invoice.Maturity).ToString("dd/MM/yyyy"),
                        valorfatura = Invoice.Value.ToString()
                    };
                }

                //Serviços//
                NFeSIR.nfd.tbservico = new tbnfdNfdServico[NFeS.Itens.Count];
                for (int X = 0; X < NFeS.Itens.Count; X++)
                {
                    NFeSRequestItens Item = NFeS.Itens[X];
                    NFeSIR.nfd.tbservico[X] = new tbnfdNfdServico
                    {
                        quantidade = Item.Amount.ToString(),
                        descricao = Item.Description,
                        codatividade = Item.ActivitiesId.ToString(), //Revisar
                        valorunitario = Item.Value.ToString(),
                        aliquota = Item.Aliquot.ToString(),
                        impostoretido = Item.TaxWithheld.ToString()
                    };
                }

                //Obtendo o XML assinado digitalmente//
                string NFSeXml = Functions.XmlFunctions.ClassForStringXml(
                        Functions.XmlFunctions.StringXmlForClass<tbnfd>(
                            Functions.XmlFunctions.Signature.Sign(
                                Functions.XmlFunctions.ClassForStringXml(NFeSIR)
                                )
                            )
                        );

                //Enviando a requisição de emissão da NFSe//
                string NFSeXmlRequest = 
                    new NFeS.API.Serra.Entrada.WSEntradaClient().nfdEntrada(
                    Homologation.CPF, 
                    Homologation.Password, 
                    int.Parse(Homologation.CityCod), 
                    NFSeXml);
                
                //Tratando o RPS(Recibo Provisório de Serviço)//
                if (Functions.XmlFunctions.IsXml(NFSeXmlRequest))
                {
                    //Enviando o RPS para receber a NFSe(5 tentativas)//
                    bool Auth = false;
                    int Cont = 0;
                    string NFSeXmlAuth = string.Empty;

                    while (!Auth & Cont <= 5)
                    {
                        NFSeXmlAuth = 
                            new NFeS.API.Serra.Saida.WSSaidaClient().nfdSaida(
                                Homologation.CPF, 
                                Homologation.Password, 
                                Homologation.IM, 
                                NFSeXmlRequest);
                        Auth = Functions.XmlFunctions.IsXml(NFSeXmlAuth);
                        Cont++;
                    }
                    
                    //Tratando a NFSe Autorizada//
                    if (Functions.XmlFunctions.IsXml(NFSeXmlAuth))
                    {
                        //Serealizando NFSe Autorizada//
                        Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd NFSe =
                            Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd>(NFSeXmlAuth);

                        //Consultando a URL de Download do PDF//
                        string NFSeXmlUrl = new NFeS.API.Serra.Util.WSUtilClient().urlNfd(
                            int.Parse(Homologation.CityCod), 
                            int.Parse(NFSe.nfdok.NewDataSet.NOTA_FISCAL.NumeroNota), 
                            int.Parse(NFSe.nfdok.NewDataSet.NOTA_FISCAL.CodigoSerie), 
                            Homologation.IM);

                        //Finalizando o processo//
                        if (Functions.XmlFunctions.IsXml(NFSeXmlUrl))
                        {
                            Models.Models.NFeSStructure.NFeSPreview.util NFSePreview =
                                Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSPreview.util>(NFSeXmlUrl);
                                                        
                            //DownLoad do PDF
                            Convert.ToBase64String(new WebClient().DownloadData(NFSePreview.urlNfd));

                            return new NFeSRequestPreview(NFSePreview.urlNfd, NFSePreview.urlAutenticidade);
                        }
                        else
                        {
                            throw new Exception(NFSeXmlUrl);
                        }
                    }
                    else
                    {
                        throw new Exception(NFSeXmlAuth);
                    }
                }
                else
                {
                    throw new Exception(NFSeXmlRequest);
                }                
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
                    if (string.IsNullOrEmpty(Item.ActivitiesId))
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