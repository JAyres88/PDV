using BLL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormPDVHistorico : Form
    {
        private FormPDVVenda _form;
        VendaModel venda1 = new VendaModel();
        VendaBLL venda = new VendaBLL();

        public FormPDVHistorico(FormPDVVenda form)
        {
            _form = form;
            InitializeComponent();
        }

        private void FormPDVHistorico_Load(object sender, EventArgs e)
        {            
            advDgvHistVenda2.DataSource = venda.listaVenda();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.No;
        }

        private void impressãoCupomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }   
               

        private void advDgvHistVenda2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (advDgvHistVenda2.RowCount > 1)
            {
                if (advDgvHistVenda2.CurrentRow.Cells[4].Value.ToString() == "Aberto")
                {
                    tstAcertoFinanceiro.Enabled = true;
                }
                else
                {
                    tstAcertoFinanceiro.Enabled = false;
                }
            }
            else
            {
                return;
            }
        }

        private void advDgvHistVenda2_DoubleClick(object sender, EventArgs e)
        {                        
            venda1.Idreg_cabecalho = Convert.ToInt32(advDgvHistVenda2.CurrentRow.Cells[0].Value);
            var cabecalhoVenda = venda.buscaCabelhoVenda(venda1);

            if (cabecalhoVenda.Rows.Count > 0)
            {
                DataRow row = cabecalhoVenda.Rows[0];
                _form.cboClienteAux.Text = row["Cliente"].ToString();
                _form.nroDocAux.Text = row["nroDoc"].ToString();
                _form.dataAux.Text = row["data"].ToString();
                _form.txtAuxDescontoPercent.Text = row["descontoPercent"].ToString();
                _form.txtAuxDescontoUnit.Text = row["descontoUnit"].ToString();
                _form.txtAcrescimoAux.Text = row["acrescimo"].ToString();
                _form.txtTotalAux.Text = row["total"].ToString();
            }

            var financeiro = venda.buscaFinanceiroVenda(venda1);

            foreach (DataRow row in financeiro.Rows)
            {
                int tipoPagamento;
                tipoPagamento = Convert.ToInt32(row["id_tipopagamento"]);

                switch (tipoPagamento)
                {
                    case 1:
                        _form.txtDinheiroAux.Text = row["valorpagto"].ToString();
                        break;
                    case 2:
                        _form.txtDebitoAux.Text = row["valorpagto"].ToString();
                        break;
                    case 3:
                        _form.txtCreditoAux.Text = row["valorpagto"].ToString();
                        break;
                    case 4:
                        _form.txtChequeAux.Text = row["valorpagto"].ToString();
                        break;
                    case 5:
                        _form.txtValeAux.Text = row["valorpagto"].ToString();
                        break;
                    case 6:
                        _form.txtBoletoAux.Text = row["valorpagto"].ToString();
                        break;
                    default:
                        break;
                }
            }
            
            _form.dtItemAux = venda.buscaItensVenda(venda1);
            _form.dgvItemAuxVenda.DataSource = _form.dtItemAux;

            this.DialogResult = DialogResult.OK;            
        }
    }
}
