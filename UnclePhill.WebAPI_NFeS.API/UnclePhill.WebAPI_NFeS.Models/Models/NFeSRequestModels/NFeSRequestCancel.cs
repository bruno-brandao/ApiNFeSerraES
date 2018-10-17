using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    public class NFeSRequestCancel
    {
        public string IM { get; set; }
        public string NumNF { get; set; }
        public string DateCancel { get; set; }
        public string Cause { get; set; }
    }
}
