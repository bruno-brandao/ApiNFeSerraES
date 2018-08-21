using System;
using System.Collections.Generic;
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
        protected ConnectionManager Conn = new ConnectionManager();
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

        protected bool CheckSession(string Session)
        {
            try
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
                SQL.AppendLine(" And DateDiff(MI, DateStart, DateEnd) <= 5 ");
                SQL.AppendLine(" And Session.SessionHash Like '" + NoInjection(Session) + "'");
                
                if (Conn.GetDataTable(SQL.ToString(), "Session").Rows.Count > 0)
                {
                    return true;
                }
                
                return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected string GenerateHash(string Password)
        {
            try
            {
                UnicodeEncoding unicode = new UnicodeEncoding();
                byte[] passwordByte = unicode.GetBytes(Password);
                SHA1Managed SHA = new SHA1Managed();
                byte[] hashByte = SHA.ComputeHash(passwordByte);
                string hash = string.Empty;

                foreach (byte b in hashByte)
                {
                    hash += b.ToString();
                }
                return hash;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}