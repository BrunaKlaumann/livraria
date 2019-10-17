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
        [AcceptVerbs("GET")]
        public List<AutorLivro> GetAutorLivros()
        {
            return AutorLivroDB.GetAutorLivro();
        }

        [AcceptVerbs("POST")]
        public bool PostAutorLivro(AutorLivro autorLivro)
        {
            return AutorLivroDB.postAutorLivro(autorLivro);
        }

        [AcceptVerbs("POST")]
        [Route("delete")]
        public bool DeleteAutorLivro(AutorLivro autorLivro)
        {
            return AutorLivroDB.deleteAutorLivro(autorLivro);
        }
    }
}