using ApiUsuarios.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.BLL
{
    public class UsuariosBO
    {
        public List<Usuario> lstUsuarios = new List<Usuario>(); 
        public UsuariosBO()
        {
            lstUsuarios.Add(new Usuario { User = "User1", Password = "Clave1" });
            lstUsuarios.Add(new Usuario { User = "User2", Password = "Clave2" });
        }


        public bool ValidarCredenciales(Usuario usuario)
        {
            bool Respuesta = false;

            if (lstUsuarios.Any(u=>u.User == usuario.User  && u.Password == usuario.Password))
            {
                Respuesta = true;
            }

            return Respuesta;
        }
    }
}
