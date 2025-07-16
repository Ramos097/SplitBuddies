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
    public class UsuarioService : IUsuario
    {
        private readonly string _rutaArchivo;

        public UsuarioService()
        {
            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta 'src'
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Armamos ruta completa a LogicaNegocio\Almacenamiento\usuarios.json
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Asegurarse que la carpeta exista
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            _rutaArchivo = Path.Combine(almacenamientoPath, "usuarios.json");
        }


        public void AgregarUsuario(Usuario usuario)
        {
            var usuarios = LeerArchivo();
            usuario.Imagen = CopiarImagen(usuario.Imagen); // Copiamos la imagen a la carpeta de almacenamiento
            usuarios.Add(usuario);
            EscribirArchivo(usuarios);

        }

        public List<Usuario> ObtenerUsuarios()
        {
            return LeerArchivo();
        }

        private List<Usuario> LeerArchivo()
        {
            if (!File.Exists(_rutaArchivo))
            {
                return new List<Usuario>();
            }

            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
            }
            catch (Exception)
            {

                return new List<Usuario>();
            }

            
            
        }

        private void EscribirArchivo (List<Usuario> usuarios)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // Para que el JSON sea legible
                };
                var json = JsonSerializer.Serialize(usuarios, opciones);
                File.WriteAllText(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }

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
            return false; // Identificación no repetida
        }

        public string CopiarImagen(string rutaOriginal)
        {
            if (string.IsNullOrWhiteSpace(rutaOriginal) || !File.Exists(rutaOriginal))
                throw new FileNotFoundException("La imagen seleccionada no existe.");

            // Obtener la ruta base del proyecto
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            string carpetaDestino = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento", "imgs");

            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string nombreArchivo = Path.GetFileName(rutaOriginal);
            string destinoFinal = Path.Combine(carpetaDestino, nombreArchivo);

            // Evitar sobrescritura
            if (File.Exists(destinoFinal))
            {
                string ext = Path.GetExtension(nombreArchivo);
                string nombreSinExt = Path.GetFileNameWithoutExtension(nombreArchivo);
                nombreArchivo = $"{nombreSinExt}_{DateTime.Now.Ticks}{ext}";
                destinoFinal = Path.Combine(carpetaDestino, nombreArchivo);
            }

            File.Copy(rutaOriginal, destinoFinal);

            // Devolvemos solo la ruta relativa
            return Path.Combine("imgs", nombreArchivo);
        }

        public Usuario ValidarAutenticacion(string id, string pass)
        {
            List<Usuario> usuarios = ObtenerUsuarios();
            foreach (var usuario in usuarios)
            {
                if (usuario.Identificacion == id && usuario.Contrasenia == pass)
                {
                    return usuario; // Autenticación exitosa
                }
            }
            return null; // Autenticación fallida
        }
    }
}
