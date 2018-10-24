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
    public class QuestionsDomain: DefaultDomains.MasterDomain
    {
        public List<Questions> Get(long QuestionId = 0)
        {
            try
            {
                List<Questions> lQuestions = GetQuestions(QuestionId);
                if (lQuestions.Count <= 0)
                {
                    throw new InternalProgramException("Não existe questões cadastradas!");
                }

                return lQuestions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private List<Questions> GetQuestions(long QuestionId = 0)
        {
            try
            {
                SQL = new StringBuilder();
                SQL.AppendLine(" Select  Questions.QuestionId , ");
                SQL.AppendLine("         Questions.[Order] , ");
                SQL.AppendLine("         Questions.Question , ");
                SQL.AppendLine("         Questions.Active , ");
                SQL.AppendLine("         Questions.DateInsert , ");
                SQL.AppendLine("         Questions.DateUpdate ");
                SQL.AppendLine(" From    Questions ");
                SQL.AppendLine(" Where   Questions.Active = 1 ");
                if (QuestionId > 0) { SQL.AppendLine(" And Questions.QuestionId = " + QuestionId); }

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "Questions");
                List<Questions> lQuestions = new List<Questions>();

                if (data != null && data.Rows.Count > 0)
                {                    
                    foreach (DataRow row in data.Rows)
                    {
                        List<Options> lOptions = GetOptions(row.Field<long>("QuestionId"));
                        if (lOptions.Count > 0)
                        {
                            Questions question = new Questions();
                            question.QuestionId = row.Field<long>("QuestionId");
                            question.Order = row.Field<long>("Order");
                            question.Question = row.Field<string>("Question");
                            question.ListOptions = lOptions;
                            question.Active = row.Field<bool>("Active");
                            question.DateInsert = row.Field<DateTime>("DateInsert").ToString("yyyy-MM-dd");
                            question.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("yyyy-MM-dd");
                            lQuestions.Add(question);
                        }                        
                    }                    
                }
                return lQuestions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Options> GetOptions(long QuestionId)
        {
            try
            {
                if (QuestionId <= 0)
                {
                    throw new InternalProgramException("Informe a questão!");
                }

                SQL = new StringBuilder();
                SQL.AppendLine(" Select Options.OptionId , ");
                SQL.AppendLine("        Options.QuestionId , ");
                SQL.AppendLine("        Options.[Order] , ");
                SQL.AppendLine("        Options.[Option] , ");
                SQL.AppendLine("        Options.Correct , ");
                SQL.AppendLine("        Options.Active , ");
                SQL.AppendLine("        Options.DateInsert , ");
                SQL.AppendLine("        Options.DateUpdate  ");
                SQL.AppendLine(" From Options ");
                SQL.AppendLine(" Where Options.Active = 1 ");
                SQL.AppendLine(" And Options.QuestionId = " + QuestionId);
                
                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "Options");
                List<Options> lOptions = new List<Options>();

                if (data != null && data.Rows.Count > 0)
                {                    
                    foreach(DataRow row in data.Rows)
                    {
                        Options option = new Options();
                        option.OptionId = row.Field<long>("OptionId");
                        option.QuestionId = row.Field<long>("QuestionId");
                        option.Order = row.Field<long>("Order");
                        option.Option = row.Field<string>("Option");
                        option.Correct = row.Field<bool>("Correct");
                        option.Active = row.Field<bool>("Active");
                        option.DateInsert = row.Field<DateTime>("DateInsert").ToString("yyyy-MM-dd");
                        option.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("yyyy-MM-dd");
                        lOptions.Add(option);                        
                    }
                }
                return lOptions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
