using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    public class NFeSRequestPreview
    {        
        public NFeSRequestPreview()
        {

        }

        public NFeSRequestPreview(string UrlNFeS, string PDF)
        {
            this.UrlNFeS = UrlNFeS;
            this.PDF = PDF;
        }

        public string UrlNFeS { get; set; }
        public string PDF { get; set; }
    }
}
