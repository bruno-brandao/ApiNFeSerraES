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
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class NFeSDomain : DefaultDomains.MasterDomain
    {
        public NFeSRequestPreview Issue(NFeSRequest NFeS)
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
                var NFeSIR = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfd();
                NFeSIR.nfd = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfd();

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
                NFeSIR.nfd.tbfatura = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdFatura[NFeS.Invoices.Count];
                for (int X = 0; X < NFeS.Invoices.Count; X++)
                {
                    NFeSRequestInvoices Invoice = NFeS.Invoices[X];
                    NFeSIR.nfd.tbfatura[X] = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdFatura
                    {
                        numfatura = Invoice.Number.ToString(),
                        vencimentofatura = DateTime.Parse(Invoice.Maturity).ToString("dd/MM/yyyy"),
                        valorfatura = Invoice.Value.ToString()
                    };
                }

                //Serviços//
                NFeSIR.nfd.tbservico = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdServico[NFeS.Itens.Count];
                for (int X = 0; X < NFeS.Itens.Count; X++)
                {
                    NFeSRequestItens Item = NFeS.Itens[X];
                    NFeSIR.nfd.tbservico[X] = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdServico
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
                        Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSIssueRequest.tbnfd>(
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
                    int Cont = 0;
                    string NFSeXmlAuth = string.Empty;

                    //Primeira tentativa
                    NFSeXmlAuth = new NFeS.API.Serra.Saida.WSSaidaClient().nfdSaida(
                                    Homologation.CPF,
                                    Homologation.Password,
                                    Homologation.IM,
                                    NFSeXmlRequest);

                    bool Auth = Functions.XmlFunctions.IsXml(NFSeXmlAuth);

                    while (!Auth & Cont <= 5)
                    {
                        NFSeXmlAuth = new NFeS.API.Serra.Saida.WSSaidaClient().nfdSaida(
                                        Homologation.CPF, 
                                        Homologation.Password, 
                                        Homologation.IM, 
                                        NFSeXmlRequest);

                        Auth = Functions.XmlFunctions.IsXml(NFSeXmlAuth);
                        Cont++;
                        System.Threading.Thread.Sleep(5000);
                    }
                    
                    //Tratando a NFSe Autorizada//
                    if (Functions.XmlFunctions.IsXml(NFSeXmlAuth))
                    {
                        //Serealizando NFSe Autorizada//
                        Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd NFeSAuth =
                            Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd>(NFSeXmlAuth);

                        //NFSe.nfdok.NewDataSet.NOTA_FISCAL.

                        //Consultando a URL de Download do PDF//
                        string NFSeXmlUrl = new NFeS.API.Serra.Util.WSUtilClient().urlNfd(
                            int.Parse(Homologation.CityCod), 
                            int.Parse(NFeSAuth.nfdok.NewDataSet.NOTA_FISCAL.NumeroNota), 
                            int.Parse(NFeSAuth.nfdok.NewDataSet.NOTA_FISCAL.CodigoSerie), 
                            Homologation.IM);

                        //Finalizando o processo//
                        if (Functions.XmlFunctions.IsXml(NFSeXmlUrl))
                        {
                            Models.Models.NFeSStructure.NFeSPreview.util NFSePreview =
                                Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSPreview.util>(NFSeXmlUrl);
                                                        
                            //DownLoad do PDF
                            string PDF = Convert.ToBase64String(new WebClient().DownloadData(NFSePreview.urlNfd));

                            //Salva a bagaça toda no banco:
                            Save(Taker, Company, CFPS, ShippingCompany, NFeSAuth, NFSeXmlAuth, PDF);

                            //Retorna as URL's de Autorização
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

        public bool Cancel(NFeSRequestCancel NFeSRequestCancel)
        {
            try
            {
                ValidateCancel(NFeSRequestCancel);

                var NFeSRequest = new Models.Models.NFeSStructure.NFeSCancel.nfd();
                NFeSRequest.inscricaomunicipalemissor = NFeSRequestCancel.IM;
                NFeSRequest.numeronf = NFeSRequestCancel.NumNF;
                NFeSRequest.datacancelamento = NFeSRequestCancel.DateCancel;
                NFeSRequest.motivocancelamento = NFeSRequestCancel.Cause;

                string Request = Functions.XmlFunctions.ClassForStringXml<Models.Models.NFeSStructure.NFeSCancel.nfd>(NFeSRequest);
                string XmlIssue = new NFeS.API.Serra.Entrada.WSEntradaClient().nfdEntradaCancelar(Homologation.CPF,Homologation.Password, Request);
                if (Functions.XmlFunctions.IsXml(XmlIssue))
                {
                    //Cenas para os próximos capitulos...
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save(Takers takers, Companys companys, CFPS cFPS, ShippingCompany shippingCompany, 
            Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd NFeS, string XML = "", string PDF = "")
        {
            try
            {
                var NFDet = NFeS.nfdok.NewDataSet.NOTA_FISCAL;

                SQL = new StringBuilder();

                SQL.AppendLine("Insert Into NFeS ");
                SQL.AppendLine("        ( TakerId , ");
                SQL.AppendLine("          CompanyId , ");
                SQL.AppendLine("          CFPSId , ");
                SQL.AppendLine("          ShippingCompanyId , ");
                SQL.AppendLine("          cae , ");
                SQL.AppendLine("          dataEmissao , ");
                SQL.AppendLine("          naturezaOperacao , ");
                SQL.AppendLine("          numeroNota , ");
                SQL.AppendLine("          numeroRps , ");
                SQL.AppendLine("          situacaoNf , ");
                SQL.AppendLine("          chaveValidacao , ");
                SQL.AppendLine("          clienteNomeRazaoSocial , ");
                SQL.AppendLine("          clienteNomeFantasia , ");
                SQL.AppendLine("          clienteCNPJCPF , ");
                SQL.AppendLine("          clienteEndereco , ");
                SQL.AppendLine("          clienteBairro , ");
                SQL.AppendLine("          clienteNumeroLogradouro , ");
                SQL.AppendLine("          clienteCidade , ");
                SQL.AppendLine("          clienteUF , ");
                SQL.AppendLine("          clientePais , ");
                SQL.AppendLine("          clienteFone , ");
                SQL.AppendLine("          clienteFax , ");
                SQL.AppendLine("          clienteInscricaoMunicipal , ");
                SQL.AppendLine("          clienteCEP , ");
                SQL.AppendLine("          clienteEmail , ");
                SQL.AppendLine("          clienteInscricaoEstadual , ");
                SQL.AppendLine("          baseCalculo , ");
                SQL.AppendLine("          iSSQNCliente , ");
                SQL.AppendLine("          iSSQNSemRetencao , ");
                SQL.AppendLine("          iSSQNTotal , ");
                SQL.AppendLine("          irrf , ");
                SQL.AppendLine("          cofins , ");
                SQL.AppendLine("          inss , ");
                SQL.AppendLine("          csll , ");
                SQL.AppendLine("          pis , ");
                SQL.AppendLine("          valorTotalNota , ");
                SQL.AppendLine("          freteCNPJ , ");
                SQL.AppendLine("          freteRazaoSocial , ");
                SQL.AppendLine("          freteEndereco , ");
                SQL.AppendLine("          freteEmitente , ");
                SQL.AppendLine("          freteDestinatario , ");
                SQL.AppendLine("          freteQuantidade , ");
                SQL.AppendLine("          freteEspecie , ");
                SQL.AppendLine("          fretePesoLiquido , ");
                SQL.AppendLine("          fretePesoBruto , ");
                SQL.AppendLine("          serie , ");
                SQL.AppendLine("          serieSimplificada , ");
                SQL.AppendLine("          codigoSerie , ");
                SQL.AppendLine("          observacao , ");
                SQL.AppendLine("          servicoCidade , ");
                SQL.AppendLine("          servicoEstado , ");
                SQL.AppendLine("          TimbreContribstringeLogo , ");
                SQL.AppendLine("          TimbreContribstringeLinha1 , ");
                SQL.AppendLine("          TimbreContribstringeLinha2 , ");
                SQL.AppendLine("          TimbreContribstringeLinha3 , ");
                SQL.AppendLine("          TimbreContribstringeLinha4 , ");
                SQL.AppendLine("          timbrePrefeituraLogo , ");
                SQL.AppendLine("          timbrePrefeituraLinha1 , ");
                SQL.AppendLine("          timbrePrefeituraLinha2 , ");
                SQL.AppendLine("          timbrePrefeituraLinha3 , ");
                SQL.AppendLine("          NotaFiscalPDF , ");
                SQL.AppendLine("          NotaFiscalXML , ");
                SQL.AppendLine("          Active , ");
                SQL.AppendLine("          DateInsert , ");
                SQL.AppendLine("          DateUpdate ");
                SQL.AppendLine("        ) ");
                SQL.AppendLine("Values  ( " + takers.TakerId.ToString() + " , ");
                SQL.AppendLine("          " + companys.CompanyId.ToString() + " , ");
                SQL.AppendLine("          " + cFPS.CFPSId.ToString() + " , ");
                SQL.AppendLine("          " + (shippingCompany.ShippingCompanyId == 0 ? "Null" : shippingCompany.ShippingCompanyId.ToString()) + " , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Cae) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.DataEmissao) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.NaturezaOperacao) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.NumeroNota) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.NumeroRps) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.SituacaoNf) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ChaveValidacao) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteNomeRazaoSocial) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteNomeFantasia) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteCNPJCPF) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteEndereco) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteBairro) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteNumeroLogradouro) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteCidade) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteUF) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClientePais) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteFone) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteFax) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteInscricaoMunicipal) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteCEP) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteEmail) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ClienteInscricaoEstadual) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.BaseCalculo) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ISSQNCliente) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ISSQNSemRetencao) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ISSQNTotal) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Irrf) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Cofins) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Inss) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Csll) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Pis) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.ValorTotalNota) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FreteCNPJ) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FreteRazaoSocial) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FreteEndereco) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FreteEmitente) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FreteDestinatario) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FreteQuantidade) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FreteEspecie) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FretePesoLiquido) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.FretePesoBruto) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Serie) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.SerieSimplificada) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.CodigoSerie) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.Observacao) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.servicoCidade) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.servicoEstado) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbreContribstringeLogo) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbreContribstringeLinha1) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbreContribstringeLinha2) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbreContribstringeLinha3) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbreContribstringeLinha4) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbrePrefeituraLogo) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbrePrefeituraLinha1) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbrePrefeituraLinha2) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFDet.TimbrePrefeituraLinha3) + "' , ");
                SQL.AppendLine("          '" + (string.IsNullOrEmpty(XML)? string.Empty:Functions.NoQuote(XML)) + "' , ");
                SQL.AppendLine("          '" + (string.IsNullOrEmpty(PDF)? string.Empty:Functions.NoQuote(PDF)) + "' , ");
                SQL.AppendLine("          1 , ");
                SQL.AppendLine("          GetDate() , ");
                SQL.AppendLine("          GetDate()  ");
                SQL.AppendLine("        )");
                
                long Id = Functions.Conn.Insert(SQL.ToString());

                if (Id > 0)
                {
                    SQL = new StringBuilder();

                    foreach (var Fat in NFDet.FATURA)
                    {                       
                        SQL.AppendLine("Insert Into NFeSInvoices ");
                        SQL.AppendLine("        ( NFSeId , ");
                        SQL.AppendLine("          numero , ");
                        SQL.AppendLine("          vencimento , ");
                        SQL.AppendLine("          valor , ");
                        SQL.AppendLine("          Active , ");
                        SQL.AppendLine("          DateInsert , ");
                        SQL.AppendLine("          DateUpdate ");
                        SQL.AppendLine("        ) ");
                        SQL.AppendLine("Values  ( " + Id + " , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Fat.Numero) + "' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Fat.Vencimento) +"' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Fat.Valor) +"' , ");
                        SQL.AppendLine("          1 , ");
                        SQL.AppendLine("          GetDate() , ");
                        SQL.AppendLine("          GetDate() ");
                        SQL.AppendLine("        )");
                        SQL.AppendLine(" ");                        
                    }

                    foreach (var Item in NFDet.ITENS)
                    {                        
                        SQL.AppendLine("Insert Into NFeSItens ");
                        SQL.AppendLine("        ( NFSeId , ");
                        SQL.AppendLine("          quantidade , ");
                        SQL.AppendLine("          codigoAtividade , ");
                        SQL.AppendLine("          servico , ");
                        SQL.AppendLine("          valorUnitario , ");
                        SQL.AppendLine("          valorTotal , ");
                        SQL.AppendLine("          impostoRetido , ");
                        SQL.AppendLine("          aliquota , ");
                        SQL.AppendLine("          Active , ");
                        SQL.AppendLine("          DateInsert , ");
                        SQL.AppendLine("          DateUpdate ");
                        SQL.AppendLine("        ) ");
                        SQL.AppendLine("Values  ( " + Id + " , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Item.Quantidade) + "' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Item.CodigoAtividade) +"' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Item.Servico) +"' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Item.ValorUnitario) +"' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Item.ValorTotal) +"' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Item.ImpostoRetido) +"' , ");
                        SQL.AppendLine("          '"+ Functions.NoQuote(Item.Aliquota) +"' , ");
                        SQL.AppendLine("          1 , ");
                        SQL.AppendLine("          GetDate() , ");
                        SQL.AppendLine("          GetDate() ");
                        SQL.AppendLine("        )");
                        SQL.AppendLine(" ");
                    }

                    if ((NFDet.FATURA.Length > 0 | NFDet.ITENS.Length > 0) & SQL.ToString().Length > 0)
                    {
                        Functions.Conn.Insert(SQL.ToString());
                    }                    
                }
            }catch(Exception ex)
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

            if (new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company,NFeS.CompanyId).CompanyId <= 0)
            {
                throw new Exception("A empresa informada não está cadastrada.");
            }

            //Tomador
            if (NFeS.TakerId <= 0)
            {
                throw new Exception("Informe o tomador do serviço.");
            }

            if (new TakerDomain().Get<Takers>(NFeS.TakerId).TakerId <= 0)
            {
                throw new Exception("O tomador informado não está cadastrado.");
            }

            //Codigo Fiscal de Prestação de Serviços
            if (NFeS.CFPSId <= 0)
            {
                throw new Exception("Informe o Código Fiscal de Prestação de Serviço (CFPS).");
            }

            if (new CFPSDomain().Get<CFPS>(NFeS.CFPSId).CFPSId <= 0)
            {
                throw new Exception("O Código Fiscal de Prestação de Serviço (CFPS) informado não está cadastrado.");
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

        private void ValidateCancel(NFeSRequestCancel NFeSRequestCancel)
        {
            if (string.IsNullOrEmpty(NFeSRequestCancel.IM))
            {
                throw new Exception("Informe a inscrição municipal.");
            }

            if (string.IsNullOrEmpty(NFeSRequestCancel.NumNF))
            {
                throw new Exception("Informe o número da nota fiscal.");
            }

            if (string.IsNullOrEmpty(NFeSRequestCancel.DateCancel))
            {
                throw new Exception("Informe a data de cancelamento.");
            }

            if (string.IsNullOrEmpty(NFeSRequestCancel.Cause))
            {
                throw new Exception("Informe a causa do cancelamento.");
            }
        }
    }
}