using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace LogicaNegocio.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un servicio
    // para generar reportes de grupos y personales
    public interface IReporte
    {
        // Genera un reporte mensual de un grupo
        public Reporte ReporteGrupoMensual(string idUsuario, int idGrupo, DateTime mensAnio, string TipoDeuda);

        // Genera un reporte anual de un grupo
        public Reporte ReporteGrupoAnual(string idUsuario, int idGrupo, DateTime anio, string TipoDeuda);

        // Genera un reporte de un grupo en un rango de fechas
        public Reporte ReporteGrupoRango(string idUsuario, int idGrupo, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);

        // Genera un reporte mensual personal (del usuario en específico)
        public Reporte ReportePersonalMensual(string idUsuario, DateTime mensAnio, string TipoDeuda);

        // Genera un reporte anual personal (del usuario en específico)
        public Reporte ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda);

        // Genera un reporte personal dentro de un rango de fechas
        public Reporte ReportePersonalRango(string idUsuario, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);
    }
}

