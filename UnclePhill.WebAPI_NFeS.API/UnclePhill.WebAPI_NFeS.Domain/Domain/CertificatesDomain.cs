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
                    return true;
                }

                throw new Exception("Não foi possivel cadastrar o certificado!");
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        private bool InstallCertOnServer(Certificates Certificate)
        {
            try
            {
                //Deserealizando:
                byte[] bCertificate = new WebClient().DownloadData(Certificate.Certificate);
                MemoryStream mStream = new MemoryStream();                
                mStream.Write(bCertificate,0,bCertificate.Length);
                mStream.Seek(0, SeekOrigin.Begin);
                X509Certificate2 Cert = (X509Certificate2)new BinaryFormatter().Deserialize(mStream);
                
                //Instalando certificado;
                X509Store Store = new X509Store(StoreName.My,StoreLocation.CurrentUser);
                Store.Open(OpenFlags.ReadWrite);
                Store.Add(Cert);
                Store.Close();
                return true;
            }
            catch (Exception ex)
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
            
            if (!InstallCertOnServer(Certificate))
            {
                throw new Exception("Não foi possivel instalar o certificado digital no servidor.");
            }
        }
    }
}
