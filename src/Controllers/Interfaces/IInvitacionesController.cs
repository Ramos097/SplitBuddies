using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers.Interfaces
{
    public interface IInvitacionesController
    {
        public List<Grupo> crt_ObtenerGruposInvitados(string usuarioId);
        public List<Usuario> crt_ObtenerUsuariosGrupo(int idGrupo);
    }
}
