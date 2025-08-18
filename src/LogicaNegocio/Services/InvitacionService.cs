using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

// Namespace: organiza el código en un grupo lógico
namespace LogicaNegocio.Services
{
    // Servicio que maneja la lógica de invitaciones a grupos
    public class InvitacionService : IInvitancion
    {
        // Archivos de almacenamiento
        private readonly string _rutaArchivoUsuarios;
        private readonly string _rutaArchivoGrupoUsuarios;

        // Dependencias hacia servicios de grupos y usuarios
        private readonly IGrupo _grupoService;
        private readonly IUsuario _usuarioService;

        // Constructor: inicializa dependencias y rutas de archivos
        public InvitacionService()
        {
            _grupoService = new GrupoService();
            _usuarioService = new UsuarioService();

            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta llegar a la raíz
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Carpeta de almacenamiento
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Crear carpeta si no existe
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            // Archivos usados
            _rutaArchivoUsuarios = Path.Combine(almacenamientoPath, "usuarios.json");
            _rutaArchivoGrupoUsuarios = Path.Combine(almacenamientoPath, "gruposUsuarios.json");
        }

        // ================== MÉTODOS PRIVADOS ==================

        // Lee las relaciones grupo-usuarios desde el archivo JSON
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
                // Si ocurre error, devolver lista vacía
                return new List<GrupoUsuarios>();
            }
        }

        // ================== MÉTODOS PÚBLICOS (INTERFAZ) ==================

        // Obtiene la lista de grupos a los que un usuario fue invitado
        // Solo devuelve los que están en estado "PENDIENTE"
        public List<Grupo> ObtenerGruposInvitados(string usuarioId)
        {
            var gruposAlUsuario = LeerArchivoGrupoUsuarios();
            var grupos = new List<Grupo>();

            foreach (var grupo in gruposAlUsuario)
            {
                if (grupo.IdentificacionUsuario.Equals(usuarioId))
                {
                    if (grupo.EstadoInvitacion.Equals("PENDIENTE"))
                    {
                        var grupoEncontrado = _grupoService.ObtenerPorId(grupo.IdGrupo);
                        grupos.Add(grupoEncontrado);
                    }
                }
            }
            return grupos;
        }

        // Obtiene los usuarios que forman parte de un grupo
        // Solo devuelve los que tienen estado "ACTIVO"
        public List<Usuario> ObtenerUsuariosGrupo(int idGrupo)
        {
            var gruposAlUsuario = LeerArchivoGrupoUsuarios();
            var UsuariosActivosGrupo = new List<Usuario>();

            foreach (var grupo in gruposAlUsuario)
            {
                if (grupo.IdGrupo == idGrupo)
                {
                    if (grupo.EstadoInvitacion.Equals("ACTIVO"))
                    {
                        var usuario = _usuarioService.ObtenerUsuarioById(grupo.IdentificacionUsuario);
                        UsuariosActivosGrupo.Add(usuario);
                    }
                }
            }
            return UsuariosActivosGrupo;
        }
    }
}
