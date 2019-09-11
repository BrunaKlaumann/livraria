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
                    autorLivro.id_livro = codigoLivro;
                    autorLivro.id_autor = codigoAutor;
                    lista.Add(autorLivro);

                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar AutorLivro." + erro.Message);
            }
            return lista;
        }
        public static bool SetIncuiAutorLivro(AutorLivro autorLivro)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into cidade(id_livro, id_autor) values(@codigoLivro, @codigoAutor)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigoLivro", NpgsqlTypes.NpgsqlDbType.Integer).Value = autorLivro.id_livro;
                cmd.Parameters.Add("@codigoAutor", NpgsqlTypes.NpgsqlDbType.Integer).Value = autorLivro.id_autor;

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
        public static bool SetAlteraAutorLivro(AutorLivro autorLivro)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update autorLivro set id_livro=@codigoLivro and id_autor=@codigoAutor";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigoLivro", NpgsqlTypes.NpgsqlDbType.Integer).Value = autorLivro.id_livro;
                cmd.Parameters.Add("@codigoAutor", NpgsqlTypes.NpgsqlDbType.Integer).Value = autorLivro.id_autor;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar" + erro.Message);

            }
            return alterou;
        }
        //public static bool SetExcluiCidade(Cidade cidade)
        //{
        //    bool excluiu = false;
        //    try
        //    {
        //        NpgsqlConnection conexao = Conexao.GetConexao();
        //        string sql = "delete from cidade where cid_codigo = @codigo";
        //        NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
        //        cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.cid_codigo;
        //        int valor = cmd.ExecuteNonQuery();
        //        if (valor == 1)
        //        {
        //            excluiu = true;
        //        }
        //    }
        //    catch (NpgsqlException erro)
        //    {
        //        Console.WriteLine("Erro ao excluir Cidade" + erro.Message);
        //    }
        //    return excluiu;
        //}

    }
}
