using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Users : DefaultModels.Master
    {
        public Users()
        {

        }

        public Users(long UserId,string Name, 
            string LastName, string CPF, 
            string Email, string Password, 
            bool Active, string DateInsert, 
            string DateUpdate)
        {
            this.UserId = UserId;
            this.Name = Name;
            this.LastName = LastName;
            this.CPF = CPF;
            this.Email = Email;
            this.Password = Password;
            this.SessionHash = string.Empty;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SessionHash { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}