using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Domain.Domain
{
    public static class API
    {
        public enum City
        {
            Serra = 0,
            Cariacica = 1
        }
        
        public static string GetActivities(City City, string CPF, string Password, string IM, int CodeCity)
        {
            switch (City)
            {
                case City.Serra:
                    return GetActivitiesSerra(CPF, Password, IM, CodeCity);
                case City.Cariacica:
                    return GetActivitiesCariacica(CPF, Password, IM, CodeCity);
                default:
                    return string.Empty;
            }
        }

        public static string Send(City City, string CPF,string Password, int CodeCity, string Xml)
        {
            switch (City)
            {
                case City.Serra:
                    return SendSerra(CPF,Password, CodeCity,Xml);
                case City.Cariacica:
                    return SendCariacica(CPF,Password,CodeCity,Xml);
                default:
                    return string.Empty;                    
            }
        }

        public static string Receive(City City, string CPF, string Password, string IM, string Xml)
        {
            switch (City)
            {
                case City.Serra:
                    return ReceiveSerra(CPF,Password,IM,Xml);
                case City.Cariacica:
                    return ReceiveCariacica(CPF,Password,IM,Xml);
                default:
                    return string.Empty;
            }
        }

        public static string GetUrl(City City, int CodeCity, int NFNumber, int NumSerie, string IM)
        {
            switch (City)
            {
                case City.Serra:
                    return GetUrlsSerra(CodeCity,NFNumber,NumSerie,IM);
                case City.Cariacica:
                    return GetUrlsCariacica(CodeCity,NFNumber,NumSerie,IM);
                default:
                    return string.Empty;
            }
        }

        #region "##-Serra/ES-##"
        private static string GetActivitiesSerra(string CPF, string Password, string IM, int CodeCity)
        {
            return new NFeS.API.Serra.Entrada.WSEntradaClient().consultarAtividades(
                CPF, 
                Password, 
                IM, 
                CodeCity);
        }

        private static string SendSerra(string CPF, string Password, int CodeCity, string Xml)
        {
            return new NFeS.API.Serra.Entrada.WSEntradaClient().nfdEntrada(
                    CPF,
                    Password,
                    CodeCity,
                    Xml);
        }

        private static string ReceiveSerra(string CPF, string Password, string IM, string Xml)
        {
            return new NFeS.API.Serra.Saida.WSSaidaClient().nfdSaida(
                                    Homologation.CPF,
                                    Homologation.Password,
                                    Homologation.IM,
                                    Xml);
        }

        private static string GetUrlsSerra(int CodeCity, int NFNumber,int NumSerie, string IM)
        {
            return new NFeS.API.Serra.Util.WSUtilClient().urlNfd(
                            CodeCity,
                            NFNumber,
                            NumSerie,
                            IM);
        }
        #endregion

        #region "##-Cariacica-##"
        private static string GetActivitiesCariacica(string CPF, string Password, string IM, int CodeCity)
        {
            return new NFeS.API.Cariacica.Entrada.WSEntradaClient().consultarAtividades(
                CPF,
                Password,
                IM,
                CodeCity);
        }

        private static string SendCariacica(string CPF, string Password, int CodeCity, string Xml)
        {
            return new NFeS.API.Cariacica.Entrada.WSEntradaClient().nfdEntrada(
                    CPF,
                    Password,
                    CodeCity,
                    Xml);
        }
               
        private static string ReceiveCariacica(string CPF, string Password, string IM, string Xml)
        {
            return new NFeS.API.Cariacica.Saida.WSSaidaClient().nfdSaida(
                                    Homologation.CPF,
                                    Homologation.Password,
                                    Homologation.IM,
                                    Xml);
        }

        private static string GetUrlsCariacica(int CodeCity, int NFNumber, int NumSerie, string IM)
        {
            return new NFeS.API.Cariacica.Util.WSUtilClient().urlNfd(
                            CodeCity,
                            NFNumber,
                            NumSerie,
                            IM);
        }
        #endregion
    }
}
