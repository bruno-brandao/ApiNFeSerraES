using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.API.Models
{
    public class Feedback
    {

        private Feedback feedback = new Feedback();

        public Feedback()
        {

        }

        public Feedback(string Status, string Message)
        {
            this.Status = Status;
            this.Message = Message;
        }

        public Feedback GetSession()
        {
            return this.feedback;
        }

        public string Status { get; set; }
        public string Message { get; set; }
    }
}