using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers.Interfaces
{
    public interface IGastosController
    {
        public List<Grupo> crt_obtenerGruposActivos(string idUsuario);
        public int ctr_ObtenerUltimoIdGasto();
        public void ctr_RegistrarGasto(Gasto gasto);
        public List<Gasto> ctr_ObtenerGastosPorGrupo(int idGrupo);
        public List<Grupo> ctr_ObtenerGruposQueDebo(string identificacion);
        public List<Gasto> ctr_ObtenerGastosPorUsuario(string idUsuario);
        public Gasto ctr_ObtenerGastoporID(int idGasto);
        public void ctr_ActualizarGasto(Gasto gasto);

        public List<string> crt_obtenerAQuieDebeUsuario(string idUsuario);



        //public bool crt_AgregarGasto(Models.Gasto gasto);
        //public bool crt_EliminarGasto(int idGasto);
        //public bool crt_ActualizarGasto(Models.Gasto gasto);
        //public Models.Gasto? crt_ObtenerGastoPorId(int idGasto);
    }
}
