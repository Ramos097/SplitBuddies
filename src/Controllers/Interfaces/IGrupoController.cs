using Models;

// Namespace: organiza el código en un grupo lógico
namespace Proyecto_1.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un controlador de grupos
    public interface IGrupoController
    {
        // Obtiene el último ID de grupo registrado
        public int ctr_ObtenerUltimoIdGrupo();

        // Crea un nuevo grupo con su lista de miembros y el ID del creador
        void ctr_CrearGrupo(Grupo grupo, List<string> miembros, string idCreadorGrupo);

        // Método comentado: estaba pensado para obtener todos los grupos
        //List<Grupo> ctr_ObtenerGrupos();

        // Método comentado: estaba pensado para agregar un miembro a un grupo
        //void AgregarMiembro(string grupoId, Usuario usuario);

        // Obtiene un grupo específico a partir de su ID
        Grupo ctr_ObtenerPorId(int id);
    }
}

