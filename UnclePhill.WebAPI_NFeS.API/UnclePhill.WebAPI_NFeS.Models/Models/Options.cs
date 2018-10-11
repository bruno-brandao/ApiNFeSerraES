using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Options: DefaultModels.Master
    {
        public Options()
        {

        }

        public Options(long OptionId, long QuestionId, long Order, string Option, bool Correct, bool Active, string DateInsert, string DateUpdate)
        {
            this.OptionId = OptionId;
            this.QuestionId = QuestionId;
            this.Order = Order;
            this.Option = Option;
            this.Correct = Correct;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long OptionId { get; set; }
        public long QuestionId { get; set; }
        public long Order { get; set; }
        public string Option { get; set; }
        public bool Correct { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}
