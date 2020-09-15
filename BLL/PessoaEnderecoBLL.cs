using DAO;
using Model;
using System.Data;


namespace BLL
{
    public class PessoaEnderecoBLL
    {
        
            public DataTable BuscaEstados()
            {
            EnderecoDAO enderecoBusca = new EnderecoDAO();
            return enderecoBusca.DtEstado();
            }
      /************************************ Busca cidade de Pessoa************************************/
            public DataTable BuscaCidadesPessoa(PessoaModel pessoa)
            {
            EnderecoDAO enderecoBusca = new EnderecoDAO();
            return enderecoBusca.DtCidadePessoa(pessoa);
            }     
        /**********************************Métodos Endereços de Pessoa***********************************/
        public DataTable DtEnderecoPessoa(PessoaModel pessoa)
        {
            EnderecoDAO enderecoBusca = new EnderecoDAO();
            return enderecoBusca.DtEnderecoPessoa(pessoa);
         }    
        public string NovoEndereco(PessoaModel pessoa)
        {
            EnderecoDAO endereco = new EnderecoDAO();
            return endereco.NovoEndereco(pessoa);
        }
        public int atualizaEndereco(PessoaModel pessoa)
        {
            EnderecoDAO endereco = new EnderecoDAO();
            return endereco.AtualizaEndereco(pessoa);
        }
        public void ExcluiEnderecoPessoa(PessoaModel pessoa)
        {
            EnderecoDAO dao = new EnderecoDAO();
            dao.ExcluiEnderecoPessoa(pessoa);
        }       
    }    
}
