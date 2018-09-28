using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Xml;
using System.Data;

namespace UnclePhill.WebAPI_NFeS.Utils.Utils
{
    public sealed class Functions
    {
        private Functions()
        {
        }

        public static ConnectionManager Conn = new ConnectionManager("unclephill.database.windows.net", "BD_NFeS", "1433", "Administrador", "M1n3Rv@7");        

        public static string Encript(string value)
        {
            try
            {
                SHA1Managed SHA1 = new SHA1Managed();
                Convert.ToBase64String(SHA1.ComputeHash(Encoding.ASCII.GetBytes(value)));
                byte[] passwordByte = Encoding.ASCII.GetBytes(value);
                return Convert.ToBase64String(passwordByte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Desencript(string value)
        {
            try
            {
                byte[] passwordByte = Convert.FromBase64String(value);
                return ASCIIEncoding.ASCII.GetString(passwordByte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string NotQuote(string Value)
        {
            return Value.Replace("'", "''");
        }

        public static string FormatNumber(decimal Value)
        {
            return Value.ToString().Replace(".", "").Replace(",", ".");
        }

        public enum TypeInput
        {
            Numero = 0,
            Texto = 1
        }

        public static bool ExistsRegister(string Value, TypeInput Type, string Field, string Table)
        {
            try
            {
                if (String.IsNullOrEmpty(Value)) { return true; }
                if (String.IsNullOrEmpty(Field)) { return true; }
                if (String.IsNullOrEmpty(Table)) { return true; }

                Value = Type == TypeInput.Texto ? "'" + Value + "'" : Value;

                StringBuilder SQL = new StringBuilder();
                SQL = new StringBuilder();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    Count(*) As Qtd ");
                SQL.AppendLine(" From " + Table);
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And " + Field + " = " + Value);

                DataTable data = Conn.GetDataTable(SQL.ToString(), Table);
                if (data != null && data.Rows.Count > 0 && int.Parse(data.AsEnumerable().First().Field<int>("Qtd").ToString()) > 0)
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

        #region "XML"
        public static Xml XmlFunctions = new Xml();
        #endregion
    }
}
