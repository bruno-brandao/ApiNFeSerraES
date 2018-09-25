using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class NFeSItens : DefaultModels.Master
    {
        public NFeSItens()
        {

        }

        public NFeSItens(long NFeSItensId, long NFeSId,
            decimal Amount, string Description,
            string ActivityCode, decimal UnitaryValue,
            decimal Aliquot, decimal TaxWithheld,
            decimal ValueTaxEstimated, bool Active,
            string DateInsert, string DateUpdate)
        {
            this.NFeSItensId = NFeSItensId;
            this.NFeSId = NFeSId;
            this.Amount = Amount;
            this.Description = Description;
            this.ActivityCode = ActivityCode;
            this.UnitaryValue = UnitaryValue;
            this.Aliquot = Aliquot;
            this.TaxWithheld = TaxWithheld;
            this.ValueTaxEstimated = ValueTaxEstimated;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long NFeSItensId { get; set; }
        public long NFeSId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string ActivityCode { get; set; }
        public decimal UnitaryValue { get; set; }
        public decimal Aliquot { get; set; }
        public decimal TaxWithheld { get; set; }
        public decimal ValueTaxEstimated { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}