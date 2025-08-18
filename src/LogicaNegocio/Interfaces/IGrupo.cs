using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace LogicaNegocio.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un servicio de grupos
    public interface IGrupo
    {
        // Obtiene el último ID de grupo registrado
        public int ObtenerUltimoIdGrupo();

        // Crea un nuevo grupo con su lista de miembros y el ID del creador
        public void CrearGrupo(Grupo grupo, List<string> miembros, string idCreadorGrupo);

        // Obtiene la lista de todos los grupos registrados
        public List<Grupo> ObtenerGrupos();

        // Método comentado: pensado para agregar un miembro a un grupo, pero no se implementó aún
        //void AgregarMiembro(string grupoId, Usuario usuario);

        // Obtiene un grupo específico a partir de su ID
        public Grupo ObtenerPorId(int id);

        // Asigna un grupo a una lista de miembros (incluye también el creador del grupo)
        public void AsignarGruposAMiembros(int idGrupo, List<string> MiembrosGrupo, string idCreadorGrupo);
    }
}

