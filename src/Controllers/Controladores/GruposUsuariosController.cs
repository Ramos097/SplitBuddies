using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Models;

namespace Controllers.Controladores
{
    public class GruposUsuariosController : IGrupoUsuariosController
    {
        private readonly IGruposUsuarios _grupoUsuariosService;

        public GruposUsuariosController()
        {
            _grupoUsuariosService = new GrupoUsuariosService();
        }

        public bool ActualizarEstadoInvitacion(string identificacion, int idgrupo, string Estado)
        {
            return _grupoUsuariosService.ActualizarEstadoInvitacion(identificacion, idgrupo,Estado);
        }

        public List<GrupoUsuarios> crt_ObtenerGruposPorUsuario(string idUsuario)
        {
          return  _grupoUsuariosService.ObtenerGruposPorUsuario(idUsuario);
        }
    }
}
