using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Models;
using Proyecto_1.Services;

namespace Controllers.Controladores
{
    public class GastosController : IGastosController
    {
        private readonly IGasto _gastoService;

        public GastosController()
        {
            _gastoService = new GastoService();
        }
        public List<Grupo> crt_obtenerGruposActivos(string idUsuario)
        {
            return _gastoService.obtenerGruposActivos(idUsuario);
        }

        public void ctr_ActualizarGasto(Gasto gasto)
        {
            _gastoService.ActualizarGasto(gasto);
        }

        public Gasto ctr_ObtenerGastoporID(int idGasto)
        {
            return _gastoService.ObtenerGastoporID(idGasto);
        }

        public List<Gasto> ctr_ObtenerGastosPorGrupo(int idGrupo)
        {
            return _gastoService.ObtenerGastosPorGrupo(idGrupo);
        }

        public List<Gasto> ctr_ObtenerGastosPorUsuario(string idUsuario)
        {
            return _gastoService.ObtenerGastosPorUsuario(idUsuario);
        }

        public List<Grupo> ctr_ObtenerGruposQueDebo(string identificacion)
        {
            return _gastoService.ObtenerGruposQueDebo(identificacion);
        }

        public int ctr_ObtenerUltimoIdGasto()
        {
            return _gastoService.ObtenerUltimoIdGasto();
        }

        public void ctr_RegistrarGasto(Gasto gasto)
        {
            _gastoService.RegistrarGasto(gasto);
            return;
        }
        public List<string> crt_obtenerAQuieDebeUsuario(string idUsuario)
        {
            return _gastoService.obtenerAQuieDebeUsuario(idUsuario);
        }
    }
}
