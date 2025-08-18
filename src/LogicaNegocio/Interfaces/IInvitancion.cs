using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace LogicaNegocio.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un servicio
    // para manejar invitaciones de usuarios a grupos
    public interface IInvitancion
    {
        // Obtiene la lista de grupos a los que un usuario ha sido invitado
        public List<Grupo> ObtenerGruposInvitados(string usuarioId);

        // Obtiene la lista de usuarios que pertenecen a un grupo específico
        public List<Usuario> ObtenerUsuariosGrupo(int idGrupo);
    }
}

