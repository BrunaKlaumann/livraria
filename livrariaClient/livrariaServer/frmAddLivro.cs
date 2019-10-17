using livrariaServer.Controllers;
using livrariaServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace livrariaServer
{
    public partial class frmAddLivro : Form
    {
        public frmAddLivro()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void BtnAdicionar_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();
            livro.nome = txtNomeLivro.Text;

            string resposta = await LivroServices.PostLivro(livro);
            if (resposta == "OK")
            {
                MessageBox.Show("Livro adicionado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar Livro!");
            }
        }
    }
}
