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
                string sql = "select * from Livros";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int codigo = (int)dr["id_livros"];
                    string titulo = (string)dr["titulo"];
                    Livros livros = new Livros();
                    livros.id_livro= codigo;
                    livros.titulo = titulo;
                    lista.Add(livros);

                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar Livros." + erro.Message);
            }
            return lista;
        }
        public static bool SetIncuiLivros(Livros livros)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into livros(id_livro,titulo) values(@codigo,@titulo)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = livros.id_livro;
                cmd.Parameters.Add("@titulo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = livros.titulo;

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
        public static bool SetAlteraLivros(Livros livros)
        {
            bool alterou = false;
            try
            {
                //verifivar linha de update livros set ...... se der pau.
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update livros set id_livro=@codigo and titulo=@titulo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = livros.id_livro;
                cmd.Parameters.Add("@titulo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = livros.titulo;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar Livro" + erro.Message);

            }
            return alterou;
        }
        public static bool SetExcluiLivros(Livros livros)
        {
            bool excluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "delete from livros where id_livro=@codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = livros.id_livro;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir Livro" + erro.Message);
            }
            return excluiu;
        }

    }
}