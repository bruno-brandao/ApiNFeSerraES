using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class CFPSDomain : MasterDomain
    {
        public T Get<T>(long? CFPSId = 0)
        {
            try
            {
                SQL = new StringBuilder();
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
                
                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "CFPS");
                if (data != null && data.Rows.Count > 0)
                {
                    if (typeof(T) == typeof(List<CFPS>))
                    {
                        List<CFPS> lCFPS = new List<CFPS>();
                        foreach (DataRow row in data.Rows)
                        {
                            lCFPS.Add(Fill(row));
                        }
                        return (T)Convert.ChangeType(lCFPS, typeof(T));
                    }
                    else if (typeof(T) == typeof(CFPS))
                    {
                        return (T)Convert.ChangeType(Fill(data.AsEnumerable().First()), typeof(T));

                    }
                }
                throw new Exception("Não foram encontrados registros!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public CFPS Fill(DataRow row)
        {
            CFPS CFPS = new CFPS();
            CFPS.CFPSId = long.Parse(row["CFPSId"].ToString());
            CFPS.CFPSCod = row["CFPS"].ToString();
            CFPS.Description = row["Description"].ToString();
            CFPS.Active = bool.Parse(row["Active"].ToString());
            CFPS.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
            CFPS.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
            return CFPS;
        }
    }
}