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
    // para manejar la relación entre grupos y usuarios
    public interface IGruposUsuarios
    {
        // Obtiene todos los grupos a los que pertenece un usuario según su ID
        public List<GrupoUsuarios> ObtenerGruposPorUsuario(string idUsuario);

        // Actualiza el estado de la invitación de un usuario en un grupo
        // (ejemplo: pendiente, aceptada o rechazada)
        public bool ActualizarEstadoInvitacion(string identificacion, int idgrupo, string Estado);
    }
}

