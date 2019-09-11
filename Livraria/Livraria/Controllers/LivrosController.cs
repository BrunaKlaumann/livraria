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

        [AcceptVerbs("GET")]
        public List<Livros> GetLivros()
        {
            return LivrosDB.GetLivros();
        }

        [AcceptVerbs("POST")]
        public bool PostLivros(Livros livro)
        {
            return LivrosDB.SetIncuiLivros(livro);
        }

        [AcceptVerbs("PUT")]
        public string PutLivros(Livros livro)
        {
            bool alterou = LivrosDB.SetAlteraLivros(livro);
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
        public string DeleteLivros(Livros livro)
        {
            bool excluiu = LivrosDB.SetExcluiLivros(livro);
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