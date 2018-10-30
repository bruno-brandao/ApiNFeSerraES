using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class ServiceDomain : DefaultDomains.MasterDomain
    {
        public T Get<T>(long? ServicesId)
        {
            try
            {
                SQL = new StringBuilder();
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    ServicesId, ");
                SQL.AppendLine("    CompanyId, ");
                SQL.AppendLine("    Unity, ");
                SQL.AppendLine("    Value, ");
                SQL.AppendLine("    Description, ");
                SQL.AppendLine("    IRRF, ");
                SQL.AppendLine("    PIS, ");
                SQL.AppendLine("    CSLL, ");
                SQL.AppendLine("    INSS, ");
                SQL.AppendLine("    COFINS, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From Services ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And CompanyId = " + SessionDomain.GetCompanySession().CompanyId);
                if (ServicesId > 0) { SQL.AppendLine(" And ServicesId = " + ServicesId); }

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "Services");
                if (data != null && data.Rows.Count > 0)
                {
                    if (typeof(T) == typeof(List<Services>))
                    {
                        List<Services> lServices = new List<Services>();
                        foreach (DataRow row in data.Rows)
                        {
                            lServices.Add(Fill(row));
                        }
                        return (T)Convert.ChangeType(lServices, typeof(T));
                    }
                    else if (typeof(T) == typeof(Services))
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

        public Services Post(Services services)
        {
            try
            {                
                Validate(services);
               
                SQL.AppendLine(" Insert Into Services ");
                SQL.AppendLine("    (CompanyId, ");
                SQL.AppendLine("    Unity, ");
                SQL.AppendLine("    Value, ");
                SQL.AppendLine("    Description, ");
                SQL.AppendLine("    IRRF, ");
                SQL.AppendLine("    PIS, ");
                SQL.AppendLine("    CSLL, ");
                SQL.AppendLine("    INSS, ");
                SQL.AppendLine("    COFINS, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    (" + services.CompanyId + ",");
                SQL.AppendLine("     '" + Functions.NoQuote(services.Unity) + "',");
                SQL.AppendLine("     " + Functions.FormatNumber(services.Value) + ",");
                SQL.AppendLine("     '" + Functions.NoQuote(services.Description) + "',");
                SQL.AppendLine("     " + Functions.FormatNumber(services.IRRF) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(services.PIS) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(services.CSLL) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(services.INSS) + ",");
                SQL.AppendLine("     " + Functions.FormatNumber(services.COFINS) + ",");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                services.ServicesId = Functions.Conn.Insert(SQL.ToString());
                if (services.ServicesId > 0)
                {
                    services.Active = true;
                    services.DateInsert = DateTime.Now.ToString("yyyy-MM-dd");
                    services.DateUpdate = DateTime.Now.ToString("yyyy-MM-dd");
                    return services;
                }
                throw new InternalProgramException("Houve um problema ao cadastrar a serviço!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Services Put(Services services)
        {
            try
            {
                Validate(services);                

                if (services.ServicesId <= 0)
                {
                    throw new InternalProgramException("Informe o código do serviço!");
                }

                SQL.AppendLine(" Update Services Set ");
                SQL.AppendLine("    CompanyId = " + services.CompanyId + ",");
                SQL.AppendLine("    Unity = '" + Functions.NoQuote(services.Unity) + "',");
                SQL.AppendLine("    Value = " + Functions.FormatNumber(services.Value) + ",");
                SQL.AppendLine("    Description = '" + Functions.NoQuote(services.Description) + "',");
                SQL.AppendLine("    IRRF = " + Functions.FormatNumber(services.IRRF) + ",");
                SQL.AppendLine("    PIS = " + Functions.FormatNumber(services.PIS) + ",");
                SQL.AppendLine("    CSLL = " + Functions.FormatNumber(services.CSLL) + ",");
                SQL.AppendLine("    INSS = " + Functions.FormatNumber(services.INSS) + ",");
                SQL.AppendLine("    COFINS = " + Functions.FormatNumber(services.COFINS) + ", ");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where ServicesId = " + services.ServicesId);

                if (Functions.Conn.Update(SQL.ToString()))
                {
                    return services;
                }
                throw new InternalProgramException("Houve um problema ao atualizar o serviço.");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(long ServicesId)
        {
            try
            {
                if (ServicesId <= 0)
                {
                    throw new Exception("Informe o código do serviço!");
                }

                SQL.AppendLine(" Update Services Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where ServicesId = " + ServicesId);

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

        private void Validate(Services services)
        {
            if (services.CompanyId <= 0)
            {
                throw new InternalProgramException("Informe a empresa!");
            }

            if (string.IsNullOrEmpty(services.Unity))
            {
                 throw new InternalProgramException("Informe a unidade de medida do serviço!");
            }

            if (services.Value <= 0)
            {
                 throw new InternalProgramException("Informe o valor do serviço!");
            }

            if (string.IsNullOrEmpty(services.Description))
            {
                 throw new InternalProgramException("Informe o valor do serviço!");
            }
        }

        private Services Fill(DataRow row)
        {
            Services service = new Services();
            service.ServicesId = long.Parse(row["ServicesId"].ToString());
            service.CompanyId = long.Parse(row["CompanyId"].ToString());
            service.Unity = row["Unity"].ToString();
            service.Value = decimal.Parse(row["Value"].ToString());
            service.Description = row["Description"].ToString();
            service.IRRF = decimal.Parse(row["IRRF"].ToString());
            service.PIS = decimal.Parse(row["PIS"].ToString());
            service.CSLL = decimal.Parse(row["CSLL"].ToString());
            service.INSS = decimal.Parse(row["INSS"].ToString());
            service.COFINS = decimal.Parse(row["COFINS"].ToString());
            service.Active = bool.Parse(row["Active"].ToString());
            service.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
            service.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
            return service;
        }
    }
}