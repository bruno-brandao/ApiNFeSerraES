using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure
{

    // OBSERVAÇÃO: o código gerado pode exigir pelo menos .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class nfd
    {

        private nfdRecibo reciboField;

        /// <remarks/>
        public nfdRecibo recibo
        {
            get
            {
                return this.reciboField;
            }
            set
            {
                this.reciboField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class nfdRecibo
    {

        private string codreciboField;

        private string datahoraField;

        private byte numeronotasField;

        private byte codmunicipioField;

        /// <remarks/>
        public string codrecibo
        {
            get
            {
                return this.codreciboField;
            }
            set
            {
                this.codreciboField = value;
            }
        }

        /// <remarks/>
        public string datahora
        {
            get
            {
                return this.datahoraField;
            }
            set
            {
                this.datahoraField = value;
            }
        }

        /// <remarks/>
        public byte numeronotas
        {
            get
            {
                return this.numeronotasField;
            }
            set
            {
                this.numeronotasField = value;
            }
        }

        /// <remarks/>
        public byte codmunicipio
        {
            get
            {
                return this.codmunicipioField;
            }
            set
            {
                this.codmunicipioField = value;
            }
        }
    }
}
