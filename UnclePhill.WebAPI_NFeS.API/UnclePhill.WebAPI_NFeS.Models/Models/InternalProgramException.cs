using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models
{
    public class InternalProgramException: Exception
    {
        public InternalProgramException():base()
        {

        }

        public InternalProgramException(string message):base(message)
        {

        }

        public InternalProgramException(string message, Exception inner):base(message,inner)
        {

        }
    }
}
