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
    public class ShippingCompanyDomain : DefaultDomains.MasterDomain
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
                throw new InternalProgramException("Não foram encontrados registros!");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public ShippingCompany Post(ShippingCompany shippingCompany)
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
                SQL.AppendLine("    ('" + Functions.NoQuote(shippingCompany.CPF_CNPJ) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(shippingCompany.Name) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(shippingCompany.NameFantasy) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(shippingCompany.CEP) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(shippingCompany.Street) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(shippingCompany.Neighborhood) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(shippingCompany.City) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(shippingCompany.State) + "',");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                shippingCompany.ShippingCompanyId = Functions.Conn.Insert(SQL.ToString());
                if (shippingCompany.ShippingCompanyId > 0)
                {
                    shippingCompany.Active = true;
                    shippingCompany.DateInsert = DateTime.Now.ToString("yyyy-MM-dd");
                    shippingCompany.DateUpdate = DateTime.Now.ToString("yyyy-MM-dd");
                    return shippingCompany;
                }
                throw new InternalProgramException("Houve um problema ao cadastrar a transportadora!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ShippingCompany Put(ShippingCompany shippingCompany)
        {
            try
            {
                Validate(shippingCompany);
                
                if (shippingCompany.ShippingCompanyId <= 0)
                {
                    throw new InternalProgramException("Informe o código da transportadora!");
                }

                SQL.AppendLine(" Update ShippingCompany Set ");
                SQL.AppendLine("    CPF_CNPJ = '" + Functions.NoQuote(shippingCompany.CPF_CNPJ) + "',");
                SQL.AppendLine("    Name = '" + Functions.NoQuote(shippingCompany.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + Functions.NoQuote(shippingCompany.NameFantasy) + "',");
                SQL.AppendLine("    CEP = '" + Functions.NoQuote(shippingCompany.CEP) + "',");
                SQL.AppendLine("    Street = '" + Functions.NoQuote(shippingCompany.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + Functions.NoQuote(shippingCompany.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + Functions.NoQuote(shippingCompany.City) + "',");
                SQL.AppendLine("    State = '" + Functions.NoQuote(shippingCompany.State) + "', ");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where ShippingCompanyId = " + shippingCompany.ShippingCompanyId);

                if (Functions.Conn.Insert(SQL.ToString()) > 0)
                {
                    return shippingCompany;
                }
                throw new InternalProgramException("Houve um problema ao atualizar o tomador.");
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
                    throw new InternalProgramException("Informe o código da transportadora!");
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
                  throw new InternalProgramException("Informe o CPF/CNPJ da transportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Name))
            {
                  throw new InternalProgramException("Informe a razão social/nome da trasportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.NameFantasy))
            {
                  throw new InternalProgramException("Informe a nome fantasia/apelido da trasportadora!");
            }

            if (string.IsNullOrEmpty(shippingCompany.CEP))
            {
                  throw new InternalProgramException("Informe o CEP!");
            }

            if (Functions.ExistsRegister(shippingCompany.CEP, TypeInput.Texto, "CEP", "ShippingCompany"))
            {
                throw new InternalProgramException("Tomador já existe!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Street))
            {
                  throw new InternalProgramException("Informe a rua!");
            }

            if (string.IsNullOrEmpty(shippingCompany.Neighborhood))
            {
                  throw new InternalProgramException("Informe o bairro!");
            }

            if (string.IsNullOrEmpty(shippingCompany.City))
            {
                  throw new InternalProgramException("Informe a cidade!");
            }

            if (string.IsNullOrEmpty(shippingCompany.State))
            {
                  throw new InternalProgramException("Informe o estado!");
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