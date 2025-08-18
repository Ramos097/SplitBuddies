using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using LogicaNegocio.Interfaces;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

// Namespace: organiza el código en un grupo lógico
namespace LogicaNegocio.Services
{
    // Servicio que maneja toda la lógica de grupos (crear, leer, asignar miembros, etc.)
    public class GrupoService : IGrupo
    {
        // Rutas de archivos JSON donde se guardan grupos y grupos-usuarios
        private readonly string _rutaArchivoGrupos;
        private readonly string _rutaArchivoGrupoUsuarios;

        // Dependencia hacia el servicio de usuarios
        private readonly IUsuario _usuarioService;

        // Constructor: inicializa dependencias y rutas de archivos
        public GrupoService()
        {
            _usuarioService = new UsuarioService();

            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta llegar a la raíz del proyecto
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Carpeta de almacenamiento
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Crear carpeta si no existe
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            // Archivos usados por este servicio
            _rutaArchivoGrupos = Path.Combine(almacenamientoPath, "grupos.json");
            _rutaArchivoGrupoUsuarios = Path.Combine(almacenamientoPath, "gruposUsuarios.json");
        }

        // ================== MÉTODOS PRIVADOS PARA ARCHIVOS ==================

        // Lee todos los grupos desde el archivo JSON
        private List<Grupo> LeerArchivoGrupos()
        {
            if (!File.Exists(_rutaArchivoGrupos))
            {
                return new List<Grupo>();
            }

            try
            {
                var json = File.ReadAllText(_rutaArchivoGrupos);
                return JsonSerializer.Deserialize<List<Grupo>>(json) ?? new List<Grupo>();
            }
            catch (Exception)
            {
                return new List<Grupo>();
            }
        }

        // Escribe la lista de grupos al archivo JSON
        private void EscribirArchivoGrupos(List<Grupo> grupos)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // JSON legible con formato
                };
                var json = JsonSerializer.Serialize(grupos, opciones);
                File.WriteAllText(_rutaArchivoGrupos, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }

        // Lee la lista de relación grupo-usuarios desde JSON
        private List<GrupoUsuarios> LeerArchivoGrupoUsuarios()
        {
            if (!File.Exists(_rutaArchivoGrupoUsuarios))
            {
                return new List<GrupoUsuarios>();
            }

            try
            {
                var json = File.ReadAllText(_rutaArchivoGrupoUsuarios);
                return JsonSerializer.Deserialize<List<GrupoUsuarios>>(json) ?? new List<GrupoUsuarios>();
            }
            catch (Exception)
            {
                return new List<GrupoUsuarios>();
            }
        }

        // Escribe la lista de relación grupo-usuarios al archivo JSON
        private void EscribirArchivoGrupoUsuarios(List<GrupoUsuarios> grupoUsuarios)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // JSON legible con formato
                };
                var json = JsonSerializer.Serialize(grupoUsuarios, opciones);
                File.WriteAllText(_rutaArchivoGrupoUsuarios, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }

        // ================== MÉTODOS PÚBLICOS (INTERFAZ) ==================

        // Obtiene el último ID de grupo registrado (para generar el siguiente)
        public int ObtenerUltimoIdGrupo()
        {
            var grupos = LeerArchivoGrupos();

            if (grupos.Count == 0)
            {
                return 1; // Si no hay grupos, el primer ID será 1
            }

            var ultimoGrupo = grupos.LastOrDefault();
            return ultimoGrupo.Id + 1;
        }

        // Crea un nuevo grupo y lo asigna a los miembros
        public void CrearGrupo(Grupo grupo, List<string> miembros, string idCreadorGrupo)
        {
            var grupos = LeerArchivoGrupos();
            grupos.Add(grupo);
            EscribirArchivoGrupos(grupos);

            // Asignar el grupo a todos los miembros
            AsignarGruposAMiembros(grupo.Id, miembros, idCreadorGrupo);
        }

        // Obtiene todos los grupos registrados
        public List<Grupo> ObtenerGrupos()
        {
            return LeerArchivoGrupos();
        }

        // Busca un grupo por su ID, si no lo encuentra lanza excepción
        public Grupo ObtenerPorId(int id)
        {
            List<Grupo> grupos = ObtenerGrupos();
            foreach (var grupo in grupos)
            {
                if (grupo.Id == id)
                {
                    return grupo;
                }
            }
            throw new Exception("Grupo no encontrado con el Id proporcionado.");
        }

        // Asigna un grupo a una lista de miembros (incluye al creador con estado "ACTIVO")
        public void AsignarGruposAMiembros(int idGrupo, List<string> MiembrosGrupo, string idCreadorGrupo)
        {
            var ListgruposUsuarios = LeerArchivoGrupoUsuarios();

            foreach (var miembro in MiembrosGrupo)
            {
                try
                {
                    // Por defecto, la invitación está pendiente
                    var estado = "PENDIENTE";

                    // Si el miembro es el creador, se activa automáticamente
                    if (miembro.Equals(idCreadorGrupo))
                    {
                        estado = "ACTIVO";
                    }

                    // Crear registro grupo-usuario
                    GrupoUsuarios grupoUsuarios = new GrupoUsuarios
                    {
                        IdGrupo = idGrupo,
                        IdentificacionUsuario = miembro,
                        EstadoInvitacion = estado,
                    };

                    ListgruposUsuarios.Add(grupoUsuarios);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al asignar el grupo al miembro {miembro}: {ex.Message}");
                }
            }

            // Guardar cambios en archivo
            EscribirArchivoGrupoUsuarios(ListgruposUsuarios);
        }
    }
}
