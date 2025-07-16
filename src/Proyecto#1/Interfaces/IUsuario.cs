using Proyecto_1.Models;
using System.Collections.Generic;

namespace Proyecto_1.Interfaces
{
    public interface IUsuario
    {
        void AgregarUsuario(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
    }
}
