using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Companys: DefaultModels.Master
    {
        public Companys()
        {

        }

        public Companys(long CompanyId, long UserId,
            string CNPJ, string IM, 
            string IE, string Name, 
            string NameFantasy,
            string CEP, string Street,
            string Neighborhood, string City, 
            string State, string Telephone, 
            string Email, string Logo,
            decimal IRRF, decimal PIS,
            decimal COFINS, decimal CSLL,
            decimal INSS, bool Active,
            string DateInsert, string DateUpdate)
        {
            this.CompanyId = CompanyId;
            this.UserId = UserId;
            this.CNPJ = CNPJ;
            this.IM = IM;
            this.IE = IE;
            this.Name = Name;
            this.NameFantasy = NameFantasy;
            this.CEP = CEP;
            this.Street = Street;
            this.Neighborhood = Neighborhood;
            this.City = City;
            this.State = State;
            this.Telephone = Telephone;
            this.Email = Email;
            this.Logo = Logo;
            this.IRRF = IRRF;
            this.PIS = PIS;
            this.COFINS = COFINS;
            this.CSLL = CSLL;
            this.INSS = INSS;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }


        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public string CNPJ { get; set; }
        public string IM { get; set; }
        public string IE { get; set; }
        public string Name { get; set; }
        public string NameFantasy { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public decimal IRRF { get; set; }
        public decimal PIS { get; set; }
        public decimal COFINS { get; set; }
        public decimal CSLL { get; set; }
        public decimal INSS { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}