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
    public partial class frmAddAutorLivro : Form
    {
        public frmAddAutorLivro()
        {
            InitializeComponent();
            comboBoxAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLivro.DropDownStyle = ComboBoxStyle.DropDownList;

            PopulaListas();
        }

        private async void PopulaListas()
        {
            List<Autor> autores = await AutorServices.GetAutores();
            comboBoxAutor.DataSource = autores;
            comboBoxAutor.DisplayMember = "nome";
            comboBoxAutor.ValueMember = "id_autor";

            List<Livro> livros= await LivroServices.GetLivros();
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
            AutorLivro autorLivro = new AutorLivro();
            autorLivro.id_autor = ((Autor) comboBoxAutor.SelectedItem).id_autor;
            autorLivro.id_livro = ((Livro) comboBoxLivro.SelectedItem).id_livro;

            string resposta = await AutorLivroServices.PostDados(autorLivro);
            if (resposta == "OK")
            {
                MessageBox.Show("Autor/Livro adicionado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar Autor/Livro!");
            }
        }
    }
}
