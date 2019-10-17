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
    public partial class frmAutores : Form
    {
        public frmAutores()
        {
            InitializeComponent();
            this.AtualizaTela();
        }

        private async void AtualizaTela()
        {
            List<Autor> lista = await AutorServices.GetAutores();
            dataGridView1.DataSource = lista;
        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            frmAddAutor frm = new frmAddAutor();
            frm.ShowDialog();
            AtualizaTela();
        }

        private async void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                Autor autor = (Autor)dataGridView1.SelectedRows[0].DataBoundItem;
                string retorno = await AutorServices.DeleteAutor(autor);
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
    }
}
