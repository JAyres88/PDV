using System;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormPDVPgtoCheque : Form
    {
        public FormPDVPgtoCheque()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState == CheckState.Checked) 
           {
                lblTerceiro.Visible = true;
                txtTerceiro.Visible = true;
                txtTerceiro.Text = "";                      
            }                  
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPDVPgtoCheque_Load(object sender, EventArgs e)
        {

        }
    }
}
