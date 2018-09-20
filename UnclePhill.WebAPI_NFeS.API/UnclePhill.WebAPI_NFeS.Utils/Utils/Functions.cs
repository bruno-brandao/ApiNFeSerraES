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
        public static Signature XmlSignature = new Signature();         

        public static bool IsXml(string parameter)
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

        public static bool ValidateXml(string XSD, string XML)
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

        private static readonly Hashtable CacheSerializers = new Hashtable();

        public static string ClassForStringXml<T>(T Obj,String Encode = "ISO-8859-1")
        {
            XElement xml;
            string keyNomeClasseEmUso = typeof(T).Name;
            XmlSerializer ser = SearchCache(keyNomeClasseEmUso, typeof(T));

            using (MemoryStream memory = new MemoryStream())
            {
                using (TextReader tr = new StreamReader(memory, Encoding.GetEncoding(Encode)))
                {
                    ser.Serialize(memory, Obj);
                    memory.Position = 0;
                    xml = XElement.Load(tr);
                    xml.Attributes().Where(x => x.Name.LocalName.Equals("xsd") || x.Name.LocalName.Equals("xsi")).Remove();
                }
            }
            return XElement.Parse(xml.ToString()).ToString(SaveOptions.DisableFormatting);
        }

        public static T StringXmlForClass<T>(string Input) where T : class
        {
            string keyNomeClasseEmUso = typeof(T).Name;
            XmlSerializer ser = SearchCache(keyNomeClasseEmUso, typeof(T));

            using (StringReader sr = new StringReader(Input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public static T ArchiveXmlForClass<T>(string Archive) where T : class
        {
            if (!File.Exists(Archive))
                throw new FileNotFoundException("Arquivo " + Archive + " não encontrado!");

            string keyNomeClasseEmUso = typeof(T).Name;
            XmlSerializer serializador = SearchCache(keyNomeClasseEmUso, typeof(T));
            FileStream stream = new FileStream(Archive, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                return (T)serializador.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }
        }

        public static void ClassForArchiveXml<T>(T Obj, string Archive, string Encode = "ISO-8859-1")
        {
            string dir = Path.GetDirectoryName(Archive);
            if (dir != null && !Directory.Exists(dir))
                throw new DirectoryNotFoundException("Diretório " + dir + " não encontrado!");

            string xml = ClassForStringXml(Obj, Encode);
            try
            {
                StreamWriter stw = new StreamWriter(Archive);
                stw.WriteLine(xml);
                stw.Close();
            }
            catch (Exception generatedExceptionName)
            {
                throw new Exception("Não foi possível criar o arquivo " + Archive + "!");
            }
        }

        public static void SaveStringXmlForArchiveXml(string Xml, string Archive)
        {
            string dir = Path.GetDirectoryName(Archive);
            if (dir != null && !Directory.Exists(dir))
                throw new DirectoryNotFoundException("Diretório " + dir + " não encontrado!");

            try
            {
                StreamWriter stw = new StreamWriter(Archive);
                stw.WriteLine(Xml);
                stw.Close();
            }
            catch (Exception generatedExceptionName)
            {
                throw new Exception("Não foi possível criar o arquivo " + Archive + "!");
            }
        }

        public static string GetNodeStream(string Node, StreamReader Stream)
        {
            XDocument xmlDoc = XDocument.Load(Stream);

            XElement xmlString = (from d in xmlDoc.Descendants()
                                  where d.Name.LocalName == Node
                                  select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no stream!", Node));
            return xmlString.ToString();
        }

        public static string GetNodeArchiveXml(string Node, string ArchiveXml)
        {
            XDocument xmlDoc = XDocument.Load(ArchiveXml);
            XElement xmlString = (from d in xmlDoc.Descendants()
                                  where d.Name.LocalName == Node
                                  select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no arquivo {1}!", Node, ArchiveXml));
            return xmlString.ToString();
        }

        public static string GetNodeStringXml(string Node, string StringXml)
        {
            string s = StringXml;
            XDocument xmlDoc = XDocument.Parse(s);
            XElement xmlString = (from d in xmlDoc.Descendants()
                                  where d.Name.LocalName == Node
                                  select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no xml!", Node));
            return xmlString.ToString();
        }

        private static XmlSerializer SearchCache(string Key, Type Type)
        {
            if (CacheSerializers.Contains(Key))
            {
                return (XmlSerializer)CacheSerializers[Key];
            }
            XmlSerializer ser = XmlSerializer.FromTypes(new Type[] { Type })[0];
            CacheSerializers.Add(Key, ser);

            return ser;
        }
        #endregion
    }
}
