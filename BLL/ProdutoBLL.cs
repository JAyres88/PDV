using DAO;
using Model;
using System;
using System.Data;


namespace BLL
{
    public class ProdutoBLL
    {
        public DataTable BuscaProdutos()
        {
            ProdutoDAO produto = new ProdutoDAO();
            return produto.BuscaProdutos();
        }
        public DataTable BuscaProdutosComSaldo()
        {
            ProdutoDAO produto = new ProdutoDAO();
            return produto.BuscaProdutosComSaldo();
        }

        public DataTable BuscaCategorias()
        {
            ProdutoDAO produto = new ProdutoDAO();
            return produto.BuscaCategorias();
        }

        public DataTable BuscaProduto(int id)
        {
            ProdutoDAO produto = new ProdutoDAO();
            return produto.BuscaProduto(id);
        }

        public int novoProduto(ProdutoModel novoProduto)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            return produtoDAO.novoProduto(novoProduto);
        }

        public string atualizaProduto(ProdutoModel produtoOld)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            return produtoDAO.atualizaProduto(produtoOld);
        }
    }
}
