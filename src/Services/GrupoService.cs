using Models;
using Proyecto_1.Interfaces;

namespace Proyecto_1.Services
{
    public class GrupoService : IGrupo
    {
        private List<Grupo> grupos;

        public GrupoService()
        {
            grupos = new List<Grupo>();
        }

        public void CrearGrupo(Grupo grupo)
        {
            grupos.Add(grupo);
        }

        public List<Grupo> ObtenerGrupos()
        {
            return grupos;
        }

        public void AgregarMiembro(string grupoId, Usuario usuario)
        {
            var grupo = grupos.FirstOrDefault(g => g.Id == grupoId);
            if (grupo != null && !grupo.Miembros.Any(m => m.Identificacion == usuario.Identificacion))
            {
                grupo.Miembros.Add(usuario);
            }
        }

        public Grupo ObtenerPorId(string id)
        {
            return grupos.FirstOrDefault(g => g.Id == id);
        }
    }
}
