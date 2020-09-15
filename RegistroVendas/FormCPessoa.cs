using BLL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace RegistroVendas
{
    public partial class FormCPessoa : Form
    {
        PessoaModel pessoa = new PessoaModel();
        PessoaBLL pessoaBll = new PessoaBLL();
        PessoaEnderecoBLL enderecoBll = new PessoaEnderecoBLL();
        FinanceiroBLL financeiroBll = new FinanceiroBLL();

        public FormCPessoa()
        {
            InitializeComponent();
        }
        /*************************Load do Form*******************************/
        private void FormCCliente_Load(object sender, EventArgs e)
        {               
            cboUf.DataSource = enderecoBll.BuscaEstados();
            cboUf.ValueMember = "id"; 
            cboUf.DisplayMember = "uf";
            cboUf.SelectedValue = 26;
            pessoa.Endereco.IdEstado = 26;
            cboCidade.DataSource = enderecoBll.BuscaCidadesPessoa(pessoa);
            cboCidade.ValueMember = "id";
            cboCidade.DisplayMember = "nome";

            cboTipoPessoa.DataSource = pessoaBll.listaTipoPessoa();
            cboTipoPessoa.ValueMember = "id";
            cboTipoPessoa.DisplayMember = "descricao";

            pessoa.Id = AppStatic.FormPessoaId;
            advDgvEndereco.DataSource=enderecoBll.DtEnderecoPessoa(pessoa);
            toolStEndStatus.Visible = false;
            toolStEndUsuario.Visible = false;
            toolStPessStatus.Visible = true;
            toolStPessUsuario.Visible = true;
           
            if (pessoa.Id != 0)
            {
              var umaPessoa =  pessoaBll.FiltraPessoa(pessoa);
                if (umaPessoa.Rows.Count > 0)
                {
                    DataRow row = umaPessoa.Rows[0];
                    cboTipoPessoa.SelectedValue = Convert.ToInt32(row["tipoPessoa"]);
                    txtNome.Text = row["nome"].ToString();
                    txtComplemento.Text = row["complemento"].ToString();
                    dtNascimento.Value = Convert.ToDateTime(row["nascimento"]);
                    txtTelefone.Text = row["telefone"].ToString();
                    txtCelular.Text = row["celular"].ToString();
                    txtEmail.Text = row["email"].ToString();
                    txtEmail2.Text = row["email2"].ToString();
                    txtCpf.Text = row["cpf"].ToString();
                    txtCnpj.Text = row["cnpj"].ToString();
                    txtAnotacoes.Text = row["anotacoes"].ToString();
                    toolStPessUsuario.Text = row["usuario"].ToString();
                }
            }
        }
        /********************** Na Alteração do TAB Index BUSCA-SE OS ENDEREÇOS**************/
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {         
        /******************** objeto endereçoCliente responsável pelos métodos relativos às ações sobre Endereços ***********************/           
            if(tabControl1.SelectedTab == tabEnderecos)
            {
                advDgvEndereco.DataSource = enderecoBll.DtEnderecoPessoa(pessoa);
            }
            else if(tabControl1.SelectedTab == tabFinanceiro)
            {
                dgvFinanceiro.DataSource = financeiroBll.listaFinanceiroPessoa(pessoa);
            }       
        }
        /**************************Lógica Botao Salvar************************/
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;     
            

            if (AppStatic.FormPessoaId >= 1 && advDgvEndereco.RowCount >= 1)
            {
                /***********************************Atualiza Cliente que já contenha Endereço*****************************/
                pessoa.Id = AppStatic.FormPessoaId;
                pessoa.Nome = txtNome.Text;
                pessoa.TipoPessoa = Convert.ToInt32(cboTipoPessoa.SelectedValue);
                pessoa.Complemento = txtComplemento.Text;
                pessoa.Nascimento = dtNascimento.Value;
                pessoa.Telefone = txtTelefone.Text;
                pessoa.Celular = txtCelular.Text;
                pessoa.Email = txtEmail.Text;
                pessoa.Email2 = txtEmail2.Text;
                pessoa.Cpf = txtCpf.Text;
                pessoa.Cnpj = txtCnpj.Text;
                pessoa.Anotacoes = txtAnotacoes.Text;
                toolStPessStatus.Text =pessoaBll.AtualizaPessoa(pessoa).ToString();                     
                  

                if (txtRua.Text != "" || txtBairro.Text != "" || txtCep.Text != "" || txtObs.Text != "" || cboTipo.Text != "")
                {
                    pessoa.Endereco.IdEndereco = Convert.ToInt32(advDgvEndereco.CurrentRow.Cells[0].Value.ToString());
                    pessoa.Endereco.Tipo = cboTipo.Text;
                    pessoa.Endereco.Rua = txtRua.Text;
                    pessoa.Endereco.Bairro = txtBairro.Text;
                    pessoa.Endereco.Cep = txtCep.Text;
                    pessoa.Endereco.Obs = txtObs.Text;
                    pessoa.Endereco.IdCidade = Convert.ToInt32(cboCidade.SelectedIndex);
                    pessoa.Endereco.IdEstado = cboUf.SelectedIndex;
                    pessoa.Id = AppStatic.FormPessoaId;
                    try
                    {
                        enderecoBll.atualizaEndereco(pessoa);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    advDgvEndereco.DataSource = null;
                    advDgvEndereco.DataSource = enderecoBll.DtEnderecoPessoa(pessoa);
                    tabControl1.TabPages[1].Focus();
                }            
         }
            /***********************************Atualiza Pessoa e adiciona endereco************************/
            else if (AppStatic.FormPessoaId > 1 && advDgvEndereco.RowCount < 1)
                {  
                    /*********************Atualiza Pessoa Já Cadastrada ******************/
                    pessoa.Nome = txtNome.Text;
                    pessoa.TipoPessoa = Convert.ToInt32(cboTipoPessoa.SelectedIndex);
                    pessoa.Complemento = txtComplemento.Text;
                    pessoa.Nascimento = dtNascimento.Value;
                    pessoa.Telefone = txtTelefone.Text;
                    pessoa.Celular = txtCelular.Text;
                    pessoa.Email = txtEmail.Text;
                    pessoa.Email2 = txtEmail2.Text;
                    pessoa.Cpf = txtCpf.Text;
                    pessoa.Cnpj = txtCnpj.Text;
                    pessoa.Anotacoes = txtAnotacoes.Text;
                    toolStPessStatus.Text = pessoaBll.AtualizaPessoa(pessoa).ToString();

                    if (txtRua.Text != "" || txtBairro.Text != "" || txtCep.Text != "" || txtObs.Text != "" || cboTipo.Text != "")
                    {
                    /***************** Adiciona Novo Endereço***************************/
                        pessoa.Endereco.IdEndereco = 0;
                        pessoa.Endereco.Rua = txtRua.Text;
                        pessoa.Endereco.Bairro = txtBairro.Text;
                        pessoa.Endereco.Cep = txtCep.Text;
                        pessoa.Endereco.Obs = txtObs.Text;
                        pessoa.Endereco.Tipo = cboTipo.SelectedText;
                        pessoa.Endereco.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                        pessoa.Endereco.IdEstado = cboUf.SelectedIndex;
                        pessoa.Id = AppStatic.FormPessoaId;
                        toolStEndStatus.Text = enderecoBll.NovoEndereco(pessoa);
                        advDgvEndereco.DataSource = null;
                        advDgvEndereco.DataSource = enderecoBll.DtEnderecoPessoa(pessoa);
                }            
            }
            /********************* Cadastra Pessoa e Endereço********************/
            else if (AppStatic.FormPessoaId < 1)
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Campo Nome Vazio.");
                    return;
                }else if(txtNome.Text== "" && txtEmail.Text == "")
                {
                    MessageBox.Show("Campo Nome e Email vazios");
                    return;
                }
                else if(txtNome.Text==""&& txtEmail.Text =="" && txtCelular.Text == "")
                {
                    MessageBox.Show("Campo Nome, Email e Celular Vazios.");
                    return;
                }
                else
                {
                    pessoa.Nome = txtNome.Text;
                    pessoa.TipoPessoa = Convert.ToInt32(cboTipoPessoa.SelectedValue);
                    pessoa.Complemento = txtComplemento.Text;
                    pessoa.Nascimento = dtNascimento.Value;
                    pessoa.Telefone = txtTelefone.Text;
                    pessoa.Celular = txtCelular.Text;
                    pessoa.Email = txtEmail.Text;
                    pessoa.Email2 = txtEmail2.Text;
                    pessoa.Cpf = txtCpf.Text;
                    pessoa.Cnpj = txtCnpj.Text;
                    pessoa.Anotacoes = txtAnotacoes.Text;
                    pessoa.Id = pessoaBll.AdicionarPessoa(pessoa);
                    toolStPessStatus.Text = "Nova Pessoa Cadastrada.";
                    toolStPessUsuario.Text = AppStatic.Nome;

                   if (txtRua.Text != "" || txtBairro.Text != "" || txtCep.Text != "" || txtObs.Text != "" || cboTipo.Text != "")
                    {
                        /**********************************************************/
                        pessoa.Endereco.Tipo = cboTipo.Text;
                        pessoa.Endereco.Rua = txtRua.Text;
                        pessoa.Endereco.Rua = txtRua.Text;
                        pessoa.Endereco.Bairro = txtBairro.Text;
                        pessoa.Endereco.Cep = txtCep.Text;
                        pessoa.Endereco.Obs = txtObs.Text;
                        pessoa.Endereco.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                        pessoa.Endereco.IdEstado = cboUf.SelectedIndex;
                        enderecoBll.NovoEndereco(pessoa);
                        advDgvEndereco.DataSource = null;
                        advDgvEndereco.DataSource = enderecoBll.DtEnderecoPessoa(pessoa);
                    }
                    else
                    {
                        toolStPessStatus.Text = "Esta pessoa foi cadastrada sem endereço.";
                    }                
                }                                  
            }else{
                MessageBox.Show("Blue Screen Of Death.");
            }
        }
        /************************** Lógica Combo UF ******************************/
        private void cboUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            PessoaModel pessoa = new PessoaModel();
            PessoaEnderecoBLL clienteNegocio = new PessoaEnderecoBLL();

            pessoa.Endereco.IdEstado = cboUf.SelectedIndex + 1;
            cboCidade.DataSource = clienteNegocio.DtEnderecoPessoa(pessoa);
            cboCidade.ValueMember = "id";
            cboCidade.DisplayMember = "nome";
        }

        /************************** Lógica Botão Adicionar *************************/
        private void toolbtnAdicionar_Click(object sender, EventArgs e)
        {
            if(txtRua.Text!="" || txtBairro.Text != "" || cboUf.Text != "")
            {
                PessoaEnderecoBLL clienteBll = new PessoaEnderecoBLL();
                PessoaModel pessoa = new PessoaModel();

                pessoa.Id = AppStatic.FormPessoaId;
                pessoa.Endereco.Tipo = cboTipo.SelectedText;
                pessoa.Endereco.Rua = txtRua.Text;
                pessoa.Endereco.Bairro = txtBairro.Text;
                pessoa.Endereco.Cep = txtCep.Text;
                pessoa.Endereco.Obs = txtObs.Text;
                pessoa.Endereco.Tipo = cboTipo.Text;
                pessoa.Endereco.IdEstado = cboUf.SelectedIndex;
                pessoa.Endereco.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                clienteBll.NovoEndereco(pessoa);
                advDgvEndereco.DataSource = null;
                advDgvEndereco.DataSource = clienteBll.DtEnderecoPessoa(pessoa);
            }
        }
        /************************** Lógica Botão Excluir *****************************/
        private void toolbtnExcluir_Click(object sender, EventArgs e)
        {
            PessoaEnderecoBLL clienteNegocio = new PessoaEnderecoBLL();
            PessoaModel pessoa = new PessoaModel();
            pessoa.Id = AppStatic.FormPessoaId;
            pessoa.Endereco.IdEndereco = Convert.ToInt32(advDgvEndereco.CurrentRow.Cells[0].Value.ToString());
            advDgvEndereco.DataSource = clienteNegocio.DtEnderecoPessoa(pessoa);
        }
        /******************************Botão Carregar*********************************/
        private void toolbtnCarregar_Click(object sender, EventArgs e)
        {
            if(advDgvEndereco.RowCount >= 1)
            {
                cboTipo.SelectedIndex = cboTipo.FindString(advDgvEndereco.CurrentRow.Cells[1].Value.ToString());
                txtRua.Text = advDgvEndereco.CurrentRow.Cells[2].Value.ToString();
                txtBairro.Text = advDgvEndereco.CurrentRow.Cells[3].Value.ToString();
                txtCep.Text = advDgvEndereco.CurrentRow.Cells[4].Value.ToString();
                txtObs.Text = advDgvEndereco.CurrentRow.Cells[5].Value.ToString();
                cboUf.SelectedIndex = cboUf.FindString(advDgvEndereco.CurrentRow.Cells[6].Value.ToString());
                cboCidade.SelectedIndex = cboCidade.FindString(advDgvEndereco.CurrentRow.Cells[7].Value.ToString());
            }
        }
        /**************************** Duplo Clique no DataGrid *********************/
        private void advDgvEndereco_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (advDgvEndereco.RowCount >= 1)
            {
                cboTipo.SelectedIndex = cboTipo.FindString(advDgvEndereco.CurrentRow.Cells[1].Value.ToString());
                txtRua.Text = advDgvEndereco.CurrentRow.Cells[2].Value.ToString();
                txtBairro.Text = advDgvEndereco.CurrentRow.Cells[3].Value.ToString();
                txtCep.Text = advDgvEndereco.CurrentRow.Cells[4].Value.ToString();
                txtObs.Text = advDgvEndereco.CurrentRow.Cells[5].Value.ToString();
                cboUf.SelectedIndex = cboUf.FindString(advDgvEndereco.CurrentRow.Cells[6].Value.ToString());
                cboCidade.SelectedIndex = cboCidade.FindString(advDgvEndereco.CurrentRow.Cells[7].Value.ToString());
                toolStEndStatus.Text = advDgvEndereco.CurrentRow.Cells[8].Value.ToString();
                toolStEndUsuario.Text = advDgvEndereco.CurrentRow.Cells[9].Value.ToString();
            }
        }
        /**************************** Botão Limpar *********************/
        private void tsbLimpar_Click(object sender, EventArgs e)
        {
            PessoaModel pessoa = new PessoaModel();
            PessoaEnderecoBLL endereco = new PessoaEnderecoBLL();
            
            if (tabControl1.SelectedTab.Name == "tabInformacoes")
            {
                txtNome.Text = "";
                txtComplemento.Text = "";
                txtAnotacoes.Text = "";
                txtEmail.Text = "";
                txtEmail2.Text = "";
                txtInscricao.Text = "";
                txtCpf.Text = "";
                txtCnpj.Text = "";
                txtObs.Text = "";
                txtRua.Text = "";
                txtBairro.Text = "";
                txtCep.Text = "";
                txtTelefone.Text = "";
                txtCelular.Text = "";
                AppStatic.FormPessoaId = 0;
                AppStatic.FormPessoaEnderecoId = 0;
                cboUf.SelectedValue = 26;
                pessoa.Endereco.IdEstado = 26;
                cboCidade.DataSource = endereco.BuscaCidadesPessoa(pessoa);
            }
            else if(tabControl1.SelectedTab.Name == "tabEnderecos")
            {
                txtRua.Text = "";
                txtBairro.Text = "";
                txtCep.Text = "";
                cboTipo.Text = "";
                txtObs.Text = "";
            }
            else
            {
                MessageBox.Show("Exceção não prevista. Entrar em contato com Administrador.");
            }
        }
        /************************ this . Close*****************************/
        private void tsbSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }        
    }
}
