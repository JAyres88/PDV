using DAO;
using Model;
using System.Data;

namespace BLL
{
     public class FinanceiroBLL
    {
        public int gravaFinanceiro(VendaModel venda, CaixaCalculoModel caixa)
        {
            FinanceiroDAO financeiroDAO = new FinanceiroDAO();
            return financeiroDAO.gravaFinanceiro(venda, caixa);
        }

        public DataTable listaFinanceiroPessoa(PessoaModel pessoa)
        {
            FinanceiroDAO financeiroDAO = new FinanceiroDAO();
            return financeiroDAO.listaFinanceiroPessoa(pessoa);
        }
    }
}
