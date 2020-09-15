using Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace DAO
{
   public class ProdutoDAO : Conexao
    {
        public DataTable BuscaProdutos()
        {          
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    DataTable dt = new DataTable();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = "sp_produto_seleciona_produtos";
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

        public int novoProduto(ProdutoModel novoProduto)
        {
           
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_produto_novo_produto", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("produto", novoProduto.Produto);
                cmd.Parameters.AddWithValue("nomeVenda", novoProduto.NomeVenda);
                cmd.Parameters.AddWithValue("idCategoria", novoProduto.Categoria);
                cmd.Parameters.Add(new MySqlParameter("msg", MySqlDbType.Int32));
                cmd.Parameters["msg"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
               
                return Convert.ToInt32(cmd.Parameters["msg"].Value);
            }
            catch (MySqlException ex)            
            {
                return ex.ErrorCode;           
            }
            finally
            {
                fecharConexao();
            }
        }

        public string atualizaProduto(ProdutoModel produtoOld)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_produto_atualiza_produto", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", produtoOld.Id);
                cmd.Parameters.AddWithValue("produto", produtoOld.Produto);
                cmd.Parameters.AddWithValue("nomeVenda", produtoOld.NomeVenda);
                cmd.Parameters.AddWithValue("idCategoria", produtoOld.Categoria);
                cmd.Parameters.Add(new MySqlParameter("msg", MySqlDbType.VarChar));
                cmd.Parameters["msg"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                /*
                   * 
                   * Manter retorno como INT para que o parâmetro inteiro possa ser passado 
                   * para a consulta de endereço.
                   * 
                */
                return cmd.Parameters["msg"].Value.ToString();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                fecharConexao();
            }
        }

        public DataTable BuscaProduto(int id)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_produto_seleciona_produto";
                cmd.Parameters.AddWithValue("id", id);
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

        public DataTable BuscaCategorias()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_categoria_produto_seleciona_categorias";
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

        public DataTable BuscaProdutosComSaldo()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_produto_seleciona_produtos_com_saldo";
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
