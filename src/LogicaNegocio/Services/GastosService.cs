using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Proyecto_1.Interfaces;

namespace Proyecto_1.Services
{
    public class GastoService : IGasto
    {
        private readonly string _rutaArchivo;
        private readonly IGruposUsuarios _gruposUsuariosService;
        private readonly IGrupo _grupoService;
        private readonly IUsuario _usuarioService;


        public GastoService()
        {

            _gruposUsuariosService = new GrupoUsuariosService();
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

            _rutaArchivo = Path.Combine(almacenamientoPath, "gastos.json");

        }

        public List<Grupo> obtenerGruposActivos(string idUsuario)
        {
            var gruposUsuarios = _gruposUsuariosService.ObtenerGruposPorUsuario(idUsuario);
            List<Grupo> gruposActivos = new List<Grupo>();
            foreach (var grupo in gruposUsuarios)
            {
                if (grupo.EstadoInvitacion.Equals("ACTIVO"))
                {
                    var grupoActivo = _grupoService.ObtenerPorId(grupo.IdGrupo);
                    gruposActivos.Add(grupoActivo);
                }
            }
            return gruposActivos;
        }

        private List<Gasto> LeerArchivoGastos()
        {
            if (!File.Exists(_rutaArchivo))
            {
                return new List<Gasto>();
            }

            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                return JsonSerializer.Deserialize<List<Gasto>>(json) ?? new List<Gasto>();
            }
            catch (Exception)
            {

                return new List<Gasto>();
            }
        }
        private void EscribirArchivoGastos(List<Gasto> gastos)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // Para que el JSON sea legible
                };
                var json = JsonSerializer.Serialize(gastos, opciones);
                File.WriteAllText(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }



        public int ObtenerUltimoIdGasto()
        {
            var grupos = LeerArchivoGastos();

            if (grupos.Count == 0)
            {
                return 1;
            }


            var ultimoGrupo = grupos.LastOrDefault(); // Último elemento de la lista
            return ultimoGrupo.id + 1;
        }

        public void RegistrarGasto(Gasto gasto)
        {

            var grupos = LeerArchivoGastos();
            grupos.Add(gasto);
            EscribirArchivoGastos(grupos);
        }

        public List<Gasto> ObtenerGastosPorGrupo(int idGrupo)
        {
            var gastosGrupo = LeerArchivoGastos();
            List<Gasto> gastosDelGrupo = new List<Gasto>();
            foreach (var gasto in gastosGrupo)
            {
                if (gasto.idGrupo == idGrupo)
                {
                    gastosDelGrupo.Add(gasto);

                }
            }
            return gastosDelGrupo;
        }

        public List<Grupo> ObtenerGruposQueDebo(string identificacion)
        {
            var gastos = LeerArchivoGastos();
            List<Grupo> GruposDebo = new List<Grupo>();
            foreach (var gasto in gastos)
            {
                if (gasto.MiembrosQueDeben.Any(id => id.Equals(identificacion)))
                {
                    var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);
                    // Verificar si el grupo ya está en la lista para evitar duplicados
                    if (GruposDebo.Any(g => g.Id == grupo.Id))
                    {
                        continue; // Si ya está, saltar a la siguiente iteración
                    }
                    else
                    {
                        GruposDebo.Add(grupo);
                    }



                }
            }
            return GruposDebo;
        }

        public List<Gasto> ObtenerGastosPorUsuario(string idUsuario)
        {
            var gastos = LeerArchivoGastos();
            List<Gasto> gastosDelUsuario = new List<Gasto>();
            foreach (var gasto in gastos)
            {
                if (gasto.idUsuarioRegistraGasto.Equals(idUsuario))
                {
                    gastosDelUsuario.Add(gasto);
                }
            }
            return gastosDelUsuario;
        }

        public Gasto ObtenerGastoporID(int idGasto)
        {
            var gastos = LeerArchivoGastos();
            var gastoEncontrado = gastos.FirstOrDefault(g => g.id == idGasto);
            return gastoEncontrado;
        }

        public void ActualizarGasto(Gasto gastoActualizado)
        {

            var gastos = LeerArchivoGastos();
            foreach (var gasto in gastos)
            {
                if (gasto.id == gastoActualizado.id)
                {
                    gasto.Descripcion = gastoActualizado.Descripcion;
                    gasto.Nombre = gastoActualizado.Nombre;
                    gasto.Monto = gastoActualizado.Monto;
                    gasto.Fecha = gastoActualizado.Fecha;
                    gasto.MiembrosQueDeben = new List<string>(gastoActualizado.MiembrosQueDeben); // Aseguramos que sea una nueva lista
                    break;
                }
            }
            EscribirArchivoGastos(gastos);

            
        }

        public List<string> obtenerAQuieDebeUsuario(string idUsuario)
        {
            var gastos = ObtenerGastosQueDebeUsuario(idUsuario);
            List<string> aQuienDebe = new List<string>();
            foreach (var gasto in gastos)
            {
                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);
                var usuarioAquienDebe = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);
                var grupoDebo = "Grupo: "+grupo.Nombre;
                var debo = "Debo a: "+ usuarioAquienDebe.NombreCompleto;
         
                if (aQuienDebe.Contains(grupoDebo))
                {
                    continue; // Si ya está, saltar a la siguiente iteración
                }
                else
                {
                    aQuienDebe.Add(grupoDebo);
                    aQuienDebe.Add(debo);
                    aQuienDebe.Add("");

                }
                


            }

            return aQuienDebe;
        }

        public List<Gasto> ObtenerGastosQueDebeUsuario(string idUsuario)
        {
            var gastos = LeerArchivoGastos();
            List<Gasto> GastosaQuienDebe = new List<Gasto>();
            foreach (var gasto in gastos)
            {
                if (gasto.MiembrosQueDeben.Any(id => id.Equals(idUsuario)))
                {
                    GastosaQuienDebe.Add(gasto);
                }



            }

            return GastosaQuienDebe;
        }
    }
}
