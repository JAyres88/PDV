using BLL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormCProduto : Form
    {
        ProdutoBLL produto = new ProdutoBLL();

        public FormCProduto()
        {
            InitializeComponent();
        }

        private void tsbSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCProduto_Load(object sender, EventArgs e)
        {
            cboCategoria.DataSource = produto.BuscaCategorias();
            cboCategoria.DisplayMember = "Descricao";
            var umProduto = produto.BuscaProduto(AppStatic.FormProdutoId);
            if (umProduto.Rows.Count > 0)
            {
                DataRow prod = umProduto.Rows[0];
                txtProduto.Text = prod["Item"].ToString();
                txtVenda.Text = prod["Nome"].ToString();
                cboCategoria.Text = prod["Categoria"].ToString();
            }
        }
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            if (AppStatic.FormProdutoId == 0)
            {
                ProdutoModel novoProduto = new ProdutoModel();               
                novoProduto.Produto = txtProduto.Text;
                novoProduto.NomeVenda = txtVenda.Text;
                novoProduto.Categoria =cboCategoria.SelectedIndex+1;
                AppStatic.FormProdutoId = produto.novoProduto(novoProduto);
                tstLblProduto.Text = "Produto Cadastrado";
            }
            else
            {
                ProdutoModel produtoOld = new ProdutoModel();
                produtoOld.Id = AppStatic.FormProdutoId;
                produtoOld.Produto = txtProduto.Text;
                produtoOld.NomeVenda = txtVenda.Text;
                produtoOld.Categoria = cboCategoria.SelectedIndex+1;
                tstLblProduto.Text = produto.atualizaProduto(produtoOld);
            }               
        }
    }
}
