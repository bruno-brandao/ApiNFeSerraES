using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Questions: DefaultModels.Master
    {
        public Questions()
        {

        }

        public Questions(long QuestionId, long Order, string Question,List<Responses> ListResponses, bool Active, string DateInsert, string DateUpdate)
        {
            this.QuestionId = QuestionId;
            this.Order = Order;
            this.Question = Question;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long QuestionId { get; set; }
        public long Order { get; set; }
        public string Question { get; set; }
        public List<Options> ListOptions { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}
