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
    public partial class frmAddUsuario : Form
    {
        public frmAddUsuario()
        {
            InitializeComponent();
        }

        private async void BtnAdicionar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.nome = txtNomeUsuario.Text;

            string resposta = await UsuarioServices.Postusuario(usuario);
            if (resposta == "OK")
            {
                MessageBox.Show("Usuário adicionado com sucesso!");
                Close();
            } else
            {
                MessageBox.Show("Erro ao adicionar usuário!");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
