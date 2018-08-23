using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.API.Models
{
    public class Feedback
    {
        public Feedback()
        {

        }

        public Feedback(string Status, 
            string Message)
        {
            this.Status = Status;
            this.Message = Message;
        }
        
        public string Status { get; set; }
        public string Message { get; set; }
    }
}