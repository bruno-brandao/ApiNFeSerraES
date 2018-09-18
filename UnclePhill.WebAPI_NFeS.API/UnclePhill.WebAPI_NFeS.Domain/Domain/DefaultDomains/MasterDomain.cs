using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class MasterDomain
    {
        protected StringBuilder SQL = new StringBuilder();

        public const string XSDInput = "http://apps.serra.es.gov.br:8080/tbw/docs/xsd/WSEntradaNfd.xsd";

        public const string XSDCancel = "http://apps.serra.es.gov.br:8080/tbw/docs/xsd/WSEntradaCancelar.xsd";
    }
}