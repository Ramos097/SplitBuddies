using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;
using Models;

namespace Controllers.Interfaces
{
    public interface IReporteController
    {
        public Reporte ctr_ReporteGrupoMensual(string idUsuario, int idGrupo, DateTime mensAnio, string TipoDeuda);
        public Reporte ctr_ReporteGrupoAnual(string idUsuario, int idGrupo, DateTime anio, string TipoDeuda);
        public Reporte ctr_ReporteGrupoRango(string idUsuario, int idGrupo, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);
        public Reporte ctr_ReportePersonalMensual(string idUsuario, DateTime mensAnio, string TipoDeuda);
        public Reporte ctr_ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda);
        public Reporte ctr_ReportePersonalRango(string idUsuario, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);
    }
}
