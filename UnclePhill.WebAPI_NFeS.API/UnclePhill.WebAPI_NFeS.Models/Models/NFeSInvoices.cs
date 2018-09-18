using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class NFeSInvoices : DefaultModels.Master
    {
        public NFeSInvoices()
        {

        }

        public NFeSInvoices(long NFeSInvoiceId, long NFeSId, 
            decimal Number, string Maturity, 
            decimal Value, bool Active,
            string DateInsert, string DateUpdate)
        {
            this.NFeSInvoiceId = NFeSInvoiceId;
            this.NFeSId = NFeSId;
            this.Number = Number;
            this.Maturity = Maturity;
            this.Value = Value;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
    }

        public long NFeSInvoiceId { get; set; }
        public long NFeSId { get; set; }
        public decimal Number { get; set; }
        public string Maturity { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }

    }
}