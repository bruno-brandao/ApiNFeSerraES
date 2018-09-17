using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace UnclePhill.WebAPI_NFeS.Utils.Utils
{
    public sealed class Functions
    {
        private Functions()
        {
        }

        private static readonly Hashtable CacheSerializers = new Hashtable();

        public static string ClassForStringXml<T>(T Obj)
        {
            XElement xml;
            string keyNomeClasseEmUso = typeof(T).Name;
            XmlSerializer ser = SearchCache(keyNomeClasseEmUso, typeof(T));

            using (MemoryStream memory = new MemoryStream())
            {
                using (TextReader tr = new StreamReader(memory, Encoding.UTF8))
                {
                    ser.Serialize(memory, Obj);
                    memory.Position = 0;
                    xml = XElement.Load(tr);
                    xml.Attributes().Where(x => x.Name.LocalName.Equals("xsd") || x.Name.LocalName.Equals("xsi")).Remove();
                }
            }
            return XElement.Parse(xml.ToString()).ToString();
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

        public static void ClassForArchiveXml<T>(T Obj, string Archive)
        {
            string dir = Path.GetDirectoryName(Archive);
            if (dir != null && !Directory.Exists(dir))
                throw new DirectoryNotFoundException("Diretório " + dir + " não encontrado!");

            string xml = ClassForStringXml(Obj);
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
    }
}
