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
using System.Security.Cryptography.X509Certificates;

namespace UnclePhill.WebAPI_NFeS.Utils.Utils
{
    public sealed class Functions
    {
        private Functions()
        {
        }
                
        public static ConnectionManager Conn = new ConnectionManager("unclephill.database.windows.net", "BD_NFeS", "1433", "Administrador", "M1n3Rv@7");

        private const string CertificateBase64 = "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";

        private const string Password = "150208";

        public static Xml XmlFunctions = new Xml();

        public static DateTime DateTimeBr()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        public static string IIf<T>(T Test)
        {
            if (Test == null)
            {
                return string.Empty;
            }
            return Test.ToString();
        }

        public static MailServer Mail = new MailServer("smtp.gmail.com",587,"meuddd.app@gmail.com", "4cess0!DDD");

        public static bool IsDate(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }catch
            {
                return false;
            }
        }

        public static bool IsNumber(string number)
        {
            try
            {
                Decimal.Parse(number);
                return true;
            }catch
            {
                return false;
            }
        }

        public static bool IsBool(string value)
        {
            try
            {
                bool.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

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

        public static string NoQuote(string Value)
        {
            return Value.Replace("'", "''");
        }

        public static string FormatNumber(decimal Value)
        {
            return Value.ToString().Replace(".", "").Replace(",", ".");
        }

        public static string RemoveCharSpecial(string Value)
        {
            return Value.Replace("/", "").Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ","");
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

        public static X509Certificate2 LoadCertificate(string Cert = "", string Pass = "")
        {
            try
            {
                if (string.IsNullOrEmpty(Cert))
                {
                    Cert = CertificateBase64;
                }

                if (string.IsNullOrEmpty(Pass))
                {
                    Pass = Password;
                }

                byte[] bytesCertificate = Convert.FromBase64String(Cert);
                return new X509Certificate2(bytesCertificate, Pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InstallCertOnServer(string Certificate, string Password)
        {            
            return InstallCertOnServer(Functions.LoadCertificate(Certificate, Password));            
        }

        public static bool InstallCertOnServer(X509Certificate2 Certificate)
        {
            try
            {
                //Instalando certificado;
                X509Store Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                Store.Open(OpenFlags.ReadWrite);
                Store.Add(Certificate);
                Store.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public enum TypeInput
        {
            Numero = 0,
            Texto = 1
        }
    }
}
