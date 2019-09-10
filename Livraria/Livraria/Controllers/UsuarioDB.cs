using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    public class UsuarioDB
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
}
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar Autores." + erro.Message);
            }
            return lista;
        }
        public static bool SetIncuiAutores(Autores autores)
{
    bool incluiu = false;
    try
    {
        NpgsqlConnection conexao = Conexao.GetConexao();
        string sql = "insert into autores(id_autor,nome) values(@codigo,@nome)";
        NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
        cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = autores.id_autor;
        cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = autores.nome;

        int valor = cmd.ExecuteNonQuery();
        if (valor == 1)
        {
            incluiu = true;
        }

    }
    catch (NpgsqlException erro)
    {
        Console.WriteLine("Erro ao incluir Autor" + erro.Message);
    }
    return incluiu;
}
public static bool SetAlteraAutores(Autores autores)
{
    bool alterou = false;
    try
    {
        NpgsqlConnection conexao = Conexao.GetConexao();
        string sql = "update autores set nome=@nome where id_autores= @codigo and nome= @nome";
        NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
        cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = autores.id_autor;
        cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = autores.nome;
        int valor = cmd.ExecuteNonQuery();
        if (valor == 1)
        {
            alterou = true;
        }
    }
    catch (NpgsqlException erro)
    {
        Console.WriteLine("Erro ao alterar Autor" + erro.Message);

    }
    return alterou;
}
public static bool SetExcluiAutores(Autores autores)
{
    bool excluiu = false;
    try
    {
        NpgsqlConnection conexao = Conexao.GetConexao();
        string sql = "delete from autores where id_autor = @codigo";
        NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
        cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = autores.id_autor;
        int valor = cmd.ExecuteNonQuery();
        if (valor == 1)
        {
            excluiu = true;
        }
    }
    catch (NpgsqlException erro)
    {
        Console.WriteLine("Erro ao excluir Autor" + erro.Message);
    }
    return excluiu;
}
    }
}
