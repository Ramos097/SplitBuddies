using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicaNegocio.Interfaces
{
    public interface IReporte
    {
        public Reporte ReporteGrupoMensual(string idUsuario, int idGrupo,DateTime mensAnio, string TipoDeuda);
        public Reporte ReporteGrupoAnual(string idUsuario, int idGrupo,DateTime anio, string TipoDeuda);
        public Reporte ReporteGrupoRango(string idUsuario, int idGrupo,DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);
        public Reporte ReportePersonalMensual(string idUsuario, DateTime mensAnio, string TipoDeuda);
        public Reporte ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda);
        public Reporte ReportePersonalRango(string idUsuario, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);
    }
}
