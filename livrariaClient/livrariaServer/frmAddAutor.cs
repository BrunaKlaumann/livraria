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
    public partial class frmAddAutor : Form
    {
        public frmAddAutor()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void BtnCriar_Click(object sender, EventArgs e)
        {
            Autor autor = new Autor();
            autor.nome = txtNomeAutor.Text;

            string resposta = await AutorServices.PostAutor(autor);
            if (resposta == "OK")
            {
                MessageBox.Show("Autor adicionado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar usuário!");
            }
        }
    }
}
