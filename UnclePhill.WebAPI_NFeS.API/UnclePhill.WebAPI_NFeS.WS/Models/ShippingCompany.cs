using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.WS.Models
{
    public class ShippingCompany
    {
        public ShippingCompany()
        {

        }

        public ShippingCompany(long ShippingCompanyId, string CPF_CNPJ,
            string Name, string NameFantasy, string CEP, string Street,
            string Neighborhood, string City, string State, bool Active,
            string DateInsert, string DateUpdate)
        {
            this.ShippingCompanyId = ShippingCompanyId;
            this.CPF_CNPJ = CPF_CNPJ;
            this.Name = Name;
            this.NameFantasy = NameFantasy;
            this.CEP = CEP;
            this.Street = Street;
            this.Neighborhood = Neighborhood;
            this.City = City;
            this.State = State;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long ShippingCompanyId { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Name { get; set; }
        public string NameFantasy { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}