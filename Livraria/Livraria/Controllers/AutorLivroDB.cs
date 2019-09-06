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
                string sql = "select * from AutorLivro";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int codigoLivro = (int)dr["id_livro"];
                    int codigoAutor = (int)dr["id_autor"];
                    AutorLivro autorLivro = new AutorLivro();
                    autorLivro.id_autor = codigoLivro;
                    autorLivro.id_autor = codigoAutor;
                    lista.Add(autorLivro);

                }
            }
            //Fiz ate aqui o resto para baixo nao fiz nada 
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar Cidade." + erro.Message);
            }
            return lista;
        }
        public static bool SetIncuiCidade(Cidade cidade)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into cidade(cid_codigo,nome,est_sigla) values(@codigo,@nome,@sigla)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.cid_codigo;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.est_sigla;

                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }

            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro inclusão da cidade " + erro.Message);
            }
            return incluiu;
        }
        public static bool SetAlteraCidade(Cidade cidade)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update cidade set nome=@nome where cid_codigo = @codigo and est_sigla = @sigla";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.cid_codigo;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.est_sigla;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar Cidade" + erro.Message);

            }
            return alterou;
        }
        public static bool SetExcluiCidade(Cidade cidade)
        {
            bool excluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "delete from cidade where cid_codigo = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.cid_codigo;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir Cidade" + erro.Message);
            }
            return excluiu;
        }

    }
}
