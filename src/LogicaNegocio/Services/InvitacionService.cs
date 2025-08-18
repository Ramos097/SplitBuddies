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

namespace LogicaNegocio.Services
{
    public class InvitacionService : IInvitancion
    {
        private readonly string _rutaArchivoUsuarios;
        private readonly string _rutaArchivoGrupoUsuarios;
        private readonly IGrupo _grupoService;
        private readonly IUsuario _usuarioService;


        public InvitacionService()
        {

            _grupoService = new GrupoService(); 
            _usuarioService = new UsuarioService();

            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta 'src'
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Armamos ruta completa a LogicaNegocio\Almacenamiento\usuarios.json
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Asegurarse que la carpeta exista
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            _rutaArchivoUsuarios = Path.Combine(almacenamientoPath, "usuarios.json");
            _rutaArchivoGrupoUsuarios = Path.Combine(almacenamientoPath, "gruposUsuarios.json");
        }



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
       


        public List<Grupo> ObtenerGruposInvitados(string usuarioId)
        {
            var gruposAlUsuario = LeerArchivoGrupoUsuarios();
            var grupos = new List<Grupo>();
            foreach (var grupo in gruposAlUsuario)
            {
                if (grupo.IdentificacionUsuario.Equals(usuarioId))
                {
                    if(grupo.EstadoInvitacion.Equals("PENDIENTE"))
                    {
                        var grupoEncontrado = _grupoService.ObtenerPorId(grupo.IdGrupo);
                        grupos.Add(grupoEncontrado);
                        
                    }
                }
            }
            return grupos;
        }













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
