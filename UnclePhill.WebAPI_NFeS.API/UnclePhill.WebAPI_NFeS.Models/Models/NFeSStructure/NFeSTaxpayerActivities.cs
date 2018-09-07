using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure.NFeSTaxpayerActivities
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AtividadesContribuinte
    {

        private Atividade[] atividadeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Atividade")]
        public Atividade[] Atividade
        {
            get
            {
                return this.atividadeField;
            }
            set
            {
                this.atividadeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Atividade
    {

        private string codigoCnaeField;

        private string descricaoField;

        private string aliquotaField;

        /// <remarks/>
        public string CodigoCnae
        {
            get
            {
                return this.codigoCnaeField;
            }
            set
            {
                this.codigoCnaeField = value;
            }
        }

        /// <remarks/>
        public string Descricao
        {
            get
            {
                return this.descricaoField;
            }
            set
            {
                this.descricaoField = value;
            }
        }

        /// <remarks/>
        public string Aliquota
        {
            get
            {
                return this.aliquotaField;
            }
            set
            {
                this.aliquotaField = value;
            }
        }
    }
}
