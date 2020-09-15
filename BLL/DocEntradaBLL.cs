using System;
using System.Data;
using DAO;



namespace BLL
{
    public class DocEntradaBLL
    {
        public DataTable DocEntrada()
        {
            

            DocEntradaDAO docEnt = new DocEntradaDAO();
            return docEnt.DtDocEntrada();
        }
    }
}
