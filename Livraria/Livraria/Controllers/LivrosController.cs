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
            lista.Where(l => l.id_livro == livros.id_livro)
                .Select(o => {
                    o.titulo = livros.titulo;
                    o.id_livro = livros.id_livro;
                    return o;
                })
                .ToList();
            return " Livro alterado com Sucesso!";
        }

        [AcceptVerbs("DELETE")]
        public string DeleteLivros(Livros livros)
        {
            Livros auxlivros = lista.Where(l => l.id_livro == livros.id_livro)
                    .Select(o => o)
                    .First();
            lista.Remove(auxlivros);
            return "Livro excluido com sucesso!";
        }
    }
}