using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.Models;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class MasterDomain
    {
        protected ConnectionManager Conn = new ConnectionManager("unclephill.database.windows.net", "BD_NFeS", "1433", "Administrador", "M1n3Rv@7");
        protected StringBuilder SQL = new StringBuilder();
        protected Sessions Session = new Sessions();

        protected const string XSDInput = "http://apps.serra.es.gov.br:8080/tbw/docs/xsd/WSEntradaNfd.xsd";
        protected const string XSDCancel = "http://apps.serra.es.gov.br:8080/tbw/docs/xsd/WSEntradaCancelar.xsd";

        protected string GenerateHash(string Password)
        {
            try
            {
                UnicodeEncoding unicode = new UnicodeEncoding();
                byte[] passwordByte = unicode.GetBytes(Password + DateTime.Now.ToString());
                SHA1Managed SHA1 = new SHA1Managed();
                byte[] hashByte = SHA1.ComputeHash(passwordByte);
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

        protected string NoInjection(string Value)
        {
            return Value.Replace("'", "''");
        }

        protected string FormatNumber(decimal Value)
        {
            return Value.ToString().Replace(".", "").Replace(",", ".");
        }
           
        protected bool IsXml(string parameter)
        {
            try
            {
                XmlDocument XML = new XmlDocument();
                XML.LoadXml(parameter);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected string ParseXml(object obj)
        {
            try
            {
                StringWriter stringWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool ValidateXml(string XSD,string XML)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, XSD);
                settings.ValidationType = ValidationType.Schema;
                XmlReader xmlReader = XmlReader.Create(new StringReader(XML), settings);
                while (xmlReader.Read()) { }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}