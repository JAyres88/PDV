namespace RegistroVendas
{
    partial class FormCDocSaida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCDocSaida));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSalvar = new System.Windows.Forms.ToolStripButton();
            this.tsbLimpar = new System.Windows.Forms.ToolStripButton();
            this.tsbApagar = new System.Windows.Forms.ToolStripButton();
            this.tsbSair = new System.Windows.Forms.ToolStripButton();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkGeraFinanceiro = new System.Windows.Forms.CheckBox();
            this.chkMovimentaEstoque = new System.Windows.Forms.CheckBox();
            this.chkPermiteVale = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSalvar,
            this.tsbLimpar,
            this.tsbApagar,
            this.tsbSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(686, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSalvar
            // 
            this.tsbSalvar.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalvar.Image")));
            this.tsbSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalvar.Name = "tsbSalvar";
            this.tsbSalvar.Size = new System.Drawing.Size(63, 22);
            this.tsbSalvar.Text = "Salvar";
            // 
            // tsbLimpar
            // 
            this.tsbLimpar.Enabled = false;
            this.tsbLimpar.Image = ((System.Drawing.Image)(resources.GetObject("tsbLimpar.Image")));
            this.tsbLimpar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLimpar.Name = "tsbLimpar";
            this.tsbLimpar.Size = new System.Drawing.Size(67, 22);
            this.tsbLimpar.Text = "Limpar";
            // 
            // tsbApagar
            // 
            this.tsbApagar.Enabled = false;
            this.tsbApagar.Image = ((System.Drawing.Image)(resources.GetObject("tsbApagar.Image")));
            this.tsbApagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApagar.Name = "tsbApagar";
            this.tsbApagar.Size = new System.Drawing.Size(69, 22);
            this.tsbApagar.Text = "Apagar";
            // 
            // tsbSair
            // 
            this.tsbSair.Image = ((System.Drawing.Image)(resources.GetObject("tsbSair.Image")));
            this.tsbSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSair.Name = "tsbSair";
            this.tsbSair.Size = new System.Drawing.Size(51, 22);
            this.tsbSair.Text = "Sair";
            this.tsbSair.Click += new System.EventHandler(this.tsbSair_Click);
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(74, 28);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(476, 22);
            this.txtNome.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkPermiteVale);
            this.panel1.Controls.Add(this.chkMovimentaEstoque);
            this.panel1.Controls.Add(this.chkGeraFinanceiro);
            this.panel1.Location = new System.Drawing.Point(74, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 117);
            this.panel1.TabIndex = 6;
            // 
            // chkGeraFinanceiro
            // 
            this.chkGeraFinanceiro.AutoSize = true;
            this.chkGeraFinanceiro.Enabled = false;
            this.chkGeraFinanceiro.Location = new System.Drawing.Point(3, 12);
            this.chkGeraFinanceiro.Name = "chkGeraFinanceiro";
            this.chkGeraFinanceiro.Size = new System.Drawing.Size(101, 17);
            this.chkGeraFinanceiro.TabIndex = 0;
            this.chkGeraFinanceiro.Text = "Gera Financeiro";
            this.chkGeraFinanceiro.UseVisualStyleBackColor = true;
            // 
            // chkMovimentaEstoque
            // 
            this.chkMovimentaEstoque.AutoSize = true;
            this.chkMovimentaEstoque.Enabled = false;
            this.chkMovimentaEstoque.Location = new System.Drawing.Point(3, 35);
            this.chkMovimentaEstoque.Name = "chkMovimentaEstoque";
            this.chkMovimentaEstoque.Size = new System.Drawing.Size(120, 17);
            this.chkMovimentaEstoque.TabIndex = 1;
            this.chkMovimentaEstoque.Text = "Movimenta Estoque";
            this.chkMovimentaEstoque.UseVisualStyleBackColor = true;
            // 
            // chkPermiteVale
            // 
            this.chkPermiteVale.AutoSize = true;
            this.chkPermiteVale.Enabled = false;
            this.chkPermiteVale.Location = new System.Drawing.Point(3, 58);
            this.chkPermiteVale.Name = "chkPermiteVale";
            this.chkPermiteVale.Size = new System.Drawing.Size(85, 17);
            this.chkPermiteVale.TabIndex = 2;
            this.chkPermiteVale.Text = "Permite Vale";
            this.chkPermiteVale.UseVisualStyleBackColor = true;
            // 
            // FormCDocSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 252);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCDocSaida";
            this.Text = "Documento de Saida";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSalvar;
        private System.Windows.Forms.ToolStripButton tsbLimpar;
        private System.Windows.Forms.ToolStripButton tsbApagar;
        private System.Windows.Forms.ToolStripButton tsbSair;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox chkMovimentaEstoque;
        public System.Windows.Forms.CheckBox chkGeraFinanceiro;
        public System.Windows.Forms.CheckBox chkPermiteVale;
    }
}