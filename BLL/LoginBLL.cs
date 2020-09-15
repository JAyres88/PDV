using DAO;
using Model;

namespace BLL
{
   public class LoginBLL
    {
        public string Base()
        {
            LoginDAO login = new LoginDAO();
            return login.Base();            
        }

        public int AuthUsuario()
        {
            LoginDAO login = new LoginDAO();
            return login.AuthUsuario();
        }
    }
}
