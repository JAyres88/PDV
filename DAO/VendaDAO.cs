using Model;
using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAO
{
   public  class VendaDAO : Conexao
    {
        public int realizaVendaCab(VendaModel Venda)
        {            
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_regcab_novo", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_iddocumento", Venda.Documento.Id);
                cmd.Parameters.AddWithValue("_pessoa", Venda.Pessoa.Id);              
                cmd.Parameters.AddWithValue("_usuario", AppStatic.Nome);
                /***************************************************************************************************/
                cmd.Parameters.Add(new MySqlParameter("regcab", MySqlDbType.Int32));
                cmd.Parameters["regcab"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.Parameters["regcab"].Value);
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

      

        public DataTable buscaItensVenda(VendaModel venda1)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_venda_seleciona_itensvenda";
                cmd.Parameters.AddWithValue("id", venda1.Idreg_cabecalho);
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

        public void excluiOrcamentoCab(VendaModel vendaAux)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_regcab_exclui", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_idregcabecalho", vendaAux.Idreg_cabecalho);                   
                cmd.ExecuteNonQuery();
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

        public void excluiItensOrcamento(VendaModel vendaAux)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_regdet_exclui", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_idregcabecalho", vendaAux.Idreg_cabecalho);
                cmd.Parameters.AddWithValue("_idproduto", vendaAux.Produto.Id);        
                cmd.ExecuteNonQuery();
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

        public void cancelaVenda(VendaModel vendaAux)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_regdet_inativa_saida", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_idregcabecalho", vendaAux.Idreg_cabecalho);
                cmd.Parameters.AddWithValue("_idproduto", vendaAux.Produto.Id);               
                cmd.ExecuteNonQuery();
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

        public DataTable buscaFinanceiroVenda(VendaModel venda1)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_venda_seleciona_financeirovenda";
                cmd.Parameters.AddWithValue("id", venda1.Idreg_cabecalho);
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

        public int realizaVendaDetalhe(VendaModel Venda)
        {            
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_regdet_novo", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_idregcabecalho", Venda.Idreg_cabecalho);                
                cmd.Parameters.AddWithValue("_idproduto", Venda.Produto.Id);
                cmd.Parameters.AddWithValue("_iddocumento", Venda.Documento.Id);    
                cmd.Parameters.AddWithValue("_quantidade", Venda.Produto.Quantidade);
                cmd.Parameters.AddWithValue("_valor", Venda.Produto.Preco);           
                cmd.Parameters.AddWithValue("_nosso", Venda.Nosso);
                cmd.Parameters.AddWithValue("_reservar", Venda.Reservar);
                cmd.Parameters.AddWithValue("_parceiro", Venda.Parceiro);                    
                cmd.Parameters.AddWithValue("_usuario", AppStatic.Nome);
                /***************************************************************************************************/
                cmd.Parameters.Add(new MySqlParameter("regdetalhe", MySqlDbType.Int32));
                cmd.Parameters["regdetalhe"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();                
              
                return Convert.ToInt32(cmd.Parameters["regdetalhe"].Value);
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

        public int atualizaVendaDetalhe(VendaModel vendaAux)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_regdet_atualiza_saida", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_idregcabecalho", vendaAux.Idreg_cabecalho);
                cmd.Parameters.AddWithValue("_idproduto", vendaAux.Produto.Id);
                cmd.Parameters.AddWithValue("_iddocumento", vendaAux.Documento.Id);
                cmd.Parameters.AddWithValue("_quantidade", vendaAux.Produto.Quantidade);
                cmd.Parameters.AddWithValue("_valor", vendaAux.Produto.Preco);
                cmd.Parameters.AddWithValue("_nosso", vendaAux.Nosso);
                cmd.Parameters.AddWithValue("_reservar", vendaAux.Reservar);
                cmd.Parameters.AddWithValue("_parceiro", vendaAux.Parceiro);
                cmd.Parameters.AddWithValue("_usuario", AppStatic.Nome);       
                cmd.ExecuteNonQuery();
                return 0;
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


        public DataTable listaVendas()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_venda_seleciona_venda";
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

        public DataTable buscaCabecalhoVenda(VendaModel venda)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_venda_seleciona_cabecalhovenda";
                cmd.Parameters.AddWithValue("id", venda.Idreg_cabecalho);
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
