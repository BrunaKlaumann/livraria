﻿namespace livrariaServer
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.livros = new System.Windows.Forms.Button();
            this.autores = new System.Windows.Forms.Button();
            this.usuarios = new System.Windows.Forms.Button();
            this.locacoes = new System.Windows.Forms.Button();
            this.btnLivroAutor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // livros
            // 
            this.livros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.livros.Location = new System.Drawing.Point(35, 73);
            this.livros.Name = "livros";
            this.livros.Size = new System.Drawing.Size(258, 24);
            this.livros.TabIndex = 0;
            this.livros.Text = "Livros";
            this.livros.UseVisualStyleBackColor = true;
            this.livros.Click += new System.EventHandler(this.Livros_Click);
            // 
            // autores
            // 
            this.autores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.autores.Location = new System.Drawing.Point(35, 27);
            this.autores.Name = "autores";
            this.autores.Size = new System.Drawing.Size(258, 26);
            this.autores.TabIndex = 1;
            this.autores.Text = "Autores";
            this.autores.UseVisualStyleBackColor = true;
            this.autores.Click += new System.EventHandler(this.Autores_Click);
            // 
            // usuarios
            // 
            this.usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.usuarios.Location = new System.Drawing.Point(35, 200);
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(258, 24);
            this.usuarios.TabIndex = 2;
            this.usuarios.Text = "Usuários";
            this.usuarios.UseVisualStyleBackColor = true;
            this.usuarios.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // locacoes
            // 
            this.locacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.locacoes.Location = new System.Drawing.Point(35, 159);
            this.locacoes.Name = "locacoes";
            this.locacoes.Size = new System.Drawing.Size(258, 24);
            this.locacoes.TabIndex = 3;
            this.locacoes.Text = "Locações";
            this.locacoes.UseVisualStyleBackColor = true;
            this.locacoes.Click += new System.EventHandler(this.Locacoes_Click);
            // 
            // btnLivroAutor
            // 
            this.btnLivroAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLivroAutor.Location = new System.Drawing.Point(35, 115);
            this.btnLivroAutor.Name = "btnLivroAutor";
            this.btnLivroAutor.Size = new System.Drawing.Size(258, 24);
            this.btnLivroAutor.TabIndex = 4;
            this.btnLivroAutor.Text = "Livro/Autor";
            this.btnLivroAutor.UseVisualStyleBackColor = true;
            this.btnLivroAutor.Click += new System.EventHandler(this.BtnLivroAutor_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 268);
            this.Controls.Add(this.btnLivroAutor);
            this.Controls.Add(this.locacoes);
            this.Controls.Add(this.usuarios);
            this.Controls.Add(this.autores);
            this.Controls.Add(this.livros);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Controle Livraria";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button livros;
        private System.Windows.Forms.Button autores;
        private System.Windows.Forms.Button usuarios;
        private System.Windows.Forms.Button locacoes;
        private System.Windows.Forms.Button btnLivroAutor;
    }
}

