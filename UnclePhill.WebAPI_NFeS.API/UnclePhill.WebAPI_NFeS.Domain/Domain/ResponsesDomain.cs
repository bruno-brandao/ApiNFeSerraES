using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain.Domain
{
    public class ResponsesDomain : DefaultDomains.MasterDomain
    {
        public bool Post(Responses responses)
        {
            try
            {
                Validate(responses);

                SQL = new StringBuilder();
                SQL.AppendLine(" Insert Into Responses ");
                SQL.AppendLine("   (UserId, ");
                SQL.AppendLine("    QuestionId, ");
                SQL.AppendLine("    OptionId, ");
                SQL.AppendLine("    Correct, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine("    ) ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("   (" + responses.UserId.ToString() + ",");
                SQL.AppendLine("    " + responses.QuestionId.ToString() + ",");
                SQL.AppendLine("    " + responses.OptionId.ToString() + ",");
                SQL.AppendLine("    " + (responses.Correct? 1:0) + ",");
                SQL.AppendLine("   1 ,");
                SQL.AppendLine("   GetDate(), ");
                SQL.AppendLine("   GetDate(), ");
                SQL.AppendLine("   ) ");

                if (Functions.Conn.Insert(SQL.ToString()) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validate(Responses responses)
        {
            if (responses.UserId <= 0)
            {
                throw new Exception("Informe o usuário!");
            }

            if (responses.QuestionId <= 0)
            {
                throw new Exception("Informe a questão!");
            }

            if (responses.OptionId <= 0)
            {
                throw new Exception("Informe a opção!");
            }
        }
    }
}
