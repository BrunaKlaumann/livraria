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
    public partial class frmAutorLivro : Form
    {
        public frmAutorLivro()
        {
            InitializeComponent();
            AtualizaTela();
        }

        private async void AtualizaTela()
        {
            List<AutorLivro> lista = await AutorLivroServices.GetDados();
            dataGridView1.DataSource = lista;
        }
    }
}
