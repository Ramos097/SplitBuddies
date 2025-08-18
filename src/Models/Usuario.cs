using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        // Identificación única del usuario (puede ser cédula, DNI o similar)
        public string Identificacion { get; set; }

        // Nombre completo del usuario
        public string NombreCompleto { get; set; }

        // Correo electrónico del usuario (sirve como contacto o login alternativo)
        public string Correo { get; set; }

        // Edad del usuario
        public int Edad { get; set; }

        // Contraseña del usuario (⚠️ se recomienda guardar encriptada, no en texto plano)
        public string Contrasenia { get; set; }

        // Ruta de la imagen de perfil (almacenada en la carpeta imgs del proyecto)
        public string Imagen { get; set; }

    }
}
