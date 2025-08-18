using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers.Interfaces
{
    public interface IGrupoUsuariosController
    {
        public List<GrupoUsuarios> crt_ObtenerGruposPorUsuario(string idUsuario);
        public bool ActualizarEstadoInvitacion(string identificacion, int idgrupo, string Estado);
    }
}
