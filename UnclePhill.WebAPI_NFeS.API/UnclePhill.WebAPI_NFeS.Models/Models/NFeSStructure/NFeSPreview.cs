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
    public partial class util
    {

        private string urlNfdField;

        private string urlAutenticidadeField;

        /// <remarks/>
        public string urlNfd
        {
            get
            {
                return this.urlNfdField;
            }
            set
            {
                this.urlNfdField = value;
            }
        }

        /// <remarks/>
        public string urlAutenticidade
        {
            get
            {
                return this.urlAutenticidadeField;
            }
            set
            {
                this.urlAutenticidadeField = value;
            }
        }
    }
}
