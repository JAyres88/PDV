namespace RegistroVendas
{
    partial class FormPDVHistorico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDVHistorico));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.advDgvHistVenda2 = new Zuby.ADGV.AdvancedDataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstAcertoFinanceiro = new System.Windows.Forms.ToolStripMenuItem();
            this.impressãoCupomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advDgvHistVenda2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(985, 536);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.advDgvHistVenda2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(977, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vendas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // advDgvHistVenda2
            // 
            this.advDgvHistVenda2.AllowUserToAddRows = false;
            this.advDgvHistVenda2.AllowUserToDeleteRows = false;
            this.advDgvHistVenda2.AllowUserToResizeRows = false;
            this.advDgvHistVenda2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advDgvHistVenda2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.advDgvHistVenda2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advDgvHistVenda2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advDgvHistVenda2.FilterAndSortEnabled = true;
            this.advDgvHistVenda2.Location = new System.Drawing.Point(3, 3);
            this.advDgvHistVenda2.MultiSelect = false;
            this.advDgvHistVenda2.Name = "advDgvHistVenda2";
            this.advDgvHistVenda2.ReadOnly = true;
            this.advDgvHistVenda2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advDgvHistVenda2.RowHeadersVisible = false;
            this.advDgvHistVenda2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.advDgvHistVenda2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advDgvHistVenda2.ShowCellErrors = false;
            this.advDgvHistVenda2.ShowCellToolTips = false;
            this.advDgvHistVenda2.ShowEditingIcon = false;
            this.advDgvHistVenda2.ShowRowErrors = false;
            this.advDgvHistVenda2.Size = new System.Drawing.Size(971, 501);
            this.advDgvHistVenda2.TabIndex = 1;
            this.advDgvHistVenda2.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.advDgvHistVenda2_RowStateChanged);
            this.advDgvHistVenda2.DoubleClick += new System.EventHandler(this.advDgvHistVenda2_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.tstAcertoFinanceiro,
            this.impressãoCupomToolStripMenuItem,
            this.carregamentoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(985, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sairToolStripMenuItem.Image")));
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // tstAcertoFinanceiro
            // 
            this.tstAcertoFinanceiro.Enabled = false;
            this.tstAcertoFinanceiro.Image = ((System.Drawing.Image)(resources.GetObject("tstAcertoFinanceiro.Image")));
            this.tstAcertoFinanceiro.Name = "tstAcertoFinanceiro";
            this.tstAcertoFinanceiro.Size = new System.Drawing.Size(128, 20);
            this.tstAcertoFinanceiro.Text = "Acerto Financeiro";
            // 
            // impressãoCupomToolStripMenuItem
            // 
            this.impressãoCupomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("impressãoCupomToolStripMenuItem.Image")));
            this.impressãoCupomToolStripMenuItem.Name = "impressãoCupomToolStripMenuItem";
            this.impressãoCupomToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.impressãoCupomToolStripMenuItem.Text = "Impressão Cupom";
            this.impressãoCupomToolStripMenuItem.Click += new System.EventHandler(this.impressãoCupomToolStripMenuItem_Click);
            // 
            // carregamentoToolStripMenuItem
            // 
            this.carregamentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("carregamentoToolStripMenuItem.Image")));
            this.carregamentoToolStripMenuItem.Name = "carregamentoToolStripMenuItem";
            this.carregamentoToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.carregamentoToolStripMenuItem.Text = "Carregamento";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // FormPDVHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 560);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPDVHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historico";
            this.Load += new System.EventHandler(this.FormPDVHistorico_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advDgvHistVenda2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem tstAcertoFinanceiro;
        private System.Windows.Forms.ToolStripMenuItem impressãoCupomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregamentoToolStripMenuItem;
        private Zuby.ADGV.AdvancedDataGridView advDgvHistVenda2;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}