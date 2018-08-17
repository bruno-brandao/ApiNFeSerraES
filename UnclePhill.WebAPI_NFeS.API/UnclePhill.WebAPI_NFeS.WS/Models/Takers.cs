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
    }
}