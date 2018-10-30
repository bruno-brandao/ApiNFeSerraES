using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Services : DefaultModels.Master
    {
        public Services()
        {

        }

        public Services(long ServicesId, long CompanyId, string Unity, 
            decimal Value, string Description, 
            decimal IRRF, decimal PIS, 
            decimal CSLL, decimal INSS, 
            decimal COFINS, bool Active, 
            string DateInsert, string DateUpdate)
        {
            this.ServicesId = ServicesId;
            this.CompanyId = CompanyId;
            this.Unity = Unity;
            this.Value = Value;
            this.Description = Description;
            this.IRRF = IRRF;
            this.PIS = PIS;
            this.CSLL = CSLL;
            this.INSS = INSS;
            this.COFINS = COFINS;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long ServicesId { get; set; }
        public long CompanyId { get; set; }
        public string Unity { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public decimal IRRF { get; set; }
        public decimal PIS { get; set; }
        public decimal CSLL { get; set; }
        public decimal INSS { get; set; }
        public decimal COFINS { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}