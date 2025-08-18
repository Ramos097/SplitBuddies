using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un controlador
    // para generar reportes tanto de grupos como personales
    public interface IReporteController
    {
        // Genera un reporte mensual de un grupo
        public Reporte ctr_ReporteGrupoMensual(string idUsuario, int idGrupo, DateTime mensAnio, string TipoDeuda);

        // Genera un reporte anual de un grupo
        public Reporte ctr_ReporteGrupoAnual(string idUsuario, int idGrupo, DateTime anio, string TipoDeuda);

        // Genera un reporte de un grupo en un rango de fechas
        public Reporte ctr_ReporteGrupoRango(string idUsuario, int idGrupo, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);

        // Genera un reporte mensual personal (solo del usuario)
        public Reporte ctr_ReportePersonalMensual(string idUsuario, DateTime mensAnio, string TipoDeuda);

        // Genera un reporte anual personal (solo del usuario)
        public Reporte ctr_ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda);

        // Genera un reporte personal en un rango de fechas
        public Reporte ctr_ReportePersonalRango(string idUsuario, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda);
    }
}

