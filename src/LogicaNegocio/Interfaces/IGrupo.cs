using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicaNegocio.Interfaces
{
    public interface IGrupo
    {

        public int ObtenerUltimoIdGrupo();
        public void CrearGrupo(Grupo grupo, List<string> miembros, string idCreadorGrupo);
        public List<Grupo> ObtenerGrupos();
        //void AgregarMiembro(string grupoId, Usuario usuario);
        public Grupo ObtenerPorId(int id);

        public void AsignarGruposAMiembros(int idGrupo, List<string> MiembrosGrupo, string idCreadorGrupo);
    
    
    
    }
}
