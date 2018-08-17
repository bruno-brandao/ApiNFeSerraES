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
                    foreach (DataRow drTaker in data.Rows)
                    {
                        Takers taker = new Takers();
                        taker.TakerId = long.Parse(drTaker["TakerId"].ToString());
                        taker.IM = drTaker["IM"].ToString();
                        taker.CPF_CNPJ = drTaker["CPF_CNPJ"].ToString();
                        taker.RG_IE = drTaker["RG_IE"].ToString();
                        taker.Name = drTaker["Name"].ToString();
                        taker.CEP = drTaker["CEP"].ToString();
                        taker.Street = drTaker["Street"].ToString();
                        taker.Neighborhood = drTaker["Neighborhood"].ToString();
                        taker.City = drTaker["City"].ToString();
                        taker.State = drTaker["State"].ToString();
                        taker.Email = drTaker["Email"].ToString();
                        taker.Active = bool.Parse(drTaker["Active"].ToString());
                        taker.DateInsert = DateTime.Parse(drTaker["DateInsert"].ToString());
                        taker.DateUpdate = DateTime.Parse(drTaker["DateUpdate"].ToString());
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
                if (string.IsNullOrEmpty(takers.IM))
                {
                    return Response(new Feedback("erro", "Informe a inscrição municipal!"));
                }

                if (string.IsNullOrEmpty(takers.CPF_CNPJ))
                {
                    return Response(new Feedback("erro", "Informe o CPF/CNPJ!"));
                }

                if (string.IsNullOrEmpty(takers.RG_IE))
                {
                    return Response(new Feedback("erro", "Informe a inscrição estadual!"));
                }

                if (string.IsNullOrEmpty(takers.RG_IE))
                {
                    return Response(new Feedback("erro", "Informe a inscrição estadual!"));
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
                SQL.AppendLine("    ('" + R(takers.IM) + ",");
                SQL.AppendLine("     '" + R(takers.CPF_CNPJ) + ",");
                SQL.AppendLine("     '" + R(takers.RG_IE) + ",");
                SQL.AppendLine("     '" + R(takers.Name) + ",");
                SQL.AppendLine("     '" + R(takers.CEP) + ",");
                SQL.AppendLine("     '" + R(takers.Street) + ",");
                SQL.AppendLine("     '" + R(takers.Neighborhood) + ",");
                SQL.AppendLine("     '" + R(takers.City) + ",");
                SQL.AppendLine("     '" + R(takers.State) + ",");
                SQL.AppendLine("     '" + R(takers.Email) + ",");
                SQL.AppendLine("     1 ,");
                SQL.AppendLine("     GetDate(), ");
                SQL.AppendLine("     GetDate() ");
                SQL.AppendLine("    ) ");

                if (Conn.Execute(SQL.ToString()))
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
                if (takers.TakerId <= 0)
                {
                    return Json(new Feedback("erro","Informe o código do tomador!"), JsonRequestBehavior.AllowGet);
                }

                SQL.AppendLine("");

                if (Conn.Execute(SQL.ToString()))
                {
                    return Json(new Feedback("ok","Tomador atualizado com sucesso!"));
                }

                return Json(new Feedback("erro","Houve um erro ao atualizar o tomador. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(long TakerId)
        {
            try
            {
                if(TakerId <= 0)
                {
                    return Json(new Feedback("erro", "Informe o código do tomador!"), JsonRequestBehavior.AllowGet);
                }

                SQL.AppendLine("");

                if (Conn.Execute(SQL.ToString()))
                {
                    return Json(new Feedback("ok","Tomador deletado com sucesso!"));
                }

                return Json(new Feedback("erro", "Houve um erro ao excluir o tomador. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }        
    }
}