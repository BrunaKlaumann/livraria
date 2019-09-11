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
    public class UsuarioController : ControllerBase
    {
        public static List<Autores> lista = new List<Autores>();

        [AcceptVerbs("GET")]
        public List<Autores> GetAutores()
        {
            return lista;
        }

        [AcceptVerbs("POST")]
        public string PostAutores(Autores autores)
        {
            lista.Add(autores);
            return "Autor incluído com Sucesso!";
        }

        [AcceptVerbs("PUT")]
        public string PutAutores(Autores autores)
        {
            lista.Where(l => l.id_autor == autores.id_autor)
                .Select(o =>
                {
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
    }
}