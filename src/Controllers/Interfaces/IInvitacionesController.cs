using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un controlador
    // para manejar las invitaciones de usuarios a grupos
    public interface IInvitacionesController
    {
        // Obtiene los grupos a los que un usuario ha sido invitado
        public List<Grupo> crt_ObtenerGruposInvitados(string usuarioId);

        // Obtiene la lista de usuarios que pertenecen a un grupo específico
        public List<Usuario> crt_ObtenerUsuariosGrupo(int idGrupo);
    }
}

