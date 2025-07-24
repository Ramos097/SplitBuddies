using LogicaNegocio.Services;
using Models;
using Proyecto_1.Interfaces;

namespace Proyecto_1.Controllers
{
    public class GrupoController
    {
        private readonly IGrupo _grupoService;
        private GrupoService grupoService;

        public GrupoController(IGrupo grupoService)
        {
            _grupoService = grupoService;
        }

        public GrupoController(GrupoService grupoService)
        {
            this.grupoService = grupoService;
        }

        public void CrearGrupo(Grupo grupo)
        {
            _grupoService.CrearGrupo(grupo);
        }

        public void AgregarMiembro(string grupoId, Usuario usuario)
        {
            _grupoService.AgregarMiembro(grupoId, usuario);
        }

        public List<Grupo> ObtenerGrupos()
        {
            return _grupoService.ObtenerGrupos();
        }

        public Grupo ObtenerPorId(string id)
        {
            return _grupoService.ObtenerPorId(id);
        }
    }
}
