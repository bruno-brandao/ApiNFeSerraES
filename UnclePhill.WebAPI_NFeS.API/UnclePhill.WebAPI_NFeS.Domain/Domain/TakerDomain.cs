using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;
using static UnclePhill.WebAPI_NFeS.Utils.Utils.Functions;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class TakerDomain : DefaultDomains.MasterDomain
    {
        public T Get<T>(long? TakerId = 0) 
        {
            try
            {               
                SQL = new StringBuilder();
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    TakerId, ");
                SQL.AppendLine("    IM, ");
                SQL.AppendLine("    CPF_CNPJ, ");
                SQL.AppendLine("    RG_IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    NameFantasy, ");
                SQL.AppendLine("    TypePerson, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Number, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Telephone, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From Takers ");
                SQL.AppendLine(" Where Active = 1 ");
                if (TakerId > 0) { SQL.AppendLine(" And TakerId = " + TakerId); }

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "Takers");
                if (data != null && data.Rows.Count > 0)
                {
                    if (typeof(T) == typeof(List<Takers>))
                    {
                        List<Takers> lTakers = new List<Takers>();
                        foreach (DataRow row in data.Rows)
                        {
                            lTakers.Add(Fill(row));
                        }
                        return (T)Convert.ChangeType(lTakers, typeof(T));
                    }
                    else if (typeof(T) == typeof(Takers))
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

        public Takers Post(Takers takers)
        {
            try
            {
                Validate(takers);

                SQL.AppendLine(" Insert Into Takers ");
                SQL.AppendLine("    (IM, ");
                SQL.AppendLine("    CPF_CNPJ, ");
                SQL.AppendLine("    RG_IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    NameFantasy, ");
                SQL.AppendLine("    TypePerson, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Number, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ('" + Functions.NoQuote(takers.IM) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.CPF_CNPJ) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.RG_IE) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.Name) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.NameFantasy) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.TypePerson) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.CEP) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.Street) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.Number) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.Neighborhood) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.City) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.State) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.Telephone) + "',");
                SQL.AppendLine("     '" + Functions.NoQuote(takers.Email) + "',");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                takers.TakerId = Functions.Conn.Insert(SQL.ToString());
                if (takers.TakerId > 0)
                {
                    takers.Active = true;
                    takers.DateInsert = DateTime.Now.ToString("yyyy-MM-dd");
                    takers.DateUpdate = DateTime.Now.ToString("yyyy-MM-dd");
                    return takers;
                }
                throw new InternalProgramException("Não foi possivel cadastar o tomador!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Takers Put(Takers takers)
        {
            try
            {
                Validate(takers);

                if (takers.TakerId <= 0)
                {
                    throw new InternalProgramException("Informe o código do tomador!");
                }

                SQL.AppendLine(" Update Takers Set ");
                SQL.AppendLine("    IM = '" + Functions.NoQuote(takers.IM) + "',");
                SQL.AppendLine("    CPF_CNPJ = '" + Functions.NoQuote(takers.CPF_CNPJ) + "',");
                SQL.AppendLine("    RG_IE = '" + Functions.NoQuote(takers.RG_IE) + "',");
                SQL.AppendLine("    Name = '" + Functions.NoQuote(takers.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + Functions.NoQuote(takers.NameFantasy) + "',");
                SQL.AppendLine("    TypePerson = '" + Functions.NoQuote(takers.TypePerson) + "',");
                SQL.AppendLine("    CEP = '" + Functions.NoQuote(takers.CEP) + "',");
                SQL.AppendLine("    Street = '" + Functions.NoQuote(takers.Street) + "',");
                SQL.AppendLine("    Number = '" + Functions.NoQuote(takers.Number) + "',");
                SQL.AppendLine("    Neighborhood = '" + Functions.NoQuote(takers.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + Functions.NoQuote(takers.City) + "', ");
                SQL.AppendLine("    State = '" + Functions.NoQuote(takers.State) + "',");
                SQL.AppendLine("    Telephone = '" + Functions.NoQuote(takers.Telephone) + "',");
                SQL.AppendLine("    Email = '" + Functions.NoQuote(takers.Email) + "',");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where TakerId = " + takers.TakerId);

                if (Functions.Conn.Update(SQL.ToString()))
                {
                    return takers;
                }
                throw new InternalProgramException("Houve um problema ao atualizar o tomador.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(long TakerId)
        {
            try
            {
                if (TakerId <= 0)
                {
                    throw new InternalProgramException("Informe o código do tomador!");
                }

                SQL.AppendLine(" Update Takers Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where TakerId = " + TakerId);

                if (Functions.Conn.Delete(SQL.ToString()))
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

        private void Validate(Takers takers)
        {            
            if (string.IsNullOrEmpty(takers.CPF_CNPJ))
            {
                 throw new InternalProgramException("Informe o CPF/CNPJ!");
            }

            if (Functions.ExistsRegister(takers.CPF_CNPJ, TypeInput.Texto, "CPF_CNPJ", "Takers"))
            {
                throw new InternalProgramException("Tomador já existe!");
            }

            if (string.IsNullOrEmpty(takers.RG_IE))
            {
                 throw new InternalProgramException("Informe a inscrição estadual!");
            }
            
            if (string.IsNullOrEmpty(takers.Name))
            {
                 throw new InternalProgramException("Informe o nome do tomador!");
            }

            if (string.IsNullOrEmpty(takers.NameFantasy))
            {
                 throw new InternalProgramException("Informe o nome nome fantasia do tomador!");
            }

            if (string.IsNullOrEmpty(takers.TypePerson))
            {
                 throw new InternalProgramException("Informe o tipo de pessoa do tomador!");
            }

            if (string.IsNullOrEmpty(takers.CEP))
            {
                 throw new InternalProgramException("Informe o CEP!");
            }

            if (string.IsNullOrEmpty(takers.Street))
            {
                 throw new InternalProgramException("Informe a Rua!");
            }

            if (string.IsNullOrEmpty(takers.Neighborhood))
            {
                 throw new InternalProgramException("Informe o bairro!");
            }

            if (string.IsNullOrEmpty(takers.City))
            {
                 throw new InternalProgramException("Informe a cidade!");
            }

            if (string.IsNullOrEmpty(takers.State))
            {
                 throw new InternalProgramException("Informe a UF!");
            }

            if (string.IsNullOrEmpty(takers.Telephone))
            {
                throw new InternalProgramException("Informe o Telefone!");
            }

            if (string.IsNullOrEmpty(takers.Email))
            {
                 throw new InternalProgramException("Informe o Email!");
            }
        }

        private Takers Fill(DataRow row)
        {
            Takers taker = new Takers();
            taker.TakerId = long.Parse(row["TakerId"].ToString());
            taker.IM = row["IM"].ToString();
            taker.CPF_CNPJ = row["CPF_CNPJ"].ToString();
            taker.RG_IE = row["RG_IE"].ToString();
            taker.Name = row["Name"].ToString();
            taker.NameFantasy = row["NameFantasy"].ToString();
            taker.TypePerson = row["TypePerson"].ToString();
            taker.CEP = row["CEP"].ToString();
            taker.Street = row["Street"].ToString();
            taker.Neighborhood = row["Neighborhood"].ToString();
            taker.City = row["City"].ToString();
            taker.State = row["State"].ToString();
            taker.Email = row["Email"].ToString();
            taker.Active = bool.Parse(row["Active"].ToString());
            taker.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
            taker.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
            return taker;
        }
    }
}