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
    public class AutoresController : ControllerBase
    {
        [AcceptVerbs("GET")]
        public List<Autores> GetAutores()
        {
            return AutoresDB.GetAutores();
        }

        [AcceptVerbs("POST")]
        public string PostAutores(Autores autor)
        {
            return AutoresDB.SetIncuiAutores(autor);
        }

        [AcceptVerbs("PUT")]
        public bool PutAutores(Autores autor)
        {
            return AutoresDB.SetAlteraAutores(autor);
        }

        [HttpDelete]
        [Route("{id_autor}")]
        public bool DeleteAutores(int id_autor)
        {
            Autores autor = new Autores();
            autor.id_autor = id_autor;
            return AutoresDB.SetExcluiAutores(autor);
        }
    }
}