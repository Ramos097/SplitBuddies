using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicaNegocio.Interfaces
{
    public interface IInvitancion
    {
        public List<Grupo> ObtenerGruposInvitados(string usuarioId);
        public List<Usuario> ObtenerUsuariosGrupo(int idGrupo);
    }
}
