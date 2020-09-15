using System;
using System.Data;
using DAO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DocSaidaDAO: Conexao
    {
        public DataTable DtDocSaida()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_documento_seleciona_docSaida";
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                fecharConexao();
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
