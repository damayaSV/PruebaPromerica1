using ApiUsuarios.BLL;
using ApiUsuarios.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet("ValidarCredenciales")]
        public bool ValidarCredenciales(string usuario, string password)
        {
            var BLL = new UsuariosBO();

            Usuario Usuario = new Usuario { User=usuario ,Password = password };

            return BLL.ValidarCredenciales(Usuario);

        }

        [HttpGet("ObtenerRolesUsuario")]
        public string  ObtenerRolesUser(string usuario)
        {
            var BLL = new UsuarioRolesBO();
            return BLL.GetRolUsuario(usuario);

        }
    }
}
