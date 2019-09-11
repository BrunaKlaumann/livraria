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
    public class locacoesController : ControllerBase
    {
        public static List<Locacoes> lista = new List<Locacoes>();

        [AcceptVerbs("GET")]
        public List<Locacoes> GetLocacoes()
        {
            return lista;
        }

        [AcceptVerbs("POST")]
        public string PostLocacoes(Locacoes locacoes)
        {
            lista.Add(locacoes);
            return "Locacao incluída com Sucesso!";
        }

        //[AcceptVerbs("PUT")]
        //public string PutLocacoes(Locacoes locacoes)
        //{
        //    //Fiz ate aqui
        //    lista.Where(l => l.id_autor == autores.id_autor)
        //        .Select(o => {
        //            o.nome = autores.nome;
        //            o.id_autor = autores.id_autor;
        //            return o;
        //        })
        //        .ToList();
        //    return " Autor alterado com Sucesso!";
        //}

        //[AcceptVerbs("DELETE")]
        //public string DeleteAutores(Autores autores)
        //{
        //    Autores auxautores = lista.Where(l => l.id_autor == autores.id_autor)
        //            .Select(o => o)
        //            .First();
        //    lista.Remove(auxautores);
        //    return "Autor excluido com sucesso!";
        //}
    }
}