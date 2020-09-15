using Model;
using System;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormPDVQtd : Form
    {
        public FormPDVQtd()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void btnAddQtd_Click(object sender, System.EventArgs e)
        {
            AppStatic.FormPdvAddQtdProduto = Convert.ToInt32(txtQtdProduto.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelarQtd_Click(object sender, System.EventArgs e)
        {
            AppStatic.FormPdvAddQtdProduto = 0;
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormPdvQtd_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AppStatic.FormPdvAddQtdProduto = Convert.ToInt32(txtQtdProduto.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }             
        }

        private void FormPdvQtd_KeyPress(object sender, KeyPressEventArgs e)
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
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQtdProduto.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
    }
}
