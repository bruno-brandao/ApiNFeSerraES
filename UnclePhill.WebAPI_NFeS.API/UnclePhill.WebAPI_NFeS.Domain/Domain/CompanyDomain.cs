using System;
using System.Collections.Generic;
using System.Data;
using UnclePhill.WebAPI_NFeS.Models;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class CompanyDomain : MasterDomain
    {
        public List<Companys> Select(long? CompanyId = 0)
        {
            try
            {
                List<Companys> lCompanys = new List<Companys>();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    CompanyId, ");
                SQL.AppendLine("    CNPJ, ");
                SQL.AppendLine("    IM, ");
                SQL.AppendLine("    IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    NameFantasy, ");
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
                        company.NameFantasy = row["NameFantasy"].ToString();
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
                    return lCompanys;
                }
                throw new Exception("Não foram encontrados registros!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Companys companys, Users usersSession)
        {
            try
            {
                Feedbacks feedback = Validate(companys);
                if (feedback.Status.Equals("erro"))
                {
                    throw new Exception(feedback.Message);
                }

                SQL.AppendLine(" Insert Into Companys ");
                SQL.AppendLine("    (CNPJ, ");
                SQL.AppendLine("    IM, ");
                SQL.AppendLine("    IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    NameFantasy, ");
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
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ('" + NoInjection(companys.CNPJ) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.IM) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.IE) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.Name) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.NameFantasy) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.CEP) + "',");
                SQL.AppendLine("     '" + NoInjection(companys.Street) + "',");
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

                companys.CompanyId = Conn.Insert(SQL.ToString());
                if (companys.CompanyId > 0)
                {
                    TaxpayerActivitiesDomain taxpayerActivitiesDomain = new TaxpayerActivitiesDomain();
                    taxpayerActivitiesDomain.Reload(usersSession.CPF,usersSession.Password,companys.IM,3,companys.CompanyId);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Companys companys, Users usersSession)
        {
            try
            {
                Feedbacks feedback = Validate(companys);
                if (feedback.Status.Equals("erro"))
                {
                    throw new Exception(feedback.Message);
                }

                if (companys.CompanyId <= 0)
                {
                     throw new Exception("Informe o código da empresa!");
                }

                SQL.AppendLine(" Update Companys Set ");
                SQL.AppendLine("    CNPJ = '" + NoInjection(companys.CNPJ) + "',");
                SQL.AppendLine("    IM = '" + NoInjection(companys.IM) + "',");
                SQL.AppendLine("    IE = '" + NoInjection(companys.IE) + "',");
                SQL.AppendLine("    Name = '" + NoInjection(companys.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + NoInjection(companys.NameFantasy) + "',");
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

                if (Conn.Insert(SQL.ToString()) > 0)
                {
                    TaxpayerActivitiesDomain taxpayerActivitiesDomain = new TaxpayerActivitiesDomain();
                    taxpayerActivitiesDomain.Reload(usersSession.CPF, usersSession.Password, companys.IM, 3, companys.CompanyId);

                    return true;
                }

                return false;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(long CompanyId)
        {
            try
            {
                //Provisório...
                return false;

                if (CompanyId <= 0)
                {
                    throw new Exception("Informe o código da empresa!");
                }

                SQL.AppendLine(" Update Companys Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where CompanyId = " + CompanyId);

                if (Conn.Delete(SQL.ToString()))
                {
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                throw ex;
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

            if (string.IsNullOrEmpty(companys.NameFantasy))
            {
                return new Feedbacks("erro", "Informe o nome fantasia da empresa!");
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

            return new Feedbacks("ok", "Sucesso");
        }
    }
}