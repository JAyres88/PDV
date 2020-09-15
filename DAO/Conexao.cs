using MySql.Data.MySqlClient;
using System;

namespace DAO
{
    public class Conexao
    {
         // Dados da conexao  
        static string connString = "Server=localhost;Port=3306;User Id=teu usuario;Password=tua senha;Database=teu banco;"; // adicionar string de conexão do usuário.
        protected MySqlConnection Con = new MySqlConnection(connString); // estabele a conexao
        protected MySqlCommand cmd;

        protected void abrirConexao()
        {
            try
            {
                 Con.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("erro ao abrir conexao" + ex.Message);
                Console.WriteLine(ex);
            }
        }

        protected void fecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Dispose();
            }
        }
    }
}
