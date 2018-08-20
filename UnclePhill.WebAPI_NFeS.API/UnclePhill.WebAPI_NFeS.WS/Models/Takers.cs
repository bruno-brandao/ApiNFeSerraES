using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.WS.Models
{
    public class Takers
    {
        private Takers takers = new Takers();

        public Takers()
        {

        }

        public Takers(long TakerId, string IM, string CPF_CNPJ, string RG_IE, string Name, string CEP, string Street, string Neighborhood, string City, string State, string Email, bool Active, string DateInsert, string DateUpdate)
        {
            this.TakerId = TakerId;
            this.IM = IM;
            this.CPF_CNPJ = CPF_CNPJ;
            this.RG_IE = RG_IE;
            this.Name = Name;
            this.CEP = CEP;
            this.Street = Street;
            this.Neighborhood = Neighborhood;
            this.City = City;
            this.State = State;
            this.Email = Email;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public Takers GetSession()
        {
            return this.takers;
        }


        public long TakerId { get; set; }
        public string IM { get; set; }
        public string CPF_CNPJ { get; set; }
        public string RG_IE { get; set; }
        public string Name { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}