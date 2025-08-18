using Models;

namespace Proyecto_1.Interfaces
{
	public interface IGrupoController
	{
        public int ctr_ObtenerUltimoIdGrupo();
        void ctr_CrearGrupo(Grupo grupo, List<string> miembros, string idCreadorGrupo);
		//List<Grupo> ctr_ObtenerGrupos();
		//void AgregarMiembro(string grupoId, Usuario usuario);
		Grupo ctr_ObtenerPorId(int id);
	}
}
