using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAO
{
    public class SaldoDAO:Conexao
    {
        
        public DataTable BuscaSaldos()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_saldo_seleciona_saldo";
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fecharConexao();
                Con.Dispose();
            }
        }
    }
}
