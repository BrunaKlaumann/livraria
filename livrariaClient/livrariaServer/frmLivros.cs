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
    public partial class frmLivros : Form
    {
        public frmLivros()
        {
            InitializeComponent();
            this.AtualizaTela();
        }

        private async void AtualizaTela()
        {
            List<Livro> lista = await LivroServices.GetLivros();
            dataGridView1.DataSource = lista;
        }
    }
}
