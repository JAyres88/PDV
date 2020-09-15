namespace RegistroVendas
{
    partial class FormPDVQtd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDVQtd));
            this.label1 = new System.Windows.Forms.Label();
            this.txtQtdProduto = new System.Windows.Forms.TextBox();
            this.btnAddQtd = new System.Windows.Forms.Button();
            this.btnCancelarQtd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe a quantidade de produto:";
            // 
            // txtQtdProduto
            // 
            this.txtQtdProduto.Location = new System.Drawing.Point(211, 12);
            this.txtQtdProduto.Name = "txtQtdProduto";
            this.txtQtdProduto.Size = new System.Drawing.Size(218, 20);
            this.txtQtdProduto.TabIndex = 1;
            // 
            // btnAddQtd
            // 
            this.btnAddQtd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddQtd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddQtd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQtd.Image = ((System.Drawing.Image)(resources.GetObject("btnAddQtd.Image")));
            this.btnAddQtd.Location = new System.Drawing.Point(435, 6);
            this.btnAddQtd.Name = "btnAddQtd";
            this.btnAddQtd.Size = new System.Drawing.Size(34, 30);
            this.btnAddQtd.TabIndex = 6;
            this.btnAddQtd.UseVisualStyleBackColor = true;
            this.btnAddQtd.Click += new System.EventHandler(this.btnAddQtd_Click);
            // 
            // btnCancelarQtd
            // 
            this.btnCancelarQtd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelarQtd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarQtd.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarQtd.Image")));
            this.btnCancelarQtd.Location = new System.Drawing.Point(475, 6);
            this.btnCancelarQtd.Name = "btnCancelarQtd";
            this.btnCancelarQtd.Size = new System.Drawing.Size(34, 30);
            this.btnCancelarQtd.TabIndex = 7;
            this.btnCancelarQtd.UseVisualStyleBackColor = true;
            this.btnCancelarQtd.Click += new System.EventHandler(this.btnCancelarQtd_Click);
            // 
            // FormPdvQtd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 44);
            this.Controls.Add(this.btnCancelarQtd);
            this.Controls.Add(this.btnAddQtd);
            this.Controls.Add(this.txtQtdProduto);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPdvQtd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantidade de Produto";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPdvQtd_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPdvQtd_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddQtd;
        private System.Windows.Forms.Button btnCancelarQtd;
        public System.Windows.Forms.TextBox txtQtdProduto;
    }
}