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
    public partial class frmAddLocacao : Form
    {
        public frmAddLocacao()
        {
            InitializeComponent();

            comboBoxUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLivro.DropDownStyle = ComboBoxStyle.DropDownList;

            PopulaListas();
        }

        private async void PopulaListas()
        {
            List<Usuario> usuarios = await UsuarioServices.GetUsuarios();
            comboBoxUsuario.DataSource = usuarios;
            comboBoxUsuario.DisplayMember = "nome";
            comboBoxUsuario.ValueMember = "id_usuario";

            List<Livro> livros = await LivroServices.GetLivros();
            comboBoxLivro.DataSource = livros;
            comboBoxLivro.DisplayMember = "nome";
            comboBoxLivro.ValueMember = "id_livro";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void BtnAdicionar_Click(object sender, EventArgs e)
        {
            Locacao locacao = new Locacao();
            locacao.id_usuario = ((Usuario)comboBoxUsuario.SelectedItem).id_usuario;
            locacao.id_livro = ((Livro)comboBoxLivro.SelectedItem).id_livro;
            locacao.data_locacao = dateTimePickerLocacao.Value;
            locacao.data_devolucao = dateTimePickerDevolucao.Value;
            locacao.data_devolvido = dateTimePickerDevolvido.Value;

            string resposta = await LocacaoServices.PostLocacao(locacao);

            if (resposta == "OK")
            {
                MessageBox.Show("Locação adicionado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar locação!");
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
