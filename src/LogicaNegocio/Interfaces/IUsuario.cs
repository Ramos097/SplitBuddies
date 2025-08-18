
using System.Collections.Generic;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace Proyecto_1.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un servicio de usuarios
    public interface IUsuario
    {
        // Agrega un nuevo usuario al sistema
        void AgregarUsuario(Usuario usuario);

        // Obtiene todos los usuarios registrados
        List<Usuario> ObtenerUsuarios();

        // Verifica si la identificación ya existe en el sistema (evita duplicados)
        bool ValidarIdentificacionRepetida(string id);

        // Copia una imagen a la carpeta de almacenamiento y devuelve la nueva ruta
        string CopiarImagen(string rutaOriginal);

        // Valida las credenciales de un usuario (autenticación con ID y contraseña)
        Usuario ValidarAutenticacion(string id, string pass);

        // Obtiene un usuario a partir de su identificación
        Usuario ObtenerUsuarioById(string identificacion);

        // Método comentado: pensado para asociar un grupo a un usuario, pero no se implementó aún
        //void AgregarGrupoUsuario(string idUsuario, GrupoAsociado nuevoGrupo);
    }
}

