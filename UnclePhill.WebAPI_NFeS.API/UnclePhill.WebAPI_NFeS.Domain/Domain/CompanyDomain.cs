using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;
using static UnclePhill.WebAPI_NFeS.Utils.Utils.Functions;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class CompanyDomain : MasterDomain
    {
        public T Get<T>(long? CompanyId = 0)
        {
            try
            {
                SQL = new StringBuilder();
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
                
                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "Companys");
                if (data != null && data.Rows.Count > 0)
                {
                    if (typeof(T) == typeof(List<Companys>))
                    {
                        List<Companys> lCompanys = new List<Companys>();
                        foreach (DataRow row in data.Rows)
                        {
                            lCompanys.Add(Fill(row));
                        }
                        return (T)Convert.ChangeType(lCompanys, typeof(T));
                    }
                    else if (typeof(T) == typeof(Takers))
                    {
                        return (T)Convert.ChangeType(Fill(data.AsEnumerable().First()), typeof(T));

                    }
                }
                throw new Exception("Não foram encontrados registros!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Post(Companys companys, Users usersSession)
        {
            try
            {
                Validate(companys);               

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
                SQL.AppendLine("    ('" + Functions.NotQuote(companys.CNPJ) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.IM) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.IE) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.Name) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.NameFantasy) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.CEP) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.Street) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.Neighborhood) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.City) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.State) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.Telephone) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.Email) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(companys.Logo) + "',");
                SQL.AppendLine("     " + Functions.FormatNumber(companys.IRRF) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(companys.PIS) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(companys.COFINS) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(companys.CSLL) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(companys.INSS) + ",");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                companys.CompanyId = Functions.Conn.Insert(SQL.ToString());
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

        public bool Put(Companys companys, Users usersSession)
        {
            try
            {
                Validate(companys);                

                if (companys.CompanyId <= 0)
                {
                     throw new Exception("Informe o código da empresa!");
                }

                SQL.AppendLine(" Update Companys Set ");
                SQL.AppendLine("    CNPJ = '" + Functions.NotQuote(companys.CNPJ) + "',");
                SQL.AppendLine("    IM = '" + Functions.NotQuote(companys.IM) + "',");
                SQL.AppendLine("    IE = '" + Functions.NotQuote(companys.IE) + "',");
                SQL.AppendLine("    Name = '" + Functions.NotQuote(companys.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + Functions.NotQuote(companys.NameFantasy) + "',");
                SQL.AppendLine("    CEP = '" + Functions.NotQuote(companys.CEP) + "',");
                SQL.AppendLine("    Street = '" + Functions.NotQuote(companys.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + Functions.NotQuote(companys.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + Functions.NotQuote(companys.City) + "', ");
                SQL.AppendLine("    State = '" + Functions.NotQuote(companys.State) + "',");
                SQL.AppendLine("    Telephone = '" + Functions.NotQuote(companys.Telephone) + "',");
                SQL.AppendLine("    Email = '" + Functions.NotQuote(companys.Email) + "',");
                SQL.AppendLine("    Logo = '" + Functions.NotQuote(companys.Logo) + "',");
                SQL.AppendLine("    IRRF = " + Functions.FormatNumber(companys.IRRF) + ",");
                SQL.AppendLine("    PIS = " + Functions.FormatNumber(companys.PIS) + ",");
                SQL.AppendLine("    COFINS = " + Functions.FormatNumber(companys.COFINS) + ",");
                SQL.AppendLine("    CSLL = " + Functions.FormatNumber(companys.CSLL) + ",");
                SQL.AppendLine("    INSS = " + Functions.FormatNumber(companys.INSS) + ",");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And CompanyId = " + companys.CompanyId);

                if (Functions.Conn.Insert(SQL.ToString()) > 0)
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

                if (Functions.Conn.Delete(SQL.ToString()))
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

        private void Validate(Companys companys)
        {
            if (string.IsNullOrEmpty(companys.CNPJ))
            {
                 throw new Exception("Informe o CNPJ!");
            }

            if (Functions.ExistsRegister(companys.CNPJ, TypeInput.Texto, "CNPJ", "Companys"))
            {
                throw new Exception("Tomador já existe!");
            }

            if (string.IsNullOrEmpty(companys.IM))
            {
                 throw new Exception("Informe a inscrição municipal!");
            }

            if (string.IsNullOrEmpty(companys.IE))
            {
                 throw new Exception("Informe a inscrição estadual!");
            }

            if (string.IsNullOrEmpty(companys.Name))
            {
                 throw new Exception("Informe o nome da empresa!");
            }

            if (string.IsNullOrEmpty(companys.NameFantasy))
            {
                 throw new Exception("Informe o nome fantasia da empresa!");
            }

            if (string.IsNullOrEmpty(companys.CEP))
            {
                 throw new Exception("Informe o CEP!");
            }

            if (string.IsNullOrEmpty(companys.Street))
            {
                 throw new Exception("Informe a rua!");
            }

            if (string.IsNullOrEmpty(companys.Neighborhood))
            {
                 throw new Exception("Informe o bairro!");
            }

            if (string.IsNullOrEmpty(companys.City))
            {
                 throw new Exception("Informe a cidade!");
            }

            if (string.IsNullOrEmpty(companys.State))
            {
                 throw new Exception("Informe o estado!");
            }

            if (string.IsNullOrEmpty(companys.Telephone))
            {
                 throw new Exception("Informe o telefone!");
            }

            if (string.IsNullOrEmpty(companys.Email))
            {
                 throw new Exception("Informe o email!");
            }
        }

        private Companys Fill(DataRow row)
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

            return company;
        }
    }
}