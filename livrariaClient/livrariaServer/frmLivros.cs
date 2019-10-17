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

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            frmAddLivro frm = new frmAddLivro();
            frm.ShowDialog();
            AtualizaTela();
        }

        private async void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                Livro livro= (Livro)dataGridView1.SelectedRows[0].DataBoundItem;
                string retorno = await LivroServices.DeleteLivro(livro);
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
