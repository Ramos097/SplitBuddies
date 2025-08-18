using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using LogicaNegocio.Interfaces;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

namespace LogicaNegocio.Services
{
    public class GrupoService : IGrupo
    {

        private readonly string _rutaArchivoGrupos;
        private readonly string _rutaArchivoGrupoUsuarios;
        private readonly IUsuario _usuarioService;
        public GrupoService()
        {

            _usuarioService = new UsuarioService();

            // Ruta base: bin/Debug/net9.0-windows → subimos 4 niveles hasta 'src'
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Armamos ruta completa a LogicaNegocio\Almacenamiento\usuarios.json
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Asegurarse que la carpeta exista
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            _rutaArchivoGrupos = Path.Combine(almacenamientoPath, "grupos.json");
            _rutaArchivoGrupoUsuarios = Path.Combine(almacenamientoPath, "gruposUsuarios.json");
        }

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
        private void EscribirArchivoGrupos(List<Grupo> grupos)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // Para que el JSON sea legible
                };
                var json = JsonSerializer.Serialize(grupos, opciones);
                File.WriteAllText(_rutaArchivoGrupos, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }



        public int ObtenerUltimoIdGrupo()
        {
            var grupos = LeerArchivoGrupos();

            if (grupos.Count == 0)
            {
                return 1;
            }
                

            var ultimoGrupo = grupos.LastOrDefault(); // Último elemento de la lista
            return ultimoGrupo.Id + 1;
        }


        public void CrearGrupo(Grupo grupo, List<string> miembros,string idCreadorGrupo)
        {
            var grupos= LeerArchivoGrupos();
            grupos.Add(grupo);
            EscribirArchivoGrupos(grupos);
            AsignarGruposAMiembros(grupo.Id, miembros, idCreadorGrupo);
            //----------------
        }

        




        public List<Grupo> ObtenerGrupos()
        {
           return LeerArchivoGrupos();
        }

        public Grupo ObtenerPorId(int id)
        {
            List<Grupo> grupos = ObtenerGrupos();
            foreach (var grupo in grupos)
            {
                if (grupo.Id == id)
                {
                    return grupo; // Usuario encontrado
                }
            }
            throw new Exception("Grupo no encontrado con el Id proporcionado.");
        }

        public void AsignarGruposAMiembros(int idGrupo, List<string> MiembrosGrupo, string idCreadorGrupo)
        {
            var ListgruposUsuarios = LeerArchivoGrupoUsuarios();
            foreach (var miembro in MiembrosGrupo)
            {


                
               
                try
                {
                    var estado ="PENDIENTE";
                    if (miembro.Equals(idCreadorGrupo))
                    {
                       
                        estado = "ACTIVO";
                    }
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
            EscribirArchivoGrupoUsuarios(ListgruposUsuarios);
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
        private void EscribirArchivoGrupoUsuarios(List<GrupoUsuarios> grupoUsuarios)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // Para que el JSON sea legible
                };
                var json = JsonSerializer.Serialize(grupoUsuarios, opciones);
                File.WriteAllText(_rutaArchivoGrupoUsuarios, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }

        
    }
}
