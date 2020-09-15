using MySql.Data.MySqlClient;
using System;
using System.Data;
using Model;


namespace DAO
{
    public class EnderecoDAO : Conexao
    {
        MySqlDataAdapter da = new MySqlDataAdapter();
        public DataTable DtEstado()
        {            
            try
            {             
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_endereco_seleciona_estados";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable DtCidadePessoa(PessoaModel pessoa)
        {       
            try
            {             
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_endereco_seleciona_cidade";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("uf", pessoa.Endereco.IdEstado);
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

            
        /***************************DAO DE ENDEREÇO PESSOA**********************/
        public DataTable DtEnderecoPessoa(PessoaModel pessoa)
        {           
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_endereco_seleciona_endereco";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idpessoa", pessoa.Id);
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

        public string NovoEndereco(PessoaModel pessoa)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_endereco_novo_endereco",Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idpessoa", pessoa.Id);
                cmd.Parameters.AddWithValue("tipo", pessoa.Endereco.Tipo);              
                cmd.Parameters.AddWithValue("rua", pessoa.Endereco.Rua);
                cmd.Parameters.AddWithValue("bairro", pessoa.Endereco.Bairro);
                cmd.Parameters.AddWithValue("obs", pessoa.Endereco.Obs);
                cmd.Parameters.AddWithValue("cep", pessoa.Endereco.Cep);
                cmd.Parameters.AddWithValue("idcidade", pessoa.Endereco.IdCidade);
                cmd.Parameters.AddWithValue("usuario", AppStatic.Nome);
                cmd.Parameters.Add(new MySqlParameter("msg", MySqlDbType.VarChar));
                cmd.Parameters["msg"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return cmd.Parameters["msg"].Value.ToString();
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

        public int AtualizaEndereco(PessoaModel pessoa)
        {           
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_endereco_atualiza_endereco",Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idpessoa", pessoa.Id);
                cmd.Parameters.AddWithValue("idendereco", pessoa.Endereco.IdEndereco);
                cmd.Parameters.AddWithValue("tipo", pessoa.Endereco.Tipo);           
                cmd.Parameters.AddWithValue("rua", pessoa.Endereco.Rua);
                cmd.Parameters.AddWithValue("bairro", pessoa.Endereco.Bairro);
                cmd.Parameters.AddWithValue("obs", pessoa.Endereco.Obs);
                cmd.Parameters.AddWithValue("idestado", pessoa.Endereco.IdEstado);
                cmd.Parameters.AddWithValue("idcidade", pessoa.Endereco.IdCidade);
                cmd.Parameters.AddWithValue("cep", pessoa.Endereco.Cep);
                cmd.Parameters.AddWithValue("usuario", AppStatic.Nome);
                return cmd.ExecuteNonQuery();
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

        public void ExcluiEnderecoPessoa(PessoaModel pessoa)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_endereco_exclui_endereco", Con);
                cmd.CommandType = CommandType.StoredProcedure;              
                cmd.Parameters.AddWithValue("idpessoa", pessoa.Endereco.IdEndereco);
                cmd.Parameters.AddWithValue("idcliente", pessoa.Id);             
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
    }
}
