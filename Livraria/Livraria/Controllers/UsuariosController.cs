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
    public class UsuariosController : ControllerBase
    {
        [AcceptVerbs("GET")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioDB.GetUsuarios();
        }

        [AcceptVerbs("POST")]
        public string PostUsuario(Usuario usuario)
        {
            return UsuarioDB.insereUsuario(usuario);
        }

        [AcceptVerbs("PUT")]
        public bool PutUsuario(Usuario usuario)
        {
            return UsuarioDB.putUsuario(usuario);
        }

        [HttpDelete]
        [Route("{id_usuario}")]
        public bool DeleteUsuario(int id_usuario)
        {
            Usuario usuario = new Usuario();
            usuario.id_usuario = id_usuario;
            return UsuarioDB.deleteUsuario(usuario);
        }
    }
}