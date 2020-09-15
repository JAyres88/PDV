using Model;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Data;


namespace DAO
{
    public class PessoaDAO:Conexao
    {   
        public DataTable ListaPessoas()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_pessoa_seleciona_pessoa";
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

        public DataTable listaTipoPessoa()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_pessoa_seleciona_tipoPessoa";
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

        public int AdicionarPessoa(PessoaModel pessoa)
        {
            string retorno;
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_pessoa_nova_pessoa", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("tipoPessoa", pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("nascimento", pessoa.Nascimento);
                cmd.Parameters.AddWithValue("complemento", pessoa.Complemento);
                cmd.Parameters.AddWithValue("telefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("celular", pessoa.Celular);
                cmd.Parameters.AddWithValue("email", pessoa.Email);
                cmd.Parameters.AddWithValue("email2", pessoa.Email2);
                cmd.Parameters.AddWithValue("cpf", pessoa.Cpf);
                cmd.Parameters.AddWithValue("cnpj", pessoa.Cnpj);
                cmd.Parameters.AddWithValue("anotacoes", pessoa.Anotacoes);
                cmd.Parameters.AddWithValue("usuario", AppStatic.Nome);
                /***************************************************************************************************/           
                cmd.Parameters.Add(new MySqlParameter("msg", MySqlDbType.Int32));
                cmd.Parameters["msg"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                /*
                   * 
                   * Manter retorno como INT para que o parâmetro inteiro possa ser passado 
                   * para a consulta de endereço.
                   * 
                */
                return Convert.ToInt32(cmd.Parameters["msg"]. Value);

              

            }
            catch (MySqlException ex)
            {                
                retorno = ex.Message;
                return 0;
            }
            finally
            {
                fecharConexao();
            }
        }

        public DataTable FiltraUmaPessoa(PessoaModel pessoa)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_pessoa_filtra_umaPessoa";
                cmd.Parameters.AddWithValue("id", pessoa.Id);
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

        public int AtualizaPessoa(PessoaModel pessoa)
        {                     
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_pessoa_atualiza_pessoa", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idpessoa", pessoa.Id);
                cmd.Parameters.AddWithValue("tipoPessoa", pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("nascimento", pessoa.Nascimento);
                cmd.Parameters.AddWithValue("complemento", pessoa.Complemento);
                cmd.Parameters.AddWithValue("telefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("celular", pessoa.Celular);
                cmd.Parameters.AddWithValue("email", pessoa.Email);
                cmd.Parameters.AddWithValue("email2", pessoa.Email2);
                cmd.Parameters.AddWithValue("cpf", pessoa.Cpf);
                cmd.Parameters.AddWithValue("cnpj", pessoa.Cnpj);       
                cmd.Parameters.AddWithValue("anotacoes", pessoa.Anotacoes);
                cmd.Parameters.AddWithValue("usuario", AppStatic.Nome);             
                return cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {             
                throw  ex;
            }
            finally
            {
                fecharConexao();
            }
        }

        public DataTable FiltraPessoa(PessoaModel pessoa)
        {
            try
            {
                abrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_pessoa_filtra_pessoa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", pessoa.Id);
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
               
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                fecharConexao();
            }
        }
        public DataTable FiltaPessoaVenda()
        {
            try
            {
                abrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = "sp_pessoa_filtra_pessoaVenda";
                cmd.CommandType = CommandType.StoredProcedure;            
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
               
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                fecharConexao();
            }
        }
    }
}
