using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Clase que representa la relación entre un Usuario y un Grupo
    public class GrupoUsuarios
    {
        // Identificación única del usuario (cedula, id o lo que uses en Usuario)
        public string IdentificacionUsuario { get; set; }

        // Identificador del grupo al que pertenece/invitado
        public int IdGrupo { get; set; }

        // Estado de la invitación: PENDIENTE, ACTIVO, RECHAZADA
        public string EstadoInvitacion { get; set; }
    }
}
