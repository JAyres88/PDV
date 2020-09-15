namespace RegistroVendas
{
    partial class FormPDVPagtoVale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDVPagtoVale));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStEndUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStEndStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.advDgvEndereco = new Zuby.ADGV.AdvancedDataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolbtnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.toolbtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolbtnCarregar = new System.Windows.Forms.ToolStripButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advDgvEndereco)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStEndUsuario,
            this.toolStEndStatus});
            this.statusStrip2.Location = new System.Drawing.Point(0, 288);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(792, 22);
            this.statusStrip2.TabIndex = 36;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.sairToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.advDgvEndereco);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Location = new System.Drawing.Point(0, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 168);
            this.panel1.TabIndex = 38;
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
            this.advDgvEndereco.Dock = System.Windows.Forms.DockStyle.Right;
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
            this.advDgvEndereco.Size = new System.Drawing.Size(768, 168);
            this.advDgvEndereco.TabIndex = 32;
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
            this.toolStrip2.Size = new System.Drawing.Size(24, 168);
            this.toolStrip2.TabIndex = 33;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolbtnAdicionar
            // 
            this.toolbtnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnAdicionar.Image")));
            this.toolbtnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnAdicionar.Name = "toolbtnAdicionar";
            this.toolbtnAdicionar.Size = new System.Drawing.Size(21, 20);
            this.toolbtnAdicionar.Text = "Adicionar Endereco";
            // 
            // toolbtnExcluir
            // 
            this.toolbtnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnExcluir.Image")));
            this.toolbtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExcluir.Name = "toolbtnExcluir";
            this.toolbtnExcluir.Size = new System.Drawing.Size(21, 20);
            this.toolbtnExcluir.Text = "Excluir Endereco";
            // 
            // toolbtnCarregar
            // 
            this.toolbtnCarregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnCarregar.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnCarregar.Image")));
            this.toolbtnCarregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnCarregar.Name = "toolbtnCarregar";
            this.toolbtnCarregar.Size = new System.Drawing.Size(21, 20);
            this.toolbtnCarregar.Text = "Carregar Endereco";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(640, 28);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(144, 20);
            this.textBox4.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(544, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Saldo Pessoa:";
            // 
            // FormPDVPagtoVale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 310);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPDVPagtoVale";
            this.Text = "Lançamento de Vale";
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advDgvEndereco)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStEndUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStEndStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridView advDgvEndereco;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolbtnAdicionar;
        private System.Windows.Forms.ToolStripButton toolbtnExcluir;
        private System.Windows.Forms.ToolStripButton toolbtnCarregar;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
    }
}