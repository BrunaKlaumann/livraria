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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Livros_Click(object sender, EventArgs e)
        {
            frmLivros frm = new frmLivros();
            frm.ShowDialog();
        }

        private void Autores_Click(object sender, EventArgs e)
        {
            frmAutores frm = new frmAutores();
            frm.ShowDialog();
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.ShowDialog();
        }

        private void Locacoes_Click(object sender, EventArgs e)
        {
            frmLocacoes frm = new frmLocacoes();
            frm.ShowDialog();
        }
    }
}
