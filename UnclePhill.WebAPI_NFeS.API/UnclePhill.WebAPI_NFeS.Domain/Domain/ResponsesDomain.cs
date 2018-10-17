using System;
using System.Collections.Generic;
using System.Data;
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
                SQL.AppendLine("    1 ,");
                SQL.AppendLine("   GetDate(), ");
                SQL.AppendLine("   GetDate() ");
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
            //Validando os dados básicos objeto:
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

            //Validado a integridade dos dados informados:
            if (new UsersDomain().Get(responses.UserId).UserId <= 0)
            {
                throw new Exception("O usuário informado não está cadastrado!");
            }

            if (new QuestionsDomain().Get(responses.QuestionId).Count <= 0)
            {
                throw new Exception("A questão informada não está cadastrada!");
            }

            long Cont = 0;
            Questions question = new QuestionsDomain().Get(responses.QuestionId).First();            
            foreach (Options option in question.ListOptions)
            {
                if (option.OptionId != responses.OptionId)
                {
                    Cont++;
                }
            }
            
            if (Cont == question.ListOptions.Count)
            {
                throw new Exception("A opção selecionada não faz parte da lista de respostas da questão!");
            }

            //Verificando se a questão já foi respondida anteriormente:
            SQL = new StringBuilder();
            SQL.AppendLine(" Select ");
            SQL.AppendLine("    Count(Responses.ResponseId) As Qtd ");
            SQL.AppendLine(" From Responses    ");
            SQL.AppendLine(" Where Responses.Active = 1 ");
            SQL.AppendLine("    And Responses.UserId = " + responses.UserId.ToString());
            SQL.AppendLine("    And Responses.QuestionId = " + responses.QuestionId.ToString());

            DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "QtdResp");
            if (data != null && data.Rows.Count > 0)
            {
                if (data.AsEnumerable().First().Field<int>("Qtd") > 0)
                {
                    throw new Exception("Essa questão já foi respondida!");
                }
            }
        }
    }
}
