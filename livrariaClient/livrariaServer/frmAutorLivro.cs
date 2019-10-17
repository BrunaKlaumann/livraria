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

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                AutorLivro autorLivro = (AutorLivro)dataGridView1.SelectedRows[0].DataBoundItem;
                string retorno = await AutorLivroServices.DeleteDados(autorLivro);
                if (retorno == "OK")
                {
                    MessageBox.Show("Excluído com sucesso!");
                    AtualizaTela();
                }
                else
                {
                    MessageBox.Show("Erro na exclusão!");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Selecione a linha inteira para realizar a exclusão!");
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            frmAddAutorLivro frm = new frmAddAutorLivro();
            frm.ShowDialog();
            AtualizaTela();
        }
    }
}
