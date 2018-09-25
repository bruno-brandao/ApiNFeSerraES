using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class CFPS : DefaultModels.Master
    {
        public CFPS()
        {

        }

        public CFPS(long CFPSId, string CFPSCod, 
            string Description, bool Active, 
            string DateInsert, string DateUpdate)
        {
            this.CFPSId = CFPSId;
            this.CFPSCod = CFPSCod;
            this.Description = Description;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }


        public long CFPSId { get; set; }
        public string CFPSCod { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}