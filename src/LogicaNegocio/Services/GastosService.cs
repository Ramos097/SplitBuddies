using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Proyecto_1.Interfaces;

// Namespace: organiza el código en un grupo lógico
namespace Proyecto_1.Services
{
    // Servicio que maneja toda la lógica de gastos (leer/guardar/consultar en JSON)
    public class GastoService : IGasto
    {
        // Ruta del archivo JSON donde se guardan los gastos
        private readonly string _rutaArchivo;

        // Dependencias hacia otros servicios (grupos, relación grupos-usuarios y usuarios)
        private readonly IGruposUsuarios _gruposUsuariosService;
        private readonly IGrupo _grupoService;
        private readonly IUsuario _usuarioService;

        // Constructor: inicializa servicios y prepara la ruta del archivo JSON
        public GastoService()
        {
            // Servicios usados por este servicio
            _gruposUsuariosService = new GrupoUsuariosService();
            _grupoService = new GrupoService();
            _usuarioService = new UsuarioService();

            // Ruta base de ejecución (ej.: bin/Debug/net9.0-windows)
            // Subimos 4 niveles para llegar a la carpeta raíz del proyecto
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            // Carpeta donde se almacenan los archivos JSON
            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            // Si la carpeta no existe, se crea
            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            // Archivo de gastos
            _rutaArchivo = Path.Combine(almacenamientoPath, "gastos.json");
        }

        // Obtiene los grupos activos (invitación en estado "ACTIVO") para un usuario
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

        // Lee el archivo JSON de gastos y devuelve la lista; si no existe o hay error, retorna lista vacía
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
                // Si ocurre cualquier error al leer/deserializar, devolver lista vacía
                return new List<Gasto>();
            }
        }

        // Escribe la lista de gastos al archivo JSON (con formato legible)
        private void EscribirArchivoGastos(List<Gasto> gastos)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true // JSON con sangría para lectura fácil
                };
                var json = JsonSerializer.Serialize(gastos, opciones);
                File.WriteAllText(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                // Si falla la escritura, lanza una excepción con detalle
                throw new Exception("Error al escribir en el archivo: " + ex.Message);
            }
        }

        // Devuelve el próximo ID para un nuevo gasto (toma el último y suma 1)
        public int ObtenerUltimoIdGasto()
        {
            var grupos = LeerArchivoGastos();

            if (grupos.Count == 0)
            {
                return 1; // Si no hay registros, empezamos en 1
            }

            var ultimoGrupo = grupos.LastOrDefault(); // Último elemento de la lista
            return ultimoGrupo.id + 1;                // Siguiente ID
        }

        // Registra (agrega) un nuevo gasto a la lista y persiste en el archivo
        public void RegistrarGasto(Gasto gasto)
        {
            var grupos = LeerArchivoGastos();
            grupos.Add(gasto);
            EscribirArchivoGastos(grupos);
        }

        // Obtiene todos los gastos que pertenecen a un grupo específico
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

        // Devuelve los grupos en los que el usuario (identificación) aparece como "que debe"
        public List<Grupo> ObtenerGruposQueDebo(string identificacion)
        {
            var gastos = LeerArchivoGastos();
            List<Grupo> GruposDebo = new List<Grupo>();

            foreach (var gasto in gastos)
            {
                // Si el usuario está en la lista de deudores del gasto
                if (gasto.MiembrosQueDeben.Any(id => id.Equals(identificacion)))
                {
                    var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                    // Evitar duplicados del mismo grupo
                    if (GruposDebo.Any(g => g.Id == grupo.Id))
                    {
                        continue; // ya estaba agregado
                    }
                    else
                    {
                        GruposDebo.Add(grupo);
                    }
                }
            }
            return GruposDebo;
        }

        // Obtiene todos los gastos registrados por un usuario (quien creó el gasto)
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

        // Busca y devuelve un gasto por su ID (o null si no existe)
        public Gasto ObtenerGastoporID(int idGasto)
        {
            var gastos = LeerArchivoGastos();
            var gastoEncontrado = gastos.FirstOrDefault(g => g.id == idGasto);
            return gastoEncontrado;
        }

        // Actualiza los campos de un gasto existente y guarda los cambios
        public void ActualizarGasto(Gasto gastoActualizado)
        {
            var gastos = LeerArchivoGastos();

            foreach (var gasto in gastos)
            {
                if (gasto.id == gastoActualizado.id)
                {
                    // Sobrescribe los campos editables
                    gasto.Descripcion = gastoActualizado.Descripcion;
                    gasto.Nombre = gastoActualizado.Nombre;
                    gasto.Monto = gastoActualizado.Monto;
                    gasto.Fecha = gastoActualizado.Fecha;

                    // Se asigna una NUEVA lista para evitar referencias compartidas
                    gasto.MiembrosQueDeben = new List<string>(gastoActualizado.MiembrosQueDeben);
                    break; // ya encontramos y actualizamos el gasto
                }
            }

            // Persistir cambios
            EscribirArchivoGastos(gastos);
        }

        // Devuelve una lista "plana" de textos indicando a quién debe el usuario por grupo
        public List<string> obtenerAQuieDebeUsuario(string idUsuario)
        {
            // Primero obtenemos los gastos donde el usuario aparece como deudor
            var gastos = ObtenerGastosQueDebeUsuario(idUsuario);
            List<string> aQuienDebe = new List<string>();

            foreach (var gasto in gastos)
            {
                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);
                var usuarioAquienDebe = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);

                // Construye líneas de salida
                var grupoDebo = "Grupo: " + grupo.Nombre;
                var debo = "Debo a: " + usuarioAquienDebe.NombreCompleto;

                // Evitar repetir el mismo grupo
                if (aQuienDebe.Contains(grupoDebo))
                {
                    continue; // ya agregado previamente
                }
                else
                {
                    // Agrega líneas y una línea en blanco como separador
                    aQuienDebe.Add(grupoDebo);
                    aQuienDebe.Add(debo);
                    aQuienDebe.Add("");
                }
            }

            return aQuienDebe;
        }

        // Devuelve los gastos en los que el usuario es deudor (aparece en MiembrosQueDeben)
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

