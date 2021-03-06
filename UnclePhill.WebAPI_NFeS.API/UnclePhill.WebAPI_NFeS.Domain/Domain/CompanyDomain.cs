﻿using System;
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
    public class CompanyDomain : DefaultDomains.MasterDomain
    {
        public T Get<T>(Type Tp = Type.All, long Id = 0)
        {
            try
            {
                SQL = new StringBuilder();
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    CompanyId, ");
                SQL.AppendLine("    UserId, ");
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
                SQL.AppendLine("    '' As Logo, ");
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
                if (Tp == Type.Company)
                {
                    if (Id > 0) { SQL.AppendLine(" And CompanyId = " + Id); }
                }
                else if (Tp == Type.User)
                {
                    if (Id > 0) { SQL.AppendLine(" And UserId = " + Id); }
                }
                
                
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
                    else if (typeof(T) == typeof(Companys))
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

        public Companys Post(Companys companys)
        {
            try
            {
                Validate(companys);

                if (Functions.ExistsRegister(companys.CNPJ, TypeInput.Texto, "CNPJ", "Companys"))
                {
                    throw new InternalProgramException("Empresa já existe!");
                }

                SQL.AppendLine(" Insert Into Companys ");
                SQL.AppendLine("    (UserId, ");
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
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ( " + companys.UserId + ",");
                SQL.AppendLine("     '" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.CNPJ)) + "',");
                SQL.AppendLine("     " + (companys.IM == null ? "Null," : "'" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.IM.ToString())) + "',"));
                SQL.AppendLine("     " + (companys.IE == null ? "Null,": "'" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.IE.ToString())) + "',"));
                SQL.AppendLine("     '" + Functions.NoQuote(companys.Name) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(companys.NameFantasy) + "',");
                SQL.AppendLine("     '" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.CEP)) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(companys.Street) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(companys.Neighborhood) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(companys.City) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(companys.State) + "',");
                SQL.AppendLine("      " + (companys.Telephone == null ? "Null," : "'" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.Telephone.ToString())) + "',"));
                SQL.AppendLine("      " + (companys.Email == null ? "Null," : "'" + Functions.RemoveCharSpecialEmail(Functions.NoQuote(companys.Email.ToString())) + "',"));
                SQL.AppendLine("     '" + (companys.Logo == null ? string.Empty:Functions.NoQuote(companys.Logo)) + "',");
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
                    taxpayerActivitiesDomain.Reload(Homologation.CPF,Homologation.Password,Homologation.IM,int.Parse(Homologation.CityCod),companys.CompanyId);
                    companys.Active = true;
                    companys.DateInsert = DateTime.Now.ToString("yyyy-MM-dd");
                    companys.DateUpdate = DateTime.Now.ToString("yyyy-MM-dd");
                    return companys;
                }
                throw new InternalProgramException("Houve um problema ao cadastrar a empresa!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Companys Put(Companys companys)
        {
            try
            {
                Validate(companys);                

                if (companys.CompanyId <= 0)
                {
                     throw new Exception("Informe o código da empresa!");
                }

                SQL.AppendLine(" Update Companys Set ");
                SQL.AppendLine("    UserId = " + companys.UserId + ",");
                SQL.AppendLine("    CNPJ = '" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.CNPJ)) + "',");
                SQL.AppendLine("    IM = " + (string.IsNullOrEmpty(companys.IM) ? "Null," : "'" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.IM)) + "',"));
                SQL.AppendLine("    IE = " + (string.IsNullOrEmpty(companys.IE) ? "Null," : "'" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.IE)) + "',"));
                SQL.AppendLine("    Name = '" + Functions.NoQuote(companys.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + Functions.NoQuote(companys.NameFantasy) + "',");
                SQL.AppendLine("    CEP = '" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.CEP)) + "',");
                SQL.AppendLine("    Street = '" + Functions.NoQuote(companys.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + Functions.NoQuote(companys.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + Functions.NoQuote(companys.City) + "', ");
                SQL.AppendLine("    State = '" + Functions.NoQuote(companys.State) + "',");
                SQL.AppendLine("    Telephone =  " + (string.IsNullOrEmpty(companys.Telephone) ? "Null," : "'" + Functions.RemoveCharSpecial(Functions.NoQuote(companys.Telephone)) + "',"));
                SQL.AppendLine("    Email = " + (string.IsNullOrEmpty(companys.Email) ? "Null," : "'" + Functions.RemoveCharSpecialEmail(Functions.NoQuote(companys.Email)) + "',"));
                SQL.AppendLine("    Logo = '" + (companys.Logo == null ? string.Empty : Functions.NoQuote(companys.Logo)) + "',");
                SQL.AppendLine("    IRRF = " + Functions.FormatNumber(companys.IRRF) + ",");
                SQL.AppendLine("    PIS = " + Functions.FormatNumber(companys.PIS) + ",");
                SQL.AppendLine("    COFINS = " + Functions.FormatNumber(companys.COFINS) + ",");
                SQL.AppendLine("    CSLL = " + Functions.FormatNumber(companys.CSLL) + ",");
                SQL.AppendLine("    INSS = " + Functions.FormatNumber(companys.INSS) + ",");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And CompanyId = " + companys.CompanyId);

                if (Functions.Conn.Update(SQL.ToString()))
                {
                    TaxpayerActivitiesDomain taxpayerActivitiesDomain = new TaxpayerActivitiesDomain();
                    taxpayerActivitiesDomain.Reload(Homologation.CPF, Homologation.Password, Homologation.IM, int.Parse(Homologation.CityCod), companys.CompanyId);

                    return companys;
                }
                throw new InternalProgramException("Houve um problema ao atualizar a empresa.");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        private void Validate(Companys companys)
        {
            if (companys.UserId <= 0)
            {
                throw new InternalProgramException("Informe o usuário!");
            }

            if (string.IsNullOrEmpty(Functions.RemoveCharSpecial(companys.CNPJ)))
            {
                 throw new InternalProgramException("Informe o CNPJ!");
            }

            if (Functions.RemoveCharSpecial(companys.CNPJ).Length != 14)
            {
                throw new InternalProgramException("O CNPJ deve ter 14 digitos!");
            }

            if (string.IsNullOrEmpty(companys.Name))
            {
                 throw new InternalProgramException("Informe o nome da empresa!");
            }

            if (string.IsNullOrEmpty(companys.NameFantasy))
            {
                companys.NameFantasy = companys.Name;
            }

            if (string.IsNullOrEmpty(companys.CEP))
            {
                 throw new InternalProgramException("Informe o CEP!");
            }

            if (companys.CEP.Length != 8)
            {
                throw new InternalProgramException("O cep deve conter 8 digitos!");
            }

            if (string.IsNullOrEmpty(companys.Street))
            {
                 throw new InternalProgramException("Informe a rua!");
            }

            if (string.IsNullOrEmpty(companys.Neighborhood))
            {
                 throw new InternalProgramException("Informe o bairro!");
            }

            if (string.IsNullOrEmpty(companys.City))
            {
                 throw new InternalProgramException("Informe a cidade!");
            }

            if (string.IsNullOrEmpty(companys.State))
            {
                 throw new InternalProgramException("Informe o estado!");
            }
           
        }

        private Companys Fill(DataRow row)
        {
            Companys company = new Companys();
            company.CompanyId = long.Parse(row["CompanyId"].ToString());
            company.UserId = long.Parse(row["UserId"].ToString());
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

        public enum Type
        {
            All = 0,
            Company = 1,
            User = 2
        }
    }
}