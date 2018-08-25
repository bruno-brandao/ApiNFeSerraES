using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class CompanyController : MasterController
    {
        [HttpGet]
        public JsonResult Select(long? CompanyId = 0)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                List<Companys> lCompanys = new List<Companys>();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    CompanyId, ");
                SQL.AppendLine("    CNPJ, ");
                SQL.AppendLine("    IM, ");
                SQL.AppendLine("    IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Telephone, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Logo, ");
                SQL.AppendLine("    IRRF, ");
                SQL.AppendLine("    PIS, ");
                SQL.AppendLine("    COFINS, ");
                SQL.AppendLine("    CSLL, ");
                SQL.AppendLine("    INSS, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From Companys ");
                SQL.AppendLine(" Where Active = 1 ");
                if (CompanyId > 0) { SQL.AppendLine(" And CompanyId = " + CompanyId); }


                DataTable data = Conn.GetDataTable(SQL.ToString(), "Companys");
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        Companys company = new Companys();
                        company.CompanyId = long.Parse(row["CompanyId"].ToString());
                        company.CNPJ = row["CNPJ"].ToString();
                        company.IM = row["IM"].ToString();                       
                        company.IE = row["IE"].ToString();
                        company.Name = row["Name"].ToString();
                        company.CEP = row["CEP"].ToString();
                        company.Street = row["Street"].ToString();
                        company.Neighborhood = row["Neighborhood"].ToString();
                        company.City = row["City"].ToString();
                        company.State = row["State"].ToString();
                        company.Telephone = row["Telephone"].ToString();
                        company.Email = row["Email"].ToString();
                        company.Logo = row["Logo"].ToString();
                        company.IRRF = decimal.Parse(row["IRRF"].ToString());
                        company.PIS = decimal.Parse(row["PIS"].ToString());
                        company.COFINS = decimal.Parse(row["COFINS"].ToString());
                        company.CSLL = decimal.Parse(row["CSLL"].ToString());
                        company.INSS = decimal.Parse(row["INSS"].ToString());                                             
                        company.Active = bool.Parse(row["Active"].ToString());
                        company.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        company.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        lCompanys.Add(company);
                    }
                    return Response(lCompanys);
                }
                return Response(new Feedbacks("erro", "Não foram encontrados registros!"));
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        [HttpPost]
        public JsonResult Insert(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                Feedbacks feedback = Validate(companys);
                if (feedback.Status.Equals("erro"))
                {
                    return Response(feedback);
                }

                SQL.AppendLine(" Insert Into Companys ");
                SQL.AppendLine("    CNPJ, ");
                SQL.AppendLine("    IM, ");
                SQL.AppendLine("    IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Telephone, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Logo, ");
                SQL.AppendLine("    IRRF, ");
                SQL.AppendLine("    PIS, ");
                SQL.AppendLine("    COFINS, ");
                SQL.AppendLine("    CSLL, ");
                SQL.AppendLine("    INSS, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ('" + NoInjection(companys.CNPJ) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.IM) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.IE) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.Name) + ",");
                SQL.AppendLine("     '" + NoInjection(companys.CEP) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.Street) + ",");
                SQL.AppendLine("     '" + NoInjection(companys.Neighborhood) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.City) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.State) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.Telephone) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.Email) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.Logo) + "',");
                SQL.AppendLine("     " + FormatNumber(companys.IRRF) + ",");
                SQL.AppendLine("     " + FormatNumber(companys.PIS) + ",");
                SQL.AppendLine("     " + FormatNumber(companys.COFINS) + ",");
                SQL.AppendLine("     " + FormatNumber(companys.CSLL) + ",");
                SQL.AppendLine("     " + FormatNumber(companys.INSS) + ",");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                if (Conn.Insert(SQL.ToString()) > 0)
                {
                    return Response(new Feedbacks("ok", "Tomador criado com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema o tomador um usuário. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        [HttpPut]
        public JsonResult Update(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                Feedbacks feedback = Validate(companys);
                if (feedback.Status.Equals("erro"))
                {
                    return Response(feedback);
                }

                if (companys.CompanyId <= 0)
                {
                    return Response(new Feedbacks("erro", "Informe o código da empresa!"));
                }

                SQL.AppendLine(" Update CompanyId Set ");
                SQL.AppendLine("    CNPJ = '" + NoInjection(companys.CNPJ) + "',");
                SQL.AppendLine("    IM = '" + NoInjection(companys.IM) + "',");                
                SQL.AppendLine("    IE = '" + NoInjection(companys.IE) + "',");
                SQL.AppendLine("    Name = '" + NoInjection(companys.Name) + "',");
                SQL.AppendLine("    CEP = '" + NoInjection(companys.CEP) + "',");
                SQL.AppendLine("    Street = '" + NoInjection(companys.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + NoInjection(companys.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + NoInjection(companys.City) + "', ");
                SQL.AppendLine("    State = '" + NoInjection(companys.State) + "',");
                SQL.AppendLine("    Telephone = '" + NoInjection(companys.Telephone) + "',");
                SQL.AppendLine("    Email = '" + NoInjection(companys.Email) + "',");
                SQL.AppendLine("    Logo = '" + NoInjection(companys.Logo) + "',");
                SQL.AppendLine("    IRRF = " + FormatNumber(companys.IRRF) + ",");
                SQL.AppendLine("    PIS = " + FormatNumber(companys.PIS) + ",");
                SQL.AppendLine("    COFINS = " + FormatNumber(companys.COFINS) + ",");
                SQL.AppendLine("    CSLL = " + FormatNumber(companys.CSLL) + ",");
                SQL.AppendLine("    INSS = " + FormatNumber(companys.INSS) + ",");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And CompanyId = " + companys.CompanyId);

                if (Conn.Update(SQL.ToString()))
                {
                    return Response(new Feedbacks("ok", "Empresa atualizada com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao atualizar a empresa. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        [HttpDelete]
        public JsonResult Delete(long CompanyId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                if (CompanyId <= 0)
                {
                    return Response(new Feedbacks("erro", "Informe o código da empresa!"));
                }

                SQL.AppendLine(" Update Company Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where CompanyId = " + CompanyId);

                if (Conn.Delete(SQL.ToString()))
                {
                    return Response(new Feedbacks("ok", "Empresa excluido com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao excluir a empresa. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        private Feedbacks Validate(Companys companys)
        {
            if (string.IsNullOrEmpty(companys.CNPJ))
            {
                return new Feedbacks("erro", "Informe o CNPJ!");
            }

            if (string.IsNullOrEmpty(companys.IM))
            {
                return new Feedbacks("erro", "Informe a inscrição municipal!");
            }

            if (string.IsNullOrEmpty(companys.IE))
            {
                return new Feedbacks("erro", "Informe a inscrição estadual!");
            }

            if (string.IsNullOrEmpty(companys.Name))
            {
                return new Feedbacks("erro", "Informe o nome da empresa!");
            }

            if (string.IsNullOrEmpty(companys.CEP))
            {
                return new Feedbacks("erro", "Informe o CEP!");
            }

            if (string.IsNullOrEmpty(companys.Street))
            {
                return new Feedbacks("erro", "Informe a rua!");
            }

            if (string.IsNullOrEmpty(companys.Neighborhood))
            {
                return new Feedbacks("erro", "Informe o bairro!");
            }

            if (string.IsNullOrEmpty(companys.City))
            {
                return new Feedbacks("erro", "Informe a cidade!");
            }

            if (string.IsNullOrEmpty(companys.State))
            {
                return new Feedbacks("erro", "Informe o estado!");
            }

            if (string.IsNullOrEmpty(companys.Telephone))
            {
                return new Feedbacks("erro", "Informe o telefone!");
            }

            if (string.IsNullOrEmpty(companys.Email))
            {
                return new Feedbacks("erro", "Informe o email!");
            }
                      
            return new Feedbacks("ok","Sucesso");
        }
    }
}