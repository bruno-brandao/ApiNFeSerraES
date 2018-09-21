using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    class NFeSRequestItens
    {
        public NFeSRequestItens()
        {

        }

        public NFeSRequestItens(decimal Number, string Maturity, decimal Value)
        {
            this.Number = Number;
            this.Maturity = Maturity;
            this.Value = Value;
        }

        public decimal Number { get; set; }
        public string Maturity { get; set; }
        public decimal Value { get; set; }
    }
}
