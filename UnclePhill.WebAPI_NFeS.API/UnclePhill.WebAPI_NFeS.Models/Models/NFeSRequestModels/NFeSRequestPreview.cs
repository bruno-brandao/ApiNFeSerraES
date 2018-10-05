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

        public NFeSRequestPreview(string UrlNFeS, string UrlNFeSAutenticidade)
        {
            this.UrlNFeS = UrlNFeS;
            this.UrlNFeSAutenticidade = UrlNFeSAutenticidade;
        }

        public string UrlNFeS { get; set; }
        public string UrlNFeSAutenticidade { get; set; }
    }
}
