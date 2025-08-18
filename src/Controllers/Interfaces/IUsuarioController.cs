using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace Proyecto_1.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un controlador de usuarios
    public interface IUsuarioController
    {
        // Agrega un nuevo usuario al sistema
        public void ctr_AgregarUsuario(Usuario usuario);

        // Valida si la identificación ya existe en el sistema (evita duplicados)
        public bool ctr_ValidarIdentificacionRepetida(string id);

        // Valida si un usuario puede iniciar sesión (autenticación con ID y contraseña)
        public Usuario ctr_ValidarAutenticacion(string id, string pass);

        // Obtiene la ruta completa de una imagen a partir de una ruta relativa
        public string ctr_ObtenerRutaImagen(string rutaRelativa);

        // Obtiene todos los usuarios registrados
        public List<Usuario> ctr_ObtenerUsuarios();

        // Obtiene un usuario específico a partir de su identificación
        public Usuario ctr_ObtenerUsuarioId(string identificacion);
    }
}

