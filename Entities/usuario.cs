using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string TipoUsuario { get; set; }

        // Nota: Por seguridad, NUNCA guardamos la contraseña en este objeto 
        // una vez que la sesión ya fue validada.
    }
}
