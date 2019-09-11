using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        public static List<Livros> lista = new List<Livros>();

        [AcceptVerbs("GET")]
        public List<Livros> GetLivros()
        {
            return lista;
        }

        [AcceptVerbs("POST")]
        public string PostLivros(Livros livros)
        {
            lista.Add(livros);
            return "Livro incluído com Sucesso!";
        }
        [AcceptVerbs("PUT")]
        public string PutLivros(Livros livros)
        {
            bool alterou = livrosDB.SetAlteraLivros(livros);
            if (alterou)
            {
                return "Livros alterados com sucesso!";
            }
            else
            {
                return "Erro livro não alterado!";
            }

        }

        [AcceptVerbs("DELETE")]
        public string DeleteLivros(Livros livros)
        {
            bool excluiu = livrosDB.SetExcluiLivros(livros);
            if (excluiu)
            {
                return "Livro excluído com sucesso!";
            }
            else
            {
                return "Erro livro não excluído!";
            }
        }
    }
}