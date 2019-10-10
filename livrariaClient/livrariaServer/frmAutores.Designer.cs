namespace livrariaServer
{
    partial class frmAutores
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.excluir = new System.Windows.Forms.Button();
            this.alterar = new System.Windows.Forms.Button();
            this.cadastrar = new System.Windows.Forms.Button();
            this.addAutor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(473, 230);
            this.dataGridView1.TabIndex = 7;
            // 
            // excluir
            // 
            this.excluir.Location = new System.Drawing.Point(410, 286);
            this.excluir.Name = "excluir";
            this.excluir.Size = new System.Drawing.Size(75, 23);
            this.excluir.TabIndex = 6;
            this.excluir.Text = "Excluir";
            this.excluir.UseVisualStyleBackColor = true;
            // 
            // alterar
            // 
            this.alterar.Location = new System.Drawing.Point(210, 286);
            this.alterar.Name = "alterar";
            this.alterar.Size = new System.Drawing.Size(75, 23);
            this.alterar.TabIndex = 5;
            this.alterar.Text = "Alterar";
            this.alterar.UseVisualStyleBackColor = true;
            // 
            // cadastrar
            // 
            this.cadastrar.Location = new System.Drawing.Point(12, 286);
            this.cadastrar.Name = "cadastrar";
            this.cadastrar.Size = new System.Drawing.Size(75, 23);
            this.cadastrar.TabIndex = 4;
            this.cadastrar.Text = "Cadastrar";
            this.cadastrar.UseVisualStyleBackColor = true;
            // 
            // addAutor
            // 
            this.addAutor.Location = new System.Drawing.Point(136, 338);
            this.addAutor.Name = "addAutor";
            this.addAutor.Size = new System.Drawing.Size(234, 23);
            this.addAutor.TabIndex = 8;
            this.addAutor.Text = "Adicionar Autor";
            this.addAutor.UseVisualStyleBackColor = true;
            // 
            // frmAutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 373);
            this.Controls.Add(this.addAutor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.excluir);
            this.Controls.Add(this.alterar);
            this.Controls.Add(this.cadastrar);
            this.Name = "frmAutores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autores";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button excluir;
        private System.Windows.Forms.Button alterar;
        private System.Windows.Forms.Button cadastrar;
        private System.Windows.Forms.Button addAutor;
    }
}