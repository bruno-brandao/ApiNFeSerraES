using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace UnclePhill.WebAPI_NFeS.Utils.Utils
{
    public class Xml
    {
        public Signature Signature = new Signature();

        public bool IsXml(string parameter)
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

        public bool ValidateXml(string XSD, string XML)
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

        private readonly Hashtable CacheSerializers = new Hashtable();

        public string ClassForStringXml<T>(T Obj, String Encode = "ISO-8859-1")
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

        public T StringXmlForClass<T>(string Input) where T : class
        {
            string keyNomeClasseEmUso = typeof(T).FullName;
            XmlSerializer ser = SearchCache(keyNomeClasseEmUso, typeof(T));

            using (StringReader sr = new StringReader(Input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public T ArchiveXmlForClass<T>(string Archive) where T : class
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

        public void ClassForArchiveXml<T>(T Obj, string Archive, string Encode = "ISO-8859-1")
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

        public void SaveStringXmlForArchiveXml(string Xml, string Archive)
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

        public string GetNodeStream(string Node, StreamReader Stream)
        {
            XDocument xmlDoc = XDocument.Load(Stream);

            XElement xmlString = (from d in xmlDoc.Descendants()
                                  where d.Name.LocalName == Node
                                  select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no stream!", Node));
            return xmlString.ToString();
        }

        public string GetNodeArchiveXml(string Node, string ArchiveXml)
        {
            XDocument xmlDoc = XDocument.Load(ArchiveXml);
            XElement xmlString = (from d in xmlDoc.Descendants()
                                  where d.Name.LocalName == Node
                                  select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no arquivo {1}!", Node, ArchiveXml));
            return xmlString.ToString();
        }

        public string GetNodeStringXml(string Node, string StringXml)
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

        private XmlSerializer SearchCache(string Key, Type Type)
        {
            if (CacheSerializers.Contains(Key))
            {
                return (XmlSerializer)CacheSerializers[Key];
            }
            XmlSerializer ser = XmlSerializer.FromTypes(new Type[] { Type })[0];
            CacheSerializers.Add(Key, ser);

            return ser;
        }
    }
}
