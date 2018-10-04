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
    public class ShippingCompanyDomain : MasterDomain
    {
        public T Get<T>(long? ShippingCompanyId = 0)
        {
            try
            {
                SQL = new StringBuilder();
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

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "ShippingCompany");
                if (data != null && data.Rows.Count > 0)
                {
                    if (typeof(T) == typeof(List<ShippingCompany>))
                    {
                        List<ShippingCompany> lShippingCompany = new List<ShippingCompany>();
                        foreach (DataRow row in data.Rows)
                        {
                            lShippingCompany.Add(Fill(row));
                        }
                        return (T)Convert.ChangeType(lShippingCompany, typeof(T));
                    }
                    else if (typeof(T) == typeof(ShippingCompany))
                    {
                        return (T)Convert.ChangeType(Fill(data.AsEnumerable().First()), typeof(T));
                    }
                }
                throw new Exception("Não foram encontrados registros!");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Post(ShippingCompany shippingCompany)
        {
            try
            {
                Validate(shippingCompany);                

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
                SQL.AppendLine("    ('" + Functions.NotQuote(shippingCompany.CPF_CNPJ) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(shippingCompany.Name) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(shippingCompany.NameFantasy) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(shippingCompany.CEP) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(shippingCompany.Street) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(shippingCompany.Neighborhood) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(shippingCompany.City) + "',");
                SQL.AppendLine("     '" + Functions.NotQuote(shippingCompany.State) + "',");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                if (Functions.Conn.Insert(SQL.ToString()) > 0)
                {
                    return true;
                }

                return false;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Put(ShippingCompany shippingCompany)
        {
            try
            {
                Validate(shippingCompany);
                
                if (shippingCompany.ShippingCompanyId <= 0)
                {
                    throw new Exception("Informe o código da transportadora!");
                }

                SQL.AppendLine(" Update ShippingCompany Set ");
                SQL.AppendLine("    CPF_CNPJ = '" + Functions.NotQuote(shippingCompany.CPF_CNPJ) + "',");
                SQL.AppendLine("    Name = '" + Functions.NotQuote(shippingCompany.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + Functions.NotQuote(shippingCompany.NameFantasy) + "',");
                SQL.AppendLine("    CEP = '" + Functions.NotQuote(shippingCompany.CEP) + "',");
                SQL.AppendLine("    Street = '" + Functions.NotQuote(shippingCompany.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + Functions.NotQuote(shippingCompany.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + Functions.NotQuote(shippingCompany.City) + "',");
                SQL.AppendLine("    State = '" + Functions.NotQuote(shippingCompany.State) + "', ");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where ShippingCompanyId = " + shippingCompany.ShippingCompanyId);

                if (Functions.Conn.Insert(SQL.ToString()) > 0)
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

                if (Functions.Conn.Delete(SQL.ToString()))
                {
                    return true;
                }

                return false;                
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private void Validate(ShippingCompany shippingCompany)
        {
            if (string.IsNullOrEmpty(shippingCompany.CPF_CNPJ))
            {
                  throw new Exception("Informe o CPF/CNPJ da transportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Name))
            {
                  throw new Exception("Informe a razão social/nome da trasportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.NameFantasy))
            {
                  throw new Exception("Informe a nome fantasia/apelido da trasportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.CEP))
            {
                  throw new Exception("Informe o CEP!");
            }

            if (Functions.ExistsRegister(shippingCompany.CEP, TypeInput.Texto, "CEP", "ShippingCompany"))
            {
                throw new Exception("Tomador já existe!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Street))
            {
                  throw new Exception("Informe a rua!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Neighborhood))
            {
                  throw new Exception("Informe o bairro!");
            }

            if (string.IsNullOrEmpty(shippingCompany.City))
            {
                  throw new Exception("Informe a cidade!");
            }

            if (string.IsNullOrEmpty(shippingCompany.State))
            {
                  throw new Exception("Informe o estado!");
            }
        }

        private ShippingCompany Fill(DataRow row)
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
            return shippingCompany;
        }
    }
}