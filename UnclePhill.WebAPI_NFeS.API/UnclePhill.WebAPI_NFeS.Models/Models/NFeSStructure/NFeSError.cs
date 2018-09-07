using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure.NFeSError
{
    // OBSERVAÇÃO: o código gerado pode exigir pelo menos .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class tbnfd
    {

        private tbnfdNfderro nfderroField;

        /// <remarks/>
        public tbnfdNfderro nfderro
        {
            get
            {
                return this.nfderroField;
            }
            set
            {
                this.nfderroField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class tbnfdNfderro
    {

        private ushort numeronfdField;

        private byte codigoerroField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort numeronfd
        {
            get
            {
                return this.numeronfdField;
            }
            set
            {
                this.numeronfdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte codigoerro
        {
            get
            {
                return this.codigoerroField;
            }
            set
            {
                this.codigoerroField = value;
            }
        }
    }
}
