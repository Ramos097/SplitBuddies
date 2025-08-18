using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Controladores
{
    // Clase que controla las operaciones relacionadas con los grupos
    // Implementa la interfaz IGrupoController
    public class GrupoController : IGrupoController
    {
        // Campo privado que guarda la referencia al servicio de grupos
        private readonly IGrupo _grupoService;

        // Constructor: inicializa el servicio de grupos cuando se crea el controlador
        public GrupoController()
        {
            _grupoService = new GrupoService();
        }

        // Método: crea un nuevo grupo con sus miembros y el ID del creador
        public void ctr_CrearGrupo(Grupo grupo, List<string> miembros, string idCreadorGrupo)
        {
            _grupoService.CrearGrupo(grupo, miembros, idCreadorGrupo);
        }

        // Método comentado: estaba pensado para obtener grupos,
        // pero no se implementó (está desactivado por ahora)
        //public List<Grupo> ctr_ObtenerGrupos()
        //{
        //    throw new NotImplementedException();
        //}

        // Método: obtiene un grupo según su ID
        public Grupo ctr_ObtenerPorId(int id)
        {
            return _grupoService.ObtenerPorId(id);
        }

        // Método: obtiene el último ID de grupo registrado
        public int ctr_ObtenerUltimoIdGrupo()
        {
            return _grupoService.ObtenerUltimoIdGrupo();
        }
    }
}

