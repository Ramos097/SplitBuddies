
using System.Collections.Generic;
using Models;

namespace Proyecto_1.Interfaces
{
    public interface IUsuario
    {
        void AgregarUsuario(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
        bool ValidarIdentificacionRepetida(string id);

        string CopiarImagen(string rutaOriginal);

        Usuario ValidarAutenticacion(string id, string pass);
    }
}
