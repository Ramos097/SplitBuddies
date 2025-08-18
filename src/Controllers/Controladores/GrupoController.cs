using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

namespace Controllers.Controladores
{
    public class GrupoController : IGrupoController
    {
        private readonly IGrupo _grupoService;

        public GrupoController()
        {
            _grupoService = new GrupoService();
        }

        public void ctr_CrearGrupo(Grupo grupo, List<string> miembros,string idCreadorGrupo)
        {
            _grupoService.CrearGrupo(grupo,miembros, idCreadorGrupo);
        }

        //public List<Grupo> ctr_ObtenerGrupos()
        //{
        //    throw new NotImplementedException();
        //}

        public Grupo ctr_ObtenerPorId(int id)
        {
           return _grupoService.ObtenerPorId(id);
        }

        public int ctr_ObtenerUltimoIdGrupo()
        {
            return _grupoService.ObtenerUltimoIdGrupo();
        }
    }
}
