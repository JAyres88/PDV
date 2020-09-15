using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        /***********************Esconde o ToolStrip e Grid *************************/
        private void FormMain_Load(object sender, EventArgs e)
        {            
            toolStripPrincipal.Visible = false;
            advDgvMain.Visible = false;            
        }

        /**********************************************************************
         * 
         * 
         * 
         * 
         *                         Lógica de Cliques Menu.
         *                         
         * 
         * 
         * 
         *------------------------------------------------------------------------/
         
        /*******************Click no Menu de Pessoas***********************/
        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripPrincipal.Visible = true;
            advDgvMain.Visible = true;
            pictureBox1.Visible = false;
            PessoaBLL pessoasBLL = new PessoaBLL();
            advDgvMain.DataSource = pessoasBLL.ListaPessoas();
            AppStatic.MenuClicado = "MnPessoas";
        }

        /*********************** Menu Produtos ***************************/
        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripPrincipal.Visible = true;
            advDgvMain.Visible = true;
            pictureBox1.Visible = false;
            ProdutoBLL produtoBLL = new ProdutoBLL();
            advDgvMain.DataSource = produtoBLL.BuscaProdutos();
            AppStatic.MenuClicado = "MnProduto";
        }

        /**********************Click no Menu de Entrada ***********************/
        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripPrincipal.Visible = true;
            advDgvMain.Visible = true;
            pictureBox1.Visible = false;
            DocEntradaBLL docEntradaBLL = new DocEntradaBLL();
            advDgvMain.DataSource = docEntradaBLL.DocEntrada();
            AppStatic.MenuClicado = "MnDocEntrada";
        }

        /**********************Click no Menu de Saida***********************/
        private void saidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripPrincipal.Visible = true;
            advDgvMain.Visible = true;
            pictureBox1.Visible = false;
            DocSaidaBLL docSaidaBLL = new DocSaidaBLL();
            advDgvMain.DataSource = docSaidaBLL.DocSaida();
            AppStatic.MenuClicado = "MnDocSaida";
        }

        /**********************Click no Menu de Saldo ***********************/
        private void saldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripPrincipal.Visible = true;
            advDgvMain.Visible = true;
            pictureBox1.Visible = false;
            SaldoBLL saldoBLL = new SaldoBLL();
            advDgvMain.DataSource = saldoBLL.BuscaSaldos();
            AppStatic.MenuClicado = "MnSaldo";
        }
         private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPDVVenda pdv = new FormPDVVenda();
            pdv.Show();
 
        }
        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripPrincipal.Visible = true;
            advDgvMain.Visible = true;
            pictureBox1.Visible = false;            
            
            AppStatic.MenuClicado = "MnPessoas";
        }
        /*********************************************************************
         * 
         * 
         * 
         * 
         *                          Click Duplo no GridView 
         *             
         * 
         * 
         * 
         ***********************************************************************/


        private void advDgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormCPessoa formPessoa = new FormCPessoa();
            FormCProduto formProduto = new FormCProduto();
            FormCDocEntrada formEntrada = new FormCDocEntrada();
            FormCDocSaida formSaida = new FormCDocSaida();
            FormCSaldo saldoForm = new FormCSaldo();

            if (AppStatic.MenuClicado == "MnPessoas")
            {               
                AppStatic.FormPessoaId = Convert.ToInt32(advDgvMain.CurrentRow.Cells[0].Value.ToString());           
                formPessoa.Show();
            }
            else if (AppStatic.MenuClicado == "MnProduto")
            {              
                AppStatic.FormProdutoId = Convert.ToInt32(advDgvMain.CurrentRow.Cells[0].Value.ToString());  
                formProduto.Show();
            }
            else if (AppStatic.MenuClicado == "MnDocEntrada")
            {              
                AppStatic.FormDocEntradaId = Convert.ToInt32(advDgvMain.CurrentRow.Cells[0].Value.ToString());
                formEntrada.txtNome.Text = advDgvMain.CurrentRow.Cells[1].Value.ToString();
                /******************checa se documento gera financeiro********************/
                if (Convert.ToInt32(advDgvMain.CurrentRow.Cells[2].Value) == 1)
                {
                    formEntrada.chkGeraFinanceiro.Checked = true;
                }
                else { formEntrada.chkGeraFinanceiro.Checked = false; }
                /***************checa se documento movimenta estoque**********************/
                if (Convert.ToInt32(advDgvMain.CurrentRow.Cells[3].Value) == 1)
                {
                    formEntrada.chkMovimentaEstoque.Checked = true;
                }
                else { formEntrada.chkMovimentaEstoque.Checked = false; }
                /****************verifica se gera vale *****************************/
                if (Convert.ToInt32(advDgvMain.CurrentRow.Cells[4].Value) == 1)
                {
                    formEntrada.chkPermiteVale.Checked = true;
                }
                else { formEntrada.chkPermiteVale.Checked = false; }

                formEntrada.Show();
            }
            else if (AppStatic.MenuClicado == "MnDocSaida")
            {
                
                AppStatic.FormDocSaidaId = Convert.ToInt32(advDgvMain.CurrentRow.Cells[0].Value.ToString());
                /*****************************************checa se documento gera financeiro********************/
                if (Convert.ToInt32(advDgvMain.CurrentRow.Cells[2].Value) == 1)
                {
                    formSaida.chkGeraFinanceiro.Checked = true;
                }
                else { formSaida.chkGeraFinanceiro.Checked = false; }
                /***************************checa se documento movimenta estoque**********************/
                if (Convert.ToInt32(advDgvMain.CurrentRow.Cells[3].Value) == 1)
                {
                    formSaida.chkMovimentaEstoque.Checked = true;
                }
                else { formSaida.chkMovimentaEstoque.Checked = false; }
                /******************************************verifica se gera vale *****************************/
                if (Convert.ToInt32(advDgvMain.CurrentRow.Cells[4].Value) == 1)
                {
                    formSaida.chkPermiteVale.Checked = true;
                }
                else { formSaida.chkPermiteVale.Checked = false; }
                formSaida.Show();
            }
            else if (AppStatic.MenuClicado == "MnSaldo")
            {                
                saldoForm.txtSaldo.Text = advDgvMain.CurrentRow.Cells[1].Value.ToString();
                saldoForm.Show();
            }
        }
        /*********************************************************************
         * 
         * 
         * 
         * 
         *                  Carrega Conteúdo dos GridView. 
         * 
         * 
         *         
         *
         **********************************************************************/
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (AppStatic.MenuClicado == "MnPessoas")
            {
               PessoaBLL pessoaBLL = new PessoaBLL();
               advDgvMain.DataSource = null;
               advDgvMain.DataSource = pessoaBLL.ListaPessoas();
            }               
            else if (AppStatic.MenuClicado == "MnProduto")
            {
                ProdutoBLL produtoBLL = new ProdutoBLL();
                advDgvMain.DataSource = null;
                advDgvMain.DataSource = produtoBLL.BuscaProdutos();
            }
            else if (AppStatic.MenuClicado == "MnDocEntrada")
            {
                DocEntradaBLL docEntrada = new DocEntradaBLL();
                advDgvMain.DataSource = null;
                advDgvMain.DataSource = docEntrada.DocEntrada();
            }
            else if (AppStatic.MenuClicado == "MnDocSaida")
            {
                DocSaidaBLL docSaida = new DocSaidaBLL();
                advDgvMain.DataSource = null;
                advDgvMain.DataSource = docSaida.DocSaida();
            }
            else if (AppStatic.MenuClicado == "MnSaldo")
            {
                SaldoBLL saldo = new SaldoBLL();
                advDgvMain.DataSource = null;
                advDgvMain.DataSource = saldo.BuscaSaldos();
            }
        }
        /*********************************************************************
         * 
         * 
         * 
         *                          Abre o Form Respectivo
         * 
         * 
         * 
         ********************************************************************/
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AppStatic.FormPessoaId = 0;
            AppStatic.FormProdutoId = 0;
            AppStatic.FormPessoaEnderecoId = 0;

            if (AppStatic.MenuClicado == "MnPessoas")
            {
                FormCPessoa formPessoa = new FormCPessoa();                
                formPessoa.Show();
            }                  
            else if (AppStatic.MenuClicado == "MnProduto")
            {
                AppStatic.FormProdutoId = 0;
                FormCProduto formProduto = new FormCProduto();
                formProduto.Show();
                
            }
            else if (AppStatic.MenuClicado == "MnDocEntrada")
            {
                FormCDocEntrada formEntrada = new FormCDocEntrada();  
                formEntrada.Show();
            }
            else if (AppStatic.MenuClicado == "MnDocSaida")
            {
                FormCDocSaida formSaida = new FormCDocSaida();             
                formSaida.Show();
            }
            else if (AppStatic.MenuClicado == "MnSaldo")
            {
                FormCSaldo saldoForm = new FormCSaldo();              
                saldoForm.Show();
            }
        }
        /*************************  this . Close  ****************************/
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPDVCompra formCompra = new FormPDVCompra();
            formCompra.Show();
        }
    }
}
