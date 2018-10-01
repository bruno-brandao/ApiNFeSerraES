using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    public class NFeSRequest
    {
        public long CompanyId { get; set; }
        public long TakerId { get; set; }
        public long CFPSId { get; set; }
        public long ShippingCompanyId { get; set; }
        public string Note { get; set; }
        public List<NFeSRequestModels.NFeSRequestItens> Itens { get; set; }
        public List<NFeSRequestModels.NFeSRequestInvoices> Invoices { get; set; }      
    }
}
