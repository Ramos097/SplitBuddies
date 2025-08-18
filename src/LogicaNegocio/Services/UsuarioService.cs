using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using Proyecto_1.Interfaces;


namespace Proyecto_1.Services
{
    // Servicio que gestiona la lógica relacionada con los usuarios.
    // Implementa la interfaz IUsuario y maneja persistencia en un archivo JSON.
    public class UsuarioService : IUsuario
    {
        // Ruta del archivo donde se guardan los usuarios en formato JSON
        private readonly string _rutaArchivo;

        // Constructor: configura la ruta al archivo de usuarios.json
        public UsuarioService()
        {
            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta 'src'
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Armamos la ruta completa hacia LogicaNegocio\Almacenamiento
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Asegurarse que la carpeta exista (si no, la crea)
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            // Definimos la ruta final del archivo usuarios.json
            _rutaArchivo = Path.Combine(almacenamientoPath, "usuarios.json");
        }

        // ================================================================
        // -------------------- MÉTODOS PÚBLICOS ---------------------------
        // ================================================================

        // Agrega un usuario al archivo JSON
        public void AgregarUsuario(Usuario usuario)
        {
            var usuarios = LeerArchivo(); // Se leen los usuarios actuales
            usuario.Imagen = CopiarImagen(usuario.Imagen); // Copiamos la imagen del usuario
            usuarios.Add(usuario); // Se agrega el nuevo usuario
            EscribirArchivo(usuarios); // Se actualiza el archivo con el nuevo listado
        }

        // Devuelve todos los usuarios registrados
        public List<Usuario> ObtenerUsuarios()
        {
            return LeerArchivo();
        }

        // Verifica si la identificación ya existe
        public bool ValidarIdentificacionRepetida(string id)
        {
            List<Usuario> usuarios = ObtenerUsuarios();
            foreach (var usuario in usuarios)
            {
                if (usuario.Identificacion == id)
                {
                    return true; // Identificación repetida
                }
            }
            return false; // Identificación única
        }

        // Copia la imagen del usuario a la carpeta de almacenamiento "imgs"
        // y devuelve la ruta relativa de la copia.
        public string CopiarImagen(string rutaOriginal)
        {
            if (string.IsNullOrWhiteSpace(rutaOriginal) || !File.Exists(rutaOriginal))
                throw new FileNotFoundException("La imagen seleccionada no existe.");

            // Obtener la ruta base del proyecto
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Carpeta destino: LogicaNegocio\Almacenamiento\imgs
            string carpetaDestino = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento", "imgs");

            // Crear carpeta si no existe
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            // Nombre del archivo original
            string nombreArchivo = Path.GetFileName(rutaOriginal);
            string destinoFinal = Path.Combine(carpetaDestino, nombreArchivo);

            // Evitar sobrescritura: si ya existe, se genera un nuevo nombre con timestamp
            if (File.Exists(destinoFinal))
            {
                string ext = Path.GetExtension(nombreArchivo);
                string nombreSinExt = Path.GetFileNameWithoutExtension(nombreArchivo);
                nombreArchivo = $"{nombreSinExt}_{DateTime.Now.Ticks}{ext}";
                destinoFinal = Path.Combine(carpetaDestino, nombreArchivo);
            }

            // Copiar archivo
            File.Copy(rutaOriginal, destinoFinal);

            // Devolver ruta relativa para guardar en el JSON
            return Path.Combine("imgs", nombreArchivo);
        }

        // Valida las credenciales de un usuario (login)
        public Usuario ValidarAutenticacion(string id, string pass)
        {
            List<Usuario> usuarios = ObtenerUsuarios();
            foreach (var usuario in usuarios)
            {
                if (usuario.Identificacion == id && usuario.Contrasenia == pass)
                {
                    return usuario; // Autenticación correcta
                }
            }
            return null; // Falló autenticación
        }

        // Busca un usuario por su identificación
        public Usuario ObtenerUsuarioById(string identificacion)
        {
            List<Usuario> usuarios = ObtenerUsuarios();
            foreach (var usuario in usuarios)
            {
                if (usuario.Identificacion == identificacion)
                {
                    return usuario; // Usuario encontrado
                }
            }
            // Si no existe, lanza una excepción
            throw new Exception("Usuario no encontrado con la identificación proporcionada.");
        }

        /* 
        // Método comentado: Asociar un grupo a un usuario.
        // Permitiría agregar grupos dentro del listado personal de cada usuario.
        public void AgregarGrupoUsuario(string idUsuario, GrupoAsociado nuevoGrupo)
        {
            List<Usuario> usuarios = LeerArchivo();
            Usuario usuario = usuarios.FirstOrDefault(u => u.Identificacion == idUsuario);
            if (usuario != null)
            {
                usuario.GruposAsociados.Add(nuevoGrupo);
                EscribirArchivo(usuarios);
            }
            else
            {
                throw new Exception("Usuario no encontrado.");
            }
        } 
        */

        // ================================================================
        // -------------------- MÉTODOS PRIVADOS --------------------------
        // ================================================================

        // Lee el archivo usuarios.json y devuelve la lista de usuarios
        private List<Usuario> LeerArchivo()
        {
            if (!File.Exists(_rutaArchivo))
            {
                return new List<Usuario>(); // Si no existe, retorna lista vacía
            }

            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
            }
            catch (Exception)
            {
                return new List<Usuario>(); // Si ocurre error, retorna lista vacía
            }
        }

        // Escribe la lista de usuarios en el archivo usuarios.json
        private void EscribirArchivo(List<Usuario> usuarios)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // Para que el JSON quede legible
                };
                var json = JsonSerializer.Serialize(usuarios, opciones);
                File.WriteAllText(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }
    }
}
