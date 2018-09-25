using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Sessions : DefaultModels.Master
    {
        
        public Sessions()
        {

        }

        public Sessions(long SessionId, string SessionHash, long UserId, string DateStart, string DateEnd, bool Active , string DateInsert, string DateUpdate)
        {
            this.SessionId = SessionId;
            this.SessionHash = SessionHash;
            this.UserId = UserId;
            this.DateStart = DateStart;
            this.DateEnd = DateEnd;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }
        
        public long SessionId { get; set; }
        public string SessionHash { get; set; }
        public long UserId { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }

    }
}