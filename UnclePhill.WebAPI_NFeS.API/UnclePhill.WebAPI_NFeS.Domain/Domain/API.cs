using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Domain.Domain
{
    public static class API
    {
        public static string EnviarSerra(string CPF, string Password, int CodDistrict, string NFs)
        {
            return new NFeS.API.Serra.Entrada.WSEntradaClient().nfdEntrada(
                    CPF,
                    Password,
                    CodDistrict,
                    NFs);
        }

        public static string EnviarCariacica(string CPF, string Password, int CodDistrict, string NFs)
        {
            return new NFeS.API.Serra.Entrada.WSEntradaClient().nfdEntrada(
                    CPF,
                    Password,
                    CodDistrict,
                    NFs);
        }
    }
}
