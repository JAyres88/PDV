using Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAO
{
    public class FinanceiroDAO:Conexao
    {
        MySqlDataAdapter da = new MySqlDataAdapter();
        public int gravaFinanceiro(VendaModel venda, CaixaCalculoModel caixa)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_financeiro_novo_financeiro", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_regcabecalho", venda.Idreg_cabecalho);
                cmd.Parameters.AddWithValue("valor", venda.TotalVenda);
                cmd.Parameters.AddWithValue("usuario", AppStatic.Nome);
                cmd.Parameters.AddWithValue("descontoPercent", caixa.DescontoPercent);
                cmd.Parameters.AddWithValue("descontoUnit", caixa.DescontoUnitario);
                cmd.Parameters.AddWithValue("acrescimo", caixa.PdvAcrescimo);
                cmd.Parameters.Add(new MySqlParameter("id", MySqlDbType.Int32));
                cmd.Parameters["id"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["id"].Value);

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                fecharConexao();
            }
        }

        public DataTable listaFinanceiroPessoa(PessoaModel pessoa)
        {
            try
            {
                abrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_financeiro_seleciona_financeiroPessoa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", pessoa.Id);
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
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
