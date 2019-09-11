using Livraria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    public class AutorLivroDB
    {
        public static List<AutorLivro> GetAutorLivro()
        {
            List<AutorLivro> lista = new List<AutorLivro>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "SELECT al.*, a.nome as nome_autor, l.nome as nome_livro FROM autor_livro al JOIN autores a ON a.id_autor = al.id_autor JOIN livros l ON l.id_livro = al.id_livro";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AutorLivro autorLivro = new AutorLivro();
                    autorLivro.id_autor = (int)dr["id_autor"];
                    autorLivro.id_livro = (int)dr["id_livro"];
                    autorLivro.nome_livro = (string)dr["nome_livro"];
                    autorLivro.nome_autor = (string)dr["nome_autor"];
                    lista.Add(autorLivro);
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar AutorLivro." + erro.Message);
            }
            return lista;
        }
        public static bool postAutorLivro(AutorLivro autorLivro)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "INSERT INTO autor_livro(id_livro, id_autor) VALUES(@codigoLivro, @codigoAutor)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigoLivro", autorLivro.id_livro);
                cmd.Parameters.AddWithValue("@codigoAutor", autorLivro.id_autor);

                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }

            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao incluir" + erro.Message);
            }
            return incluiu;
        }
        public static bool deleteAutorLivro(AutorLivro autorLivro)
        {
            bool excluiu = false;

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "DELETE FROM autor_livro WHERE id_autor = @idAutor AND id_livro = @idLivro";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@idAutor", autorLivro.id_autor);
                cmd.Parameters.AddWithValue("@idLivro", autorLivro.id_livro);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir " + erro.Message);
            }
            return excluiu;
        }

    }
}
