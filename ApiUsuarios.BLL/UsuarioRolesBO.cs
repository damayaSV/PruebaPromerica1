using ApiUsuarios.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.BLL
{
    public class UsuarioRolesBO
    {
        public List<UsuariosRoles> lstUsuariosRoles = new List<UsuariosRoles> { };
        public UsuarioRolesBO()
        {
            lstUsuariosRoles.Add(new UsuariosRoles { Usuario = "User1", Rol = "Principal" });
            lstUsuariosRoles.Add(new UsuariosRoles { Usuario = "User2", Rol = "Delegado" });
        }

        public string GetRolUsuario(string usuario)
        {
            string Respuesta = "";

            var user = lstUsuariosRoles.Where(x => x.Usuario == usuario).FirstOrDefault();

            if (user != null )
            {
                Respuesta = user.Rol;
            }

            return Respuesta;
        }
    }
}
