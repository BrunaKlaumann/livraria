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

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            frmAddUsuario frm = new frmAddUsuario();
            frm.ShowDialog();
            AtualizaTela();
        }

        private async void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)dataGridView1.SelectedRows[0].DataBoundItem;
                string retorno = await UsuarioServices.DeleteUsuario(usuario);
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

        private async void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Usuario usuario = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
            string retorno = await UsuarioServices.PutUsuario(usuario);
            if (retorno == "OK")
            {
                //MessageBox.Show("Alterado com sucesso!");
                AtualizaTela();
            }
            else
            {
                MessageBox.Show("Erro na alteração!");
            }
        }
    }
}
