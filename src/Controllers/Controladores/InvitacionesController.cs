using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Controladores
{
    // Clase que controla las operaciones relacionadas con las invitaciones
    // Implementa la interfaz IInvitacionesController
    public class InvitacionesController : IInvitacionesController
    {
        // Campo privado que guarda la referencia al servicio de invitaciones
        private readonly IInvitancion _invitacionService;

        // Constructor: inicializa el servicio de invitaciones al crear el controlador
        public InvitacionesController()
        {
            _invitacionService = new InvitacionService();
        }

        // Método: obtiene la lista de grupos a los que un usuario ha sido invitado
        public List<Grupo> crt_ObtenerGruposInvitados(string usuarioId)
        {
            return _invitacionService.ObtenerGruposInvitados(usuarioId);
        }

        // Método: obtiene la lista de usuarios que pertenecen a un grupo
        public List<Usuario> crt_ObtenerUsuariosGrupo(int idGrupo)
        {
            return _invitacionService.ObtenerUsuariosGrupo(idGrupo);
        }
    }
}
