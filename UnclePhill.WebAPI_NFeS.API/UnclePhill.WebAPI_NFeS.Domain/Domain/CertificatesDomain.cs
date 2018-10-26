using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain.Domain
{
    public class CertificatesDomain: DefaultDomains.MasterDomain
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
                    SQL.AppendLine("   Certificate = '" + Functions.NoQuote(Certificate.Certificate) + "' , ");
                    SQL.AppendLine("   Password = '" + Functions.NoQuote(Certificate.Password) + "' , ");
                    SQL.AppendLine("   Active = 1 , ");
                    SQL.AppendLine("   DateUpdate = GetDate() ");
                    SQL.AppendLine(" Where Certificates.CertificateId =  (Select Top 1 " );
                    SQL.AppendLine("                                                 IsNull(CertificateId, 0) As CertificateId ");
                    SQL.AppendLine("                                        From     Certificates ");
                    SQL.AppendLine("                                        Where    Active = 1 ");
                    SQL.AppendLine("                                                 And CompanyId = " + Certificate.CompanyId);
                    SQL.AppendLine("                                      )  ");

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
                    SQL.AppendLine(" ( " + Certificate.CompanyId + ", ");
                    SQL.AppendLine("  '" + Functions.NoQuote(Certificate.Certificate) + "',");
                    SQL.AppendLine("  '" + Functions.NoQuote(Certificate.Password) + "',");
                    SQL.AppendLine("  1, ");
                    SQL.AppendLine("  GetDate(), ");
                    SQL.AppendLine("  GetDate() ");
                    SQL.AppendLine(" ) ");

                    Certificate.CertificateId = Functions.Conn.Insert(SQL.ToString());
                }           
                
                if (Certificate.CertificateId > 0)
                {
                    return true;
                }

                throw new InternalProgramException("Não foi possivel cadastrar o certificado!");
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
                throw new InternalProgramException("Informe a empresa!");
            }

            if (new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company,Certificate.CompanyId).CompanyId <= 0)
            {
                throw new InternalProgramException("A empresa informada não está cadastrada.");
            }

            if (String.IsNullOrEmpty(Certificate.Certificate))
            {
                throw new InternalProgramException("Informe o certificado!");
            }

            if (string.IsNullOrEmpty(Certificate.Password))
            {
                throw new InternalProgramException("Informe a senha do certificado!");
            } 
            
            if (!Functions.InstallCertOnServer(Certificate.Certificate,Certificate.Password))
            {
                throw new InternalProgramException("Não foi possivel instalar o certificado digital no servidor.");
            }
        }
    }
}
