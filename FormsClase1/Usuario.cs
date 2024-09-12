using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsClase1
{
    internal class Usuario
    {
        public string NombreUsuario {  get; set; }
        public string Contraseña { get; set; }

        public Usuario(string usuario,string contraseña) { 
            NombreUsuario = usuario;
            Contraseña = contraseña;
        }
    }

 
}
