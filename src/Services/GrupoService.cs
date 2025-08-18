using Models;
using Proyecto_1.Interfaces;

namespace Proyecto_1.Services
{
    // Implementa la interfaz IGrupo para manejar la lógica relacionada con los grupos
    public class GrupoService : IGrupo
    {
        // Lista en memoria que contiene todos los grupos creados
        private List<Grupo> grupos;

        // Constructor: inicializa la lista de grupos vacía
        public GrupoService()
        {
            grupos = new List<Grupo>();
        }

        // Crea un nuevo grupo y lo agrega a la lista
        public void CrearGrupo(Grupo grupo)
        {
            grupos.Add(grupo);
        }

        // Retorna todos los grupos que existen en memoria
        public List<Grupo> ObtenerGrupos()
        {
            return grupos;
        }

        // Agrega un miembro a un grupo dado su ID y el usuario
        public void AgregarMiembro(string grupoId, Usuario usuario)
        {
            // Busca el grupo con el ID proporcionado
            var grupo = grupos.FirstOrDefault(g => g.Id == grupoId);

            // Si el grupo existe y el usuario no está ya dentro, lo agrega
            if (grupo != null && !grupo.Miembros.Any(m => m.Identificacion == usuario.Identificacion))
            {
                grupo.Miembros.Add(usuario);
            }
        }

        // Obtiene un grupo por su ID
        public Grupo ObtenerPorId(string id)
        {
            return grupos.FirstOrDefault(g => g.Id == id);
        }
    }
}
