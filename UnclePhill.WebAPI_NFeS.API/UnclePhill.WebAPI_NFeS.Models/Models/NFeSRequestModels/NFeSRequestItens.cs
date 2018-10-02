using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    public class NFeSRequestItens
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int ActivitiesId { get; set; }
        public decimal Value { get; set; }
        public decimal Aliquot { get; set; }
        public decimal TaxWithheld { get; set; }
    }
}
