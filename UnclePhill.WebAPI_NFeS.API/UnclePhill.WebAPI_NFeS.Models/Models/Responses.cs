using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class Responses: DefaultModels.Master
    {
        public Responses()
        {

        }

        public Responses(long ResponseId, long CompanyId, long QuestionId, long OptionId, bool Correct, bool Active, string DateInsert, string DateUpdate)
        {
            this.ResponseId = ResponseId;
            this.CompanyId = CompanyId;
            this.QuestionId = QuestionId;
            this.OptionId = OptionId;
            this.Correct = Correct;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
        }

        public long ResponseId { get; set; }
        public long CompanyId { get; set; }
        public long QuestionId { get; set; }
        public long OptionId { get; set; }
        public bool Correct { get; set; }
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
    }
}
