﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Domain
{
    public class UsersDomain : MasterDomain
    {      
        public Users Login(string Email, string Password)
        {
            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    throw new Exception("Email ou senha não informado!");
                }

                SQL = new StringBuilder();
                SQL.AppendLine(" Select * From Users ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And Email Like '" + NoInjection(Email) + "'");
                SQL.AppendLine(" And Password Like '" + NoInjection(Password) + "'");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Users");
                if (data != null && data.Rows.Count > 0)
                {
                    DataRow row = data.AsEnumerable().First();
                    Sessions session = NewSession(row.Field<long>("UserId"));
                    if (session.SessionId > 0)
                    {
                        Users users = new Users();
                        users.UserId = row.Field<long>("UserId");
                        users.Name = row.Field<string>("Name");
                        users.LastName = row.Field<string>("LastName");
                        users.CPF = row.Field<string>("CPF");
                        users.Email = row.Field<string>("Email");
                        users.Password = row.Field<string>("Password");
                        users.SessionHash = session.SessionHash;
                        users.Active = row.Field<bool>("Active");
                        users.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        users.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        return users;
                    }
                    throw new Exception("Não foi possivel gerar uma sessão para o usuário!");
                }

                throw new Exception("Email ou senha inválidos!");
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Users users)
        {
            try
            {
                Feedbacks feedback = Validate(users);
                if (feedback.Status.Equals("erro"))
                {
                    throw new Exception(feedback.Message);
                }

                SQL = new StringBuilder();
                SQL.AppendLine(" Insert Into Users ");
                SQL.AppendLine("   (Name, ");
                SQL.AppendLine("    LastName, ");
                SQL.AppendLine("    CPF, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Password, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values( ");
                SQL.AppendLine("    '" + NoInjection(users.Name) + "',");
                SQL.AppendLine("    '" + NoInjection(users.LastName) + "',");
                SQL.AppendLine("    '" + NoInjection(users.CPF) + "',");
                SQL.AppendLine("    '" + NoInjection(users.Email) + "',");
                SQL.AppendLine("    '" + NoInjection(users.Password) + "',");
                SQL.AppendLine("    1,");
                SQL.AppendLine("    GetDate(),");
                SQL.AppendLine("    GetDate() ");
                SQL.AppendLine(" ) ");

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

        public bool Update(Users users)
        {
            try
            {
                if (users.UserId <= 0)
                {
                    throw new Exception("Informe o código do usuário!");
                }

                Feedbacks feedback = Validate(users);
                if (feedback.Status.Equals("erro")){ throw new Exception(feedback.Message);}

                SQL = new StringBuilder();
                SQL.AppendLine(" Update Users Set ");
                SQL.AppendLine("    Name = '" + NoInjection(users.Name) + "',");
                SQL.AppendLine("    LastName = '" + NoInjection(users.LastName) + "',");
                SQL.AppendLine("    CPF = '" + NoInjection(users.CPF) + "',");
                SQL.AppendLine("    Email = '" + NoInjection(users.Email) + "',");
                SQL.AppendLine("    Password = '" + NoInjection(users.Password) + "',");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And UserId = " + users.UserId);

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

        private Sessions NewSession(long UserId)
        {
            try
            {
                if (UserId <= 0)
                {
                    throw new Exception("Usuario não encontrado!");
                }

                DataTable data;

                SQL = new StringBuilder();
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    Count(SessionId) As Sessions ");
                SQL.AppendLine(" From Session ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And DateDiff(MI, DateStart, Getdate()) <= 5 ");
                SQL.AppendLine(" And Session.UserId = " + UserId);

                data = Conn.GetDataTable(SQL.ToString(), "Session");
                if (data != null && data.Rows.Count > 0 && data.AsEnumerable().First().Field<int>("Sessions") > 0)
                {
                    throw new Exception("Já existe sessão aberta para o usuário atual!");
                }

                string Hash = GenerateHash(UserId.ToString());

                SQL = new StringBuilder();
                SQL.AppendLine(" Insert Into Session ");
                SQL.AppendLine("    (UserId, ");
                SQL.AppendLine("     SessionHash,");
                SQL.AppendLine("     DateStart, ");
                SQL.AppendLine("     DateEnd, ");
                SQL.AppendLine("     Active, ");
                SQL.AppendLine("     DateInsert, ");
                SQL.AppendLine("     DateUpdate)");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ( " + UserId + ",");
                SQL.AppendLine("     '" + Hash + "',");
                SQL.AppendLine("     GetDate(),");
                SQL.AppendLine("     DateAdd(MI,5,GetDate()),");
                SQL.AppendLine("     1, ");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate()) ");

                Sessions session = new Sessions();
                session.SessionId = Conn.Insert(SQL.ToString());

                if (session.SessionId > 0)
                {
                    SQL = new StringBuilder();
                    SQL.AppendLine(" Select ");
                    SQL.AppendLine("    SessionId, ");
                    SQL.AppendLine("    UserId, ");
                    SQL.AppendLine("    SessionHash, ");
                    SQL.AppendLine("    DateStart, ");
                    SQL.AppendLine("    DateEnd, ");
                    SQL.AppendLine("    Active, ");
                    SQL.AppendLine("    DateInsert, ");
                    SQL.AppendLine("    DateUpdate ");
                    SQL.AppendLine(" From Session ");
                    SQL.AppendLine(" Where Active = 1 ");
                    SQL.AppendLine(" And Session.SessionId = " + session.SessionId);

                    data = Conn.GetDataTable(SQL.ToString(), "Session");
                    if (data != null && data.Rows.Count > 0)
                    {
                        DataRow row = data.AsEnumerable().First();
                        session.SessionId = row.Field<long>("SessionId");
                        session.UserId = row.Field<long>("UserId");
                        session.SessionHash = row.Field<string>("SessionHash");
                        session.DateStart = row.Field<DateTime>("DateStart").ToString("dd-MM-yyyy"); ;
                        session.DateEnd = row.Field<DateTime>("DateEnd").ToString("dd-MM-yyyy");
                        session.Active = row.Field<bool>("Active");
                        session.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        session.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        return session;
                    }
                    throw new Exception("Não foi possivel criar uma sessão para o usuário!");
                }
                throw new Exception("Não foi possivel criar uma sessão para o usuário!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Feedbacks Validate(Users users)
        {

            if (string.IsNullOrEmpty(users.Name))
            {
                return new Feedbacks("erro", "Informe o nome do usuário!");
            }

            if (string.IsNullOrEmpty(users.LastName))
            {
                return new Feedbacks("erro", "Informe o Sobrenome do usuário!");
            }

            if (string.IsNullOrEmpty(users.CPF))
            {
                return new Feedbacks("erro", "Informe o CPF do usuário!");
            }

            if (string.IsNullOrEmpty(users.Email))
            {
                return new Feedbacks("erro", "Informe o Email do usuário!");
            }

            if (string.IsNullOrEmpty(users.Password))
            {
                return new Feedbacks("erro", "Informe a senha do usuário!");
            }

            return new Feedbacks("ok", "Sucesso");
        }
    }
}