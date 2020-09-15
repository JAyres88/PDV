using BLL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormPDVBuscaCliente : Form
    {
        PessoaBLL pessoaBll = new PessoaBLL();
        public FormPDVBuscaCliente()
        {
            InitializeComponent();
        }
        private void FormPDVBuscaCliente_Load(object sender, EventArgs e)
        {            
            this.advDgvBuscaCliente.DataSource = pessoaBll.FiltraPessoaVenda();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void advDgvBuscaCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {          
            AppStatic.FormPdvBuscaCliente = Convert.ToInt32(advDgvBuscaCliente.CurrentRow.Cells[0].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AppStatic.FormPdvBuscaCliente = Convert.ToInt32(advDgvBuscaCliente.CurrentRow.Cells[0].Value);
            FormCPessoa pessoa = new FormCPessoa();
            pessoa.DialogResult = DialogResult.Ignore;
            pessoa.ShowDialog();
            if (pessoa.DialogResult == DialogResult.OK)
            {
                advDgvBuscaCliente.DataSource = null;
                advDgvBuscaCliente.DataSource = pessoaBll.FiltraPessoaVenda();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppStatic.FormPessoaId = Convert.ToInt32(advDgvBuscaCliente.CurrentRow.Cells[0].Value);
            FormCPessoa formPessoa = new FormCPessoa();
            formPessoa.DialogResult = DialogResult.None;
            formPessoa.ShowDialog();
            if(formPessoa.DialogResult == DialogResult.OK)
            {
                advDgvBuscaCliente.DataSource = null;
                advDgvBuscaCliente.DataSource = pessoaBll.ListaPessoas();
                this.Close();
            }
            else if(formPessoa.DialogResult == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
