using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;
using Models;

namespace LogicaNegocio.Services
{
    public class GrupoUsuariosService : IGruposUsuarios
    {


        private readonly string _rutaArchivo;

        public GrupoUsuariosService()
        {
            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta 'src'
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Armamos ruta completa a LogicaNegocio\Almacenamiento\usuarios.json
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Asegurarse que la carpeta exista
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            _rutaArchivo = Path.Combine(almacenamientoPath, "gruposUsuarios.json");
        }


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

                return new List<GrupoUsuarios>();
            }



        }

        private void EscribirArchivo(List<GrupoUsuarios> gruposUsuarios)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // Para que el JSON sea legible
                };
                var json = JsonSerializer.Serialize(gruposUsuarios, opciones);
                File.WriteAllText(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }


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

        public bool ActualizarEstadoInvitacion(string identificacion, int idgrupo, string Estado)
        {
            var gruposUsuarios = LeerArchivo();

            foreach (var grupo in gruposUsuarios)
            {
                if (grupo.IdentificacionUsuario.Equals(identificacion) && grupo.IdGrupo == idgrupo)
                {
                    if (Estado.Equals("RECHAZADA"))
                    {
                        gruposUsuarios.Remove(grupo);
                        break;
                    }
                    else
                    {
                        grupo.EstadoInvitacion = Estado;
                        break;

                    }
                    
                }
            }
            EscribirArchivo(gruposUsuarios);
           
            return true;


        }
    }
}
