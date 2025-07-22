using Models;

namespace Proyecto_1.Interfaces
{
	public interface IGrupo
	{
		void CrearGrupo(Grupo grupo);
		List<Grupo> ObtenerGrupos();
		void AgregarMiembro(string grupoId, Usuario usuario);
		Grupo ObtenerPorId(string id);
	}
}
