using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    public class NFeSRequestQuery
    {
        public string NumberNF { get; set; }
        public string KeyValidation { get; set; }
        public string Total { get; set; }
        public string TotalISS { get; set; }
        public string Name { get; set; }
        public string NameFantasy { get; set; }
        public string CPF_CNPJ { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string DateEmission { get; set; }
        public string Note { get; set; }
        public string XML { get; set; }
        public string PDF { get; set; }
        public string URL { get; set; }
        public string URLAuthenticity { get; set; }
    }
}
