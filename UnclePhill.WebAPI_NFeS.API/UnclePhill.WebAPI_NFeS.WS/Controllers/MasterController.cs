using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class MasterController : Controller
    {
        protected ConnectionManager Conn = new ConnectionManager("unclephill.database.windows.net","BD_NFeS","1433","Administrador","M1n3Rv@7");
        protected StringBuilder SQL = new StringBuilder();
        protected Session Session = new Session();

        public ActionResult Index()
        {
            return View();
        }

        protected string NoInjection(string Value)
        {
            return Value.Replace("'", "''");
        }

        protected JsonResult Response(object Param)
        {
            return Json(Param, JsonRequestBehavior.AllowGet);
        }

        protected bool CheckSession()
        {
            try
            {
                UpdateSession();

                string Session = Request.Headers.Get("SessionHash");
                if (string.IsNullOrEmpty(Session))
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
                SQL.AppendLine(" And Session.SessionHash Like '" + NoInjection(Session) + "'");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Session");
                if (data.Rows.Count > 0)
                {
                    DataRow row = data.AsEnumerable().First();
                    SQL = new StringBuilder();
                    SQL.AppendLine(" Update Session Set ");
                    SQL.AppendLine("    DateStart = GetDate(), ");
                    SQL.AppendLine("    DateEnd = DateAdd(MI,5,GetDate()) ");
                    SQL.AppendLine(" Where SessionId = " + row.Field<long>("SessionId"));

                    Conn.Execute(SQL.ToString());

                    return true;
                }
                throw new Exception("Não foram encontradas sessões para esse usuário!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void UpdateSession()
        {
            try
            {
                SQL = new StringBuilder();
                SQL.AppendLine(" Update Session Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And DateDiff(MI,DateStart,GetDate()) > 5 ");

                Conn.Update(SQL.ToString());

            }
            catch(Exception ex)
            {
                
            }
        }

        protected string GenerateHash(string Password)
        {
            try
            {
                UnicodeEncoding unicode = new UnicodeEncoding();
                byte[] passwordByte = unicode.GetBytes(Password + DateTime.Now.ToString());
                SHA1Managed SHA = new SHA1Managed();
                byte[] hashByte = SHA.ComputeHash(passwordByte);
                string hash = string.Empty;

                foreach (byte b in hashByte)
                {
                    hash += b.ToString();
                }
                return hash;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
    }
}