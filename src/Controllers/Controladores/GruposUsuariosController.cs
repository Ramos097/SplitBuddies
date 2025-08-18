using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Controladores
{
    // Clase que controla las operaciones relacionadas con los grupos y usuarios
    // Implementa la interfaz IGrupoUsuariosController
    public class GruposUsuariosController : IGrupoUsuariosController
    {
        // Campo privado que guarda la referencia al servicio de grupos-usuarios
        private readonly IGruposUsuarios _grupoUsuariosService;

        // Constructor: inicializa el servicio de grupos-usuarios al crear el controlador
        public GruposUsuariosController()
        {
            _grupoUsuariosService = new GrupoUsuariosService();
        }

        // Método: actualiza el estado de una invitación (ej: aceptada, rechazada)
        // Recibe la identificación del usuario, el ID del grupo y el nuevo estado
        public bool ActualizarEstadoInvitacion(string identificacion, int idgrupo, string Estado)
        {
            return _grupoUsuariosService.ActualizarEstadoInvitacion(identificacion, idgrupo, Estado);
        }

        // Método: obtiene todos los grupos a los que pertenece un usuario según su ID
        public List<GrupoUsuarios> crt_ObtenerGruposPorUsuario(string idUsuario)
        {
            return _grupoUsuariosService.ObtenerGruposPorUsuario(idUsuario);
        }
    }
}
