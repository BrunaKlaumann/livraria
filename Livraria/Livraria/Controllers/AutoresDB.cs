using Livraria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    public class AutoresDB
    {
        public static List<Autores> GetAutores()
        {
            List<Autores> lista = new List<Autores>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from autores";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int codigo = (int)dr["id_autor"];
                    string nome = (string)dr["nome"];
                    Autores autores = new Autores();
                    autores.id_autor = codigo;
                    autores.nome = nome;
                    lista.Add(autores);
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar Autores." + erro.Message);
            }
            return lista;
        }
        public static string SetIncuiAutores(Autores autor)
        {
            int incluidos = 0;

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into autores(nome) values(@nome)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@nome", autor.nome);

                incluidos = cmd.ExecuteNonQuery();
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao incluir Autor" + erro.Message);
            }

            if (incluidos == 1)
            {
                return "Autor incuído com sucesso.";
            }
            else
            {
                return "Falha ao incluir o autor";
            }
        }

        public static bool SetAlteraAutores(Autores autor)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update autores set nome = @nome where id_autor = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", autor.id_autor);
                cmd.Parameters.AddWithValue("@nome", autor.nome);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar Autor" + erro.Message);
            }
            return alterou;
        }
        public static bool SetExcluiAutores(Autores autor)
        {
            bool excluiu = false;

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "delete from autores where id_autor = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", autor.id_autor);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir Autor" + erro.Message);
            }
            return excluiu;
        }
    }
}
