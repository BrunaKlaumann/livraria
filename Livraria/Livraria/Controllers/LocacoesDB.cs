using Livraria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    public class LocacoesDB
    {
        public static List<Locacoes> GetLocacoes()
        {
            List<Locacoes> lista = new List<Locacoes>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select l.*, u.nome as nome_usuario, li.nome as nome_livro from locacoes l join usuarios u on l.id_usuario = u.id_usuario join livros li on li.id_livro = l.id_livro";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Locacoes locacao = new Locacoes();
                    locacao.id_livro = (int)dr["id_livro"];
                    locacao.id_locacao = (int)dr["id_locacao"];
                    locacao.id_usuario = (int)dr["id_usuario"];
                    locacao.nome_livro = (string)dr["nome_livro"];
                    locacao.nome_usuario = (string)dr["nome_usuario"];
                    locacao.data_devolucao = (DateTime)dr["data_devolucao"];
                    locacao.data_devolvido = (DateTime)dr["data_devolvido"];
                    locacao.data_locacao = (DateTime)dr["data_locacao"];
                    lista.Add(locacao);
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar Locações. " + erro.Message);
            }
            return lista;
        }

        public static bool postLocacao(Locacoes locacao)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "INSERT INTO locacoes(id_livro, id_usuario, data_locacao, data_devolucao, data_devolvido) VALUES(@idLivro, @idUsuario, @dataLocacao, @dataDevolucao, @dataDevolvido)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@idLivro", locacao.id_livro);
                cmd.Parameters.AddWithValue("@idUsuario", locacao.id_usuario);
                cmd.Parameters.AddWithValue("@dataLocacao", locacao.data_locacao);
                cmd.Parameters.AddWithValue("@dataDevolucao", locacao.data_devolucao);
                cmd.Parameters.AddWithValue("@dataDevolvido", locacao.data_devolvido);

                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro inclusão da locação. " + erro.Message);
            }
            return incluiu;
        }

        public static bool putLocacao(Locacoes locacao)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "UPDATE locacoes SET id_livro = @idLivro, id_usuario = @idUsuario, data_locacao = @dataLocacao, data_devolucao = @dataDevolucao, data_devolvido = @dataDevolvido WHERE id_locacao = @idLocacao";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@idLocacao", locacao.id_locacao);
                cmd.Parameters.AddWithValue("@idLivro", locacao.id_livro);
                cmd.Parameters.AddWithValue("@idUsuario", locacao.id_usuario);
                cmd.Parameters.AddWithValue("@dataLocacao", locacao.data_locacao);
                cmd.Parameters.AddWithValue("@dataDevolucao", locacao.data_devolucao);
                cmd.Parameters.AddWithValue("@dataDevolvido", locacao.data_devolvido);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar Livro " + erro.Message);

            }
            return alterou;
        }

        public static bool deleteLocacao(Locacoes locacao)
        {
            bool excluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "DELETE FROM locacoes WHERE id_locacao=@codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", locacao.id_locacao);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
                Conexao.setFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir Locação " + erro.Message);
            }
            return excluiu;
        }
    }
}
