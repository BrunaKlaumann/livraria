﻿using System;
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
    public class LocacoesController : ControllerBase
    {
        [AcceptVerbs("GET")]
        public List<Locacoes> GetLocacoes()
        {
            return LocacoesDB.GetLocacoes();
        }

        [AcceptVerbs("POST")]
        public bool PostLocacao(Locacoes locacao)
        {
            return LocacoesDB.postLocacao(locacao);
        }

        [AcceptVerbs("PUT")]
        public bool PutLocacao(Locacoes locacao)
        {
            return LocacoesDB.putLocacao(locacao);
        }

        [AcceptVerbs("DELETE")]
        public bool DeleteLocacao(Locacoes locacao)
        {
            return LocacoesDB.deleteLocacao(locacao);
        }
    }
}