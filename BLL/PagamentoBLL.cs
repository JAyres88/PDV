using DAO;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class PagamentoBLL
    {
        public double AdicionaPagamento(PagamentoModel pagamento)
        {
            double totalFalta;
            totalFalta = pagamento.TotalInicial-pagamento.ValorPagamento;            
            return totalFalta;
        }    
        public double RemovePagamento(PagamentoModel pagamento)
        {
            double totalFalta;
            totalFalta = pagamento.TotalInicial+pagamento.ValorPagamento;
            return totalFalta;
        }       
                
        public string GravaPagamento(VendaModel vendaAux,List<PagamentoModel> pagamentoAux)
        {
            PagamentoDAO pagamento = new PagamentoDAO();
            return pagamento.gravaPagamentos(pagamentoAux, vendaAux);            
        }       
    }
 }



