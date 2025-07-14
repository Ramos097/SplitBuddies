using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Models
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Contraseña { get; set; }
        public string Imagen { get; set; }

    }
}
