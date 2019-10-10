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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            this.AtualizaTela();
        }

        private async void AtualizaTela()
        {
            List<Usuario> lista = await UsuarioServices.GetUsuarios();
            dataGridView1.DataSource = lista;
        }
    }
}
