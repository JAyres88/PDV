using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormPDVVenda : Form
    {
        DataTable dtItemPedido = new DataTable();
        DataTable dtItemPedido2 = new DataTable();
        DataTable dtItemPedido3 = new DataTable();
        public DataTable dtItemAux = new DataTable();

        VendaModel venda1 = new VendaModel();
        VendaModel venda2 = new VendaModel();
        VendaModel venda3 = new VendaModel();
        VendaModel vendaAux = new VendaModel();

        VendaBLL venda = new VendaBLL();

        CaixaCalculoModel caixa1 = new CaixaCalculoModel();
        CaixaCalculoModel caixa2 = new CaixaCalculoModel();
        CaixaCalculoModel caixa3 = new CaixaCalculoModel();
        CaixaCalculoModel caixaAux = new CaixaCalculoModel();

        CaixaCalculoBLL caixaCalculo = new CaixaCalculoBLL(); 

        PagamentoBLL pagamentoBLL = new PagamentoBLL();
        PessoaBLL pessoaBll = new PessoaBLL();

        PagamentoModel dinheirocx1 = new PagamentoModel(1);
        PagamentoModel debitocx1 = new PagamentoModel(2);
        PagamentoModel creditocx1 = new PagamentoModel(3);
        PagamentoModel chequecx1 = new PagamentoModel(4);
        PagamentoModel valecx1 = new PagamentoModel(5);
        PagamentoModel boletocx1 = new PagamentoModel(6);

        PagamentoModel dinheirocx2 = new PagamentoModel(1);
        PagamentoModel debitocx2 = new PagamentoModel(2);
        PagamentoModel creditocx2 = new PagamentoModel(3);
        PagamentoModel chequecx2 = new PagamentoModel(4);
        PagamentoModel valecx2 = new PagamentoModel(5);
        PagamentoModel boletocx2 = new PagamentoModel(6);

        PagamentoModel dinheirocx3 = new PagamentoModel(1);
        PagamentoModel debitocx3 = new PagamentoModel(2);
        PagamentoModel creditocx3 = new PagamentoModel(3);
        PagamentoModel chequecx3 = new PagamentoModel(4);
        PagamentoModel valecx3 = new PagamentoModel(5);
        PagamentoModel boletocx3 = new PagamentoModel(6);

        PagamentoModel dinheiroAux = new PagamentoModel(1);
        PagamentoModel debitocxAux= new PagamentoModel(2);
        PagamentoModel creditocxAux = new PagamentoModel(3);
        PagamentoModel chequecxAux = new PagamentoModel(4);
        PagamentoModel valecxAux = new PagamentoModel(5);
        PagamentoModel boletocxAux = new PagamentoModel(6);

        BindingSource bs = new BindingSource();

        ProdutoBLL produto = new ProdutoBLL();
        DocSaidaBLL doc = new DocSaidaBLL();

        public FormPDVVenda()
        {
            InitializeComponent();
        }

        private void FormPDVVenda_Load(object sender, EventArgs e)
        {

            txtTotalCx1.Text = Convert.ToString(0);       

            advDgvProdutos.DataSource = produto.BuscaProdutosComSaldo();
            /*********************************************************************** SOURCE DOS COMBOXES **************************************************************************/
            cboDoc.DataSource = doc.DocSaida();
            cboDoc.ValueMember = "Id";
            cboDoc.DisplayMember = "Descricao";
            cboDoc.Enabled = true;
            /***************DEFINIÇÃO CLIENTE PADRÃO TAB1*****************/
            cboClientePdvCx1.DataSource = pessoaBll.FiltraPessoaVenda();
            cboClientePdvCx1.ValueMember = "id";
            cboClientePdvCx1.DisplayMember = "nome";
            cboClientePdvCx1.SelectedValue = -1;        
            cboClientePdvCx1.Enabled = true;
            /**************DEFINIÇÃO CLIENTE PADRAO TAB2******************/
            cboClientePdvCx2.DataSource = pessoaBll.FiltraPessoaVenda();
            cboClientePdvCx2.ValueMember = "id";
            cboClientePdvCx2.DisplayMember = "nome";
            cboClientePdvCx2.SelectedValue = -1;           
            cboClientePdvCx2.Enabled = true;
            /**************DEFINIÇÃO CLIENTE PADRAO TAB3******************/
            cboClientePdvCx3.DataSource = pessoaBll.FiltraPessoaVenda();
            cboClientePdvCx3.ValueMember = "id";
            cboClientePdvCx3.DisplayMember = "nome";
            cboClientePdvCx3.SelectedValue = -1;
            cboClientePdvCx3.Enabled = true;

            /*****************************DEFINIÇÃO DE TIPOS DO DATATABLE 1**********************************/
            dtItemPedido.Columns.Add("Id", typeof(int));
            dtItemPedido.Columns.Add("Item", typeof(string));
            dtItemPedido.Columns.Add("Nome", typeof(string));
            dtItemPedido.Columns.Add("Parceiro", typeof(bool));
            dtItemPedido.Columns.Add("Nosso", typeof(bool));
            dtItemPedido.Columns.Add("Reservar", typeof(bool));
            dtItemPedido.Columns.Add("Obs", typeof(string));
            dtItemPedido.Columns.Add("Qtd", typeof(double));
            dtItemPedido.Columns.Add("Valor", typeof(double));
            dtItemPedido.Columns.Add("Total", typeof(decimal), "(Qtd * Valor)");
            dgvItensCx1.DataSource = dtItemPedido;

            /*****************************DEFINIÇÃO DE TIPOS DO DATATABLE 2********************************/
            dtItemPedido2.Columns.Add("Id", typeof(int));
            dtItemPedido2.Columns.Add("Item", typeof(string));
            dtItemPedido2.Columns.Add("Nome", typeof(string));
            dtItemPedido2.Columns.Add("Parceiro", typeof(bool));
            dtItemPedido2.Columns.Add("Nosso", typeof(bool));
            dtItemPedido2.Columns.Add("Reservar", typeof(bool));
            dtItemPedido2.Columns.Add("Obs", typeof(string));
            dtItemPedido2.Columns.Add("Qtd", typeof(double));
            dtItemPedido2.Columns.Add("Valor", typeof(double));
            dtItemPedido2.Columns.Add("Total", typeof(decimal), "(Valor * Qtd)");
            dgvItensCx2.DataSource = dtItemPedido2;

            /*****************************DEFINIÇÃO DE TIPOS DO DATATABLE 3********************************/
            dtItemPedido3.Columns.Add("Id", typeof(int));
            dtItemPedido3.Columns.Add("Item", typeof(string));
            dtItemPedido3.Columns.Add("Nome", typeof(string));
            dtItemPedido3.Columns.Add("Parceiro", typeof(bool));
            dtItemPedido3.Columns.Add("Nosso", typeof(bool));
            dtItemPedido3.Columns.Add("Reservar", typeof(bool));
            dtItemPedido3.Columns.Add("Obs", typeof(string));
            dtItemPedido3.Columns.Add("Qtd", typeof(double));
            dtItemPedido3.Columns.Add("Valor", typeof(double));
            dtItemPedido3.Columns.Add("Total", typeof(decimal), "(Valor * Qtd)");
            dgvItensCx3.DataSource = dtItemPedido3;

            /*****************************DEFINIÇÃO DE TIPOS DO DATATABLE 4********************************/
            dtItemAux.Columns.Add("Id", typeof(int));
            dtItemAux.Columns.Add("Item", typeof(string));
            dtItemAux.Columns.Add("Nome", typeof(string));
            dtItemAux.Columns.Add("Parceiro", typeof(bool));
            dtItemAux.Columns.Add("Nosso", typeof(bool));
            dtItemAux.Columns.Add("Reservar", typeof(bool));
            dtItemAux.Columns.Add("Obs", typeof(string));
            dtItemAux.Columns.Add("Qtd", typeof(double));
            dtItemAux.Columns.Add("Valor", typeof(double));
            dtItemAux.Columns.Add("Total", typeof(decimal), "(Valor * Qtd)");
            dgvItemAuxVenda.DataSource = dtItemAux;

            /******************************CONFIGURAÇÃO BOTÕES DE FINALIZAÇÃO DE VENDA************/
            btnFinalizaVendaCx1.Enabled = false;
            btnFinalizaVendaCx2.Enabled = false;
            btnFinalizaVendaCx3.Enabled = false;
            btnFinalizaAux.Enabled = false;

            /***************************** CONFIGURAÇÃO DE CAMPOS DO TABCONTROL1  ****************/
            txtAcrescimoCx1.Text = "0";
            txtDescontoPercentCx1.Text = "0%";
            txtDescontoUnitarioCx1.Text = "0";
            txtTrocoCx1.Text = "0";
            txtDinheiroCx1.Text = "0";
            txtDebitoCx1.Text = "0";
            txtCreditoCx1.Text = "0";
            txtValeCx1.Text = "0";
            txtFaltaCx1.Text = "0";
            txtChequeCx1.Text = "0";
            txtBoletoCx1.Text = "0";         
            chkImprimeCarregamentoCx1.Checked = true;
            chkImprimeCupomCx1.Checked = false;
            /***************************CONFIGURAÇÃO DE CAMPOS DO TABCONTROL2 *************/
            txtAcrescimoCx2.Text = "0";
            txtDescontoPercentCx2.Text = "0%";
            txtDescontoUnitarioCx2.Text = "0";
            txtTrocoCx2.Text = "0";
            txtDinheiroCx2.Text = "0";
            txtCartaoDebitoCx2.Text = "0";
            txtCartaoCreditoCx2.Text = "0";
            txtValeCx2.Text = "0";
            txtChequeCx2.Text = "0";
            txtBoletoCx2.Text = "0";
            txtTotalCx2.Text = "0";
            txtFaltaCx2.Text = "0";
            txtTrocoCx2.Text = "0";
            chkImprimeCarregamentoCx2.Checked = true;
            chkImprimeCupomCx2.Checked = false;
            /***************************CONFIGURAÇÃO DE CAMPOS DO TABCONTROL3 *************/
            txtAcrescimoCx3.Text = "0";
            txtDescontoPercentCx3.Text = "0%";
            txtDescontoUnitarioCx3.Text = "0";
            txtTrocoCx3.Text = "0";
            txtDinheiroCx3.Text = "0";
            txtCartaoDebitoCx3.Text = "0";
            txtCartaoCreditoCx3.Text = "0";
            txtValeCx3.Text = "0";
            txtChequeCx3.Text = "0";
            txtBoletoCx3.Text = "0";
            txtTotalCx3.Text = "0";
            txtFaltaCx3.Text = "0";
            txtTrocoCx3.Text = "0";
            chkImprimeCarregamentoCx3.Checked = true;
            chkImprimeCupomCx3.Checked = false;
            /**********************CONFIGURAÇÃO DE CAMPOS DO TABCONTROL 4********************/
            txtAcrescimoAux.Text = "0";
            txtAuxDescontoPercent.Text = "0%";
            txtAuxDescontoUnit.Text = "0";
            txtTrocoAux.Text = "0";
            txtDinheiroAux.Text = "0";
            txtDebitoAux.Text = "0";
            txtCreditoAux.Text = "0";
            txtValeAux.Text = "0";
            txtChequeAux.Text = "0";
            txtBoletoAux.Text = "0";
            txtTotalAux.Text = "0";
            txtFaltaAux.Text = "0";
            txtTrocoAux.Text = "0";
            chkImprimeCarregamentoAux.Checked = true;
            chkImprimeCupomAux.Checked = false;      

            /************************* DEFINIÇÃO DOS DESCONTOS INICIAIS ************************/
            caixa1.DescontoPercent = 0;
            caixa1.DescontoUnitario = 0;
            caixa2.DescontoPercent = 0;
            caixa2.DescontoUnitario = 0;
            caixa3.DescontoPercent = 0;
            caixa3.DescontoPercent = 0;
            caixaAux.DescontoPercent = 0;
            caixaAux.DescontoUnitario = 0; 

            btnFinalizaVendaCx1.MouseHover += btnFinalizaVendaCx1_MouseHover;
            btnExcluiVendaCx1.MouseHover += btnExcluiVendaCx1_MouseHover;
            btnArquivaVendaCx1.MouseHover += btnArquivaVendaCx1_MouseHover;
            btnBuscaPessoaCx1.MouseHover += btnBuscaPessoaCx1_MouseHover;
            btnAddPessoaCx1.MouseHover += btnAddPessoaCx1_MouseHover;

            btnFinalizaVendaCx2.MouseHover += btnFinalizaVendaCx2_MouseHover;
            btnExcluiVendaCx2.MouseHover += btnExcluiVendaCx2_MouseHover;
            btnArquivaVendaCx2.MouseHover += btnArquivaVendaCx2_MouseHover;
            btnBuscaPessoaCx2.MouseHover += btnBuscaPessoaCx2_MouseHover;
            btnAddPessoaCx2.MouseHover += btnAddPessoaCx2_MouseHover;

            btnFinalizaVendaCx3.MouseHover += btnFinalizaVendaCx3_MouseHover;
            btnExcluiVendaCx3.MouseHover += btnExcluiVendaCx3_MouseHover;
            btnArquivaVendaCx3.MouseHover += btnArquivaVendaCx3_MouseHover;
            btnBuscaPessoaCx3.MouseHover += btnBuscaPessoaCx3_MouseHover;
            btnAddPessoaCx3.MouseHover += btnAddPessoaCx3_MouseHover;

            btnFinalizaAux.MouseHover += btnFinalizaAux_MouseHover;
            btnExcluiAux.MouseHover += btnExcluiAux_MouseHover;
            btnReservaAux.MouseHover += btnReservaAux_MouseHover;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /***************************************************  EVENTOS DE BOTÃO DE BUSCA DE CLIENTE    **************************************************/
        private void btnBuscaPessoa_Click(object sender, EventArgs e)
        {
            FormPDVBuscaCliente pdvBusca = new FormPDVBuscaCliente();
            pdvBusca.DialogResult = DialogResult.Ignore;
            pdvBusca.ShowDialog();
            if (pdvBusca.DialogResult == DialogResult.OK)
            {
                cboClientePdvCx1.SelectedValue = AppStatic.FormPdvBuscaCliente;  /*objeto statico responsável por transportar o id de um form pro outro.*/
            }
            else if (pdvBusca.DialogResult == DialogResult.Cancel)
            {
                cboClientePdvCx1.SelectedValue = AppStatic.FormPdvBuscaCliente;
                pdvBusca.Close();
            }
        }

        private void btnBuscaPessoaCx2_Click(object sender, EventArgs e)
        {
            FormPDVBuscaCliente pdvBusca = new FormPDVBuscaCliente();
            pdvBusca.DialogResult = DialogResult.Ignore;
            pdvBusca.ShowDialog(); 

            if (pdvBusca.DialogResult == DialogResult.OK)
            {
                cboClientePdvCx2.SelectedValue = AppStatic.FormPdvBuscaCliente;  /*objeto statico responsável por transportar o id de um form pro outro.*/
            }
            else if (pdvBusca.DialogResult == DialogResult.Cancel)
            {
                cboClientePdvCx2.SelectedValue = AppStatic.FormPdvBuscaCliente;
                pdvBusca.Close();
            }
        }
        private void btnBuscaPessoaCx3_Click(object sender, EventArgs e)
        {
            FormPDVBuscaCliente pdvBusca = new FormPDVBuscaCliente();
            pdvBusca.DialogResult = DialogResult.Ignore;
            pdvBusca.ShowDialog();
            if (pdvBusca.DialogResult == DialogResult.OK)
            {
                cboClientePdvCx3.SelectedValue = AppStatic.FormPdvBuscaCliente;
                cboClientePdvCx3.SelectedValue = AppStatic.FormPdvBuscaCliente;  /*objeto statico responsável por transportar o id de um form pro outro.*/
            }
            else if (pdvBusca.DialogResult == DialogResult.Cancel)
            {
                pdvBusca.Close();
            }
        }

        /******************************************************* EVENTOS BOTÃO ADD *****************************************************/
        private void btnAddPessoa_Click(object sender, EventArgs e)
        {
            FormCPessoa formPessoa1 = new FormCPessoa();
            formPessoa1.DialogResult = DialogResult.Ignore;
            formPessoa1.ShowDialog();
            if (formPessoa1.DialogResult == DialogResult.OK)
            {
                cboClientePdvCx1.DataSource = pessoaBll.ListaPessoas();
                cboClientePdvCx1.Update();
            }
        }
        private void btnAddPessoaCx2_Click(object sender, EventArgs e)
        {
            FormCPessoa formPessoa2 = new FormCPessoa();
            formPessoa2.DialogResult = DialogResult.Ignore;
            formPessoa2.ShowDialog();
            if (formPessoa2.DialogResult == DialogResult.OK)
            {
                cboClientePdvCx2.DataSource = pessoaBll.ListaPessoas();
                cboClientePdvCx2.Update();
            }
        }
        private void btnAddPessoaCx3_Click(object sender, EventArgs e)
        {
            FormCPessoa formPessoa3 = new FormCPessoa();
            formPessoa3.DialogResult = DialogResult.Ignore;
            formPessoa3.ShowDialog();
            if (formPessoa3.DialogResult == DialogResult.OK)
            {
                cboClientePdvCx3.DataSource = pessoaBll.ListaPessoas();
                cboClientePdvCx3.Update();
            }
        }

        /***************************************** LÓGICA DE ADIÇÃO DE PRODUTO NO GRID  *************************************/

        private void advDgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab.Name == "tabPage1")
            {
                FormPDVQtd formQtd = new FormPDVQtd();
                formQtd.DialogResult = DialogResult.Ignore;
                formQtd.ShowDialog();

                string nome = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
                string apelido = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();
                double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);

                if (formQtd.DialogResult == DialogResult.OK)
                {
                    int qtd = AppStatic.FormPdvAddQtdProduto;
                    dtItemPedido.Rows.Add(nome, apelido, "", true, true, false, "", qtd, valor, valor * qtd);
                    dgvItensCx1.Refresh();
                }
                else if (formQtd.DialogResult == DialogResult.Cancel)
                {
                    formQtd.Close();
                }
            }
            else if (tabControl2.SelectedTab.Name == "tabPage2")
            {
                FormPDVQtd formQtd = new FormPDVQtd();
                formQtd.DialogResult = DialogResult.Ignore;
                formQtd.ShowDialog();

                string id = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
                string nome = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();
                double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);

                if (formQtd.DialogResult == DialogResult.OK)
                {
                    int qtd = AppStatic.FormPdvAddQtdProduto;
                    dtItemPedido2.Rows.Add(id, nome, "", true, true, false, "", qtd, valor, valor * qtd);
                    dgvItensCx2.Refresh();
                }
                else if (formQtd.DialogResult == DialogResult.Cancel)
                {
                    formQtd.Close();
                }
            }
            else if (tabControl2.SelectedTab.Name == "tabPage3")
            {
                FormPDVQtd formQtd = new FormPDVQtd();
                formQtd.DialogResult = DialogResult.Ignore;
                formQtd.ShowDialog();
                string nome = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
                string apelido = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();
                double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);

                if (formQtd.DialogResult == DialogResult.OK)
                {
                    double qtd = Convert.ToDouble(formQtd.txtQtdProduto.Text);
                    dtItemPedido3.Rows.Add(nome, apelido, "", true, true, false, "", qtd, valor, valor * qtd);
                    dgvItensCx3.Refresh();
                }
                else if (formQtd.DialogResult == DialogResult.Cancel)
                {
                    formQtd.Close();
                }
            }
            else if (tabControl2.SelectedTab.Name == "tabPage4")
            {
                FormPDVQtd formQtd = new FormPDVQtd();
                formQtd.DialogResult = DialogResult.Ignore;
                formQtd.ShowDialog();
                string nome = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
                string apelido = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();
                double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);      
                 
                if (formQtd.DialogResult == DialogResult.OK)
                {                   
                   double qtd = Convert.ToDouble(formQtd.txtQtdProduto.Text);
                   dtItemAux.Rows.Add(nome, apelido, "", 1,1, 0, "", qtd, valor, valor * qtd);               
                   dgvItemAuxVenda.Refresh();           
                }
                else if (formQtd.DialogResult == DialogResult.Cancel)
                {
                    formQtd.Close();
                }
            }         
        }
        /***********************************************************************  EXCLUSÃO / LIMPEZA DE CAMPOS   *************************************************************************************/
        private void btnExcluiVendaCx1_Click(object sender, EventArgs e)
        {
            for (int i = dtItemPedido.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtItemPedido.Rows[i];
                dr.Delete();
            }
            txtAcrescimoCx1.Text = "0";
            txtDescontoPercentCx1.Text = "0%";
            txtDescontoUnitarioCx1.Text = "0";
            txtTrocoCx1.Text = "0";
            txtDinheiroCx1.Text = "0";
            txtDebitoCx1.Text = "0";
            txtCreditoCx1.Text = "0";
            txtValeCx1.Text = "0";
            txtFaltaCx1.Text = "0";
            txtChequeCx1.Text = "0";
            txtBoletoCx1.Text = "0";
            cboClientePdvCx1.Text = "";
            tabControl2.TabPages[0].Text = "Caixa 1";
        }
        private void btnExcluiVendaCx2_Click(object sender, EventArgs e)
        {
            for (int i = dtItemPedido2.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtItemPedido2.Rows[i];
                dr.Delete();
            }
            txtAcrescimoCx2.Text = "0";
            txtDescontoPercentCx2.Text = "0%";
            txtDescontoUnitarioCx2.Text = "0";
            txtTrocoCx2.Text = "0";
            txtDinheiroCx2.Text = "0";
            txtCartaoDebitoCx2.Text = "0";
            txtCartaoCreditoCx2.Text = "0";
            txtValeCx2.Text = "0";
            txtFaltaCx2.Text = "0";
            txtChequeCx2.Text = "0";
            txtBoletoCx2.Text = "0";
            cboClientePdvCx2.Text = "";
            tabControl2.TabPages[1].Text = "Caixa 2";
        }

        private void btnExcluiVendaCx3_Click(object sender, EventArgs e)
        {
            for (int i = dtItemPedido3.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtItemPedido3.Rows[i];
                dr.Delete();
            }
            txtAcrescimoCx3.Text = "0";
            txtDescontoPercentCx3.Text = "0%";
            txtDescontoUnitarioCx3.Text = "0";
            txtTrocoCx3.Text = "0";
            txtDinheiroCx3.Text = "0";
            txtCartaoDebitoCx3.Text = "0";
            txtCartaoCreditoCx3.Text = "0";
            txtValeCx3.Text = "0";
            txtFaltaCx3.Text = "0";
            txtChequeCx3.Text = "0";
            txtBoletoCx3.Text = "0";
            cboClientePdvCx3.Text = "";
            tabControl2.TabPages[2].Text = "Caixa 3";

        }

        private void btnExcluiAux_Click(object sender, EventArgs e)
        {
            for (int i = dtItemAux.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtItemAux.Rows[i];
                dr.Delete();
            }
            lblDataAux.Visible = false;
            dataAux.Visible = false;
            lblDocAux.Visible = false;
            nroDocAux.Visible = false;

            txtAcrescimoAux.Text = "0";
            txtAuxDescontoPercent.Text = "0%";
            txtAuxDescontoUnit.Text = "0";
            txtTrocoAux.Text = "0";
            txtDinheiroAux.Text = "0";
            txtDebitoAux.Text = "0";
            txtCreditoAux.Text = "0";
            txtValeAux.Text = "0";
            txtFaltaAux.Text = "0";
            txtChequeAux.Text = "0";
            txtBoletoAux.Text = "0";
            cboClienteAux.Text = "";
            dataAux.Text = "";
            nroDocAux.Text = "";
            tabControl2.TabPages[2].Text = "Caixa 3";
        }

        /********************************************************** EVENTO DE ADIÇÃO DE LINHA  ***************************************************************/
        /**---------------------------------------------------------- ADV DGV CAIXA 1 ROWS ADDED -------------------------------------------------------------**/

        private void dgvItensCx1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItensCx1.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemPedido.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemPedido.Rows[i]["Valor"]);
            }
            txtTotalCx1.Text = sum.ToString();
            txtFaltaCx1.Text = txtTotalCx1.Text;
            caixa1.TotalPdv = sum;
            txtDescontoPercentCx1.Text = "0";
            txtDescontoUnitarioCx1.Text = "0";
            txtAcrescimoCx1.Text = "0";
            caixa1.DescontoPercent = 0;
            caixa1.DescontoUnitario = 0;
            caixa1.PdvAcrescimo = 0;

            txtDinheiroCx1.Enabled = true;
            txtDebitoCx1.Enabled = true;
            txtCreditoCx1.Enabled = true;
            txtChequeCx1.Enabled = true;
            txtValeCx1.Enabled = true;
            txtBoletoCx1.Enabled = true;
            txtDescontoPercentCx1.Enabled = true;
            txtDescontoUnitarioCx1.Enabled = true;
            txtAcrescimoCx1.Enabled = true;
            dgvItensCx1.Enabled = true;
            btnArquivaVendaCx1.Enabled = true;
        }

        /**---------------------------------------------------------- ADV DGV CAIXA 2 ROWS ADDED ---------------------------------------------------------------------**/
        private void dgvItensCx2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItensCx2.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemPedido2.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemPedido2.Rows[i]["Valor"]);
            }
            txtTotalCx2.Text = sum.ToString();
            txtFaltaCx2.Text = txtTotalCx2.Text;
            caixa2.TotalPdv = sum;
            txtDescontoPercentCx2.Text = "0";
            txtDescontoUnitarioCx2.Text = "0";
            txtAcrescimoCx2.Text = "0";
            caixa2.DescontoPercent = 0;
            caixa2.DescontoUnitario = 0;
            caixa2.PdvAcrescimo = 0;

            txtDinheiroCx2.Enabled = true;
            txtCartaoDebitoCx2.Enabled = true;
            txtCartaoCreditoCx2.Enabled = true;
            txtChequeCx2.Enabled = true;
            txtValeCx2.Enabled = true;
            txtBoletoCx2.Enabled = true;
            txtDescontoPercentCx2.Enabled = true;
            txtDescontoUnitarioCx2.Enabled = true;
            txtAcrescimoCx2.Enabled = true;
            dgvItensCx2.Enabled = true;
            btnArquivaVendaCx2.Enabled = true;
    
        }
        /**---------------------------------------------------------- ADV DGV CAIXA 3 ROWS ADDED ---------------------------------------------------------------------**/
        private void dgvItensCx3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItensCx3.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemPedido3.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemPedido3.Rows[i]["Valor"]);
            }
            txtTotalCx3.Text = sum.ToString();
            txtFaltaCx3.Text = txtTotalCx3.Text;
            caixa3.TotalPdv = sum;
            txtDescontoPercentCx3.Text = "0";
            txtDescontoUnitarioCx3.Text = "0";
            txtAcrescimoCx3.Text = "0";
            caixa3.DescontoPercent = 0;
            caixa3.DescontoUnitario = 0;
            caixa3.PdvAcrescimo = 0;

            txtDinheiroCx3.Enabled = true;
            txtCartaoDebitoCx3.Enabled = true;
            txtCartaoCreditoCx3.Enabled = true;
            txtChequeCx3.Enabled = true;
            txtValeCx3.Enabled = true;
            txtBoletoCx3.Enabled = true;
            txtDescontoPercentCx3.Enabled = true;
            txtDescontoUnitarioCx3.Enabled = true;
            txtAcrescimoCx3.Enabled = true;
            dgvItensCx3.Enabled = true;
            btnArquivaVendaCx3.Enabled = true;
           
        }
        /**---------------------------------------------------------- ADV DGV CAIXA 4 ROWS ADDED ---------------------------------------------------------------------**/
        private void dgvItemAuxVenda_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItemAuxVenda.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemAux.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemAux.Rows[i]["Valor"]);
            }
            txtTotalAux.Text = sum.ToString();
            txtFaltaAux.Text = txtTotalAux.Text;
            caixaAux.TotalPdv = sum;
            txtAuxDescontoPercent.Text = "0";
            txtAuxDescontoUnit.Text = "0";
            txtAcrescimoAux.Text = "0";
            caixaAux.DescontoPercent = 0;
            caixaAux.DescontoUnitario = 0;
            caixaAux.PdvAcrescimo = 0;

            txtDinheiroAux.Enabled = true;
            txtDebitoAux.Enabled = true;
            txtCreditoAux.Enabled = true;
            txtChequeAux.Enabled = true;
            txtValeAux.Enabled = true;
            txtBoletoAux.Enabled = true;
            txtAuxDescontoPercent.Enabled = true;
            txtAuxDescontoUnit.Enabled = true;
            txtAcrescimoAux.Enabled = true;
            dgvItemAuxVenda.Enabled = true;
            btnReservaAux.Enabled = true;
        }

        /************************************************** DGV CELL ENTER ****************************************************************************/
        private void dgvItensCx1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Id"].ReadOnly = true;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Item"].ReadOnly = true;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Nome"].ReadOnly = false;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Parceiro"].ReadOnly = false;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Nosso"].ReadOnly = false;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Reservar"].ReadOnly = false;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Obs"].ReadOnly = false;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Qtd"].ReadOnly = false;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Valor"].ReadOnly = true;
            this.dgvItensCx1.Rows[e.RowIndex].Cells["Total"].ReadOnly = false;
        }

        private void dgvItensCx2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Id"].ReadOnly = true;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Item"].ReadOnly = true;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Nome"].ReadOnly = false;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Parceiro"].ReadOnly = false;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Nosso"].ReadOnly = false;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Reservar"].ReadOnly = false;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Obs"].ReadOnly = false;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Qtd"].ReadOnly = false;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Valor"].ReadOnly = true;
            this.dgvItensCx2.Rows[e.RowIndex].Cells["Total"].ReadOnly = false;
        }

        private void dgvItensCx3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Id"].ReadOnly = true;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Item"].ReadOnly = true;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Nome"].ReadOnly = false;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Parceiro"].ReadOnly = false;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Nosso"].ReadOnly = false;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Reservar"].ReadOnly = false;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Obs"].ReadOnly = false;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Qtd"].ReadOnly = false;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Valor"].ReadOnly = true;
            this.dgvItensCx3.Rows[e.RowIndex].Cells["Total"].ReadOnly = false;
        }

        /************************************************************** ALTERAÇÃO DOS DADOS NO DATAGRIDVIEW **************************************************************/
        /***--------------------------------------------------------------------------Alteração GRIDView 1-----------------------------------------------------------------****/
        private void dgvItensCx1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dtItemPedido.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemPedido.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemPedido.Rows[i]["Valor"]);

            }
            ((DataRowView)this.dgvItensCx1.CurrentRow.DataBoundItem).Row.EndEdit();
            txtTotalCx1.Text = sum.ToString();
            txtFaltaCx1.Text = txtTotalCx1.Text;
            venda1.TotalVenda = sum;
            caixa1.TotalPdv = sum;

            txtAcrescimoCx1.Text = "0";
            txtDescontoUnitarioCx1.Text = "0";
            txtDescontoPercentCx1.Text = "0";
            caixa1.DescontoPercent = 0;
            caixa1.DescontoUnitario = 0;
            caixa1.PdvAcrescimo = 0;
        }
        /***--------------------------------------------------------------------------Alteração GRIDView 2-----------------------------------------------------------------****/
        private void dgvItensCx2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dtItemPedido2.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemPedido2.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemPedido2.Rows[i]["Valor"]);
            }
            ((DataRowView)this.dgvItensCx2.CurrentRow.DataBoundItem).Row.EndEdit();

            txtTotalCx2.Text = sum.ToString();
            txtFaltaCx2.Text = txtTotalCx2.Text;
            venda2.TotalVenda = sum;
            caixa2.TotalPdv = sum;

            txtAcrescimoCx2.Text = "0";
            txtDescontoUnitarioCx2.Text = "0";
            txtDescontoPercentCx2.Text = "0";
            caixa2.DescontoPercent = 0;
            caixa2.DescontoUnitario = 0;
            caixa2.PdvAcrescimo = 0;
        }
        /***--------------------------------------------------------------------------Alteração GRIDView 3-----------------------------------------------------------------****/
        private void dgvItensCx3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dtItemPedido3.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemPedido3.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemPedido3.Rows[i]["Valor"]);
            }
            ((DataRowView)this.dgvItensCx3.CurrentRow.DataBoundItem).Row.EndEdit();

            txtTotalCx3.Text = sum.ToString();
            txtFaltaCx3.Text = txtTotalCx3.Text;
            venda3.TotalVenda = sum;
            caixa3.TotalPdv = sum;

            txtAcrescimoCx3.Text = "0";
            txtDescontoUnitarioCx3.Text = "0";
            txtDescontoPercentCx3.Text = "0";
            caixa3.DescontoPercent = 0;
            caixa3.DescontoUnitario = 0;
            caixa3.PdvAcrescimo = 0;
        }
        /***--------------------------------------------------------------------------Alteração GRIDView 4-----------------------------------------------------------------****/
        private void dgvItemAuxVenda_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dtItemAux.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dtItemAux.Rows[i]["Qtd"]) * Convert.ToDouble(dtItemAux.Rows[i]["Valor"]);
            }
            ((DataRowView)this.dgvItemAuxVenda.CurrentRow.DataBoundItem).Row.EndEdit();

            txtTotalAux.Text = sum.ToString();
            txtFaltaAux.Text = txtTotalAux.Text;
            vendaAux.TotalVenda = sum;
            caixaAux.TotalPdv = sum;

            txtAcrescimoAux.Text = "0";
            txtAuxDescontoUnit.Text = "0";
            txtAuxDescontoPercent.Text = "0";
            caixaAux.DescontoPercent = 0;
            caixaAux.DescontoUnitario = 0;
            caixaAux.PdvAcrescimo = 0;
        }

        /*************************************************************** REMOÇÃO DE LINHAS DO DATAGRIDVIEW *****************************************************************/
        /************---------------------------------------------------  DATAGRIDVIEW CAIXA 1 REMOÇÂO DE LINHA ---------------------------------------**************/
        private void dgvItensCx1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItensCx1.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dgvItensCx1.Rows[i].Cells["Qtd"].Value) * Convert.ToDouble(dgvItensCx1.Rows[i].Cells["Valor"].Value);
            }

            /*Recálculo do Total.*/
            txtTotalCx1.Text = sum.ToString();
            txtFaltaCx1.Text = txtTotalCx1.Text;
            caixa1.TotalPdv = sum;
            venda1.TotalVenda = sum;

            /*Limpeza de Campos*/
            txtDescontoPercentCx1.Text = "0";
            txtDescontoUnitarioCx1.Text = "0";
            txtAcrescimoCx1.Text = "0";
            txtDinheiroCx1.Text = "0";
            txtDebitoCx1.Text = "0";
            txtCreditoCx1.Text = "0";
            txtChequeCx1.Text = "0";
            txtBoletoCx1.Text = "0";
            txtValeCx1.Text = "0";
            /*Limpeza dos objetos utilizados*/
            caixa1.PdvAcrescimo = 0;
            caixa1.TotalPdvDescontPercent = 0;
            caixa1.TotalPdvDescontUnitario = 0;
            caixa1.TotalTempPdv = 0;
            caixa1.PdvFaltaValor = 0;
            /*Limpeza dos Objetos de Pagamento*/
            dinheirocx1.ValorPagamento = 0;
            dinheirocx1.TotalInicial = 0;
            debitocx1.ValorPagamento = 0;
            debitocx1.TotalInicial = 0;
            creditocx1.ValorPagamento = 0;
            creditocx1.TotalInicial = 0;
            chequecx1.ValorPagamento = 0;
            chequecx1.TotalInicial = 0;
            valecx1.TotalInicial = 0;
            valecx1.ValorPagamento = 0;
            boletocx1.TotalInicial = 0;
            boletocx1.ValorPagamento = 0;
        }
        /************----------------------------------------------------------DATAGRIDVIEW CAIXA 2 REMOÇÂO DE LINHA ---------------------------------------**************/
        private void dgvItensCx2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItensCx2.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dgvItensCx2.Rows[i].Cells["Qtd"].Value) * Convert.ToDouble(dgvItensCx2.Rows[i].Cells["Valor"].Value);
            }

            /*Recálculo do Total.*/
            txtTotalCx2.Text = sum.ToString();
            txtFaltaCx2.Text = txtTotalCx2.Text;
            venda2.TotalVenda = sum;
            caixa2.TotalPdv = sum;

            /*Limpeza de Campos*/
            txtDescontoPercentCx2.Text = "0";
            txtDescontoUnitarioCx2.Text = "0";
            txtAcrescimoCx2.Text = "0";
            txtDinheiroCx2.Text = "0";
            txtCartaoDebitoCx2.Text = "0";
            txtCartaoCreditoCx2.Text = "0";
            txtChequeCx2.Text = "0";
            txtBoletoCx2.Text = "0";
            txtValeCx2.Text = "0";
            /*Limpeza dos objetos utilizados*/
            caixa2.PdvAcrescimo = 0;
            caixa2.TotalPdvDescontPercent = 0;
            caixa2.TotalPdvDescontUnitario = 0;
            caixa2.TotalTempPdv = 0;
            caixa2.PdvFaltaValor = 0;
            /*Limpeza dos Objetos de Pagamento*/
            dinheirocx2.ValorPagamento = 0;
            dinheirocx2.TotalInicial = 0;
            debitocx2.ValorPagamento = 0;
            debitocx2.TotalInicial = 0;
            creditocx2.ValorPagamento = 0;
            creditocx2.TotalInicial = 0;
            chequecx2.ValorPagamento = 0;
            chequecx2.TotalInicial = 0;
            valecx2.TotalInicial = 0;
            valecx2.ValorPagamento = 0;
            boletocx2.TotalInicial = 0;
            boletocx2.ValorPagamento = 0;
        }
        /************----------------------------------------------------------DATAGRIDVIEW CAIXA 3 REMOÇÂO DE LINHA ---------------------------------------**************/
        private void dgvItensCx3_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItensCx3.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dgvItensCx3.Rows[i].Cells["Qtd"].Value) * Convert.ToDouble(dgvItensCx3.Rows[i].Cells["Valor"].Value);
            }

            /*Recálculo do Total.*/
            txtTotalCx3.Text = sum.ToString();
            txtFaltaCx3.Text = txtTotalCx3.Text;
            venda3.TotalVenda = sum;
            caixa3.TotalPdv = sum;

            /*Limpeza de Campos*/
            txtDescontoPercentCx3.Text = "0";
            txtDescontoUnitarioCx3.Text = "0";
            txtAcrescimoCx3.Text = "0";
            txtDinheiroCx3.Text = "0";
            txtCartaoDebitoCx3.Text = "0";
            txtCartaoCreditoCx3.Text = "0";
            txtChequeCx3.Text = "0";
            txtBoletoCx3.Text = "0";
            txtValeCx3.Text = "0";
            /*Limpeza dos objetos utilizados*/
            caixa3.PdvAcrescimo = 0;
            caixa3.TotalPdvDescontPercent = 0;
            caixa3.TotalPdvDescontUnitario = 0;
            caixa3.TotalTempPdv = 0;
            caixa3.PdvFaltaValor = 0;
            /*Limpeza dos Objetos de Pagamento*/
            dinheirocx3.TipoPagamento = 1;
            dinheirocx3.ValorPagamento = 0;
            dinheirocx3.TotalInicial = 0;
            debitocx3.TipoPagamento = 2;
            debitocx3.ValorPagamento = 0;
            debitocx3.TotalInicial = 0;
            creditocx3.TipoPagamento = 3;
            creditocx3.ValorPagamento = 0;
            creditocx3.TotalInicial = 0;
            chequecx3.TipoPagamento = 4;
            chequecx3.ValorPagamento = 0;
            chequecx3.TotalInicial = 0;
            valecx3.TipoPagamento = 5;
            valecx3.TotalInicial = 0;
            valecx3.ValorPagamento = 0;
            boletocx3.TipoPagamento = 6;
            boletocx3.TotalInicial = 0;
            boletocx3.ValorPagamento = 0;
        }
        /************----------------------------------------------------------DATAGRIDVIEW CAIXA 4 REMOÇÂO DE LINHA ---------------------------------------**************/
        private void dgvItemAuxVenda_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i <= dgvItemAuxVenda.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDouble(dgvItemAuxVenda.Rows[i].Cells["Qtd"].Value) * Convert.ToDouble(dgvItemAuxVenda.Rows[i].Cells["Valor"].Value);
            }

            /*Recálculo do Total.*/
            txtTotalAux.Text = sum.ToString();
            txtFaltaAux.Text = txtTotalAux.Text;
            vendaAux.TotalVenda = sum;
            caixaAux.TotalPdv = sum;

            /*Limpeza de Campos*/
            txtAuxDescontoPercent.Text = "0";
            txtAuxDescontoUnit.Text = "0";
            txtAcrescimoAux.Text = "0";
            txtDinheiroAux.Text = "0";
            txtDebitoAux.Text = "0";
            txtCreditoAux.Text = "0";
            txtChequeAux.Text = "0";
            txtBoletoAux.Text = "0";
            txtValeAux.Text = "0";

            /*Limpeza dos objetos utilizados*/
            caixaAux.PdvAcrescimo = 0;
            caixaAux.TotalPdvDescontPercent = 0;
            caixaAux.TotalPdvDescontUnitario = 0;
            caixaAux.TotalTempPdv = 0;
            caixaAux.PdvFaltaValor = 0;

            /*Limpeza dos Objetos de Pagamento*/
            dinheiroAux.TipoPagamento = 1;
            dinheiroAux.ValorPagamento = 0;
            dinheiroAux.TotalInicial = 0;
            debitocxAux.TipoPagamento = 2;
            debitocxAux.ValorPagamento = 0;
            debitocxAux.TotalInicial = 0;
            creditocxAux.TipoPagamento = 3;
            creditocxAux.ValorPagamento = 0;
            creditocxAux.TotalInicial = 0;
            chequecxAux.TipoPagamento = 4;
            chequecxAux.ValorPagamento = 0;
            chequecxAux.TotalInicial = 0;
            valecxAux.TipoPagamento = 5;
            valecxAux.TotalInicial = 0;
            valecxAux.ValorPagamento = 0;
            boletocxAux.TipoPagamento = 6;
            boletocxAux.TotalInicial = 0;
            boletocxAux.ValorPagamento = 0;
        }
        /********************************************************* FINALIZAÇÃO DE UMA VENDA CX1 ************************************************************/
        private void btnFinalizaVenda_Click(object sender, EventArgs e)
        {
            FinanceiroBLL financeiroBLL = new FinanceiroBLL();
            VendaBLL vendaBLL = new VendaBLL();
            venda1.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
            venda1.Pessoa.Id = Convert.ToInt32(cboClientePdvCx1.SelectedValue);
            venda1.TotalVenda = Convert.ToDouble(txtTotalCx1.Text);
            venda1.Idreg_cabecalho = vendaBLL.realizaVenda(venda1);
            caixa1.PdvAcrescimo = Convert.ToDouble(txtAcrescimoCx1.Text);
            caixa1.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx1.Text);
            caixa1.DescontoUnitario = Convert.ToDouble(txtDescontoUnitarioCx1.Text) ;             

            foreach (DataGridViewRow row in dgvItensCx1.Rows)
            {
                venda1.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
                venda1.Pessoa.Id = Convert.ToInt32(cboClientePdvCx1.SelectedValue);
                venda1.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                venda1.Produto.NomeVenda = row.Cells["Item"].Value.ToString();
                venda1.Parceiro = Convert.ToBoolean(row.Cells["Parceiro"].Value);
                venda1.Nosso = Convert.ToBoolean(row.Cells["Nosso"].Value);
                venda1.Reservar = Convert.ToBoolean(row.Cells["Reservar"].Value);
                venda1.Produto.Quantidade = Convert.ToDouble(row.Cells["Qtd"].Value);
                venda1.Produto.Preco = Convert.ToDouble(row.Cells["Valor"].Value);
                int res = vendaBLL.realizaVendaDetalhe(venda1);
                if (res == 0)
                {
                    toolCaixa1.Text = "Venda Registrada.";
                }
                else if (res != 0)
                {
                    toolCaixa1.Text = "Venda em aberto.";
                }
            }

            venda1.NroDoc = financeiroBLL.gravaFinanceiro(venda1,caixa1);
            var pagamentos = new List<PagamentoModel>();
            pagamentos.Add(dinheirocx1);
            pagamentos.Add(debitocx1);
            pagamentos.Add(creditocx1);
            pagamentos.Add(chequecx1);
            pagamentos.Add(valecx1);
            pagamentos.Add(boletocx1);

            toolStripStatusLabel1.Text = pagamentoBLL.GravaPagamento(venda1, pagamentos);

            btnFinalizaVendaCx1.Enabled = false;
            btnArquivaVendaCx1.Enabled = false;
            txtDinheiroCx1.Enabled = false;
            txtDebitoCx1.Enabled = false;
            txtCreditoCx1.Enabled = false;
            txtChequeCx1.Enabled = false;
            txtValeCx1.Enabled = false;
            txtBoletoCx1.Enabled = false;
            txtDescontoPercentCx1.Enabled = false;
            txtDescontoUnitarioCx1.Enabled = false;
            txtAcrescimoCx1.Enabled = false;
            tstMaisCaixa1.Enabled = false;
            tstMenosCaixa1.Enabled = false;
            dgvItensCx1.Enabled = false;
                                    
            tabControl2.TabPages[0].Text = "Caixa 1";
        
        }
        /********************************************************* FINALIZAÇÃO DE UMA VENDA CX2 ************************************************************/
        private void btnFinalizaVendaCx2_Click(object sender, EventArgs e)
        {
            FinanceiroBLL financeiroBLL = new FinanceiroBLL();
            VendaBLL vendaBLL = new VendaBLL();
            venda2.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
            venda2.Pessoa.Id = Convert.ToInt32(cboClientePdvCx2.SelectedValue);
            venda2.TotalVenda = Convert.ToDouble(txtTotalCx2.Text);
            venda2.Idreg_cabecalho = vendaBLL.realizaVenda(venda2);
            caixa2.PdvAcrescimo = Convert.ToDouble(txtAcrescimoCx2.Text);
            caixa2.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx2.Text);
            caixa2.DescontoUnitario = Convert.ToDouble(txtDescontoUnitarioCx2.Text);

            foreach (DataGridViewRow row in dgvItensCx2.Rows)
            {
                venda2.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
                venda2.Pessoa.Id = Convert.ToInt32(cboClientePdvCx2.SelectedValue);
                venda2.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                venda2.Produto.NomeVenda = row.Cells["Item"].Value.ToString();
                venda2.Parceiro = Convert.ToBoolean(row.Cells["Parceiro"].Value);
                venda2.Nosso = Convert.ToBoolean(row.Cells["Nosso"].Value);
                venda2.Reservar = Convert.ToBoolean(row.Cells["Reservar"].Value);
                venda2.Produto.Quantidade = Convert.ToDouble(row.Cells["Qtd"].Value);
                venda2.Produto.Preco = Convert.ToDouble(row.Cells["Valor"].Value);
                int res = vendaBLL.realizaVendaDetalhe(venda2);
                if (res == 0)
                {
                    toolCaixa1.Text = "Venda Registrada.";
                }
                else if (res != 0)
                {
                    toolCaixa1.Text = "Venda em aberto.";
                }
            }

            venda2.NroDoc = financeiroBLL.gravaFinanceiro(venda2, caixa2);

            var pagamentos = new List<PagamentoModel>();

            pagamentos.Add(dinheirocx2);
            pagamentos.Add(debitocx2);
            pagamentos.Add(creditocx2);
            pagamentos.Add(chequecx2);
            pagamentos.Add(valecx2);
            pagamentos.Add(boletocx2);

            toolStripStatusLabel1.Text = pagamentoBLL.GravaPagamento(venda2, pagamentos);

            btnFinalizaVendaCx2.Enabled = false;
            tstMaisCaixa2.Enabled = false;
            tstMenosCaixa2.Enabled = false;
            txtDinheiroCx2.Enabled = false;
            txtCartaoDebitoCx2.Enabled = false;
            txtCartaoCreditoCx2.Enabled = false;
            txtChequeCx2.Enabled = false;
            txtValeCx2.Enabled = false;
            txtBoletoCx2.Enabled = false;
            txtDescontoPercentCx2.Enabled = false;
            txtDescontoUnitarioCx2.Enabled = false;
            txtAcrescimoCx2.Enabled = false;
            dgvItensCx2.Enabled = false;
            btnExcluiVendaCx2.Focus();
            tabControl2.TabPages[1].Text = "Caixa 2";

        }
        /********************************************************* FINALIZAÇÃO DE UMA VENDA CX3 ************************************************************/
        private void btnFinalizaVendaCx3_Click(object sender, EventArgs e)
        {
            FinanceiroBLL financeiroBLL = new FinanceiroBLL();
            VendaBLL vendaBLL = new VendaBLL();
            venda3.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
            venda3.Pessoa.Id = Convert.ToInt32(cboClientePdvCx3.SelectedValue);
            venda3.TotalVenda = Convert.ToDouble(txtTotalCx3.Text);
            venda3.Idreg_cabecalho = vendaBLL.realizaVenda(venda3);
            caixa3.PdvAcrescimo = Convert.ToDouble(txtAcrescimoCx3.Text);
            caixa3.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx3.Text);
            caixa3.DescontoUnitario = Convert.ToDouble(txtDescontoUnitarioCx3.Text);

            foreach (DataGridViewRow row in dgvItensCx3.Rows)
            {
                venda3.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
                venda3.Pessoa.Id = Convert.ToInt32(cboClientePdvCx3.SelectedValue);
                venda3.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                venda3.Produto.NomeVenda = row.Cells["Item"].Value.ToString();
                venda3.Parceiro = Convert.ToBoolean(row.Cells["Parceiro"].Value);
                venda3.Nosso = Convert.ToBoolean(row.Cells["Nosso"].Value);
                venda3.Reservar = Convert.ToBoolean(row.Cells["Reservar"].Value);
                venda3.Produto.Quantidade = Convert.ToDouble(row.Cells["Qtd"].Value);
                venda3.Produto.Preco = Convert.ToDouble(row.Cells["Valor"].Value);
                int res = vendaBLL.realizaVendaDetalhe(venda3);
                if (res == 0)
                {
                    toolCaixa1.Text = "Venda Registrada.";
                }
                else if (res != 0)
                {
                    toolCaixa1.Text = "Venda em aberto.";
                }
            }

            venda3.NroDoc = financeiroBLL.gravaFinanceiro(venda3, caixa3);

            var pagamentos = new List<PagamentoModel>();

            pagamentos.Add(dinheirocx3);
            pagamentos.Add(debitocx3);
            pagamentos.Add(creditocx3);
            pagamentos.Add(chequecx3);
            pagamentos.Add(valecx3);
            pagamentos.Add(boletocx3);

            toolStripStatusLabel1.Text = pagamentoBLL.GravaPagamento(venda3, pagamentos);

            btnFinalizaVendaCx3.Enabled = false;
            tstMaisCaixa3.Enabled = false;
            tstMenosCaixa3.Enabled = false;
            txtDinheiroCx3.Enabled = false;
            txtCartaoDebitoCx3.Enabled = false;
            txtCartaoCreditoCx3.Enabled = false;
            txtChequeCx3.Enabled = false;
            txtValeCx3.Enabled = false;
            txtBoletoCx3.Enabled = false;
            txtDescontoPercentCx3.Enabled = false;
            txtDescontoUnitarioCx3.Enabled = false;
            txtAcrescimoCx3.Enabled = false;
            dgvItensCx3.Enabled = false;
            btnExcluiVendaCx3.Focus();
            tabControl2.TabPages[2].Text = "Caixa 3";

        }
        /**------------------------------------------------------------------- EDITA VENDA AUX ----------------------------------------------------------------------**/
        private void btnFinalizaAux_Click(object sender, EventArgs e)
        {        
            VendaBLL vendaBLL = new VendaBLL();
            vendaAux.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
            vendaAux.Pessoa.Id = Convert.ToInt32(cboClienteAux.SelectedValue);
            vendaAux.TotalVenda = Convert.ToDouble(txtTotalAux.Text);
            vendaAux.Idreg_cabecalho = Convert.ToInt32(nroDocAux.Text);        
            caixaAux.PdvAcrescimo = Convert.ToDouble(txtAcrescimoAux.Text);
            caixaAux.DescontoPercent = Convert.ToDouble(txtAuxDescontoPercent.Text);
            caixaAux.DescontoUnitario = Convert.ToDouble(txtAuxDescontoUnit.Text);

            foreach (DataGridViewRow row in dgvItemAuxVenda.Rows)
            {
                vendaAux.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
                vendaAux.Pessoa.Id = Convert.ToInt32(cboClienteAux.SelectedValue);
                vendaAux.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                vendaAux.Produto.NomeVenda = row.Cells["Item"].Value.ToString();
                vendaAux.Parceiro = Convert.ToBoolean(row.Cells["Parceiro"].Value);
                vendaAux.Nosso = Convert.ToBoolean(row.Cells["Nosso"].Value);
                vendaAux.Reservar = Convert.ToBoolean(row.Cells["Reservar"].Value);
                vendaAux.Produto.Quantidade = Convert.ToDouble(row.Cells["Qtd"].Value);
                vendaAux.Produto.Preco = Convert.ToDouble(row.Cells["Valor"].Value);

                int res = vendaBLL.atualizaVendaDetalhe(vendaAux);
                if (res == 0)
                {
                    toolCaixa1.Text = "Venda Registrada.";
                }
                else if (res != 0)
                {
                    toolCaixa1.Text = "Venda em aberto.";
                }
            }

            vendaAux.NroDoc = Convert.ToInt32(nroDocAux.Text);
            caixaAux.DescontoPercent = Convert.ToDouble(txtAuxDescontoPercent.Text);
            caixaAux.DescontoUnitario = Convert.ToDouble(txtAuxDescontoUnit.Text);
            caixaAux.PdvAcrescimo = Convert.ToDouble(txtAcrescimoAux.Text);
            dinheiroAux.ValorPagamento = Convert.ToDouble(txtDinheiroAux.Text);
            debitocxAux.ValorPagamento = Convert.ToDouble(txtDebitoAux.Text);
            creditocxAux.ValorPagamento = Convert.ToDouble(txtCreditoAux.Text);
            chequecxAux.ValorPagamento = Convert.ToDouble(txtChequeAux.Text);
            valecxAux.ValorPagamento = Convert.ToDouble(txtValeAux.Text);

            FinanceiroBLL financeiro = new FinanceiroBLL();
            financeiro.gravaFinanceiro(vendaAux, caixaAux);

            var pagamentoAux = new List<PagamentoModel>();

            pagamentoAux.Add(dinheiroAux);
            pagamentoAux.Add(debitocxAux);
            pagamentoAux.Add(creditocxAux);
            pagamentoAux.Add(chequecxAux);
            pagamentoAux.Add(valecxAux);
            pagamentoAux.Add(boletocxAux);

            toolStripStatusLabel1.Text = pagamentoBLL.GravaPagamento(vendaAux, pagamentoAux);

        }


        /********************************************************** EVENTO DO BOTÃO ARQUIVA VENDA ************************************************************/
        private void btnArquivaVenda_Click(object sender, EventArgs e)
        {        
            venda1.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
            venda1.Pessoa.Id = Convert.ToInt32(cboClientePdvCx1.SelectedValue);           
            venda1.Idreg_cabecalho = venda.realizaVenda(venda1);
            venda1.TotalVenda = Convert.ToDouble(txtTotalCx1.Text);
            caixa1.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx1.Text);
            caixa1.DescontoUnitario = 0;
            caixa1.PdvAcrescimo = 0;            

            foreach (DataGridViewRow row in dgvItensCx1.Rows)
            {
                venda1.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
                venda1.Pessoa.Id = Convert.ToInt32(cboClientePdvCx1.SelectedValue);
                venda1.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                venda1.Produto.NomeVenda = row.Cells["Item"].Value.ToString();
                venda1.Parceiro = Convert.ToBoolean(row.Cells["Parceiro"].Value);
                venda1.Nosso = Convert.ToBoolean(row.Cells["Nosso"].Value);
                venda1.Reservar = Convert.ToBoolean(row.Cells["Reservar"].Value);
                venda1.Produto.Quantidade = Convert.ToDouble(row.Cells["Qtd"].Value);
                venda1.Produto.Preco = Convert.ToDouble(row.Cells["Valor"].Value);
                int res = venda.realizaVendaDetalhe(venda1);
                if (res == 0)
                {
                    toolCaixa1.Text = "Venda Arquivada.";
                }
                else
                {
                    toolCaixa1.Text = "Venda Arquivada";
                }
            }

            btnExcluiVendaCx1.Focus();

        }
        /****************************************************** EVENTO DO BOTÃO ARQUIVA VENDA CAIXA 2 **********************************************************/
        private void btnArquivaVendaCx2_Click(object sender, EventArgs e)
        {
            venda2.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
            venda2.Pessoa.Id = Convert.ToInt32(cboClientePdvCx2.SelectedValue);
            venda2.Idreg_cabecalho = venda.realizaVenda(venda2);
            venda2.TotalVenda = Convert.ToDouble(txtTotalCx2.Text);
            caixa2.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx2.Text);
            caixa2.DescontoUnitario = 0;
            caixa2.PdvAcrescimo = 0;

            foreach (DataGridViewRow row in dgvItensCx2.Rows)
            {
                venda2.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
                venda2.Pessoa.Id = Convert.ToInt32(cboClientePdvCx2.SelectedValue);
                venda2.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                venda2.Produto.NomeVenda = row.Cells["Item"].Value.ToString();
                venda2.Parceiro = Convert.ToBoolean(row.Cells["Parceiro"].Value);
                venda2.Nosso = Convert.ToBoolean(row.Cells["Nosso"].Value);
                venda2.Reservar = Convert.ToBoolean(row.Cells["Reservar"].Value);
                venda2.Produto.Quantidade = Convert.ToDouble(row.Cells["Qtd"].Value);
                venda2.Produto.Preco = Convert.ToDouble(row.Cells["Total"].Value);
                int res = venda.realizaVendaDetalhe(venda2);
                if (res == 0)
                {
                    toolCaixa1.Text = "Venda Arquivada.";
                }
                else
                {
                    toolCaixa1.Text = "Venda Arquivada";
                }
            }         
        }
        /****************************************************** EVENTO DO BOTÃO ARQUIVA VENDA CAIXA 3 **********************************************************/
        private void btnArquivaVendaCx3_Click(object sender, EventArgs e)
        {
            venda3.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
            venda3.Pessoa.Id = Convert.ToInt32(cboClientePdvCx3.SelectedValue);
            venda3.Idreg_cabecalho = venda.realizaVenda(venda3);
            venda3.TotalVenda = Convert.ToDouble(txtTotalCx3.Text);
            caixa3.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx3.Text);
            caixa3.DescontoUnitario = 0;
            caixa3.PdvAcrescimo = 0;

            foreach (DataGridViewRow row in dgvItensCx3.Rows)
            {
                venda3.Documento.Id = Convert.ToInt32(cboDoc.SelectedValue);
                venda3.Pessoa.Id = Convert.ToInt32(cboClientePdvCx3.SelectedValue);
                venda3.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                venda3.Produto.NomeVenda = row.Cells["Item"].Value.ToString();
                venda3.Parceiro = Convert.ToBoolean(row.Cells["Parceiro"].Value);
                venda3.Nosso = Convert.ToBoolean(row.Cells["Nosso"].Value);
                venda3.Reservar = Convert.ToBoolean(row.Cells["Reservar"].Value);
                venda3.Produto.Quantidade = Convert.ToDouble(row.Cells["Qtd"].Value);
                venda3.Produto.Preco = Convert.ToDouble(row.Cells["Valor"].Value);
                int res = venda.realizaVendaDetalhe(venda3);
                if (res == 0)
                {
                    toolCaixa1.Text = "Venda Arquivada.";
                }
                else
                {
                    toolCaixa1.Text = "Venda Arquivada";
                }
            }            
        }

        /****************************************************** EVENTO DO BOTÃO ARQUIVA VENDA CAIXA 4 **********************************************************/
        private void btnReservaAux_Click(object sender, EventArgs e)
        {

        }

        /*************************************************************************** LISTAGEM DE HISTÓRICO DE VENDAS ********************************************************************************/
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabVendas)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = venda.listaVenda();
                advDgvHistVenda.DataSource = bs;
                advDgvHistVenda.Refresh();
            }
            else if(tabControl1.SelectedTab==tabVenda)
            {
                toolStripStatusLabel1.Text = "";
                advDgvProdutos.DataSource = produto.BuscaProdutosComSaldo();
                advDgvHistVenda.Refresh();
            }           
        }
        /**************************************************************************   CLICK BOTÃO MAIS DO GRID DE ITEM DA VENDA  ******************************************************************/
        /***********-----------------------------------------------------------------                   CLICK MAIS CAIXA1                               --------------------------------------------------******************/
        private void toolbtnAdicionar_Click(object sender, EventArgs e)
        {
            FormPDVQtd formQtd = new FormPDVQtd();
            formQtd.DialogResult = DialogResult.Ignore;
            formQtd.ShowDialog();
            string nome = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
            string apelido = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();          
            double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);

            if (formQtd.DialogResult == DialogResult.OK)
            {
                double qtd = Convert.ToDouble(formQtd.txtQtdProduto.Text);
                dtItemPedido.Rows.Add(nome, apelido, "", 1, 1, 0, "", qtd, valor, valor * qtd);
                dgvItensCx1.EndEdit();
                dgvItensCx1.Refresh();
            }
            else if (formQtd.DialogResult == DialogResult.Cancel)
            {
                formQtd.Close();
            }
            /*
            dtItemPedido.Rows.Add(advDgvProdutos.CurrentRow.Cells[0].Value.ToString(), advDgvProdutos.CurrentRow.Cells[1].Value.ToString(), "", true, true, false, "", 0, Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value), 0);
            advDgvItensVenda1.DataSource = dtItemPedido;
            */
        }
        /***********-------------------------------------------------------------              CLICK MAIS CAIXA2              -----------------------------------------------------------******************/
        private void tstMaisCaixa2_Click(object sender, EventArgs e)
        {
            FormPDVQtd formQtd = new FormPDVQtd();
            formQtd.DialogResult = DialogResult.Ignore;
            formQtd.ShowDialog();
            string nome = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
            string apelido = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();
            double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);

            if (formQtd.DialogResult == DialogResult.OK)
            {
                double qtd = Convert.ToDouble(formQtd.txtQtdProduto.Text);
                dtItemPedido2.Rows.Add(nome, apelido, "", true, true, false, "", qtd, valor, valor * qtd);
                dgvItensCx2.EndEdit();
                dgvItensCx2.Refresh();
            }
            else if (formQtd.DialogResult == DialogResult.Cancel)
            {
                formQtd.Close();
            }
        }
        /***********---------------------------------------------------------                CLICK MAIS CAIXA3                 ---------------------------------------------------------******************/
        private void tstMaisCaixa3_Click(object sender, EventArgs e)
        {
            FormPDVQtd formQtd = new FormPDVQtd();
            formQtd.DialogResult = DialogResult.Ignore;
            formQtd.ShowDialog();
            string nome = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
            string apelido = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();
           
            double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);

            if (formQtd.DialogResult == DialogResult.OK)
            {
                double qtd = Convert.ToDouble(formQtd.txtQtdProduto.Text);
                dtItemPedido3.Rows.Add(nome, apelido, "", true, true, false, "", qtd, valor, valor * qtd);
                dgvItensCx3.EndEdit();
                dgvItensCx3.Refresh();
            }
            else if (formQtd.DialogResult == DialogResult.Cancel)
            {
                formQtd.Close();
            }
        }
        /***********---------------------------------------------------------        CLICK MAIS CAIXA AUXILIAR    ---------------------------------------------------------******************/
        private void tstMaisItem_Click(object sender, EventArgs e)
        {
            FormPDVQtd formQtd = new FormPDVQtd();
            formQtd.DialogResult = DialogResult.Ignore;
            formQtd.ShowDialog();
            string nome = advDgvProdutos.CurrentRow.Cells[0].Value.ToString();
            string apelido = advDgvProdutos.CurrentRow.Cells[1].Value.ToString();
            double valor = Convert.ToDouble(advDgvProdutos.CurrentRow.Cells[3].Value);

            if (formQtd.DialogResult == DialogResult.OK)
            {
                double qtd = Convert.ToDouble(formQtd.txtQtdProduto.Text);
                dtItemAux.Rows.Add(nome, apelido, "", true, true, false, "", qtd, valor, valor * qtd);
                dgvItemAuxVenda.EndEdit();
                dgvItemAuxVenda.Refresh();
            }
            else if (formQtd.DialogResult == DialogResult.Cancel)
            {
                formQtd.Close();
            }
        }
        /**************************************************************** EXCLUSÃO E EDIÇÃO CAMPO TOTAL************************************************************************/
        /***--------------------------------------------------------------------------Botão Excluir advDvg Caixa 1-----------------------------------------------------------------****/
        private void toolbtnExcluir_Click(object sender, EventArgs e)
        {
            dgvItensCx1.Rows.RemoveAt(dgvItensCx1.CurrentRow.Index);
        }
        /***--------------------------------------------------------------------------Botão Excluir advDvg Caixa 2-----------------------------------------------------------------****/
        private void tstMenosCaixa2_Click(object sender, EventArgs e)
        {
            dgvItensCx2.Rows.RemoveAt(dgvItensCx2.CurrentRow.Index);
        }
        /***--------------------------------------------------------------------------Botão Excluir advDvg Caixa 3-----------------------------------------------------------------****/
        private void tstMenosCaixa3_Click(object sender, EventArgs e)
        {
            dgvItensCx3.Rows.RemoveAt(dgvItensCx3.CurrentRow.Index);
        }
        /***--------------------------------------------------------------------------Botão Excluir advDvg Caixa Aux ------------------------------------------------------------****/
        private void tstMenosItem_Click(object sender, EventArgs e)
        {
            dgvItemAuxVenda.Rows.RemoveAt(dgvItemAuxVenda.CurrentRow.Index);
        }
        /************************************************************* LEAVE DO TXT DE ACRESCIMO ***************************************************************************/
        /*---------------------------------------------------------           ACRESCIMO CAIXA 1          -----------------------------------------------------------*/
        private void txtAcrescimo_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoCx1.Text == "")
            {
                txtAcrescimoCx1.Text = "0";
            }
            caixa1.PdvAcrescimo = Convert.ToDouble(txtAcrescimoCx1.Text);
            caixa1.TotalTempPdv = Convert.ToDouble(txtTotalCx1.Text);
            caixa1.TotalPdvAcrescimo = caixaCalculo.AdicionaAcrescimo(caixa1);
            txtTotalCx1.Text = caixa1.TotalPdvAcrescimo.ToString();
            txtFaltaCx1.Text = txtTotalCx1.Text;            
        }

        private void txtAcrescimoCx1_Enter(object sender, EventArgs e)
        {
            txtFaltaCx1.Text = txtTotalCx1.Text;
            txtDinheiroCx1.Text = "0";
            dinheirocx1.ValorPagamento = 0;
            txtDebitoCx1.Text = "0";
            debitocx1.ValorPagamento = 0;
            txtCreditoCx1.Text = "0";
            creditocx1.ValorPagamento = 0;
            txtChequeCx1.Text = "0";
            chequecx1.ValorPagamento = 0;
            txtValeCx1.Text = "0";
            valecx1.ValorPagamento = 0;
            txtBoletoCx1.Text = "0";
            boletocx1.ValorPagamento = 0;
            txtAcrescimoCx1.Text = "0";
            btnFinalizaVendaCx1.Enabled = false;
        }
        /*---------------------------------------------------------            ACRESCIMO CAIXA 2        -----------------------------------------------------------*/
        private void txtAcrescimoCx2_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoCx2.Text == "")
            {
                txtAcrescimoCx2.Text = "0";
            }
            caixa2.PdvAcrescimo = Convert.ToDouble(txtAcrescimoCx2.Text);
            caixa2.TotalTempPdv = Convert.ToDouble(txtTotalCx2.Text);
            caixa2.TotalPdvAcrescimo = caixaCalculo.AdicionaAcrescimo(caixa2);
            txtTotalCx2.Text = caixa2.TotalPdvAcrescimo.ToString();
            txtFaltaCx2.Text = txtTotalCx2.Text;
        }
        private void txtAcrescimoCx2_Enter(object sender, EventArgs e)
        {
            txtFaltaCx2.Text = txtTotalCx2.Text;
            txtDinheiroCx2.Text = "0";
            dinheirocx2.ValorPagamento = 0;
            txtCartaoDebitoCx2.Text = "0";
            debitocx2.ValorPagamento = 0;
            txtCartaoCreditoCx2.Text = "0";
            creditocx2.ValorPagamento = 0;
            txtChequeCx2.Text = "0";
            chequecx2.ValorPagamento = 0;
            txtValeCx2.Text = "0";
            valecx2.ValorPagamento = 0;
            txtBoletoCx2.Text = "0";
            boletocx2.ValorPagamento = 0;
            txtAcrescimoCx2.Text = "0";
            btnFinalizaVendaCx2.Enabled = false;
        }
        /*---------------------------------------------------------           ACRESCIMO CAIXA 3           -----------------------------------------------------------*/
        private void txtAcrescimoCx3_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoCx3.Text == "")
            {
                txtAcrescimoCx3.Text = "0";
            }
            caixa3.PdvAcrescimo = Convert.ToDouble(txtAcrescimoCx3.Text);
            caixa3.TotalTempPdv = Convert.ToDouble(txtTotalCx3.Text);
            caixa3.TotalPdvAcrescimo = caixaCalculo.AdicionaAcrescimo(caixa3);
            txtTotalCx3.Text = caixa3.TotalPdvAcrescimo.ToString();
            txtFaltaCx3.Text = txtTotalCx3.Text;
        }
        private void txtAcrescimoCx3_Enter(object sender, EventArgs e)
        {
            txtFaltaCx3.Text = txtTotalCx3.Text;
            txtDinheiroCx3.Text = "0";
            dinheirocx3.ValorPagamento = 0;
            txtCartaoDebitoCx3.Text = "0";
            debitocx3.ValorPagamento = 0;
            txtCartaoCreditoCx3.Text = "0";
            creditocx3.ValorPagamento = 0;
            txtChequeCx3.Text = "0";
            chequecx3.ValorPagamento = 0;
            txtValeCx3.Text = "0";
            valecx3.ValorPagamento = 0;
            txtBoletoCx3.Text = "0";
            boletocx3.ValorPagamento = 0;
            txtAcrescimoCx3.Text = "0";
            btnFinalizaVendaCx3.Enabled = false;
        }
        /*---------------------------------------------------  ACRESCIMO CAIXA AUX -------------------------------------------------------*/ 
        private void txtAcrescimoAux_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoAux.Text == "")
            {
                txtAcrescimoAux.Text = "0";
            }
            caixaAux.PdvAcrescimo = Convert.ToDouble(txtAcrescimoAux.Text);
            caixaAux.TotalTempPdv = Convert.ToDouble(txtTotalCx3.Text);
            caixaAux.TotalPdvAcrescimo = caixaCalculo.AdicionaAcrescimo(caixaAux);
            txtTotalAux.Text = caixaAux.TotalPdvAcrescimo.ToString();
            txtFaltaAux.Text = txtTotalAux.Text;
        }
        private void txtAcrescimoAux_Enter(object sender, EventArgs e)
        {
            txtFaltaAux.Text = txtTotalAux.Text;
            txtDinheiroAux.Text = "0";
            dinheiroAux.ValorPagamento = 0;
            txtDebitoAux.Text = "0";
            debitocxAux.ValorPagamento = 0;
            txtCreditoAux.Text = "0";
            creditocxAux.ValorPagamento = 0;
            txtChequeAux.Text = "0";
            chequecxAux.ValorPagamento = 0;
            txtValeAux.Text = "0";
            valecxAux.ValorPagamento = 0;
            txtBoletoAux.Text = "0";
            boletocxAux.ValorPagamento = 0;
            txtAcrescimoAux.Text = "0";
            btnFinalizaAux.Enabled = false;
        }   
        /********************************************************** CALCULOS DESCONTOS PERCENT **********************************************************/
        /*---------------------------------------------------------   DESCONTO PERCENTUAL CAIXA 1 -----------------------------------------------------------*/

        private void txtDescontoPercent_Leave(object sender, EventArgs e)
        {
            if (txtDescontoPercentCx1.Text == "")
            {
                txtDescontoPercentCx1.Text = "0";
            }
            if (caixa1.DescontoPercent == 0)
            {
                caixa1.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx1.Text);
                caixa1.TotalTempPdv = Convert.ToDouble(txtTotalCx1.Text);
                txtTotalCx1.Text = caixaCalculo.DescontoPercentual(caixa1).ToString();
                txtFaltaCx1.Text = txtTotalCx1.Text;
            }      
        }

        private void txtDescontoPercentCx1_Enter(object sender, EventArgs e)
        {
            txtDinheiroCx1.Text = "0";
            dinheirocx1.ValorPagamento = 0;
            txtDebitoCx1.Text = "0";
            debitocx1.ValorPagamento = 0;
            txtCreditoCx1.Text = "0";
            creditocx1.ValorPagamento = 0;
            txtChequeCx1.Text = "0";
            chequecx1.ValorPagamento = 0;
            txtValeCx1.Text = "0";
            valecx1.ValorPagamento = 0;
            txtBoletoCx1.Text = "0";
            boletocx1.ValorPagamento = 0;
            txtDescontoPercentCx1.Text = "0";
            caixa1.DescontoPercent = 0;
        }
        /*--------------------------------------------- DESCONTO PERCENTUAL CAIXA2 ----------------------------------------------------*/

        private void txtDescontoPercentCx2_Leave(object sender, EventArgs e)
        {
            if (txtDescontoPercentCx2.Text == "")
            {
                txtDescontoPercentCx2.Text = "0";
            }
            if (caixa2.DescontoPercent == 0)
            {
                caixa2.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx2.Text);
                caixa2.TotalTempPdv = Convert.ToDouble(txtTotalCx2.Text);
                txtTotalCx2.Text = caixaCalculo.DescontoPercentual(caixa2).ToString();
                txtFaltaCx2.Text = txtTotalCx2.Text;
            }
        }

        private void txtDescontoPercentCx2_Enter(object sender, EventArgs e)
        {
            txtDinheiroCx2.Text = "0";
            dinheirocx2.ValorPagamento = 0;
            txtCartaoDebitoCx2.Text = "0";
            debitocx2.ValorPagamento = 0;
            txtCartaoCreditoCx2.Text = "0";
            creditocx2.ValorPagamento = 0;
            txtChequeCx2.Text = "0";
            chequecx2.ValorPagamento = 0;
            txtValeCx2.Text = "0";
            valecx2.ValorPagamento = 0;
            txtBoletoCx2.Text = "0";
            boletocx2.ValorPagamento = 0;
            txtDescontoPercentCx2.Text = "0";
            caixa2.DescontoPercent = 0;
        }
 
        /*--------------------------------------------- DESCONTO PERCENTUAL CAIXA3 ----------------------------------------------------*/
        private void txtDescontoPercentCx3_Leave(object sender, EventArgs e)
        {
            if (txtDescontoPercentCx3.Text == "")
            {
                txtDescontoPercentCx3.Text = "0";
            }
            if (caixa3.DescontoPercent == 0)
            {
                caixa3.DescontoPercent = Convert.ToDouble(txtDescontoPercentCx3.Text);
                caixa3.TotalTempPdv = Convert.ToDouble(txtTotalCx3.Text);
                txtTotalCx3.Text = caixaCalculo.DescontoPercentual(caixa3).ToString();
                txtFaltaCx3.Text = txtTotalCx3.Text;
            }
        }
        private void txtDescontoPercentCx3_Enter(object sender, EventArgs e)
        {
            txtDinheiroCx3.Text = "0";
            dinheirocx3.ValorPagamento = 0;
            txtCartaoDebitoCx3.Text = "0";
            debitocx3.ValorPagamento = 0;
            txtCartaoCreditoCx3.Text = "0";
            creditocx3.ValorPagamento = 0;
            txtChequeCx3.Text = "0";
            chequecx3.ValorPagamento = 0;
            txtValeCx3.Text = "0";
            valecx3.ValorPagamento = 0;
            txtBoletoCx3.Text = "0";
            boletocx3.ValorPagamento = 0;
            txtDescontoPercentCx3.Text = "0";
            caixa3.DescontoPercent = 0;
        }
        /*--------------------------------------------- DESCONTO PERCENTUAL CAIXA 4 AUX ---------------------------------------------------*/

        private void txtAuxDescontoPercent_Leave(object sender, EventArgs e)
        {
            if (txtAuxDescontoPercent.Text == "")
            {
                txtAuxDescontoPercent.Text = "0";
            }
            if (caixaAux.DescontoPercent == 0)
            {
                caixaAux.DescontoPercent = Convert.ToDouble(txtAuxDescontoPercent.Text);
                caixaAux.TotalTempPdv = Convert.ToDouble(txtTotalAux.Text);
                txtTotalAux.Text = caixaCalculo.DescontoPercentual(caixaAux).ToString();
                txtFaltaAux.Text = txtTotalAux.Text;
            }
        }

        private void txtAuxDescontoPercent_Enter(object sender, EventArgs e)
        {     
            txtDinheiroAux.Text = "0";
            dinheiroAux.ValorPagamento = 0;
            txtDebitoAux.Text = "0";
            debitocxAux.ValorPagamento = 0;
            txtCreditoAux.Text = "0";
            creditocxAux.ValorPagamento = 0;
            txtChequeAux.Text = "0";
            chequecxAux.ValorPagamento = 0;
            txtValeAux.Text = "0";
            valecxAux.ValorPagamento = 0;
            txtBoletoAux.Text = "0";
            boletocxAux.ValorPagamento = 0;
            txtAuxDescontoPercent.Text = "0";
            caixaAux.DescontoPercent = 0;
        }
        /********************************************************  CALCULOS DESCONTOS UNITÁRIOS    *************************************************************/
        /*------------------------------------------------------------- DESCONTO UNITÁRIO CAIXA1 --------------------------------------------------------------------*/
        private void txtDescontoUnitario_Leave(object sender, EventArgs e)
        {
            if (txtDescontoUnitarioCx1.Text == "")
            {
                txtDescontoUnitarioCx1.Text = "0";
            }
            else
            {
                if (caixa1.DescontoUnitario == 0)
                {
                    caixa1.DescontoUnitario = Convert.ToDouble(txtDescontoUnitarioCx1.Text);
                    caixa1.TotalTempPdv = Convert.ToDouble(txtTotalCx1.Text);
                    txtTotalCx1.Text = caixaCalculo.DescontoUnitario(caixa1).ToString();
                    txtFaltaCx1.Text = txtTotalCx1.Text;
                }
                else
                {
                    return;
                }
            }
        }
        private void txtDescontoUnitarioCx1_Enter(object sender, EventArgs e)
        {
            txtDinheiroCx1.Text = "0";
            dinheirocx1.ValorPagamento = 0;
            txtDebitoCx1.Text = "0";
            debitocx1.ValorPagamento = 0;
            txtCreditoCx1.Text = "0";
            creditocx1.ValorPagamento = 0;
            txtChequeCx1.Text = "0";
            chequecx1.ValorPagamento = 0;
            txtValeCx1.Text = "0";
            valecx1.ValorPagamento = 0;
            txtBoletoCx1.Text = "0";
            boletocx1.ValorPagamento = 0;
            txtDescontoUnitarioCx1.Text = "0";
            caixa1.DescontoUnitario = 0;

            if (Convert.ToDouble(txtDescontoPercentCx1.Text) != 0)
            {
                txtTotalCx1.Text = caixa1.TotalPdvDescontPercent.ToString();
            }
            else if (Convert.ToDouble(txtAcrescimoCx1.Text) != 0)
            {
                txtTotalCx1.Text = caixa1.TotalPdvAcrescimo.ToString();
            }
        }

        /*--------------------------------------------- DESCONTO UNITÁRIO CAIXA2 ----------------------------------------------------*/
        private void txtDescontoUnitarioCx2_Leave(object sender, EventArgs e)
        {
            if (txtDescontoUnitarioCx2.Text == "")
            {
                txtDescontoUnitarioCx2.Text = "0";
            }
            else
            {
                if (caixa2.DescontoUnitario == 0)
                {
                    caixa2.DescontoUnitario = Convert.ToDouble(txtDescontoUnitarioCx2.Text);
                    caixa2.TotalTempPdv = Convert.ToDouble(txtTotalCx2.Text);
                    txtTotalCx2.Text = caixaCalculo.DescontoUnitario(caixa2).ToString();
                    txtFaltaCx2.Text = txtTotalCx2.Text;
                }
                else
                {
                    return;
                }
            }
        }
        private void txtDescontoUnitarioCx2_Enter(object sender, EventArgs e)
        {
            txtDinheiroCx2.Text = "0";
            dinheirocx2.ValorPagamento = 0;
            txtCartaoDebitoCx2.Text = "0";
            debitocx2.ValorPagamento = 0;
            txtCartaoCreditoCx2.Text = "0";
            creditocx2.ValorPagamento = 0;
            txtChequeCx2.Text = "0";
            chequecx2.ValorPagamento = 0;
            txtValeCx2.Text = "0";
            valecx2.ValorPagamento = 0;
            txtBoletoCx2.Text = "0";
            boletocx2.ValorPagamento = 0;
            txtDescontoUnitarioCx2.Text = "0";           
            caixa2.DescontoUnitario = 0;

            if (Convert.ToDouble(txtDescontoPercentCx2.Text) != 0)
            {
                txtTotalCx2.Text = caixa2.TotalPdvDescontPercent.ToString();
            }
            else if (Convert.ToDouble(txtAcrescimoCx2.Text) != 0)
            {
                txtTotalCx2.Text = caixa2.TotalPdvAcrescimo.ToString();
            }
        }         
        /*--------------------------------------------- DESCONTO UNITÁRIO CAIXA3----------------------------------------------------*/
        private void txtDescontoUnitarioCx3_Leave(object sender, EventArgs e)
        {
            if (txtDescontoUnitarioCx3.Text == "")
            {
                txtDescontoUnitarioCx3.Text = "0";
            }
            else
            {
                if (caixa3.DescontoUnitario == 0)
                {
                    caixa3.DescontoUnitario = Convert.ToDouble(txtDescontoUnitarioCx3.Text);
                    caixa3.TotalTempPdv = Convert.ToDouble(txtTotalCx3.Text);
                    txtTotalCx3.Text = caixaCalculo.DescontoUnitario(caixa3).ToString();
                    txtFaltaCx3.Text = txtTotalCx3.Text;
                }
                else
                {
                    return;
                }
            }
        }
        private void txtDescontoUnitarioCx3_Enter(object sender, EventArgs e)
        {
            txtDinheiroCx3.Text = "0";
            dinheirocx3.ValorPagamento = 0;
            txtCartaoDebitoCx3.Text = "0";
            debitocx3.ValorPagamento = 0;
            txtCartaoCreditoCx3.Text = "0";
            creditocx3.ValorPagamento = 0;
            txtChequeCx3.Text = "0";
            chequecx3.ValorPagamento = 0;
            txtValeCx3.Text = "0";
            valecx3.ValorPagamento = 0;
            txtBoletoCx3.Text = "0";
            boletocx3.ValorPagamento = 0;
            txtDescontoUnitarioCx3.Text = "0";         
            caixa3.DescontoUnitario = 0;

            if (Convert.ToDouble(txtDescontoPercentCx3.Text) != 0)
            {
                txtTotalCx3.Text = caixa3.TotalPdvDescontPercent.ToString();
            }
            else if (Convert.ToDouble(txtAcrescimoCx3.Text) != 0)
            {
                txtTotalCx3.Text = caixa3.TotalPdvAcrescimo.ToString();
            }
        }
        /*--------------------------------------------- DESCONTO UNITÁRIO CAIXA 4 ----------------------------------------------------*/
        private void txtAuxDescontoUnit_Leave(object sender, EventArgs e)
        {
            if (txtAuxDescontoUnit.Text == "")
            {
                txtAuxDescontoUnit.Text = "0";
            }
            else
            {
                if (caixaAux.DescontoUnitario == 0)
                {
                    caixaAux.DescontoUnitario = Convert.ToDouble(txtAuxDescontoUnit.Text);
                    caixaAux.TotalTempPdv = Convert.ToDouble(txtTotalAux.Text);
                    txtTotalCx3.Text = caixaCalculo.DescontoUnitario(caixaAux).ToString();
                    txtFaltaAux.Text = txtTotalAux.Text;
                }
                else
                {
                    return;
                }
            }
        }

        private void txtAuxDescontoUnit_Enter(object sender, EventArgs e)
        {
            txtDinheiroAux.Text = "0";
            dinheiroAux.ValorPagamento = 0;
            txtDebitoAux.Text = "0";
            debitocxAux.ValorPagamento = 0;
            txtCreditoAux.Text = "0";
            creditocxAux.ValorPagamento = 0;
            txtChequeAux.Text = "0";
            chequecxAux.ValorPagamento = 0;
            txtValeAux.Text = "0";
            valecxAux.ValorPagamento = 0;
            txtBoletoAux.Text = "0";
            boletocxAux.ValorPagamento = 0;
            txtDebitoAux.Text = "0";
            caixaAux.DescontoUnitario = 0;

            if (Convert.ToDouble(txtAuxDescontoPercent.Text) != 0)
            {
                txtTotalAux.Text = caixaAux.TotalPdvDescontPercent.ToString();
            }
            else if (Convert.ToDouble(txtAcrescimoAux.Text) != 0)
            {
                txtTotalAux.Text = caixaAux.TotalPdvAcrescimo.ToString();
            }
        }

        /********************************************ADIÇÃO E EXCLUSÃO FORMA DE PAGAMENTO CAIXA 1 ******************************************/
        /********------------------------------------------------ + DINHEIRO  ---------------------------------------*********/
        private void txtDinheiroCx1_Leave(object sender, EventArgs e)
        {
            if (txtDinheiroCx1.Text == "")
            {
                txtDinheiroCx1.Text = "0";
            }
            dinheirocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            dinheirocx1.ValorPagamento = Convert.ToDouble(txtDinheiroCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheirocx1);
            if (falta < 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                txtTrocoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = false;
            }
        }
        /*****------------------------------------------------------ - DINHEIRO -----------------------------------------------*****/
        private void txtDinheiroCx1_Enter(object sender, EventArgs e)
        {           
                dinheirocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
                dinheirocx1.ValorPagamento = Convert.ToDouble(txtDinheiroCx1.Text);
                double falta = pagamentoBLL.RemovePagamento(dinheirocx1);
                txtFaltaCx1.Text = falta.ToString();                  
        }
        /********------------------------------------------------ TXTDINHEIRO DO CAIXA 2 ---------------------------------------*********/
        /********------------------------------------------------ + DINHEIRO  ---------------------------------------*********/
        private void txtDinheiroCx2_Leave(object sender, EventArgs e)
        {
            if (txtDinheiroCx2.Text == "")
            {
                txtDinheiroCx2.Text = "0";
            }
            dinheirocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            dinheirocx2.ValorPagamento = Convert.ToDouble(txtDinheiroCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheirocx2);
            if (falta < 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                txtTrocoCx2.Text = "0";
                btnFinalizaVendaCx1.Enabled = false;
            }
        }
        /*****------------------------------------------------------ - DINHEIRO -----------------------------------------------*****/
        private void txtDinheiroCx2_Enter(object sender, EventArgs e)
        {
            dinheirocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            dinheirocx2.ValorPagamento = Convert.ToDouble(txtDinheiroCx2.Text);
            double falta = pagamentoBLL.RemovePagamento(dinheirocx2);
            txtFaltaCx2.Text = falta.ToString();
        }


        /********------------------------------------------------ TXTDINHEIRO DO CAIXA 3 ---------------------------------------*********/
        /********------------------------------------------------ + DINHEIRO  ---------------------------------------*********/
        private void txtDinheiroCx3_Leave(object sender, EventArgs e)
        {
            if (txtDinheiroCx3.Text == "")
            {
                txtDinheiroCx3.Text = "0";
            }

            dinheirocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            dinheirocx3.ValorPagamento = Convert.ToDouble(txtDinheiroCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheirocx3);
            if (falta < 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                txtTrocoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = false;
            }
        }
        /********------------------------------------------------ - DINHEIRO  ---------------------------------------*********/
        private void txtDinheiroCx3_Enter(object sender, EventArgs e)
        {
            dinheirocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            dinheirocx3.ValorPagamento = Convert.ToDouble(txtDinheiroCx3.Text);
            double falta = pagamentoBLL.RemovePagamento(dinheirocx3);
            txtFaltaCx3.Text = falta.ToString();
        }

        /********------------------------------------------------ TXTDINHEIRO DO CAIXA 3 ---------------------------------------*********/
        /********------------------------------------------------ + DINHEIRO  ---------------------------------------*********/
        private void txtDinheiroAux_Leave(object sender, EventArgs e)
        {
            if (txtDinheiroAux.Text == "")
            {
                txtDinheiroAux.Text = "0";
            }
            dinheiroAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            dinheiroAux.ValorPagamento = Convert.ToDouble(txtDinheiroAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheiroAux);
            if (falta < 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaAux.Text = falta.ToString();
                txtTrocoAux.Text = "0";
                btnFinalizaAux.Enabled = false;
            }
        }
        /********------------------------------------------------ - DINHEIRO  ---------------------------------------*********/
        private void txtDinheiroAux_Enter(object sender, EventArgs e)
        {
            dinheiroAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            dinheiroAux.ValorPagamento = Convert.ToDouble(txtDinheiroAux.Text);
            double falta = pagamentoBLL.RemovePagamento(dinheiroAux);
            txtFaltaAux.Text = falta.ToString();
        }

        /***-------------------------------------------------- ALTERAÇÃO VALOR CAMPO CARTÃO DÉBITO --------------------------- ***/
        /*********--------------------------------------------          TXT DEBITO DO CAIXA 1         ----------------------------------*******/
        private void txtDebito_Leave(object sender, EventArgs e)
        {
            if (txtCartaoDebitoCx2.Text == "")
            {
                txtCartaoDebitoCx2.Text = "0";
            }
            debitocx1.ValorPagamento = Convert.ToDouble(txtDebitoCx1.Text);
            debitocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocx1);

            if (falta < 0)
            {
                txtFaltaCx1.Text = "0";
                txtDebitoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                txtTrocoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = false;
            }
        }
        private void txtDebitoCx1_Enter(object sender, EventArgs e)
        {

                debitocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
                debitocx1.ValorPagamento = Convert.ToDouble(txtDebitoCx1.Text);
                double falta = pagamentoBLL.RemovePagamento(debitocx1);
                txtFaltaCx1.Text = falta.ToString();
        
        }
        /*********------------------------------------------------TXT DEBITO DO CAIXA 2 ------------------------------------------*******/
        private void txtCartaoDebitoCx2_Leave(object sender, EventArgs e)
        {
            if (txtCartaoDebitoCx2.Text == "")
            {
                txtCartaoDebitoCx2.Text = "0";
            }
            debitocx2.ValorPagamento = Convert.ToDouble(txtCartaoDebitoCx2.Text);
            debitocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocx2);

            if (falta < 0)
            {
                txtFaltaCx2.Text = "0";
                txtCartaoDebitoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                txtTrocoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = false;
            }
        }

        private void txtCartaoDebitoCx2_Enter(object sender, EventArgs e)
        {
                debitocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
                debitocx2.ValorPagamento = Convert.ToDouble(txtCartaoDebitoCx2.Text);
                double falta = pagamentoBLL.RemovePagamento(debitocx2);
                txtFaltaCx2.Text = falta.ToString();          
        }

        /*********------------------------------------------------TXT DEBITO DO CAIXA 3 ------------------------------------------*******/
        private void txtCartaoDebitoCx3_Leave(object sender, EventArgs e)
        {
            if (txtCartaoDebitoCx3.Text == "")
            {
                txtCartaoDebitoCx3.Text = "0";
            }
            debitocx3.ValorPagamento = Convert.ToDouble(txtCartaoDebitoCx3.Text);
            debitocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocx3);

            if (falta < 0)
            {
                txtFaltaCx3.Text = "0";
                txtCartaoDebitoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                txtTrocoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = false;
            }
        }
        private void txtCartaoDebitoCx3_Enter(object sender, EventArgs e)
        {           
                debitocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
                debitocx3.ValorPagamento = Convert.ToDouble(txtCartaoDebitoCx3.Text);
                double falta = pagamentoBLL.RemovePagamento(debitocx3);
                txtFaltaCx3.Text = falta.ToString();         
        }
        /*********------------------------------------------------TXT DEBITO DO CAIXA AUX ------------------------------------------*******/

        private void txtDebitoAux_Leave(object sender, EventArgs e)
        {
            if (txtDebitoAux.Text == "")
            {
                txtDebitoAux.Text = "0";
            }
            debitocxAux.ValorPagamento = Convert.ToDouble(txtDebitoAux.Text);
            debitocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocxAux);

            if (falta < 0)
            {
                txtFaltaAux.Text = "0";
                txtDebitoAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaAux.Text = falta.ToString();
                txtTrocoAux.Text = "0";
                btnFinalizaAux.Enabled = false;
            }
        }
        private void txtDebitoAux_Enter(object sender, EventArgs e)
        {
            debitocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            debitocxAux.ValorPagamento = Convert.ToDouble(txtCreditoAux.Text);
            double falta = pagamentoBLL.RemovePagamento(debitocxAux);
            txtFaltaAux.Text = falta.ToString();
        }

        /**************************************************** ALTERAÇÃO VALOR CAMPO CARTÃO CRÉDITO*****************************************/
        /*********------------------------------------------------TXT CREDITO CAIXA 1------------------------------------------*******/
        private void txtCredito_Leave(object sender, EventArgs e)
        {
            if (txtCreditoCx1.Text == "")
            {
                txtCreditoCx1.Text = "0";
            }
            creditocx1.ValorPagamento = Convert.ToDouble(txtCreditoCx1.Text);
            creditocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocx1);

            if (falta < 0)
            {
                txtFaltaCx1.Text = "0";
                txtCreditoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                txtTrocoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = false;
            }
        }

        private void txtCreditoCx1_Enter(object sender, EventArgs e)
        {
                creditocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
                creditocx1.ValorPagamento = Convert.ToDouble(txtCreditoCx1.Text);
                double falta = pagamentoBLL.RemovePagamento(creditocx1);
                txtFaltaCx1.Text = falta.ToString();   
        }
        /*********------------------------------------------------TXT CREDITO CAIXA 2------------------------------------------*******/
        private void txtCartaoCreditoCx2_Leave(object sender, EventArgs e)
        {
            if (txtCartaoCreditoCx2.Text == "")
            {
                txtCartaoCreditoCx2.Text = "0";
            }
            creditocx2.ValorPagamento = Convert.ToDouble(txtCartaoCreditoCx2.Text);
            creditocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocx2);

            if (falta < 0)
            {
                txtFaltaCx2.Text = "0";
                txtCartaoCreditoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                txtTrocoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = false;
            }
        }

        private void txtCartaoCreditoCx2_Enter(object sender, EventArgs e)
        {
                creditocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
                creditocx2.ValorPagamento = Convert.ToDouble(txtCartaoCreditoCx2.Text);
                double falta = pagamentoBLL.RemovePagamento(creditocx2);
                txtFaltaCx2.Text = falta.ToString();     
        }
        /*********------------------------------------------------TXT CREDITO CAIXA 3------------------------------------------*******/
        private void txtCartaoCreditoCx3_Leave(object sender, EventArgs e)
        {
            if (txtCartaoCreditoCx3.Text == "")
            {
                txtCartaoCreditoCx3.Text = "0";
            }
            creditocx3.ValorPagamento = Convert.ToDouble(txtCartaoCreditoCx3.Text);
            creditocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocx3);

            if (falta < 0)
            {
                txtFaltaCx3.Text = "0";
                txtCartaoCreditoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                txtTrocoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = false;
            }
        }
        private void txtCartaoCreditoCx3_Enter(object sender, EventArgs e)
        {
                creditocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
                creditocx3.ValorPagamento = Convert.ToDouble(txtCartaoCreditoCx3.Text);
                double falta = pagamentoBLL.RemovePagamento(creditocx3);
                txtFaltaCx3.Text = falta.ToString();            
        }
        /*********------------------------------------------------TXT CREDITO CAIXA 4 AUX------------------------------------------*******/
        private void txtCreditoAux_Leave(object sender, EventArgs e)
        {
            if (txtCreditoAux.Text == "")
            {
                txtCreditoAux.Text = "0";
            }
            creditocxAux.ValorPagamento = Convert.ToDouble(txtCreditoAux.Text);
            creditocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocxAux);

            if (falta < 0)
            {
                txtFaltaAux.Text = "0";
                txtCreditoAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaAux.Text = falta.ToString();
                txtTrocoAux.Text = "0";
                btnFinalizaAux.Enabled = false;
            }
        }

        private void txtCreditoAux_Enter(object sender, EventArgs e)
        {
            creditocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            creditocxAux.ValorPagamento = Convert.ToDouble(txtCreditoAux.Text);
            double falta = pagamentoBLL.RemovePagamento(creditocxAux);
            txtFaltaAux.Text = falta.ToString();
        }

        /******************************************************* ALTERAÇÃO VALOR CAMPO VALE **********************************************/
        /*********------------------------------------------------           TXT VALE CAIXA 1             ------------------------------------------*******/

        private void txtVale_Leave(object sender, EventArgs e)
        {
            if (txtValeCx1.Text == "")
            {
                txtValeCx1.Text = "0";
            }
            valecx1.ValorPagamento = Convert.ToDouble(txtValeCx1.Text);
            valecx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(valecx1);

            if (falta < 0)
            {
                txtFaltaCx1.Text = "0";
                txtValeCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                txtTrocoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = false;
            }
        }
        private void txtValeCx1_Enter(object sender, EventArgs e)
        {
                valecx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
                valecx1.ValorPagamento = Convert.ToDouble(txtValeCx1.Text);
                double falta = pagamentoBLL.RemovePagamento(valecx1);
                txtFaltaCx1.Text = falta.ToString();       
        }

        /*********------------------------------------------------           TXT VALE CAIXA 2             ------------------------------------------*******/
        private void txtValeCx2_Leave(object sender, EventArgs e)
        {
            if (txtValeCx2.Text == "")
            {
                txtValeCx2.Text = "0";
            }
            valecx2.ValorPagamento = Convert.ToDouble(txtValeCx2.Text);
            valecx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(valecx2);

            if (falta < 0)
            {
                txtFaltaCx2.Text = "0";
                txtValeCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                txtTrocoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = false;
            }
        }

        private void txtValeCx2_Enter(object sender, EventArgs e)
        {
                valecx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
                valecx2.ValorPagamento = Convert.ToDouble(txtValeCx2.Text);
                double falta = pagamentoBLL.RemovePagamento(valecx2);
                txtFaltaCx2.Text = falta.ToString();
        }

        /*********------------------------------------------------           TXT VALE CAIXA 3             ------------------------------------------*******/
        private void txtValeCx3_Leave(object sender, EventArgs e)
        {
            if (txtValeCx3.Text == "")
            {
                txtValeCx3.Text = "0";
            }
            valecx3.ValorPagamento = Convert.ToDouble(txtValeCx3.Text);
            valecx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(valecx3);
        
            if (falta < 0)
            {
                txtFaltaCx3.Text = "0";
                txtValeCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                txtTrocoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = false;
            }
        }

        private void txtValeCx3_Enter(object sender, EventArgs e)
        {
                valecx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
                valecx3.ValorPagamento = Convert.ToDouble(txtValeCx3.Text);
                double falta = pagamentoBLL.RemovePagamento(valecx3);
                txtFaltaCx3.Text = falta.ToString();
        }
        /*********------------------------------------------------           TXT VALE CAIXA 4             ------------------------------------------*******/
        private void txtValeAux_Leave(object sender, EventArgs e)
        {
            if (txtValeAux.Text == "")
            {
                txtValeAux.Text = "0";
            }
            valecxAux.ValorPagamento = Convert.ToDouble(txtValeAux.Text);
            valecxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(valecxAux);

            if (falta < 0)
            {
                txtFaltaAux.Text = "0";
                txtValeAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaAux.Text = falta.ToString();
                txtTrocoAux.Text = "0";
                btnFinalizaAux.Enabled = false;
            }
        }

        private void txtValeAux_Enter(object sender, EventArgs e)
        {
            valecxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            valecxAux.ValorPagamento = Convert.ToDouble(txtValeAux.Text);
            double falta = pagamentoBLL.RemovePagamento(valecxAux);
            txtFaltaAux.Text = falta.ToString();
        }
        /******************************************** EVENTO LEAVE/ENTER DO CAMPO CHEQUE ******************************************/
        /*----------------------------------------------------   TXTCHEQUE  1 --------------------------------------------*/
        private void txtCheque_Leave(object sender, EventArgs e)
        {
            if (txtChequeCx1.Text == "")
            {
                txtChequeCx1.Text = "0";
            }
            chequecx1.ValorPagamento = Convert.ToDouble(txtChequeCx1.Text);
            chequecx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecx1);

            if (falta < 0)
            {
                txtFaltaCx1.Text = "0";
                txtChequeCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                txtTrocoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = false;
            }
        }
        private void txtChequeCx1_Enter(object sender, EventArgs e)
        {
                chequecx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
                chequecx1.ValorPagamento = Convert.ToDouble(txtChequeCx1.Text);
                double falta = pagamentoBLL.RemovePagamento(chequecx1);
                txtFaltaCx1.Text = falta.ToString();
        }
        /*-------------------------------------------   TXTCHEQUE  2 -----------------------------------------*/
        private void txtChequeCx2_Leave(object sender, EventArgs e)
        {
            if (txtChequeCx2.Text == "")
            {
                txtChequeCx2.Text = "0";
            }
            chequecx2.ValorPagamento = Convert.ToDouble(txtChequeCx2.Text);
            chequecx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecx2);
            if (falta < 0)
            {
                txtFaltaCx2.Text = "0";
                txtChequeCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                txtTrocoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = false;
            }
        }
        private void txtChequeCx2_Enter(object sender, EventArgs e)
        {
                chequecx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
                chequecx2.ValorPagamento = Convert.ToDouble(txtChequeCx2.Text);
                double falta = pagamentoBLL.RemovePagamento(chequecx2);
                txtFaltaCx2.Text = falta.ToString();         
        }
        /*----------------------------------------------- TXTCHEQUE    3 ----------------------------------------------------*/
        private void txtChequeCx3_Leave(object sender, EventArgs e)
        {
            if (txtChequeCx3.Text == "")
            {
                txtChequeCx3.Text = "0";
            }
            chequecx3.ValorPagamento = Convert.ToDouble(txtChequeCx3.Text);
            chequecx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecx3);
         
            if (falta < 0)
            {
                txtFaltaCx3.Text = "0";
                txtChequeCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                txtTrocoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = false;
            }
        }
        private void txtChequeCx3_Enter(object sender, EventArgs e)
        {
                chequecx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
                chequecx3.ValorPagamento = Convert.ToDouble(txtChequeCx3.Text);
                double falta = pagamentoBLL.RemovePagamento(chequecx3);
                txtFaltaCx3.Text = falta.ToString();
        }
        /*--------------------------------------------------------- TXTCHEQUE 4 ----------------------------------------------------*/
        private void txtChequeAux_Leave(object sender, EventArgs e)
        {
            if (txtChequeAux.Text == "")
            {
                txtChequeAux.Text = "0";
            }
            chequecxAux.ValorPagamento = Convert.ToDouble(txtChequeAux.Text);
            chequecxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecxAux);
            if (falta < 0)
            {
                txtFaltaAux.Text = "0";
                txtChequeAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaAux.Text = falta.ToString();
                txtTrocoAux.Text = "0";
                btnFinalizaAux.Enabled = false;
            }
        }

        private void txtChequeAux_Enter(object sender, EventArgs e)
        {
            chequecxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            chequecxAux.ValorPagamento = Convert.ToDouble(txtValeAux.Text);
            double falta = pagamentoBLL.RemovePagamento(chequecxAux);
            txtFaltaAux.Text = falta.ToString();
        }

        /************************************************ EVENTO LEAVE/ENTER BOLETO  ************************************************/
        private void txtBoletoCx1_Leave(object sender, EventArgs e)
        {
            if (txtBoletoCx1.Text == "")
            {
                txtBoletoCx1.Text = "0";
            }
            boletocx1.ValorPagamento = Convert.ToDouble(txtBoletoCx1.Text);
            boletocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocx1);
           
            if (falta < 0)
            {
                txtFaltaCx1.Text = "0";
                txtChequeCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                txtTrocoCx1.Text = "0";
                btnFinalizaVendaCx1.Enabled = false;
            }
        }

        private void txtBoletoCx1_Enter(object sender, EventArgs e)
        {
                boletocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
                boletocx1.ValorPagamento = Convert.ToDouble(txtBoletoCx1.Text);
                double falta = pagamentoBLL.RemovePagamento(boletocx1);
                txtFaltaCx1.Text = falta.ToString();
        }
        /*--------------------------------------------------TXT BOLETO CAIXA 2 ------------------------------------------*/
        private void txtBoletoCx2_Leave(object sender, EventArgs e)
        {
            if (txtBoletoCx2.Text == "")
            {
                txtBoletoCx2.Text = "0";
            }
            boletocx2.ValorPagamento = Convert.ToDouble(txtBoletoCx2.Text);
            boletocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocx2);
          
            if (falta < 0)
            {
                txtFaltaCx2.Text = "0";
                txtBoletoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                txtTrocoCx2.Text = "0";
                btnFinalizaVendaCx2.Enabled = false;
            }
        }

        private void txtBoletoCx2_Enter(object sender, EventArgs e)
        {
                boletocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
                boletocx2.ValorPagamento = Convert.ToDouble(txtBoletoCx2.Text);
                double falta = pagamentoBLL.RemovePagamento(boletocx2);
                txtFaltaCx2.Text = falta.ToString();           
        }
        /*------------------------------------------------- TXTBOLETO CAIXA 3 ---------------------------------------------------*/
        private void txtBoletoCx3_Leave(object sender, EventArgs e)
        {
            if (txtBoletoCx3.Text == "")
            {
                txtBoletoCx3.Text = "0";
            }
            boletocx3.ValorPagamento = Convert.ToDouble(txtBoletoCx3.Text);
            boletocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocx3);

            if (falta < 0)
            {
                txtFaltaCx3.Text = "0";
                txtChequeCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                txtTrocoCx3.Text = "0";
                btnFinalizaVendaCx3.Enabled = false;
            }
        }
        private void txtBoletoCx3_Enter(object sender, EventArgs e)
        {
                boletocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
                boletocx3.ValorPagamento = Convert.ToDouble(txtBoletoCx3.Text);
                double falta = pagamentoBLL.RemovePagamento(boletocx3);
                txtFaltaCx3.Text = falta.ToString();
        }
        /*------------------------------------------------- TXTBOLETO CAIXA 4 ---------------------------------------------------*/
        private void txtBoletoAux_Leave(object sender, EventArgs e)
        {
            if (txtBoletoAux.Text == "")
            {
                txtBoletoAux.Text = "0";
            }
            boletocxAux.ValorPagamento = Convert.ToDouble(txtBoletoAux.Text);
            boletocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocxAux);

            if (falta < 0)
            {
                txtFaltaAux.Text = "0";
                txtChequeAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta == 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
                btnFinalizaAux.Enabled = true;
            }
            else if (falta > 0)
            {
                txtFaltaAux.Text = falta.ToString();
                txtTrocoAux.Text = "0";
                btnFinalizaAux.Enabled = false;
            }
        }
        private void txtBoletoAux_Enter(object sender, EventArgs e)
        {
            boletocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            boletocxAux.ValorPagamento = Convert.ToDouble(txtBoletoAux.Text);
            double falta = pagamentoBLL.RemovePagamento(boletocxAux);
            txtFaltaCx3.Text = falta.ToString();
        }

        /************************* CLICK DO BOTÃO PREENCHIMENTO FORMA PAGAMENTO CAIXA1 ************************/
        private void btnDinheiroCx1_Click(object sender, EventArgs e)
        {
            txtDinheiroCx1.Text = txtFaltaCx1.Text;
            dinheirocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            dinheirocx1.ValorPagamento = Convert.ToDouble(txtDinheiroCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheirocx1);
            if (falta < 0)
            {
                txtTrocoCx1.Text = falta.ToString();
                txtFaltaCx1.Text = "0";
            }
            else if (falta == 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                btnFinalizaVendaCx1.Enabled = true;
            }
        }
        private void btnDebitoCx1_Click(object sender, EventArgs e)
        {
            txtDebitoCx1.Text = txtFaltaCx1.Text;
            debitocx1.ValorPagamento = Convert.ToDouble(txtDebitoCx1.Text);
            debitocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocx1);
            if (falta == 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                btnFinalizaVendaCx1.Enabled = true;
            }
        }

        private void btnCreditoCx1_Click(object sender, EventArgs e)
        {
            txtCreditoCx1.Text = txtFaltaCx1.Text;
            creditocx1.ValorPagamento = Convert.ToDouble(txtCreditoCx1.Text);
            creditocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocx1);
            if (falta == 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                btnFinalizaVendaCx1.Enabled = true;
            }
        }

        private void btnChequeCx1_Click(object sender, EventArgs e)
        {
            txtChequeCx1.Text = txtFaltaCx1.Text;
            chequecx1.ValorPagamento = Convert.ToDouble(txtChequeCx1.Text);
            chequecx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecx1);
            if (falta == 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                btnFinalizaVendaCx1.Enabled = true;
            }
        }

        private void btnValeCx1_Click(object sender, EventArgs e)
        {
            txtValeCx1.Text = txtFaltaCx1.Text;
            valecx1.ValorPagamento = Convert.ToDouble(txtValeCx1.Text);
            valecx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(valecx1);
            if (falta == 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                btnFinalizaVendaCx1.Enabled = true;
            }
        }

        private void btnBoletoCx1_Click(object sender, EventArgs e)
        {
            txtBoletoCx1.Text = txtFaltaCx1.Text;
            boletocx1.ValorPagamento = Convert.ToDouble(txtBoletoCx1.Text);
            boletocx1.TotalInicial = Convert.ToDouble(txtFaltaCx1.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocx1);
            if (falta == 0)
            {
                txtFaltaCx1.Text = falta.ToString();
                btnFinalizaVendaCx1.Enabled = true;
            }
        }
        /************************* CLICK DO BOTÃO PREENCHIMENTO FORMA PAGAMENTO CAIXA2 ************************/
        private void btnDinheiroCx2_Click(object sender, EventArgs e)
        {
            txtDinheiroCx2.Text = txtFaltaCx2.Text;
            dinheirocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            dinheirocx2.ValorPagamento = Convert.ToDouble(txtDinheiroCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheirocx2);
            if (falta < 0)
            {
                txtTrocoCx2.Text = falta.ToString();
                txtFaltaCx2.Text = "0";
            }
            else if (falta == 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                btnFinalizaVendaCx2.Enabled = true;
            }
        }

        private void btnDebitoCx2_Click(object sender, EventArgs e)
        {
            txtCartaoDebitoCx2.Text = txtFaltaCx2.Text;
            debitocx2.ValorPagamento = Convert.ToDouble(txtCartaoDebitoCx2.Text);
            debitocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocx2);
            if (falta == 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                btnFinalizaVendaCx2.Enabled = true;
            }
        }

        private void btnCreditoCx2_Click(object sender, EventArgs e)
        {
            txtCartaoCreditoCx2.Text = txtFaltaCx2.Text;
            creditocx2.ValorPagamento = Convert.ToDouble(txtCartaoCreditoCx2.Text);
            creditocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocx2);
            if (falta == 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                btnFinalizaVendaCx2.Enabled = true;
            }
        }

        private void btnChequeCx2_Click(object sender, EventArgs e)
        {
            txtChequeCx2.Text = txtFaltaCx2.Text;
            chequecx2.ValorPagamento = Convert.ToDouble(txtChequeCx2.Text);
            chequecx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecx2);
            if (falta == 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                btnFinalizaVendaCx2.Enabled = true;
            }
        }

        private void btnValeCx2_Click(object sender, EventArgs e)
        {
            txtValeCx2.Text = txtFaltaCx2.Text;
            valecx2.ValorPagamento = Convert.ToDouble(txtValeCx2.Text);
            valecx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(valecx2);
            if (falta == 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                btnFinalizaVendaCx2.Enabled = true;
            }
        }

        private void btnBoletoCx2_Click(object sender, EventArgs e)
        {
            txtBoletoCx2.Text = txtFaltaCx2.Text;
            boletocx2.ValorPagamento = Convert.ToDouble(txtBoletoCx2.Text);
            boletocx2.TotalInicial = Convert.ToDouble(txtFaltaCx2.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocx2);
            if (falta == 0)
            {
                txtFaltaCx2.Text = falta.ToString();
                btnFinalizaVendaCx2.Enabled = true;
            }
        }
        /************************* CLICK DO BOTÃO PREENCHIMENTO FORMA PAGAMENTO CAIXA3 ************************/
        private void btnDinheiroCx3_Click(object sender, EventArgs e)
        {
            txtDinheiroCx3.Text = txtFaltaCx3.Text;
            dinheirocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            dinheirocx3.ValorPagamento = Convert.ToDouble(txtDinheiroCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheirocx3);
            if (falta < 0)
            {
                txtTrocoCx3.Text = falta.ToString();
                txtFaltaCx3.Text = "0";
            }
            else if (falta == 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                btnFinalizaVendaCx3.Enabled = true;
            }
        }

        private void btnDebitoCx3_Click(object sender, EventArgs e)
        {
            txtCartaoDebitoCx3.Text = txtFaltaCx3.Text;
            debitocx3.ValorPagamento = Convert.ToDouble(txtCartaoDebitoCx3.Text);
            debitocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocx3);
            if (falta == 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                btnFinalizaVendaCx3.Enabled = true;
            }
        }

        private void btnCreditoCx3_Click(object sender, EventArgs e)
        {
            txtCartaoCreditoCx3.Text = txtFaltaCx3.Text;
            creditocx3.ValorPagamento = Convert.ToDouble(txtCartaoCreditoCx3.Text);
            creditocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocx3);
            if (falta == 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                btnFinalizaVendaCx3.Enabled = true;
            }
        }

        private void btnChequeCx3_Click(object sender, EventArgs e)
        {
            txtChequeCx3.Text = txtFaltaCx3.Text;
            chequecx3.ValorPagamento = Convert.ToDouble(txtChequeCx3.Text);
            chequecx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecx3);
            if (falta == 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                btnFinalizaVendaCx3.Enabled = true;
            }
        }

        private void btnValeCx3_Click(object sender, EventArgs e)
        {
            txtValeCx3.Text = txtFaltaCx3.Text;
            valecx3.ValorPagamento = Convert.ToDouble(txtValeCx3.Text);
            valecx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(valecx3);
            if (falta == 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                btnFinalizaVendaCx3.Enabled = true;
            }
        }

        private void btnBoletoCx3_Click(object sender, EventArgs e)
        {
            txtBoletoCx3.Text = txtFaltaCx3.Text;
            boletocx3.ValorPagamento = Convert.ToDouble(txtBoletoCx3.Text);
            boletocx3.TotalInicial = Convert.ToDouble(txtFaltaCx3.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocx3);
            if (falta == 0)
            {
                txtFaltaCx3.Text = falta.ToString();
                btnFinalizaVendaCx3.Enabled = true;
            }
        }
        /************************* CLICK DO BOTÃO PREENCHIMENTO FORMA PAGAMENTO CAIXA 4 ************************/
        private void btnDinheiroAux_Click(object sender, EventArgs e)
        {
            txtDinheiroAux.Text = txtFaltaAux.Text;
            dinheiroAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            dinheiroAux.ValorPagamento = Convert.ToDouble(txtDinheiroAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(dinheiroAux);
            if (falta < 0)
            {
                txtTrocoAux.Text = falta.ToString();
                txtFaltaAux.Text = "0";
            }
            else if (falta == 0)
            {
                txtFaltaAux.Text = falta.ToString();
                btnFinalizaAux.Enabled = true;
            }
        }
        private void btnDebitoAux_Click(object sender, EventArgs e)
        {
            txtDebitoAux.Text = txtFaltaAux.Text;
            debitocxAux.ValorPagamento = Convert.ToDouble(txtDebitoAux.Text);
            debitocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(debitocxAux);
            if (falta == 0)
            {
                txtFaltaAux.Text = falta.ToString();
                btnFinalizaAux.Enabled = true;
            }
        }
        private void btnCreditoAux_Click(object sender, EventArgs e)
        {
            txtCreditoAux.Text = txtFaltaAux.Text;
            creditocxAux.ValorPagamento = Convert.ToDouble(txtCreditoAux.Text);
            creditocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(creditocxAux);
            if (falta == 0)
            {
                txtFaltaAux.Text = falta.ToString();
                btnFinalizaAux.Enabled = true;
            }
        }
        private void btnChequeAux_Click(object sender, EventArgs e)
        {
            txtChequeAux.Text = txtFaltaAux.Text;
            chequecxAux.ValorPagamento = Convert.ToDouble(txtChequeAux.Text);
            chequecxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecxAux);
            if (falta == 0)
            {
                txtFaltaAux.Text = falta.ToString();
                btnFinalizaAux.Enabled = true;
            }
        }
        private void btnValeAux_Click(object sender, EventArgs e)
        {
            txtValeAux.Text = txtFaltaAux.Text;
            valecxAux.ValorPagamento = Convert.ToDouble(txtChequeAux.Text);
            valecxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(chequecxAux);
            if (falta == 0)
            {
                txtFaltaAux.Text = falta.ToString();
                btnFinalizaAux.Enabled = true;
            }
        }
        private void btnBoletoAux_Click(object sender, EventArgs e)
        {
            txtBoletoAux.Text = txtFaltaAux.Text;
            boletocxAux.ValorPagamento = Convert.ToDouble(txtBoletoAux.Text);
            boletocxAux.TotalInicial = Convert.ToDouble(txtFaltaAux.Text);
            double falta = pagamentoBLL.AdicionaPagamento(boletocxAux);
            if (falta == 0)
            {
                txtFaltaAux.Text = falta.ToString();
                btnFinalizaAux.Enabled = true;
            }
        }

        /**----------------------------------------------- DIGITAÇÃO CONTROL H ---------------------------------------------**/
        private void FormPDVVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.H)
            {
                var form = new FormPDVHistorico(this);
                form.DialogResult = DialogResult.Ignore;
                form.ShowDialog(this);

                if(form.DialogResult == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabVenda;
                    tabControl2.SelectedTab = tabPage4;
                    form.Close();
                }
                else if(form.DialogResult == DialogResult.No)
                {
                    form.Close();
                }
            }
        }

        private void imprimeCupomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }
        /*----------------------------------------------CLIQUE DUPLO NO DATAGRIDVIEW ----------------------------------*/
        private void advDgvHistVenda_DoubleClick(object sender, EventArgs e)
        {
            lblDataAux.Visible = true;
            nroDocAux.Visible = true;
            lblDocAux.Visible = true;
            dataAux.Visible = true;
           
            venda1.Idreg_cabecalho = Convert.ToInt32(advDgvHistVenda.CurrentRow.Cells[0].Value);                   
            dtItemAux = venda.buscaItensVenda(venda1);
            dgvItemAuxVenda.DataSource = dtItemAux;
           
            tabControl1.SelectedTab = tabVenda;
            tabControl2.SelectedTab = tabPage4;

            btnFinalizaAux.Enabled = false;
            btnExcluiAux.Enabled = true;

            var cabecalhoVenda = venda.buscaCabelhoVenda(venda1);

            if (cabecalhoVenda.Rows.Count > 0)
            {
                DataRow row = cabecalhoVenda.Rows[0];
                cboClienteAux.Text = row["Cliente"].ToString();
                nroDocAux.Text = row["nroDoc"].ToString();
                dataAux.Text = row["data"].ToString();
                txtAuxDescontoPercent.Text = row["descontoPercent"].ToString();
                txtAuxDescontoUnit.Text = row["descontoUnit"].ToString();
                txtAcrescimoAux.Text = row["acrescimo"].ToString();
                txtTotalAux.Text = row["total"].ToString();
            }         
        
            var financeiro = venda.buscaFinanceiroVenda(venda1);

            foreach (DataRow row in financeiro.Rows)
            {
                int tipoPagamento;
                tipoPagamento = Convert.ToInt32(row["id_tipopagamento"]);

                switch (tipoPagamento)
                {
                    case 1:
                        txtDinheiroAux.Text = row["valorpagto"].ToString();
                        break;
                    case 2:
                        txtDebitoAux.Text = row["valorpagto"].ToString();
                        break;
                    case 3:
                        txtCreditoAux.Text = row["valorpagto"].ToString();
                        break;
                    case 4:
                        txtChequeAux.Text = row["valorpagto"].ToString();
                        break;
                    case 5:
                        txtValeAux.Text = row["valorpagto"].ToString();
                        break;
                    case 6:
                        txtBoletoAux.Text = row["valorpagto"].ToString();
                        break;
                    default:
                        break;
                }
            }
            if (advDgvHistVenda.CurrentRow.Cells[1].Value.ToString() == "Finalizada")
            {
                txtAuxDescontoPercent.Enabled = false;
                txtAuxDescontoUnit.Enabled = false;
                txtAcrescimoAux.Enabled = false;
                txtDinheiroAux.Enabled = false;
                txtDebitoAux.Enabled = false;
                txtCreditoAux.Enabled = false;
                txtChequeAux.Enabled = false;
                txtValeAux.Enabled = false;
                txtValeAux.Enabled = false;
                txtBoletoAux.Enabled = false;
                tstMaisItem.Enabled = false;
                tstMenosItem.Enabled = false;
                btnExcluiAux.Enabled = false;
                btnExcluirOrcamento.Enabled = false;
            }

        }

        /************************************************************************* VALIDAÇÃO KEYPRESS *****************************************************************************/
        private void txtAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtAcrescimoCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDescontoPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDescontoPercentCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDescontoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDescontoUnitarioCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDinheiroCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDebitoCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtCreditoCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtVale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtValeCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtChequeCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtBoletoCx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtBoletoCx1.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        /*------------------------------------------------------------------ KEY PRESS CAIXA 2 --------------------------------------------------------------------*/
        private void txtDescontoPercentCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDescontoPercentCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDescontoUnitarioCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDescontoUnitarioCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtAcrescimoCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtAcrescimoCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDinheiroCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDinheiroCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtCartaoDebitoCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtCartaoDebitoCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtCartaoCreditoCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtCartaoCreditoCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtChequeCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtChequeCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtValeCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtValeCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtBoletoCx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtBoletoCx2.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        /**----------------------------------------------------------  KEYPRESS CAIXA 3 ---------------------------------------------------------- **/
        private void txtDescontoPercentCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDescontoPercentCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDescontoUnitarioCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDescontoUnitarioCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtAcrescimoCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtAcrescimoCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDinheiroCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDinheiroCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtCartaoDebitoCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtCartaoCreditoCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtCartaoCreditoCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtCartaoCreditoCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtChequeCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtChequeCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtValeCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtValeCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtBoletoCx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtBoletoCx3.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        /**-------------------------------------------------------- KEYPRESS CAIXA 4 ---------------------------------------------------------**/
        private void txtAuxDescontoPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtAuxDescontoPercent.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtAuxDescontoUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtAuxDescontoUnit.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtAcrescimoAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtAcrescimoAux.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDinheiroAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDinheiroAux.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtDebitoAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDebitoAux.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtCreditoAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtCreditoAux.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtChequeAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtChequeAux.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtValeAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtValeAux.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        private void txtBoletoAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == ',') && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1) && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtBoletoAux.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
        /*-------------------------------------DESCRIÇÃO BOTOES CAIXA 1-------------------------------------*/
        private void btnFinalizaVendaCx1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnFinalizaVendaCx1, "Finalizar Venda");
        }
        private void btnExcluiVendaCx1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnExcluiVendaCx1, "Limpa Venda");
        }
        private void btnArquivaVendaCx1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnArquivaVendaCx1, "Reservar Venda");
        }
        private void btnBuscaPessoaCx1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnBuscaPessoaCx1, "Pesquisa Pessoa");
        }
        private void btnAddPessoaCx1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnAddPessoaCx1, "Adicionar Pessoa");
        }
        /***-------------------------------- BOTOES CAIXA 2 -------------------------------------***/
        private void btnBuscaPessoaCx2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnBuscaPessoaCx2, "Pesquisa Pessoa");
        }
        private void btnAddPessoaCx2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnAddPessoaCx2, "Adicionar Pessoa");
        }
        private void btnArquivaVendaCx2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnArquivaVendaCx2, "Reservar Venda");
        }
        private void btnExcluiVendaCx2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnExcluiVendaCx2, "Limpa Venda");
        }
        private void btnFinalizaVendaCx2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnFinalizaVendaCx2, "Finalizar Venda");
        }
        /***-------------------------------- BOTOES CAIXA 3 -------------------------------------***/
        private void btnBuscaPessoaCx3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnBuscaPessoaCx3, "Pesquisa Pessoa");
        }
        private void btnAddPessoaCx3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnAddPessoaCx3, "Adicionar Pessoa");
        }
        private void btnArquivaVendaCx3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnArquivaVendaCx3, "Reservar Venda");
        }
        private void btnExcluiVendaCx3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnExcluiVendaCx3, "Limpa Venda");
        }
        private void btnFinalizaVendaCx3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnFinalizaVendaCx3, "Finalizar Venda");
        }
        /***-------------------------------- BOTOES CAIXA AUX -------------------------------------***/

        private void btnFinalizaAux_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnFinalizaAux, "Finalizar Venda");
        }

        private void btnExcluirOrcamento_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnFinalizaAux, "Exclui Venda");
        }

        private void btnExcluiAux_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnExcluiAux, "Limpa Campos");
        }

        private void btnReservaAux_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnReservaAux, "Reservar Venda");
        }

        /*------------------------------- EVENTOS CONTOLE DO COMBO BOX CLIENTE -------------------------------*/
        private void cboClientePdvCx1_SelectedIndexChanged(object sender, EventArgs e)
        {     
            if(this.cboClientePdvCx1.Text == "")
            {
                tabControl2.TabPages[0].Text = "Caixa 1";
            }
            else
            {
                tabControl2.TabPages[0].Text = cboClientePdvCx1.Text;
            }                        
        }

        private void cboClientePdvCx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboClientePdvCx2.Text == "")
            {
                tabControl2.TabPages[1].Text = "Caixa 2";
            }
            else
            {
                tabControl2.TabPages[1].Text = cboClientePdvCx2.Text;
            }
        }

        private void cboClientePdvCx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboClientePdvCx3.Text == "")
            {
                tabControl2.TabPages[2].Text = "Caixa 3";
            }
            else
            {
                tabControl2.TabPages[2].Text = cboClientePdvCx3.Text;
            }
        }

        private void cboClientePdvCx1_Leave(object sender, EventArgs e)
        {
            if (this.cboClientePdvCx1.Text == "")
            {
                tabControl2.TabPages[0].Text = "Caixa 1";
            }
        }

        private void cboClientePdvCx2_Leave(object sender, EventArgs e)
        {
            if (this.cboClientePdvCx2.Text == "")
            {
                tabControl2.TabPages[1].Text = "Caixa 2";
            }
        }

        private void tabControl2_Leave(object sender, EventArgs e)
        {
            if (this.cboClientePdvCx3.Text == "")
            {
                tabControl2.TabPages[2].Text = "Caixa 3";
            }
        }

        private void excluirVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vendaAux.Idreg_cabecalho = Convert.ToInt32(advDgvHistVenda.CurrentRow.Cells[0].Value);
            if(advDgvHistVenda.CurrentRow.Cells[1].Value.ToString() == "Finalizado")
            {
                venda.cancelaVenda(vendaAux);
            }
            else if(advDgvHistVenda.CurrentRow.Cells[1].Value.ToString()=="Orçamento")
            {               
                foreach (DataGridViewRow row in dgvItemAuxVenda.Rows)
                {
                    vendaAux.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                    venda.excluiItensOrcamento(vendaAux);
                }
                venda.excluiOrcamentoCab(vendaAux);
            }        
        }

        private void btnExcluirOrcamento_Click(object sender, EventArgs e)
        {

            vendaAux.Idreg_cabecalho = Convert.ToInt32(nroDocAux.Text);                  

            foreach (DataGridViewRow row in dgvItemAuxVenda.Rows)
            {                
                vendaAux.Produto.Id = Convert.ToInt32(row.Cells["Id"].Value);            
                venda.excluiItensOrcamento(vendaAux);
               
            }
            venda.excluiOrcamentoCab(vendaAux);
            txtAuxDescontoPercent.Text = "0%";
            txtAuxDescontoUnit.Text = "0";
            txtAcrescimoAux.Text = "0";
            txtTotalAux.Text = "0";
            txtTrocoAux.Text = "0";
            txtDinheiroAux.Text = "0";
            txtCreditoAux.Text = "0";
            txtDebitoAux.Text = "0";
            txtValeAux.Text = "0";
            txtChequeAux.Text = "0";
            txtBoletoAux.Text = "0";
            cboClienteAux.Text = "";
            btnFinalizaAux.Enabled = false;
            btnExcluiAux.Enabled = false; 
        }

    }
}

