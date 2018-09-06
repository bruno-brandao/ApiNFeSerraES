﻿using System;
using System.Collections.Generic;
using System.Data;
using UnclePhill.WebAPI_NFeS.Models;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class TakerDomain : MasterDomain
    {
        public List<Takers> Get(long? TakerId = 0)
        {
            try
            {
                List<Takers> lTakers = new List<Takers>();

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
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From Takers ");
                SQL.AppendLine(" Where Active = 1 ");
                if (TakerId > 0) { SQL.AppendLine(" And TakerId = " + TakerId); }

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Takers");
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
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
                        lTakers.Add(taker);
                    }
                    return lTakers;
                }
                throw new Exception("Não foram encontrados registros!");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Post(Takers takers)
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
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ('" + NoInjection(takers.IM) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.CPF_CNPJ) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.RG_IE) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.Name) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.NameFantasy) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.TypePerson) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.CEP) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.Street) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.Neighborhood) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.City) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.State) + "',");
                SQL.AppendLine("     '" + NoInjection(takers.Email) + "',");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

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

        public bool Put(Takers takers)
        {
            try
            {
                Validate(takers);

                if (takers.TakerId <= 0)
                {
                    throw new Exception("Informe o código do tomador!");
                }

                SQL.AppendLine(" Update Takers Set ");
                SQL.AppendLine("    IM = '" + NoInjection(takers.IM) + "',");
                SQL.AppendLine("    CPF_CNPJ = '" + NoInjection(takers.CPF_CNPJ) + "',");
                SQL.AppendLine("    RG_IE = '" + NoInjection(takers.RG_IE) + "',");
                SQL.AppendLine("    Name = '" + NoInjection(takers.Name) + "',");
                SQL.AppendLine("    NameFantasy = '" + NoInjection(takers.NameFantasy) + "',");
                SQL.AppendLine("    TypePerson = '" + NoInjection(takers.TypePerson) + "',");
                SQL.AppendLine("    CEP = '" + NoInjection(takers.CEP) + "',");
                SQL.AppendLine("    Street = '" + NoInjection(takers.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + NoInjection(takers.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + NoInjection(takers.City) + "', ");
                SQL.AppendLine("    State = '" + NoInjection(takers.State) + "',");
                SQL.AppendLine("    Email = '" + NoInjection(takers.Email) + "',");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where TakerId = " + takers.TakerId);

                if (Conn.Update(SQL.ToString()))
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

        public bool Delete(long TakerId)
        {
            try
            {
                if (TakerId <= 0)
                {
                    throw new Exception("Informe o código do tomador!");
                }

                SQL.AppendLine(" Update Takers Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where TakerId = " + TakerId);

                if (Conn.Delete(SQL.ToString()))
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
            if (string.IsNullOrEmpty(takers.IM))
            {
                 throw new Exception("Informe a inscrição municipal!");
            }

            if (string.IsNullOrEmpty(takers.CPF_CNPJ))
            {
                 throw new Exception("Informe o CPF/CNPJ!");
            }

            if (string.IsNullOrEmpty(takers.RG_IE))
            {
                 throw new Exception("Informe a inscrição estadual!");
            }

            if (string.IsNullOrEmpty(takers.RG_IE))
            {
                 throw new Exception("Informe a inscrição estadual!");
            }

            if (string.IsNullOrEmpty(takers.Name))
            {
                 throw new Exception("Informe o nome do tomador!");
            }

            if (string.IsNullOrEmpty(takers.NameFantasy))
            {
                 throw new Exception("Informe o nome nome fantasia do tomador!");
            }

            if (string.IsNullOrEmpty(takers.TypePerson))
            {
                 throw new Exception("Informe o tipo de pessoa do tomador!");
            }

            if (string.IsNullOrEmpty(takers.CEP))
            {
                 throw new Exception("Informe o CEP!");
            }

            if (string.IsNullOrEmpty(takers.Street))
            {
                 throw new Exception("Informe a Rua!");
            }

            if (string.IsNullOrEmpty(takers.Neighborhood))
            {
                 throw new Exception("Informe o bairro!");
            }

            if (string.IsNullOrEmpty(takers.City))
            {
                 throw new Exception("Informe a cidade!");
            }

            if (string.IsNullOrEmpty(takers.State))
            {
                 throw new Exception("Informe a UF!");
            }

            if (string.IsNullOrEmpty(takers.Email))
            {
                 throw new Exception("Informe o Email!");
            }
        }
    }
}