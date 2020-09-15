using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class SaldoBLL
    {
        public DataTable BuscaSaldos()
        {
            SaldoDAO saldoDao = new SaldoDAO();
            return saldoDao.BuscaSaldos();
        }
    }
}
