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
using System.Data;
using UnclePhill.WebAPI_NFeS.Domain.Domain;
using System.EnterpriseServices;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class NFeSDomain : DefaultDomains.MasterDomain
    {
        public NFeSRequestPreview Issue(NFeSRequest NFeS)
        {
            try
            {
                ValidateIssue(NFeS);

                Takers Taker = new TakerDomain().Get<Takers>(NFeS.TakerId);
                Companys Company = new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company,NFeS.CompanyId);
                CFPS CFPS = new CFPSDomain().Get<CFPS>(NFeS.CFPSId);
                TaxpayerActivities TaxpayerActivities = new TaxpayerActivitiesDomain().Get(NFeS.TaxpayerActivitiesId);
                ShippingCompany ShippingCompany = new ShippingCompany();
                if (NFeS.ShippingCompanyId > 0){ShippingCompany = new ShippingCompanyDomain().Get<ShippingCompany>(NFeS.ShippingCompanyId);}
                var NFeSRequest = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfd();
                NFeSRequest.nfd = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfd();
                
                NFeSRequest.nfd.numeronfd = Homologation.NumberNF; 
                NFeSRequest.nfd.codseriedocumento = Homologation.Serie; 
                NFeSRequest.nfd.codnaturezaoperacao = CFPS.CFPSCod;
                NFeSRequest.nfd.codigocidade = Homologation.CityCod;
                NFeSRequest.nfd.inscricaomunicipalemissor = Homologation.IM;
                NFeSRequest.nfd.dataemissao = DateTime.Now.ToString("dd/MM/yyyy");
                NFeSRequest.nfd.razaotomador = Taker.Name;
                NFeSRequest.nfd.nomefantasiatomador = Taker.NameFantasy;
                NFeSRequest.nfd.enderecotomador = Taker.Street;
                NFeSRequest.nfd.numeroendereco = Taker.Number;
                NFeSRequest.nfd.cidadetomador = Taker.City;
                NFeSRequest.nfd.estadotomador = Taker.State;
                NFeSRequest.nfd.paistomador = Homologation.Country;
                NFeSRequest.nfd.fonetomador = Taker.Telephone;
                NFeSRequest.nfd.faxtomador = Taker.Telephone;
                NFeSRequest.nfd.ceptomador = Taker.CEP;
                NFeSRequest.nfd.bairrotomador = Taker.Neighborhood;
                NFeSRequest.nfd.emailtomador = Taker.Email;
                NFeSRequest.nfd.tppessoa = Taker.TypePerson;
                NFeSRequest.nfd.cpfcnpjtomador = Taker.CPF_CNPJ;
                NFeSRequest.nfd.inscricaoestadualtomador = Taker.RG_IE;
                NFeSRequest.nfd.inscricaomunicipaltomador = Taker.IM;         
                NFeSRequest.nfd.observacao = NFeS.Note;
                NFeSRequest.nfd.razaotransportadora = Functions.IIf(ShippingCompany.Name);
                NFeSRequest.nfd.cpfcnpjtransportadora = Functions.IIf(ShippingCompany.CPF_CNPJ);
                NFeSRequest.nfd.pis = Homologation.PIS;
                NFeSRequest.nfd.cofins = Homologation.COFINS;
                NFeSRequest.nfd.csll = Homologation.CSLL;
                NFeSRequest.nfd.irrf = Homologation.IRRF;
                NFeSRequest.nfd.inss = Homologation.INSS;
                NFeSRequest.nfd.descdeducoesconstrucao = string.Empty;
                NFeSRequest.nfd.totaldeducoesconstrucao = string.Empty;
                NFeSRequest.nfd.tributadonomunicipio = string.Empty;
                NFeSRequest.nfd.vlroutros = string.Empty;
                NFeSRequest.nfd.numerort = string.Empty;
                NFeSRequest.nfd.codigoseriert = string.Empty;
                NFeSRequest.nfd.dataemissaort = string.Empty;
                NFeSRequest.nfd.fatorgerador = DateTime.Now.Month + "/" + DateTime.Now.Year;                
                NFeSRequest.nfd.enderecotransportadora =
                    Functions.IIf(ShippingCompany.Street) + ","
                    + Functions.IIf(ShippingCompany.Neighborhood) + ","
                    + Functions.IIf(ShippingCompany.City) + ","
                    + Functions.IIf(ShippingCompany.State);
                
                NFeSRequest.nfd.tbfatura = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdFatura[NFeS.Invoices.Count];
                for (int X = 0; X < NFeS.Invoices.Count; X++)
                {
                    NFeSRequestInvoices Invoice = NFeS.Invoices[X];
                    NFeSRequest.nfd.tbfatura[X] = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdFatura
                    {
                        numfatura = Invoice.Number.ToString(),
                        vencimentofatura = DateTime.Parse(Invoice.Maturity).ToString("dd/MM/yyyy"),
                        valorfatura = Invoice.Value.ToString()
                    };
                }
                
                NFeSRequest.nfd.tbservico = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdServico[NFeS.Itens.Count];
                for (int X = 0; X < NFeS.Itens.Count; X++)
                {
                    NFeSRequestItens Item = NFeS.Itens[X];                    
                    Services Services = new ServiceDomain().Get<Services>(Item.ServicesId);

                    NFeSRequest.nfd.tbservico[X] = new Models.Models.NFeSStructure.NFeSIssueRequest.tbnfdNfdServico
                    {
                        quantidade = Item.Amount.ToString(),
                        descricao = Services.Description,
                        codatividade = TaxpayerActivities.CNAE,
                        valorunitario = Item.Value.ToString(),
                        aliquota = TaxpayerActivities.Aliquot.ToString(),
                        impostoretido = Item.TaxWithheld
                    };
                }
             
                string XmlRPS = API.Send(API.GetCity(Company.City), Homologation.CPF, Homologation.Password, int.Parse(Homologation.CityCod), this.Assign(NFeSRequest));

                if (Functions.XmlFunctions.IsXml(XmlRPS))
                {                  
                    //Enviando o RPS para receber a NFSe(5 tentativas)//
                    int Cont = 0;
                    string XmlAuthorized = string.Empty;

                    //Primeira tentativa
                    XmlAuthorized = API.Receive(API.GetCity(Company.City),
                                    Homologation.CPF,
                                    Homologation.Password,
                                    Homologation.IM,
                                    XmlRPS);

                    bool Auth = Functions.XmlFunctions.IsXml(XmlAuthorized);

                    while (!Auth & Cont <= 5)
                    {
                        XmlAuthorized = API.Receive(API.GetCity(Company.City),
                                   Homologation.CPF,
                                   Homologation.Password,
                                   Homologation.IM,
                                   XmlRPS);

                        Auth = Functions.XmlFunctions.IsXml(XmlAuthorized);
                        Cont++;
                        System.Threading.Thread.Sleep(5000);
                    }


                    if (Functions.XmlFunctions.IsXml(XmlAuthorized))
                    {
                        var NFeSAuthorized = Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd>(XmlAuthorized);
                        string XmlUrl = API.GetUrl(API.City.Serra,
                                        int.Parse(Homologation.CityCod),
                                        int.Parse(NFeSAuthorized.nfdok.NewDataSet.NOTA_FISCAL.NumeroNota),
                                        int.Parse(NFeSAuthorized.nfdok.NewDataSet.NOTA_FISCAL.CodigoSerie),
                                        Homologation.IM);

                        if (Functions.XmlFunctions.IsXml(XmlUrl))
                        {
                            var NFeSUrl = Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSPreview.util>(XmlUrl);                                
                            string PDF = Download(NFeSUrl.urlNfd);

                            Save(Taker, 
                                Company, 
                                CFPS, 
                                ShippingCompany, 
                                NFeSAuthorized,
                                NFeSUrl, 
                                XmlAuthorized, 
                                PDF);
                            
                            return new NFeSRequestPreview(NFeSUrl.urlNfd, NFeSUrl.urlAutenticidade);
                        }
                        else
                        {
                            throw new InternalProgramException(XmlUrl);
                        }
                    }
                    else
                    {
                        throw new InternalProgramException(XmlAuthorized);
                    }
                }
                else
                {
                    throw new InternalProgramException(XmlRPS);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public T Get<T>(long Id = 0)
        {
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine(" Select ");
                SQL.AppendLine(" 	NumeroNota As 'NumberNF', ");
                SQL.AppendLine(" 	ChaveValidacao As 'KeyValidation', ");
                SQL.AppendLine(" 	ValorTotalNota As 'Total', ");
                SQL.AppendLine(" 	ISSQNTotal As 'TotalISS', ");
                SQL.AppendLine(" 	ClienteNomeRazaoSocial As 'Name', ");
                SQL.AppendLine(" 	ClienteNomeFantasia As 'NameFantasy', ");
                SQL.AppendLine(" 	ClienteCNPJCPF As 'CPF_CNPJ', ");
                SQL.AppendLine(" 	ClienteInscricaoEstadual As 'IE', ");
                SQL.AppendLine(" 	ClienteInscricaoMunicipal As 'IM', ");
                SQL.AppendLine(" 	DataEmissao As 'DateEmission', ");
                SQL.AppendLine(" 	Observacao As 'Note', ");
                SQL.AppendLine(" 	NotaFiscalXML As 'XML', ");
                SQL.AppendLine(" 	NotaFiscalPDF As 'PDF', ");
                SQL.AppendLine(" 	URL as 'URL', ");
                SQL.AppendLine(" 	URLAutenticidade As 'URLAuthenticity' ");
                SQL.AppendLine(" From NFeS ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And CompanyId = " + SessionDomain.GetCompanySession().CompanyId);
                if (Id > 0) { SQL.AppendLine(" And NFeSId = " + Id); }

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "NFeS");
                
                if (data != null && data.Rows.Count > 0)
                {
                    if (typeof(T) == typeof(List<NFeSRequestQuery>))
                    {
                        List<NFeSRequestQuery> lRequestQuery = new List<NFeSRequestQuery>();
                        foreach (DataRow row in data.Rows)
                        {
                            lRequestQuery.Add(Fill(row));
                        }
                        return (T)Convert.ChangeType(lRequestQuery, typeof(T));
                    }
                    else if (typeof(T) == typeof(NFeSRequestQuery))
                    {
                        return (T)Convert.ChangeType(Fill(data.AsEnumerable().First()), typeof(T));
                    }
                }
                throw new InternalProgramException("Não foram encontrados registros!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string GetArchives(long CompanyId, string NFNumber, TypeArchive Tp)
        {
            try
            {
                Validate(CompanyId,NFNumber);

                string Field = string.Empty;
                switch (Tp)
                {
                    case (TypeArchive.Xml):
                        Field = "NotaFiscalXML";
                        break;
                    case (TypeArchive.PDF):
                        Field = "NotaFiscalPDF";
                        break;
                    case (TypeArchive.URL):
                        Field = "URL";
                        break;
                    case (TypeArchive.URLAuth):
                        Field = "URLAutenticidade";
                        break;
                    default:
                        throw new InternalProgramException("Informe o tipo do arquivo!");
                }

                SQL = new StringBuilder();
                SQL.AppendLine(" Select Top 1 ");
                SQL.AppendLine("    " + Field);       
                SQL.AppendLine(" From NFeS ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine("    And CompanyId = " + CompanyId);
                SQL.AppendLine("    And NumeroNota = '" + Functions.NoQuote(NFNumber) + "' ");
                SQL.AppendLine("    And CompanyId = " + CompanyId);

                DataTable Data = Functions.Conn.GetDataTable(SQL.ToString(), "NFAuth");
                if (Data != null && Data.Rows.Count > 0)
                {
                    return Data.AsEnumerable().First().Field<string>(Field);
                }
                throw new InternalProgramException("A nota fiscal solicitada não existe na base de dados!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Cancel(long CompanyId, string NFNumber)
        {
            try
            {
                Validate(CompanyId, NFNumber);

                Companys Company = new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company, CompanyId);

                string Xml = GetArchives(CompanyId, NFNumber,TypeArchive.Xml);
                string XmlIssue = API.Cancel(API.GetCity(Company.City),Homologation.CPF,Homologation.Password, Xml);
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

        #region "##-Métodos de Apoio-##"
        private void Save(Takers takers, Companys companys, CFPS cFPS, ShippingCompany shippingCompany, 
            Models.Models.NFeSStructure.NFeSProcessingResult.tbnfd NFeS,
            Models.Models.NFeSStructure.NFeSPreview.util NFeSUrl, string XML = "", string PDF = "")
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
                SQL.AppendLine("          Cae , ");
                SQL.AppendLine("          DataEmissao , ");
                SQL.AppendLine("          NaturezaOperacao , ");
                SQL.AppendLine("          NumeroNota , ");
                SQL.AppendLine("          NumeroRps , ");
                SQL.AppendLine("          SituacaoNf , ");
                SQL.AppendLine("          ChaveValidacao , ");
                SQL.AppendLine("          ClienteNomeRazaoSocial , ");
                SQL.AppendLine("          ClienteNomeFantasia , ");
                SQL.AppendLine("          ClienteCNPJCPF , ");
                SQL.AppendLine("          ClienteEndereco , ");
                SQL.AppendLine("          ClienteBairro , ");
                SQL.AppendLine("          ClienteNumeroLogradouro , ");
                SQL.AppendLine("          ClienteCidade , ");
                SQL.AppendLine("          ClienteUF , ");
                SQL.AppendLine("          ClientePais , ");
                SQL.AppendLine("          ClienteFone , ");
                SQL.AppendLine("          ClienteFax , ");
                SQL.AppendLine("          ClienteInscricaoMunicipal , ");
                SQL.AppendLine("          ClienteCEP , ");
                SQL.AppendLine("          ClienteEmail , ");
                SQL.AppendLine("          ClienteInscricaoEstadual , ");
                SQL.AppendLine("          BaseCalculo , ");
                SQL.AppendLine("          ISSQNCliente , ");
                SQL.AppendLine("          ISSQNSemRetencao , ");
                SQL.AppendLine("          ISSQNTotal , ");
                SQL.AppendLine("          Irrf , ");
                SQL.AppendLine("          Cofins , ");
                SQL.AppendLine("          Inss , ");
                SQL.AppendLine("          Csll , ");
                SQL.AppendLine("          Pis , ");
                SQL.AppendLine("          ValorTotalNota , ");
                SQL.AppendLine("          FreteCNPJ , ");
                SQL.AppendLine("          FreteRazaoSocial , ");
                SQL.AppendLine("          FreteEndereco , ");
                SQL.AppendLine("          FreteEmitente , ");
                SQL.AppendLine("          FreteDestinatario , ");
                SQL.AppendLine("          FreteQuantidade , ");
                SQL.AppendLine("          FreteEspecie , ");
                SQL.AppendLine("          FretePesoLiquido , ");
                SQL.AppendLine("          FretePesoBruto , ");
                SQL.AppendLine("          Serie , ");
                SQL.AppendLine("          SerieSimplificada , ");
                SQL.AppendLine("          CodigoSerie , ");
                SQL.AppendLine("          Observacao , ");
                SQL.AppendLine("          ServicoCidade , ");
                SQL.AppendLine("          ServicoEstado , ");
                SQL.AppendLine("          TimbreContribuinteLogo , ");
                SQL.AppendLine("          TimbreContribuinteLinha1 , ");
                SQL.AppendLine("          TimbreContribuinteLinha2 , ");
                SQL.AppendLine("          TimbreContribuinteLinha3 , ");
                SQL.AppendLine("          TimbreContribuinteLinha4 , ");
                SQL.AppendLine("          TimbrePrefeituraLogo , ");
                SQL.AppendLine("          TimbrePrefeituraLinha1 , ");
                SQL.AppendLine("          TimbrePrefeituraLinha2 , ");
                SQL.AppendLine("          TimbrePrefeituraLinha3 , ");
                SQL.AppendLine("          URLAutenticidade , ");
                SQL.AppendLine("          URL , ");
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
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFeSUrl.urlAutenticidade) + "' , ");
                SQL.AppendLine("          '" + Functions.NoQuote(NFeSUrl.urlNfd) + "' , ");
                SQL.AppendLine("          '" + (string.IsNullOrEmpty(PDF) ? string.Empty : Functions.NoQuote(PDF)) + "' , ");
                SQL.AppendLine("          '" + (string.IsNullOrEmpty(XML)? string.Empty:Functions.NoQuote(XML)) + "' , ");               
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
                        SQL.AppendLine("        ( NFeSId , ");
                        SQL.AppendLine("          Numero , ");
                        SQL.AppendLine("          Vencimento , ");
                        SQL.AppendLine("          Valor , ");
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
                        SQL.AppendLine("        ( NFeSId , ");
                        SQL.AppendLine("          Quantidade , ");
                        SQL.AppendLine("          CodigoAtividade , ");
                        SQL.AppendLine("          Servico , ");
                        SQL.AppendLine("          ValorUnitario , ");
                        SQL.AppendLine("          ValorTotal , ");
                        SQL.AppendLine("          ImpostoRetido , ");
                        SQL.AppendLine("          Aliquota , ");
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

        private string Assign(Models.Models.NFeSStructure.NFeSIssueRequest.tbnfd NFeSIR)
        {
            try
            {
                return Functions.XmlFunctions.ClassForStringXml(
                            Functions.XmlFunctions.StringXmlForClass<Models.Models.NFeSStructure.NFeSIssueRequest.tbnfd>(
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
        
        private string Download(string URL)
        {
            try
            {
                return Convert.ToBase64String(new WebClient().DownloadData(URL));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        private void ValidateIssue(NFeSRequest NFeS)
        {
            //Empresa
            if (NFeS.CompanyId <= 0)
            {
                throw new InternalProgramException("Informe o emissor.");
            }

            Companys Comp = new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company, NFeS.CompanyId);
            if (Comp.CompanyId <= 0)
            {
                throw new InternalProgramException("A empresa informada não está cadastrada.");
            }

            if (string.IsNullOrEmpty(Comp.IE))
            {
                throw new InternalProgramException("A empresa não tem a inscrição estadual cadastrada.");
            }

            if (string.IsNullOrEmpty(Comp.IM))
            {
                throw new InternalProgramException("A empresa não tem a inscrição municipal cadastrada.");
            }

            //Tomador
            if (NFeS.TakerId <= 0)
            {
                throw new InternalProgramException("Informe o tomador do serviço.");
            }

            if (new TakerDomain().Get<Takers>(NFeS.TakerId).TakerId <= 0)
            {
                throw new InternalProgramException("O tomador informado não está cadastrado.");
            }

            //Codigo Fiscal de Prestação de Serviços
            if (NFeS.CFPSId <= 0)
            {
                throw new InternalProgramException("Informe o Código Fiscal de Prestação de Serviço (CFPS).");
            }

            if (new CFPSDomain().Get<CFPS>(NFeS.CFPSId).CFPSId <= 0)
            {
                throw new InternalProgramException("O Código Fiscal de Prestação de Serviço (CFPS) informado não está cadastrado.");
            }
            
            //Atividades do contribuinte
            if (NFeS.TaxpayerActivitiesId <= 0)
            {
                throw new InternalProgramException("Informe o código da atividade.");
            }

            if (new TaxpayerActivitiesDomain().Get(NFeS.TaxpayerActivitiesId).TaxpayerActivitiesId <= 0 )
            {
                throw new InternalProgramException("Atividade inexistente.");
            }

            //Faturas - Quatidades
            if (NFeS.Invoices.Count <= 0)
            {
                throw new InternalProgramException("Ao menos 1 (Uma) fatura deve ser informada.");
            }

            //Faturas - Informações
            if (NFeS.Invoices.Count > 0)
            {
                foreach (NFeSRequestInvoices Invoice in NFeS.Invoices)
                {
                    if (Invoice.Number <= 0)
                    {
                        throw new InternalProgramException("Informe o número da fatura.");
                    }
                    if (string.IsNullOrEmpty(Invoice.Maturity) || !Functions.IsDate(Invoice.Maturity))
                    {
                        throw new InternalProgramException("Informe a data de vencimento da fatura.");
                    }
                    if (Invoice.Value <= 0)
                    {
                        throw new InternalProgramException("Informe o valor da fatura.");
                    }
                }
            }

            //Serviços - Quantidades
            if (NFeS.Itens.Count <= 0)
            {
                throw new InternalProgramException("Informe ao menos 1 (Um) serviço.");
            }

            //Serviços - Informações
            if (NFeS.Itens.Count > 0)
            {
                foreach (NFeSRequestItens Item in NFeS.Itens)
                {
                    if (Item.Amount <= 0)
                    {
                        throw new InternalProgramException("Informe a quantidade do serviço prestado.");
                    }                    
                    if (Item.Value <= 0)
                    {
                        throw new InternalProgramException("Informe o valor do serviço.");
                    }
                }
            }
        }

        private void Validate(long CompanyId, string NFNumber)
        {
            if (CompanyId <= 0)
            {
                throw new InternalProgramException("Informe a empresa!");
            }

            if (new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company,CompanyId).CompanyId <= 0)
            {
                throw new InternalProgramException("A empresa informada não está cadastrada.");
            }
            
            if (string.IsNullOrEmpty(NFNumber))
            {
                throw new InternalProgramException("Informe o número da nota fiscal!");
            }
        }

        private NFeSRequestQuery Fill(DataRow row)
        {
            NFeSRequestQuery Query = new NFeSRequestQuery();

            Query.NumberNF = row["NumberNF"].ToString();
            Query.KeyValidation = row["KeyValidation"].ToString();
            Query.Total = row["Total"].ToString();
            Query.TotalISS = row["TotalISS"].ToString();
            Query.Name = row["Name"].ToString();
            Query.NameFantasy = row["NameFantasy"].ToString();
            Query.CPF_CNPJ = row["CPF_CNPJ"].ToString();
            Query.IE = row["IE"].ToString();
            Query.IM = row["IM"].ToString();
            Query.DateEmission = row["DateEmission"].ToString();
            Query.Note = row["Note"].ToString();
            Query.XML = row["XML"].ToString();
            Query.PDF = row["PDF"].ToString();
            Query.URL = row["URL"].ToString();
            Query.URLAuthenticity = row["URLAuthenticity"].ToString();

            return Query;
        }
        
        public enum TypeArchive
        {
            Xml = 1,
            PDF = 2,
            URL = 3,
            URLAuth = 4
        }
        #endregion
    }
}