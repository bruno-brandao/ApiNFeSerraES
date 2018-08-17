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
        private List<Takers> lTakers = new List<Takers>();

        public JsonResult Select()
        {
            try
            {
                SQL.AppendLine("  ");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Takers");
                if (data != null && data.Rows.Count > 0 )
                {
                    foreach (DataRow drTaker in data.Rows)
                    {
                        Takers taker = new Takers();
                        taker.TakerId = long.Parse(drTaker[""].ToString());
                        lTakers.Add(taker);
                    }
                    return Json(lTakers, JsonRequestBehavior.AllowGet);
                }
                return Json(new Feedback("erro", "Não foram encontrados registros!"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }            
        }

        public JsonResult Insert(Takers takers)
        {
            try
            {
                SQL.AppendLine("  ");

                if (Conn.Execute(SQL.ToString()))
                {
                    return Json(new Feedback("ok", "Tomador criado com sucesso!"), JsonRequestBehavior.AllowGet);
                }

                return Json(new Feedback("erro", "Houve um problema o tomador um usuário. Tente novamente!"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
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