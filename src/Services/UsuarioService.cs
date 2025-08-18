using Models;
using Proyecto_1.Interfaces;

namespace Proyecto_1.Services
{
    // Servicio que implementa la lógica para gestionar usuarios
    public class UsuarioService : IUsuario
    {
        // Lista en memoria de todos los usuarios
        private List<Usuario> usuarios;

        // Constructor: inicializa la lista vacía
        public UsuarioService()
        {
            usuarios = new List<Usuario>();
        }

        // Agrega un nuevo usuario a la lista
        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        // Obtiene todos los usuarios almacenados en memoria
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        // Valida si una identificación ya existe en la lista
        public bool ValidarIdentificacionRepetida(string id)
        {
            return usuarios.Any(u => u.Identificacion == id);
        }

        // Copia la imagen de perfil a la carpeta "imagenes" del proyecto
        public string CopiarImagen(string rutaOriginal)
        {
            // Ruta destino: /bin/Debug/.../imagenes
            string destino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenes");

            // Crear la carpeta si no existe
            if (!Directory.Exists(destino))
                Directory.CreateDirectory(destino);

            // Se arma el nombre de archivo y la ruta final
            string nombreArchivo = Path.GetFileName(rutaOriginal);
            string rutaDestino = Path.Combine(destino, nombreArchivo);

            // Copia la imagen (sobrescribe si ya existe)
            File.Copy(rutaOriginal, rutaDestino, true);

            // Retorna la ruta completa de la imagen copiada
            return rutaDestino;
        }

        // Valida credenciales de inicio de sesión
        public Usuario ValidarAutenticacion(string id, string pass)
        {
            return usuarios.FirstOrDefault(u => u.Identificacion == id && u.Contrasena == pass);
        }
    }
}
