using Model;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace DAO
{
    public class LoginDAO : Conexao
    {
      
      
        public string Base()
        {

            MySqlCommand myCommand = new MySqlCommand("select DATABASE()", Con);
            myCommand.Connection.Open();
            MySqlDataReader myReader = myCommand.ExecuteReader();
            try
            {
                while (myReader.Read())
                {
                    return myReader.GetString(0);
                }
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                myReader.Close();
                Con.Close();
            }
            return "Base não Localizada.";
        }

        public int AuthUsuario()
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_sys_auth", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sysusuario", AppStatic.Nome);
                cmd.Parameters.AddWithValue("syssenha", AppStatic.Senha);
                /***************************************************************************************************/
                cmd.Parameters.AddWithValue("sts", MySqlDbType.Int32);
                cmd.Parameters["sts"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["sts"].Value);

            }
            catch (MySqlException ex)
            {
                fecharConexao();
                ex.GetHashCode();
                return ex.GetHashCode(); ;
            }
            finally
            {
                fecharConexao();
                Con.Dispose();
            }
        }
    }
}