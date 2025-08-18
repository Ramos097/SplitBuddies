using System;
using Models;

namespace Controllers.Interfaces
{
    public interface IGasto
    {
        public List<Grupo> obtenerGruposActivos(string idUsuario);
        public int ObtenerUltimoIdGasto();
        public void RegistrarGasto(Gasto gasto);
        public List<Gasto> ObtenerGastosPorGrupo(int idGrupo);
        public List<Grupo> ObtenerGruposQueDebo(string identificacion);
        public List<Gasto> ObtenerGastosPorUsuario(string idUsuario);
        public List<Gasto> ObtenerGastosQueDebeUsuario(string idUsuario);
        public Gasto ObtenerGastoporID(int idGasto);
        public void ActualizarGasto(Gasto gasto);
        public List<string> obtenerAQuieDebeUsuario(string idUsuario);
    }
}
