using BLL;
using System;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormPDVCompra : Form
    {
        DocEntradaBLL docEnt = new DocEntradaBLL();

        public FormPDVCompra()
        {
            InitializeComponent();
        }

        private void FormPDVCompra_Load(object sender, EventArgs e)
        {
            cboDoc.ValueMember = "id";
            cboDoc.DisplayMember = "Descricao";
            cboDoc.DataSource = docEnt.DocEntrada();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
