using Models;

// Namespace: organiza el c�digo en un grupo l�gico
namespace Proyecto_1.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un controlador de grupos
    public interface IGrupoController
    {
        // Obtiene el �ltimo ID de grupo registrado
        public int ctr_ObtenerUltimoIdGrupo();

        // Crea un nuevo grupo con su lista de miembros y el ID del creador
        void ctr_CrearGrupo(Grupo grupo, List<string> miembros, string idCreadorGrupo);

        // M�todo comentado: estaba pensado para obtener todos los grupos
        //List<Grupo> ctr_ObtenerGrupos();

        // M�todo comentado: estaba pensado para agregar un miembro a un grupo
        //void AgregarMiembro(string grupoId, Usuario usuario);

        // Obtiene un grupo espec�fico a partir de su ID
        Grupo ctr_ObtenerPorId(int id);
    }
}

