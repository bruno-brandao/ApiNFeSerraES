using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Certificates : DefaultModels.Master
    {
        public Certificates()
        {

        }

        public Certificates(long CertificateId, long CompanyId, string Certificate, 
            string Password, bool Active, string DateInsert, string DateUpdate)
        {
            this.CertificateId = CertificateId;
            this.CompanyId = CompanyId;
            this.Certificate = Certificate;
            this.Password = Password;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long CertificateId { get; set; }
        public long CompanyId { get; set; }
        public string Certificate { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}
