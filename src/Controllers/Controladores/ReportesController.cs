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
    public class ReportesController : IReporteController
    {

        private readonly IReporte _reporteService;

        public ReportesController()
        {
            _reporteService = new ReporteService();
        }

        public Reporte ctr_ReporteGrupoAnual(string idUsuario, int idGrupo, DateTime anio, string TipoDeuda)
        {
            return _reporteService.ReporteGrupoAnual(idUsuario, idGrupo, anio, TipoDeuda);
        }

        public Reporte ctr_ReporteGrupoMensual(string idUsuario, int idGrupo, DateTime mensAnio, string TipoDeuda)
        {
            return _reporteService.ReporteGrupoMensual(idUsuario, idGrupo, mensAnio, TipoDeuda);
        }

        public Reporte ctr_ReporteGrupoRango(string idUsuario, int idGrupo, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda)
        {
            return _reporteService.ReporteGrupoRango(idUsuario, idGrupo, fechaInicio, fechaFin, TipoDeuda);
        }

        public Reporte ctr_ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda)
        {
            return _reporteService.ReportePersonalAnual(idUsuario, anio, TipoDeuda);
        }

        public Reporte ctr_ReportePersonalMensual(string idUsuario, DateTime mensAnio, string TipoDeuda)
        {
            return _reporteService.ReportePersonalMensual(idUsuario, mensAnio, TipoDeuda);
        }

        public Reporte ctr_ReportePersonalRango(string idUsuario, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda)
        {
            return _reporteService.ReportePersonalRango(idUsuario, fechaInicio, fechaFin, TipoDeuda);
        }
    }
}
