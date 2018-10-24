using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public static class SessionDomain
    {
        private static StringBuilder SQL = new StringBuilder();

        public static string GenerateHash(string Value)
        {
            try
            {
                return Functions.Encript(Value + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckSession(string SessionHash)
        {
            try
            {
                UpdateSession();

                if (string.IsNullOrEmpty(SessionHash))
                {
                    return false;
                }

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
                SQL.AppendLine(" And DateDiff(MI, DateStart, GetDate()) <= 5 ");
                SQL.AppendLine(" And Session.SessionHash Like '" + SessionHash.Replace("'", "''") + "'");

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "Session");
                if (data.Rows.Count > 0)
                {
                    DataRow row = data.AsEnumerable().First();
                    SQL = new StringBuilder();
                    SQL.AppendLine(" Update Session Set ");
                    SQL.AppendLine("    DateStart = GetDate(), ");
                    SQL.AppendLine("    DateEnd = DateAdd(MI,5,GetDate()) ");
                    SQL.AppendLine(" Where SessionId = " + row.Field<long>("SessionId"));

                    Functions.Conn.Execute(SQL.ToString());

                    return true;
                }
                throw new InternalProgramException("Não foram encontradas sessões para esse usuário!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateSession()
        {
            try
            {
                SQL = new StringBuilder();
                SQL.AppendLine(" Update Session Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And DateDiff(MI,DateStart,GetDate()) > 5 ");

                Functions.Conn.Update(SQL.ToString());

            }
            catch (Exception ex)
            {

            }
        }

        public static Users GetUserSession(string SessionHash)
        {
            try
            {
                if (string.IsNullOrEmpty(SessionHash))
                {
                    throw new InternalProgramException("Variavel de Sessão não informada!");
                }

                DataTable data;

                SQL = new StringBuilder();
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    UserId ");
                SQL.AppendLine(" From Session ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And SessionHash Like '" + SessionHash + "'");

                data = Functions.Conn.GetDataTable(SQL.ToString(), "Session");

                if (data != null && data.Rows.Count > 0)
                {
                    SQL = new StringBuilder();
                    SQL.AppendLine(" Select * From Users ");
                    SQL.AppendLine(" Where Active = 1 ");
                    SQL.AppendLine(" And UserId = " + data.AsEnumerable().First().Field<long>("UserId"));

                    data = Functions.Conn.GetDataTable(SQL.ToString(), "Users");
                    if (data != null && data.Rows.Count > 0)
                    {
                        DataRow row = data.AsEnumerable().First();

                        Users users = new Users();
                        users.UserId = row.Field<long>("UserId");
                        users.Name = row.Field<string>("Name");
                        users.LastName = row.Field<string>("LastName");
                        users.CPF = row.Field<string>("CPF");
                        users.Email = row.Field<string>("Email");
                        users.Password = row.Field<string>("Password");
                        users.SessionHash = string.Empty;
                        users.Active = row.Field<bool>("Active");
                        users.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        users.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");

                        return users;
                    }
                    throw new InternalProgramException("Usuário não encontrado!");
                }
                throw new InternalProgramException("Sessão não encontrada!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Sessions GetSessionById(long SessionId)
        {
            try
            {
                if (SessionId <= 0) { throw new InternalProgramException("Informe o código da sessão."); }

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
                SQL.AppendLine(" And Session.SessionId = " + SessionId);

                var data = Functions.Conn.GetDataTable(SQL.ToString(), "Session");
                if (data != null && data.Rows.Count > 0)
                {
                    Sessions session = new Sessions();
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
                throw new InternalProgramException("Não foi encontrar sessões!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Sessions NewSession(long UserId)
        {
            try
            {
                if (UserId <= 0)
                {
                    throw new InternalProgramException("Usuario não encontrado!");
                }

                DataTable data;

                SQL = new StringBuilder();
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    Count(SessionId) As Sessions ");
                SQL.AppendLine(" From Session ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And DateDiff(MI, DateStart, Getdate()) <= 5 ");
                SQL.AppendLine(" And Session.UserId = " + UserId);

                data = Functions.Conn.GetDataTable(SQL.ToString(), "Session");
                if (data != null && data.Rows.Count > 0 && data.AsEnumerable().First().Field<int>("Sessions") > 0)
                {
                    return SessionDomain.GetSessionById(data.AsEnumerable().First().Field<long>("SessionId"));
                }

                string Hash = SessionDomain.GenerateHash(UserId.ToString());

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
                session.SessionId = Functions.Conn.Insert(SQL.ToString());

                if (session.SessionId > 0)
                {
                    return SessionDomain.GetSessionById(session.SessionId);
                }
                throw new InternalProgramException("Não foi possivel criar uma sessão para o usuário!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
