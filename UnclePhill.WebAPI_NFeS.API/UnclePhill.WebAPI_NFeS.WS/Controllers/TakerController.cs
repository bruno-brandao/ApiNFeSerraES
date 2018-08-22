using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class TakerController : MasterController
    {       
        public JsonResult Select()
        {
            try
            {
                if (!base.CheckSession())
                {
                    return Response(new Feedback("erro", "Sessão inválida!"));
                }

                List<Takers> lTakers = new List<Takers>();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    TakerId, ");
                SQL.AppendLine("    IM, ");
                SQL.AppendLine("    CPF_CNPJ, ");
                SQL.AppendLine("    RG_IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From Takers ");
                
                DataTable data = Conn.GetDataTable(SQL.ToString(), "Takers");
                if (data != null && data.Rows.Count > 0 )
                {
                    foreach (DataRow row in data.Rows)
                    {
                        Takers taker = new Takers();
                        taker.TakerId = long.Parse(row["TakerId"].ToString());
                        taker.IM = row["IM"].ToString();
                        taker.CPF_CNPJ = row["CPF_CNPJ"].ToString();
                        taker.RG_IE = row["RG_IE"].ToString();
                        taker.Name = row["Name"].ToString();
                        taker.CEP = row["CEP"].ToString();
                        taker.Street = row["Street"].ToString();
                        taker.Neighborhood = row["Neighborhood"].ToString();
                        taker.City = row["City"].ToString();
                        taker.State = row["State"].ToString();
                        taker.Email = row["Email"].ToString();
                        taker.Active = bool.Parse(row["Active"].ToString());
                        taker.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        taker.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        lTakers.Add(taker);
                    }
                    return Response(lTakers);
                }
                return Response(new Feedback("erro", "Não foram encontrados registros!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedback("erro", ex.Message));
            }            
        }

        public JsonResult Insert(Takers takers)
        {
            try
            {
                if (!base.CheckSession())
                {
                    return Response(new Feedback("erro", "Sessão inválida!"));
                }

                Feedback feedback = Validate(takers);
                if (feedback.Status.Equals("erro"))
                {
                    return Response(feedback);
                }

                SQL.AppendLine(" Insert Into Takers ");
                SQL.AppendLine("    IM, ");
                SQL.AppendLine("    CPF_CNPJ, ");
                SQL.AppendLine("    RG_IE, ");
                SQL.AppendLine("    Name, ");
                SQL.AppendLine("    CEP, ");
                SQL.AppendLine("    Street, ");
                SQL.AppendLine("    Neighborhood, ");
                SQL.AppendLine("    City, ");
                SQL.AppendLine("    State, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" Values ");
                SQL.AppendLine("    ('" + NoInjection(takers.IM) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.CPF_CNPJ) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.RG_IE) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.Name) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.CEP) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.Street) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.Neighborhood) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.City) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.State) + ",");
                SQL.AppendLine("     '" + NoInjection(takers.Email) + ",");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                if (Conn.Insert(SQL.ToString())> 0)
                {
                    return Response(new Feedback("ok", "Tomador criado com sucesso!"));
                }

                return Response(new Feedback("erro", "Houve um problema o tomador um usuário. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedback("erro", ex.Message));
            }            
        }

        public JsonResult Update(Takers takers)
        {
            try
            {
                if (!base.CheckSession())
                {
                    return Response(new Feedback("erro", "Sessão inválida!"));
                }

                Feedback feedback = Validate(takers);
                if (feedback.Status.Equals("erro"))
                {
                    return Response(feedback);
                }

                SQL.AppendLine(" Update Takers ");
                SQL.AppendLine("    IM = '" + NoInjection(takers.IM) + "',");
                SQL.AppendLine("    CPF_CNPJ = '" + NoInjection(takers.CPF_CNPJ) +"',");
                SQL.AppendLine("    RG_IE = '" + NoInjection(takers.RG_IE) + "',");
                SQL.AppendLine("    Name = '" + NoInjection(takers.Name) + "',");
                SQL.AppendLine("    CEP = '" + NoInjection(takers.CEP) + "',");
                SQL.AppendLine("    Street = '" + NoInjection(takers.Street) + "',");
                SQL.AppendLine("    Neighborhood = '" + NoInjection(takers.Neighborhood) + "',");
                SQL.AppendLine("    City = '" + NoInjection(takers.City) + "', ");
                SQL.AppendLine("    State = '" + NoInjection(takers.State) + "',");
                SQL.AppendLine("    Email = '" + NoInjection(takers.Email) + "',");
                SQL.AppendLine("    Active = 1, ");   
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where TakerId = " + takers.TakerId);
                
                if (Conn.Update(SQL.ToString()))
                {
                    return Response(new Feedback("ok","Tomador atualizado com sucesso!"));
                }

                return Response(new Feedback("erro","Houve um erro ao atualizar o tomador. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedback("erro", ex.Message));
            }
        }

        public JsonResult Delete(long TakerId)
        {
            try
            {
                if (!base.CheckSession())
                {
                    return Response(new Feedback("erro", "Sessão inválida!"));
                }

                if (TakerId <= 0)
                {
                    return Response(new Feedback("erro", "Informe o código do tomador!"));
                }

                SQL.AppendLine(" Update Takers Set ");
                SQL.AppendLine("    Active = 0 ");
                SQL.AppendLine(" Where TakerId = " + TakerId);
                
                if (Conn.Delete(SQL.ToString()))
                {
                    return Response(new Feedback("ok","Tomador deletado com sucesso!"));
                }

                return Response(new Feedback("erro", "Houve um erro ao excluir o tomador. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedback("erro", ex.Message));
            }
        }
        
        private Feedback Validate(Takers takers)
        {
            if (string.IsNullOrEmpty(takers.IM))
            {
                return new Feedback("erro", "Informe a inscrição municipal!");
            }

            if (string.IsNullOrEmpty(takers.CPF_CNPJ))
            {
                return new Feedback("erro", "Informe o CPF/CNPJ!");
            }

            if (string.IsNullOrEmpty(takers.RG_IE))
            {
                return new Feedback("erro", "Informe a inscrição estadual!");
            }

            if (string.IsNullOrEmpty(takers.RG_IE))
            {
                return new Feedback("erro", "Informe a inscrição estadual!");
            }

            if (string.IsNullOrEmpty(takers.Name))
            {
                return new Feedback("erro", "Informe o nome do tomador!");
            }

            if (string.IsNullOrEmpty(takers.CEP))
            {
                return new Feedback("erro", "Informe o CEP!");
            }

            if (string.IsNullOrEmpty(takers.Street))
            {
                return new Feedback("erro", "Informe a Rua!");
            }

            if (string.IsNullOrEmpty(takers.Neighborhood))
            {
                return new Feedback("erro", "Informe o bairro!");
            }

            if (string.IsNullOrEmpty(takers.City))
            {
                return new Feedback("erro", "Informe a cidade!");
            }

            if (string.IsNullOrEmpty(takers.State))
            {
                return new Feedback("erro", "Informe a UF!");
            }

            if (string.IsNullOrEmpty(takers.Email))
            {
                return new Feedback("erro", "Informe o CEP!");
            }

            return new Feedback("ok", "Sucesso");
        }
    }
}