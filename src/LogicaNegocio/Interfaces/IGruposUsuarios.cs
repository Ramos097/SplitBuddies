using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicaNegocio.Interfaces
{
    public interface IGruposUsuarios
    {

        public List<GrupoUsuarios> ObtenerGruposPorUsuario(string idUsuario);
        public bool ActualizarEstadoInvitacion(string identificacion, int idgrupo, string Estado);
    }
}
