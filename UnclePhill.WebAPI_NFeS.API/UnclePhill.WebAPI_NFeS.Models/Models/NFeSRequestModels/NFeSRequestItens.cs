using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    public class NFeSRequestItens
    {
        public long ServicesId { get; set; }        
        public decimal Amount { get; set; }        
        public decimal Value { get; set; }
    }
}
