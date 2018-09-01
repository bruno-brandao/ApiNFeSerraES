using System;
using System.Collections.Generic;
using System.Data;
using UnclePhill.WebAPI_NFeS.Models;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class CFPSDomain : MasterDomain
    {

        public List<CFPS> Select(long? CFPSId = 0)
        {
            try
            {
                List<CFPS> lCFPS = new List<CFPS>();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    CFPSId, ");
                SQL.AppendLine("    CFPS, ");
                SQL.AppendLine("    Description, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From CFPS ");
                SQL.AppendLine(" Where Active = 1 ");
                if (CFPSId > 0) { SQL.AppendLine(" And CFPSId = " + CFPSId); }


                DataTable data = Conn.GetDataTable(SQL.ToString(), "CFPS");
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        CFPS CFPS = new CFPS();
                        CFPS.CFPSId = long.Parse(row["CFPSId"].ToString());
                        CFPS.CFPSCod = row["CFPS"].ToString();
                        CFPS.Description = row["Description"].ToString();
                        CFPS.Active = bool.Parse(row["Active"].ToString());
                        CFPS.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        CFPS.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        lCFPS.Add(CFPS);
                    }
                    return lCFPS;
                }
                throw new Exception("Não foram encontrados registros!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}