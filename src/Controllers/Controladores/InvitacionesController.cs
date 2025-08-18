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

namespace Controllers.Controladores
{
    public class InvitacionesController : IInvitacionesController
    {
        private readonly IInvitancion _invitacionService;

        public InvitacionesController()
        {
            _invitacionService = new InvitacionService();
        }


        public List<Grupo> crt_ObtenerGruposInvitados(string usuarioId)
        {
            return _invitacionService.ObtenerGruposInvitados(usuarioId);
        }

        public List<Usuario> crt_ObtenerUsuariosGrupo(int idGrupo)
        {
            return _invitacionService.ObtenerUsuariosGrupo(idGrupo);
        }
    }
}
