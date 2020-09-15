namespace RegistroVendas
{
    partial class FormPDVPgtoCheque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDVPgtoCheque));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtTerceiro = new System.Windows.Forms.TextBox();
            this.lblTerceiro = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolbtnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.toolbtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolbtnCarregar = new System.Windows.Forms.ToolStripButton();
            this.advDgvEndereco = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStEndUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStEndStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddPessoaCheque = new System.Windows.Forms.Button();
            this.btnBuscaPessoaCheque = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advDgvEndereco)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(784, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.sairToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Enabled = false;
            this.sairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sairToolStripMenuItem.Image")));
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.sairToolStripMenuItem.Text = "Salvar";
            // 
            // sairToolStripMenuItem1
            // 
            this.sairToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("sairToolStripMenuItem1.Image")));
            this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
            this.sairToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.sairToolStripMenuItem1.Text = "Sair";
            this.sairToolStripMenuItem1.Click += new System.EventHandler(this.sairToolStripMenuItem1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(86, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(256, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(742, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bom Para:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(19, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Terceiro?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtTerceiro
            // 
            this.txtTerceiro.Location = new System.Drawing.Point(71, 67);
            this.txtTerceiro.Name = "txtTerceiro";
            this.txtTerceiro.Size = new System.Drawing.Size(569, 20);
            this.txtTerceiro.TabIndex = 7;
            this.txtTerceiro.Visible = false;
            // 
            // lblTerceiro
            // 
            this.lblTerceiro.AutoSize = true;
            this.lblTerceiro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerceiro.Location = new System.Drawing.Point(14, 68);
            this.lblTerceiro.Name = "lblTerceiro";
            this.lblTerceiro.Size = new System.Drawing.Size(56, 16);
            this.lblTerceiro.TabIndex = 6;
            this.lblTerceiro.Text = "Pessoa:";
            this.lblTerceiro.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(855, 34);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(104, 20);
            this.txtTotal.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(816, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnAdicionar,
            this.toolbtnExcluir,
            this.toolbtnCarregar});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(24, 196);
            this.toolStrip2.TabIndex = 33;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolbtnAdicionar
            // 
            this.toolbtnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnAdicionar.Enabled = false;
            this.toolbtnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnAdicionar.Image")));
            this.toolbtnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnAdicionar.Name = "toolbtnAdicionar";
            this.toolbtnAdicionar.Size = new System.Drawing.Size(21, 20);
            this.toolbtnAdicionar.Text = "Adicionar Endereco";
            // 
            // toolbtnExcluir
            // 
            this.toolbtnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnExcluir.Enabled = false;
            this.toolbtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnExcluir.Image")));
            this.toolbtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExcluir.Name = "toolbtnExcluir";
            this.toolbtnExcluir.Size = new System.Drawing.Size(21, 20);
            this.toolbtnExcluir.Text = "Excluir Endereco";
            // 
            // toolbtnCarregar
            // 
            this.toolbtnCarregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnCarregar.Enabled = false;
            this.toolbtnCarregar.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnCarregar.Image")));
            this.toolbtnCarregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnCarregar.Name = "toolbtnCarregar";
            this.toolbtnCarregar.Size = new System.Drawing.Size(21, 20);
            this.toolbtnCarregar.Text = "Carregar Endereco";
            // 
            // advDgvEndereco
            // 
            this.advDgvEndereco.AllowUserToAddRows = false;
            this.advDgvEndereco.AllowUserToDeleteRows = false;
            this.advDgvEndereco.AllowUserToResizeRows = false;
            this.advDgvEndereco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advDgvEndereco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.advDgvEndereco.CausesValidation = false;
            this.advDgvEndereco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advDgvEndereco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.advDgvEndereco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advDgvEndereco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advDgvEndereco.FilterAndSortEnabled = true;
            this.advDgvEndereco.Location = new System.Drawing.Point(24, 0);
            this.advDgvEndereco.MultiSelect = false;
            this.advDgvEndereco.Name = "advDgvEndereco";
            this.advDgvEndereco.ReadOnly = true;
            this.advDgvEndereco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advDgvEndereco.RowHeadersVisible = false;
            this.advDgvEndereco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advDgvEndereco.ShowCellErrors = false;
            this.advDgvEndereco.ShowCellToolTips = false;
            this.advDgvEndereco.ShowEditingIcon = false;
            this.advDgvEndereco.ShowRowErrors = false;
            this.advDgvEndereco.Size = new System.Drawing.Size(948, 196);
            this.advDgvEndereco.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.advDgvEndereco);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Location = new System.Drawing.Point(5, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 200);
            this.panel1.TabIndex = 34;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStEndUsuario,
            this.toolStEndStatus});
            this.statusStrip2.Location = new System.Drawing.Point(0, 341);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(986, 22);
            this.statusStrip2.TabIndex = 35;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStEndUsuario
            // 
            this.toolStEndUsuario.Name = "toolStEndUsuario";
            this.toolStEndUsuario.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStEndStatus
            // 
            this.toolStEndStatus.Name = "toolStEndStatus";
            this.toolStEndStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "654\tA.J. RENNER S.A.",
            "246\tABC-BRASIL S.A.",
            "213\tARBI S.A.",
            "19\tAZTECA DO BRASIL S.A.",
            "25\tBANCO ALFA",
            "241\tBanco Classico S.A",
            "83\tBANCO DA CHINA BRASIL S.A.",
            "300\tBANCO DE LA NACION ARGENTINA",
            "495\tBANCO DE LA PROVINCIA DE BUENOS AIRES",
            "494\tBANCO DE LA REPUBLICA ORIENTAL DEL URUGUAY",
            "1\tBANCO DO BRASIL",
            "37\tBANCO DO ESTADO DO PARÁ S.A",
            "456\tBANCO TOKYO MITSUBISH UFJ BRASIL S.A",
            "370\tBANCO WESTLB DO BRASIL",
            "756\tBANCOOB",
            "756\tBANCOOB",
            "47\tBANESE",
            "33\tBANESPA",
            "21\tBANESTES",
            "719\tBANIF-BANCO INTERNACIONAL DO FUNCHAL (BRASIL) S.A",
            "755\tBANK OF AMERICA MERRILL LYNCH BANCO MULTIPLO S.A.",
            "41\tBANRISUL",
            "740\tBARCLAYS S.A.",
            "3\tBASA",
            "107\tBBM S.A",
            "81\tBBN BANCO BRASILEIRO DE NEGOCIOS S.A",
            "250\tBCV - BANCO DE CREDITO E VAREJO S.A",
            "36\tBEM",
            "122\tBERJ S.A",
            "78\tBES INVESTIMENTO DO BRASIL SA - BANCO DE INVESTIM.",
            "739\tBGN S.A.",
            "320\tBIC BANCO",
            "96\tBM&F DE SERV. DE LIQUIDACAO E CUSTODIA S.A",
            "394\tBMC S.A.",
            "318\tBMG S.A.",
            "4\tBNB",
            "752\tBNP PARIBAS BRASIL S.A",
            "17\tBNY MELLON S.A.",
            "248\tBOA VISTA INTERATLANTICO S.A",
            "218\tBONSUCESSO S.A.",
            "69\tBPN BRASIL BANCO MULTIPLO S.A",
            "65\tBRACCE S.A.",
            "237\tBRADESCO",
            "225\tBRASCAN S.A.",
            "125\tBRASIL PLURAL S.A. BANCO MULTIPLO",
            "70\tBRB",
            "92\tBRICKELL S A CREDITO, FINANCIAMENTO E INVESTIMENTO",
            "208\tBTG PACTUAL S.A.",
            "263\tCACIQUE S.A.",
            "104\tCAIXA ECON. FEDERAL",
            "473\tCAIXA GERAL - BRASIL S.A.",
            "412\tCAPITAL S.A.",
            "40\tCARGILL S.A",
            "112\tCC UNICRED BRASIL CENTRAL",
            "84\tCC UNIPRIME NORTE DO PARANA",
            "114\tCECOOPES-CENTRAL DAS COOP DE ECON E CRED MUTUO DO",
            "85\tCECREDI",
            "266\tCEDULA S.A.",
            "233\tCIFRA S.A.",
            "745\tCITIBANK",
            "477\tCitibank N.A.",
            "90\tCOOPERATIVA CENTRAL DE CREDITO DO ESTADO DE SP",
            "97\tCOOPERATIVA CENTRAL DE CREDITO NOROESTE BRASILEIRO",
            "89\tCOOPERATIVA DE CREDITO RURAL DA REGIAO DA MOGIANA",
            "75\tCR2 S.A",
            "98\tCREDIALIANCA COOPERATIVA DE CREDITO RURAL",
            "222\tCREDIT AGRICOLE BRASIL S.A.",
            "505\tCREDIT SUISSE (BRASIL) S.A.",
            "707\tDAYCOVAL",
            "487\tDEUTSCHE BANK S. A. - BANCO ALEMAO",
            "214\tDIBENS S.A.",
            "265\tFATOR S.A.",
            "224\tFIBRA",
            "626\tFICSA S.A.",
            "121\tGERADOR S.A.",
            "612\tGUANABARA S.A.",
            "62\tHIPERCARD BANCO MULTIPLO S.A",
            "399\tHSBC",
            "63\tIBI",
            "604\tINDUSTRIAL DO BRASIL S. A.",
            "653\tINDUSVAL S.A.",
            "492\tING BANK N.V.",
            "630\tINTERCAP S.A.",
            "77\tINTERMEDIUM S.A.",
            "249\tInvestcred Unibanco",
            "341\tITAÚ",
            "652\tITAU HOLDING FINANCEIRA S.A",
            "184\tItaú-BBA",
            "74\tJ. SAFRA S.A.",
            "376\tJ.P. MORGAN S.A.",
            "217\tJOHN DEERE S.A.",
            "488\tJPMORGAN CHASE BANK",
            "76\tKDB DO BRASIL S.A",
            "757\tKEB DO BRASIL S.A.",
            "600\tLuso Brasileiro",
            "243\tMAXIMA S.A.",
            "389\tMERCANTIL DO BRASIL",
            "746\tMODAL S.A.",
            "66\tMORGAN STANLEY DEAN WITTER S.A",
            "14\tNATIXIS BRASIL S.A. - BANCO MòLTIPLO",
            "753\tNBC BANK BRASIL S.A.- BANCO MULTIPLO",
            "45\tOPPORTUNITY S.A.",
            "79\tORIGINAL DO AGRONEGOCIO S.A.",
            "212\tORIGINAL S.A.",
            "623\tPANAMERICANO",
            "254\tPARANA BANCO S.A.",
            "611\tPAULISTA",
            "613\tPECUNIA S.A.",
            "94\tPETRA S.A.",
            "643\tPINE S.A.",
            "735\tPOTTENCIAL S.A.",
            "747\tRABOBANK INTERNATIONAL BRASIL S.A.",
            "88\tRANDON S.A.",
            "633\tRENDIMENTO S.A.",
            "741\tRIBEIRÃO PRETO",
            "120\tRODOBENS S.A",
            "453\tRURAL",
            "72\tRURAL MAIS S.A",
            "422\tSAFRA",
            "751\tSCOTIABANK BRASIL S.A BANCO MULTIPLO",
            "743\tSEMEAR S.A.",
            "748\tSICREDI",
            "749\tSIMPLES S.A.",
            "366\tSOCIETE GENERALE BRASIL S.A",
            "637\tSOFISA S.A.",
            "464\tSUMITOMO MITSUI BRASILEIRO S.A.",
            "82\tTOPAZIO S.A.",
            "634\tTriangulo",
            "230\tUNICARD BANCO MULTIPLO S.A",
            "91\tUNICRED CENTRAL RS - CENTRAL DE COOP ECON CRED MUT",
            "87\tUNICRED CENTRAL SANTA CATARINA",
            "99\tUNIPRIME CENTRAL - CENTRAL INT DE COOP DE CRED LTD",
            "655\tVOTORANTIM",
            "610\tVR S.A.",
            "119\tWESTERN UNION DO BRASIL S.A.",
            "124\tWOORI BANK DO BRASIL S.A"});
            this.comboBox1.Location = new System.Drawing.Point(156, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(103, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "Banco:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(333, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "Agência:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(392, 34);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 20);
            this.textBox5.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(616, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 40;
            this.label8.Text = "Nº Cheque:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(696, 34);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(87, 20);
            this.textBox6.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(432, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(528, 20);
            this.textBox2.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(351, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Observação:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(528, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(480, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Conta:";
            // 
            // btnAddPessoaCheque
            // 
            this.btnAddPessoaCheque.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddPessoaCheque.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPessoaCheque.Image")));
            this.btnAddPessoaCheque.Location = new System.Drawing.Point(688, 63);
            this.btnAddPessoaCheque.Name = "btnAddPessoaCheque";
            this.btnAddPessoaCheque.Size = new System.Drawing.Size(34, 30);
            this.btnAddPessoaCheque.TabIndex = 47;
            this.btnAddPessoaCheque.UseVisualStyleBackColor = true;
            // 
            // btnBuscaPessoaCheque
            // 
            this.btnBuscaPessoaCheque.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscaPessoaCheque.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaPessoaCheque.Image")));
            this.btnBuscaPessoaCheque.Location = new System.Drawing.Point(648, 63);
            this.btnBuscaPessoaCheque.Name = "btnBuscaPessoaCheque";
            this.btnBuscaPessoaCheque.Size = new System.Drawing.Size(34, 30);
            this.btnBuscaPessoaCheque.TabIndex = 46;
            this.btnBuscaPessoaCheque.UseVisualStyleBackColor = true;
            // 
            // FormPDVPgtoCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 363);
            this.Controls.Add(this.btnAddPessoaCheque);
            this.Controls.Add(this.btnBuscaPessoaCheque);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTerceiro);
            this.Controls.Add(this.lblTerceiro);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPDVPgtoCheque";
            this.Text = "Cheque";
            this.Load += new System.EventHandler(this.FormPDVPgtoCheque_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advDgvEndereco)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.Label lblTerceiro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolbtnAdicionar;
        private System.Windows.Forms.ToolStripButton toolbtnExcluir;
        private System.Windows.Forms.ToolStripButton toolbtnCarregar;
        private Zuby.ADGV.AdvancedDataGridView advDgvEndereco;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStEndUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStEndStatus;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.TextBox txtTerceiro;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddPessoaCheque;
        private System.Windows.Forms.Button btnBuscaPessoaCheque;
    }
}