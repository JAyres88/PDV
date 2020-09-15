using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace DAO
{
    public class DocEntradaDAO:Conexao
    {
        public DataTable DtDocEntrada()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_documento_seleciona_docEntrada";
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
            }
        }
    }
}
