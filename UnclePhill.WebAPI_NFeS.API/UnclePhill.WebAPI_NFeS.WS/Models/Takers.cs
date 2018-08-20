using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.WS.Models
{
    public class Takers
    {

        public Takers()
        {

        }

        public Takers(long TakerId)
        {
            this.TakerId = TakerId;
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