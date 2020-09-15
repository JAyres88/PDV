using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class AplicacaoStatic
    {
         static DateTime horarioSistema;
         static string nomeSistema;
         static string baseDeDados;

        static AplicacaoStatic()
        {
            horarioSistema = DateTime.Now;
        }
    }
}
