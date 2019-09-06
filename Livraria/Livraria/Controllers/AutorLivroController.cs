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
    public class AutorLivroController : ControllerBase
    {
        public static List<AutorLivro> lista = new List<AutorLivro>();

        [AcceptVerbs("GET")]
        public List<AutorLivro> GetAutorLivro()
        {
            return lista;
        }

        [AcceptVerbs("POST")]
        public string PostAutorLivro(AutorLivro autorLivro)
        {
            lista.Add(autorLivro);
            return "Autor incluído com Sucesso!";
        }
        [AcceptVerbs("PUT")]
        public string PutAutorLivro(AutorLivro autorLivro)
            //Mexi ate aqui apenas para baixo s'o ctrl c
        {
            lista.Where(l => l.id_autor == autores.id_autor)
                .Select(o => {
                    o.nome = autores.nome;
                    o.id_autor = autores.id_autor;
                    return o;
                })
                .ToList();
            return " Autor alterado com Sucesso!";
        }

        [AcceptVerbs("DELETE")]
        public string DeleteAutores(Autores autores)
        {
            Autores auxautores = lista.Where(l => l.id_autor == autores.id_autor)
                    .Select(o => o)
                    .First();
            lista.Remove(auxautores);
            return "Autor excluido com sucesso!";
        }
    }2
}
}