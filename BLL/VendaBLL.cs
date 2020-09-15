using DAO;
using Model;
using System;
using System.Data;

namespace BLL
{
   public class VendaBLL
    {        
        public int realizaVenda(VendaModel venda)
        {
            VendaDAO vendaDAO = new VendaDAO();
            return vendaDAO.realizaVendaCab(venda);                   
        }

        public int atualizaVendaDetalhe(VendaModel vendaAux)
        {
            VendaDAO vendaDAO = new VendaDAO();
            return vendaDAO.atualizaVendaDetalhe(vendaAux);
        }

        public int realizaVendaDetalhe(VendaModel venda)
        {
            VendaDAO vendaDAO = new VendaDAO();
            return vendaDAO.realizaVendaDetalhe(venda);
        }
        public DataTable listaVenda()
        {
            VendaDAO vendaDAO = new VendaDAO();
            return vendaDAO.listaVendas();
        }

        public DataTable buscaCabelhoVenda(VendaModel venda)
        {
            VendaDAO vendaDAO = new VendaDAO();
            return vendaDAO.buscaCabecalhoVenda(venda);
        }

        public DataTable buscaFinanceiroVenda(VendaModel venda1)
        {
            VendaDAO vendaDAO = new VendaDAO();
            return vendaDAO.buscaFinanceiroVenda(venda1);
        }

        public DataTable buscaItensVenda(VendaModel venda1)
        {
            VendaDAO vendaDAO = new VendaDAO();
            return vendaDAO.buscaItensVenda(venda1);
        }

        public void cancelaVenda(VendaModel vendaAux)
        {
            VendaDAO vendaDAO = new VendaDAO();
             vendaDAO.cancelaVenda(vendaAux);
        }

        public void excluiItensOrcamento(VendaModel vendaAux)
        {
            VendaDAO vendaDAO = new VendaDAO();
            vendaDAO.excluiItensOrcamento(vendaAux);
        }
        public void excluiOrcamentoCab(VendaModel vendaAux)
        {
            VendaDAO vendaDAO = new VendaDAO();
            vendaDAO.excluiOrcamentoCab(vendaAux);
        }
    }
}
