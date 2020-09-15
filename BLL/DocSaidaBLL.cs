using DAO;

using System.Data;


namespace BLL
{
    public class DocSaidaBLL
    {
        public DataTable DocSaida()
        {
            DocSaidaDAO saidaDAO = new DocSaidaDAO();
            return saidaDAO.DtDocSaida();        
        }
    }
}
