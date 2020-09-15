using DAO;
using Model;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace BLL
{
   public class PessoaBLL
    {
        public DataTable listaTipoPessoa()
        {
            PessoaDAO pessoa = new PessoaDAO();
            return pessoa.listaTipoPessoa();
        }

        public DataTable ListaPessoas()
        {
            PessoaDAO pessoa = new PessoaDAO();
             return pessoa.ListaPessoas() ; 
        }     
        public int AdicionarPessoa(PessoaModel pessoa)
        {
            PessoaDAO pessoaDao = new PessoaDAO();
            return pessoaDao.AdicionarPessoa(pessoa);
        }
        public int AtualizaPessoa(PessoaModel pessoa)
        {
            PessoaDAO pessoaDao = new PessoaDAO();
            return pessoaDao.AtualizaPessoa(pessoa);
        }
        public DataTable FiltraPessoa(PessoaModel pessoa)
        {
            PessoaDAO pessoaDao = new PessoaDAO();
            return pessoaDao.FiltraPessoa(pessoa);
        }
        public DataTable FiltraPessoaVenda()
        {
            PessoaDAO pessoaDao = new PessoaDAO();
          return  pessoaDao.FiltaPessoaVenda();
        }

        public DataTable FiltraUmaPessoa(PessoaModel pessoa)
        {
            PessoaDAO pessoaDao = new PessoaDAO();
            return pessoaDao.FiltraUmaPessoa(pessoa);
        }
    }
}
