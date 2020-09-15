using Model;
using System;
using BLL;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginBLL loginBll = new LoginBLL();
            AppStatic.Nome = textBox1.Text;
            AppStatic.Senha = textBox2.Text;
            if (loginBll.AuthUsuario() == 1)
            {
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                toolStripStatusLabel1.Text += " Usuário Não encontrado.";
                this.DialogResult = DialogResult.Ignore;
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
