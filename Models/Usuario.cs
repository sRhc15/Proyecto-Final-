using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalum2020v1.Models
{
    public class Usuario
    {
        
       // public int Id{get; set;}
        [Key]
        public string Username {get; set;}
        public bool Enabled {get; set;}
        public string Nombres{get; set;}
        public string Apellidos {get; set;}
        public string Email{get; set;}

        public List<UsuarioRol> UsuariosRoles{ get; set;}
    }
}