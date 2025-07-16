using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Contrasenia { get; set; }
        public string Imagen { get; set; }

    }
}
