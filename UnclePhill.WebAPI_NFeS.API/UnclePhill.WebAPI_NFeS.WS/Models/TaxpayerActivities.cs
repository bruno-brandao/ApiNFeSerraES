using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.WS.Models
{
    public class TaxpayerActivities
    {

        public TaxpayerActivities()
        {

        }

        public TaxpayerActivities(long TaxpayerActivitiesId, string CNAE, string Description, decimal Aliquot, bool Active, string DateInsert, string DateUpdate)
        {
            this.TaxpayerActivitiesId = TaxpayerActivitiesId;
            this.CNAE = CNAE;
            this.Description = Description;
            this.Aliquot = Aliquot;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long TaxpayerActivitiesId { get; set; }
        public string CNAE { get; set; }
        public string Description { get; set; }
        public decimal Aliquot { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }

    }
        
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