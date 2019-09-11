using Livraria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    public class livrosDB
    {
        public static List<Livros> GetLivros()
        {
            List<Livros> lista = new List<Livros>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "SELECT * FROM livros";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int codigo = (int)dr["id_livro"];
                    string nome = (string)dr["nome"];
                    Livros livros = new Livros();
                    livros.id_livro = codigo;
                    livros.nome = nome;
                    lista.Add(livros);
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar Livros. " + erro.Message);
            }
            return lista;
        }
        public static bool SetIncuiLivros(Livros livro)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "INSERT INTO livros(nome) VALUES(@nome)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@nome", livro.nome);

                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }

            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro inclusão do livros " + erro.Message);
            }
            return incluiu;
        }
        public static bool SetAlteraLivros(Livros livro)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "UPDATE livros SET nome = @nome WHERE id_livro = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", livro.id_livro);
                cmd.Parameters.AddWithValue("@nome", livro.nome);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar Livro " + erro.Message);

            }
            return alterou;
        }
        public static bool SetExcluiLivros(Livros livro)
        {
            bool excluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "DELETE FROM livros WHERE id_livro=@codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", livro.id_livro);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir Livro " + erro.Message);
            }
            return excluiu;
        }

    }
}