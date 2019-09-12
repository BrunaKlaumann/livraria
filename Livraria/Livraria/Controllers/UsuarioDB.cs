using Livraria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    public class UsuarioDB
    {
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "SELECT * FROM usuarios";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id_usuario = (int)dr["id_usuario"];
                    usuario.nome = (string)dr["nome"];
                    lista.Add(usuario);
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar usuarios." + erro.Message);
            }
            return lista;
        }

        public static string insereUsuario(Usuario usuario)
        {
            int incluidos = 0;

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "INSERT INTO USUARIOS(nome) VALUES(@nome)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@nome", usuario.nome);

                incluidos = cmd.ExecuteNonQuery();
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao incluir usuário " + erro.Message);
            }

            if (incluidos == 1)
            {
                return "Usuário incuído com sucesso.";
            }
            else
            {
                return "Falha ao incluir o usuário";
            }
        }

        public static bool putUsuario(Usuario usuario)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "UPDATE usuarios SET nome = @nome WHERE id_usuario = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", usuario.id_usuario);
                cmd.Parameters.AddWithValue("@nome", usuario.nome);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar Usuário " + erro.Message);
            }
            return alterou;
        }

        public static bool deleteUsuario(Usuario usuario)
        {
            bool excluiu = false;

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "DELETE FROM usuarios WHERE id_usuario = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", usuario.id_usuario);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir Usuário " + erro.Message);
            }
            return excluiu;
        }
    }
}
