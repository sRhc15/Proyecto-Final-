using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class Rol
    {
        public int Id {get; set;}
        public string Nombre {get; set;}

        public List<UsuarioRol> UsuariosRoles{ get; set;}
    }
}