using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain.Domain
{
    public class CertificatesDomain: MasterDomain
    {
        public bool UploadCertificate(Certificates Certificate)
        {
            try
            {
                Validate(Certificate);

                SQL = new StringBuilder();
                if (Functions.ExistsRegister(Certificate.CompanyId.ToString(), Functions.TypeInput.Numero, "CompanyId", "Certificates"))
                {
                    SQL.AppendLine(" Update Certificates Set ");
                    SQL.AppendLine("   Certificate = '" + Functions.NotQuote(Certificate.Certificate) + "' , ");
                    SQL.AppendLine("   Password = '" + Functions.NotQuote(Certificate.Password) + "' , ");
                    SQL.AppendLine("   Active = 1 , ");
                    SQL.AppendLine("   DateUpdate = GetDate() ");
                    SQL.AppendLine(" Where Certificates.CertificateId = " + Certificate.CertificateId);

                    Functions.Conn.Update(SQL.ToString());
                }
                else
                {
                    SQL.AppendLine(" Insert Into Certificates ");
                    SQL.AppendLine(" ( CompanyId , ");
                    SQL.AppendLine("   Certificate , ");
                    SQL.AppendLine("   Password , ");
                    SQL.AppendLine("   Active , ");
                    SQL.AppendLine("   DateInsert , ");
                    SQL.AppendLine("   DateUpdate) ");
                    SQL.AppendLine(" Values ");
                    SQL.AppendLine(" ( " + Certificate.CompanyId);
                    SQL.AppendLine("  '" + Functions.NotQuote(Certificate.Certificate) + "',");
                    SQL.AppendLine("  '" + Functions.NotQuote(Certificate.Password) + "',");
                    SQL.AppendLine("  1, ");
                    SQL.AppendLine("  GetDate(), ");
                    SQL.AppendLine("  GetDate() ");
                    SQL.AppendLine(" ) ");

                    Certificate.CertificateId = Functions.Conn.Insert(SQL.ToString());
                }           
                
                if (Certificate.CertificateId > 0)
                {
                    Certificate.Active = true;
                    Certificate.DateInsert = DateTime.Now.ToString("yyyy-MM-dd");
                    Certificate.DateUpdate = DateTime.Now.ToString("yyyy-MM-dd");
                    return true;
                }

                throw new Exception("Não foi possivel cadastrar o certificado!");
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        private void Validate(Certificates Certificate)
        {
            if (Certificate.CompanyId <= 0)
            {
                throw new Exception("Informe a empresa!");
            }

            if (String.IsNullOrEmpty(Certificate.Certificate))
            {
                throw new Exception("Informe o certificado!");
            }

            if (string.IsNullOrEmpty(Certificate.Password))
            {
                throw new Exception("Informe a senha do certificado!");
            }            
        }
    }
}
