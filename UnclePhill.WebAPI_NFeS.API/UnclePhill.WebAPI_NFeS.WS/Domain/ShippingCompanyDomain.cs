using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Domain
{
    public class ShippingCompanyDomain : MasterDomain
    {
        public List<ShippingCompany> Select(long? ShippingCompanyId)
        {
            try
            {
                List<ShippingCompany> lShippingCompany = new List<ShippingCompany>();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    ShippingCompanyId, ");
                SQL.AppendLine("    CPF_CNPJ, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    NameFantasy, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From ShippingCompany ");
                SQL.AppendLine(" Where Active = 1 ");
                if (ShippingCompanyId > 0) { SQL.AppendLine(" And ShippingCompanyId = " + ShippingCompanyId); }

                DataTable data = Conn.GetDataTable(SQL.ToString(), "ShippingCompany");
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        ShippingCompany shippingCompany = new ShippingCompany();
                        shippingCompany.ShippingCompanyId = long.Parse(row["ShippingCompanyId"].ToString());
                        shippingCompany.CPF_CNPJ = row["CPF_CNPJ"].ToString();
                        shippingCompany.Name = row["Name"].ToString();
                        shippingCompany.NameFantasy = row["NameFantasy"].ToString();
                        shippingCompany.CEP = row["CEP"].ToString();
                        shippingCompany.Street = row["Street"].ToString();
                        shippingCompany.Neighborhood = row["Neighborhood"].ToString();
                        shippingCompany.City = row["City"].ToString();
                        shippingCompany.State = row["State"].ToString();
                        shippingCompany.Active = bool.Parse(row["Active"].ToString());
                        shippingCompany.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        shippingCompany.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        lShippingCompany.Add(shippingCompany);
                    }
                    return lShippingCompany;
                }
                throw new Exception("Não foram encontrados registros!");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(ShippingCompany shippingCompany)
        {
            try
            {
                Feedbacks feedback = Validate(shippingCompany);
                if (feedback.Status.Equals("erro"))
                {
                    throw new Exception(feedback.Message);
                }

                SQL.AppendLine(" Insert Into ShippingCompany ");
                SQL.AppendLine("    (CPF_CNPJ, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    NameFantasy, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ('" + NoInjection(shippingCompany.CPF_CNPJ) + "',");
                SQL.AppendLine("     '" + NoInjection(shippingCompany.Name) + "',");
                SQL.AppendLine("     '" + NoInjection(shippingCompany.NameFantasy) + "',");
                SQL.AppendLine("     '" + NoInjection(shippingCompany.CEP) + "',");
                SQL.AppendLine("     '" + NoInjection(shippingCompany.Street) + "',");
                SQL.AppendLine("     '" + NoInjection(shippingCompany.Neighborhood) + "',");
                SQL.AppendLine("     '" + NoInjection(shippingCompany.City) + "',");
                SQL.AppendLine("     '" + NoInjection(shippingCompany.State) + "',");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                if (Conn.Insert(SQL.ToString()) > 0)
                {
                    return true;
                }

                return false;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ShippingCompany shippingCompany)
        {
            try
            {
                Feedbacks feedback = Validate(shippingCompany);
                if (feedback.Status.Equals("erro"))
                {
                    throw new Exception(feedback.Message);
                }

                if (shippingCompany.ShippingCompanyId <= 0)
                {
                    throw new Exception("Informe o código da transportadora!");
                }

                SQL.AppendLine(" Update Services Set ");
                SQL.AppendLine("    CPF_CNPJ = '" + NoInjection(shippingCompany.CPF_CNPJ) + "',");
                SQL.AppendLine("    Name = '" + NoInjection(shippingCompany.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + NoInjection(shippingCompany.NameFantasy) + "',");
                SQL.AppendLine("    CEP = '" + NoInjection(shippingCompany.CEP) + "',");
                SQL.AppendLine("    Street = '" + NoInjection(shippingCompany.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + NoInjection(shippingCompany.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + NoInjection(shippingCompany.City) + "',");
                SQL.AppendLine("    State = '" + NoInjection(shippingCompany.State) + "', ");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where ServicesId = " + shippingCompany.ShippingCompanyId);

                if (Conn.Insert(SQL.ToString()) > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(long ShippingCompanyId)
        {
            try
            {
                if (ShippingCompanyId <= 0)
                {
                    throw new Exception("Informe o código da transportadora!");
                }

                SQL.AppendLine(" Update ShippingCompany Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where ShippingCompanyId = " + ShippingCompanyId);

                if (Conn.Delete(SQL.ToString()))
                {
                    return true;
                }

                return false;                
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private Feedbacks Validate(ShippingCompany shippingCompany)
        {
            if (string.IsNullOrEmpty(shippingCompany.CPF_CNPJ))
            {
                return new Feedbacks("erro", "Informe o CPF/CNPJ da transportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Name))
            {
                return new Feedbacks("erro", "Informe a razão social/nome da trasportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.NameFantasy))
            {
                return new Feedbacks("erro", "Informe a nome fantasia/apelido da trasportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.CEP))
            {
                return new Feedbacks("erro", "Informe o CEP!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Street))
            {
                return new Feedbacks("erro", "Informe a rua!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Neighborhood))
            {
                return new Feedbacks("erro", "Informe o bairro!");
            }

            if (string.IsNullOrEmpty(shippingCompany.City))
            {
                return new Feedbacks("erro", "Informe a cidade!");
            }

            if (string.IsNullOrEmpty(shippingCompany.State))
            {
                return new Feedbacks("erro", "Informe o estado!");
            }

            return new Feedbacks("ok", "Sucesso");
        }
    }
}