using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace LogicaNegocio.Services
{
    // Servicio que maneja la relación entre grupos y usuarios
    // (invitaciones, estado, pertenencia, etc.)
    public class GrupoUsuariosService : IGruposUsuarios
    {
        // Ruta del archivo JSON donde se guarda la información
        private readonly string _rutaArchivo;

        // Constructor: inicializa la ruta al archivo de almacenamiento
        public GrupoUsuariosService()
        {
            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta llegar al proyecto
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Carpeta de almacenamiento
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Crear carpeta si no existe
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            // Archivo donde se guardan las relaciones grupo-usuarios
            _rutaArchivo = Path.Combine(almacenamientoPath, "gruposUsuarios.json");
        }

        // ================== MÉTODOS PRIVADOS ==================

        // Lee el archivo JSON de grupos-usuarios y devuelve la lista
        private List<GrupoUsuarios> LeerArchivo()
        {
            if (!File.Exists(_rutaArchivo))
            {
                return new List<GrupoUsuarios>();
            }

            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                return JsonSerializer.Deserialize<List<GrupoUsuarios>>(json) ?? new List<GrupoUsuarios>();
            }
            catch (Exception)
            {
                // Si ocurre un error, se devuelve lista vacía
                return new List<GrupoUsuarios>();
            }
        }

        // Escribe la lista de grupos-usuarios en el archivo JSON
        private void EscribirArchivo(List<GrupoUsuarios> gruposUsuarios)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // JSON legible con sangrías
                };
                var json = JsonSerializer.Serialize(gruposUsuarios, opciones);
                File.WriteAllText(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }

        // ================== MÉTODOS PÚBLICOS ==================

        // Obtiene todos los grupos en los que participa un usuario
        public List<GrupoUsuarios> ObtenerGruposPorUsuario(string idUsuario)
        {
            var gruposUsuarios = LeerArchivo();
            List<GrupoUsuarios> gruposAsociados = new List<GrupoUsuarios>();

            foreach (var grupo in gruposUsuarios)
            {
                if (grupo.IdentificacionUsuario.Equals(idUsuario))
                {
                    gruposAsociados.Add(grupo);
                }
            }

            return gruposAsociados;
        }

        // Actualiza el estado de una invitación (ej: PENDIENTE, ACTIVO, RECHAZADA)
        public bool ActualizarEstadoInvitacion(string identificacion, int idgrupo, string Estado)
        {
            var gruposUsuarios = LeerArchivo();

            foreach (var grupo in gruposUsuarios)
            {
                // Buscar el registro que coincide con el usuario y el grupo
                if (grupo.IdentificacionUsuario.Equals(identificacion) && grupo.IdGrupo == idgrupo)
                {
                    if (Estado.Equals("RECHAZADA"))
                    {
                        // Si se rechaza, se elimina la relación
                        gruposUsuarios.Remove(grupo);
                        break;
                    }
                    else
                    {
                        // Si se acepta o cambia, solo se actualiza el estado
                        grupo.EstadoInvitacion = Estado;
                        break;
                    }
                }
            }

            // Guardar cambios en el archivo
            EscribirArchivo(gruposUsuarios);

            return true;
        }
    }
}
